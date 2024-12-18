using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;
using System.Text;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }

        // Метод для инициализации графика
        private void InitializeChart()
        {
            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            Series series = new Series("Graph")
            {
                ChartType = SeriesChartType.Line
            };
            chart.Series.Clear();
            chart.Series.Add(series);

            chartArea.AxisX.Minimum = -10;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = -10;
            chartArea.AxisY.Maximum = 10;
        }

        // Метод для построения графика
        private void BtnPlot_Click(object sender, EventArgs e)
        {
            try
            {
                string equation = txtEquation.Text;

                if (equation == "exp(x)")
                {
                    MessageBox.Show("Для функции Exp(x) экстремумов нет.");
                    return;
                }

                if (!ValidateInput(out double start, out double end) || !ValidateFunction(equation))
                    return;

                Series series = chart.Series["Graph"];
                series.Points.Clear();

                double step = 0.1;

                for (double x = start; x <= end; x += step)
                {
                    double y = EvaluateEquation(equation, x);
                    series.Points.AddXY(x, y);
                }

                FindExtrema(equation, start, end);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private bool ValidateInput(out double start, out double end)
        {
            start = end = 0;
            if (!double.TryParse(txtStart.Text, out start) || !double.TryParse(txtEnd.Text, out end))
            {
                MessageBox.Show("Введите корректные числовые значения для интервалов.");
                return false;
            }
            if (start >= end)
            {
                MessageBox.Show("Начало интервала должно быть меньше конца.");
                return false;
            }
            return true;
        }

        private bool ValidateFunction(string equation)
        {
            equation = equation.Replace("cos", "Cos")
                               .Replace("sin", "Sin")
                               .Replace("exp", "Exp")
                               .Replace("log", "Log");

            // Список допустимых математических функций
            string[] validFunctions = { "Sin", "Cos", "Log", "Exp" };

            foreach (var func in validFunctions)
            {
                if (equation.Contains(func + "("))
                {
                    if (equation.Contains(func + "(x") || equation.Contains(func + "(X") || equation.Contains(func + "(" + "0"))
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: некорректные скобки в функции {func}.");
                        return false;
                    }
                }
            }

            foreach (char c in equation)
            {
                if (!Char.IsDigit(c) && !"+-*/^()x. ".Contains(c.ToString().ToLower()) && !"CosSinLogExp".Contains(c.ToString()))
                {
                    MessageBox.Show("Функция содержит недопустимые символы.");
                    return false;
                }
            }

            int openParenthesesCount = 0;
            foreach (char c in equation)
            {
                if (c == '(') openParenthesesCount++;
                if (c == ')') openParenthesesCount--;
            }

            if (openParenthesesCount != 0)
            {
                MessageBox.Show("Функция содержит незакрытые скобки.");
                return false;
            }

            return true;
        }

        private double EvaluateEquation(string equation, double x)
        {
            try
            {
                equation = equation.Replace("cos", "Cos")
                                   .Replace("sin", "Sin")
                                   .Replace("exp", "Exp")
                                   .Replace("log", "Log10")
                                   .Replace("ln", "Log");

                equation = equation.Replace("E", "e");

                string expressionStr = ReplacePowerOperators(equation)
                    .Replace("x", x.ToString("G", CultureInfo.InvariantCulture))
                    .Replace("X", x.ToString("G", CultureInfo.InvariantCulture));

                Console.WriteLine($"Преобразованное выражение: {expressionStr}");

                var engine = new Expression(expressionStr);

                engine.Parameters["Sin"] = new Func<double, double>(Math.Sin);
                engine.Parameters["Cos"] = new Func<double, double>(Math.Cos);
                engine.Parameters["Log10"] = new Func<double, double>(Math.Log10);
                engine.Parameters["Log"] = new Func<double, double>(Math.Log);
                engine.Parameters["Exp"] = new Func<double, double>(Math.Exp);

                object result = engine.Evaluate();

                if (result is double || result is int || result is decimal)
                {
                    double resultValue = Convert.ToDouble(result);
                    Console.WriteLine($"Результат вычисления для x = {x}: {resultValue}");
                    return resultValue;
                }

                throw new InvalidOperationException($"Неверный тип результата вычисления: {result.GetType()}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в вычислении уравнения '{equation}' при x = {x}: {ex.Message}");
                throw new InvalidOperationException($"Ошибка в вычислении уравнения '{equation}' при x = {x}: {ex.Message}");
            }
        }


        private string ReplacePowerOperators(string equation)
        {
            return Regex.Replace(equation, @"(\b(?:x|X))\^(\d+(\.\d+)?)", "Pow($1, $2)", RegexOptions.IgnoreCase);
        }

        private double Derivative(string equation, double x, double h = 0.001)
        {
            double f_x_plus_h = EvaluateEquation(equation, x + h);
            double f_x_minus_h = EvaluateEquation(equation, x - h);

            return (f_x_plus_h - f_x_minus_h) / (2 * h);
        }

        private void FindExtrema(string equation, double start, double end)
        {
            double step = 0.01;
            double previousY = EvaluateEquation(equation, start);
            double currentY;
            double prevDerivative = Derivative(equation, start);

            var extrema = new List<DataPoint>();

            StringBuilder extremaMessage = new StringBuilder("Найденные экстремумы:\n");
            bool hasExtrema = false;

            for (double x = start + step; x <= end; x += step)
            {
                currentY = EvaluateEquation(equation, x);
                double currentDerivative = Derivative(equation, x);

                Console.WriteLine($"x = {x}, f'(x) = {currentDerivative}");

                if (Math.Sign(prevDerivative) != Math.Sign(currentDerivative))
                {
                    string extremumType = "Неизвестно";

                    if (x > start + step && x < end - step)
                    {
                        double leftY = EvaluateEquation(equation, x - step);
                        double rightY = EvaluateEquation(equation, x + step);

                        if (currentY > leftY && currentY > rightY)
                        {
                            extremumType = "Максимум";
                        }
                        else if (currentY < leftY && currentY < rightY)
                        {
                            extremumType = "Минимум";
                        }
                    }

                    extrema.Add(new DataPoint(x, currentY));

                    extremaMessage.AppendLine($"x = {x}, y = {currentY}, Тип: {extremumType}");
                    hasExtrema = true;
                }

                prevDerivative = currentDerivative;
            }

            if (hasExtrema)
            {
                MessageBox.Show(extremaMessage.ToString(), "Экстремумы");
            }
            else
            {
                MessageBox.Show("Экстремумы не найдены для данной функции.");
            }

            DisplayExtremaOnChart(extrema);
        }



        private void DisplayExtremaOnChart(List<DataPoint> extrema)
        {
            if (chart.Series.IndexOf("Extremum") >= 0)
            {
                chart.Series.Remove(chart.Series["Extremum"]);
            }

            if (extrema.Count > 0)
            {
                Series extremumSeries = new Series("Extremum")
                {
                    ChartType = SeriesChartType.Point,
                    Color = System.Drawing.Color.Red,
                    MarkerSize = 10
                };

                foreach (var point in extrema)
                {
                    extremumSeries.Points.Add(point);
                }

                chart.Series.Add(extremumSeries);
            }
        }



        private void BtnScrollLeft_Click(object sender, EventArgs e)
        {
            ScrollChart("Left");
        }

        private void BtnScrollRight_Click(object sender, EventArgs e)
        {
            ScrollChart("Right");
        }

        private void BtnScrollUp_Click(object sender, EventArgs e)
        {
            ScrollChart("Up");
        }

        private void BtnScrollDown_Click(object sender, EventArgs e)
        {
            ScrollChart("Down");
        }

        private void ScrollChart(string direction)
        {
            double xMin = chart.ChartAreas[0].AxisX.Minimum;
            double xMax = chart.ChartAreas[0].AxisX.Maximum;
            double yMin = chart.ChartAreas[0].AxisY.Minimum;
            double yMax = chart.ChartAreas[0].AxisY.Maximum;

            double shiftAmount = 2;

            switch (direction)
            {
                case "Left":
                    chart.ChartAreas[0].AxisX.Minimum = xMin - shiftAmount;
                    chart.ChartAreas[0].AxisX.Maximum = xMax - shiftAmount;
                    break;
                case "Right":
                    chart.ChartAreas[0].AxisX.Minimum = xMin + shiftAmount;
                    chart.ChartAreas[0].AxisX.Maximum = xMax + shiftAmount;
                    break;
                case "Up":
                    chart.ChartAreas[0].AxisY.Minimum = yMin + shiftAmount;
                    chart.ChartAreas[0].AxisY.Maximum = yMax + shiftAmount;
                    break;
                case "Down":
                    chart.ChartAreas[0].AxisY.Minimum = yMin - shiftAmount;
                    chart.ChartAreas[0].AxisY.Maximum = yMax - shiftAmount;
                    break;
            }
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomChart(0.8);
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomChart(1.25);
        }

        private void ZoomChart(double factor)
        {
            var area = chart.ChartAreas[0];
            double xRange = area.AxisX.Maximum - area.AxisX.Minimum;
            double yRange = area.AxisY.Maximum - area.AxisY.Minimum;

            double xMid = (area.AxisX.Minimum + area.AxisX.Maximum) / 2;
            double yMid = (area.AxisY.Minimum + area.AxisY.Maximum) / 2;

            area.AxisX.Minimum = xMid - (xRange * factor) / 2;
            area.AxisX.Maximum = xMid + (xRange * factor) / 2;
            area.AxisY.Minimum = yMid - (yRange * factor) / 2;
            area.AxisY.Maximum = yMid + (yRange * factor) / 2;
        }
    }
}
