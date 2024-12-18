namespace kursovaya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинный, если управляемый ресурс должен быть удален; иначе ложный.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows


        private void InitializeComponent()
        {
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtEquation = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnScrollLeft = new System.Windows.Forms.Button();
            this.btnScrollRight = new System.Windows.Forms.Button();
            this.btnScrollUp = new System.Windows.Forms.Button();
            this.btnScrollDown = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.Location = new System.Drawing.Point(9, 10);
            this.chart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(450, 325);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // txtEquation
            // 
            this.txtEquation.Location = new System.Drawing.Point(9, 341);
            this.txtEquation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEquation.Name = "txtEquation";
            this.txtEquation.Size = new System.Drawing.Size(282, 20);
            this.txtEquation.TabIndex = 1;
            this.txtEquation.Text = "Введите уравнение (например, x^2 + 2*x + 1)";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(9, 366);
            this.txtStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(76, 20);
            this.txtStart.TabIndex = 2;
            this.txtStart.Text = "-10";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(98, 366);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(76, 20);
            this.txtEnd.TabIndex = 3;
            this.txtEnd.Text = "10";
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(188, 366);
            this.btnPlot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(103, 20);
            this.btnPlot.TabIndex = 4;
            this.btnPlot.Text = "Построить";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // btnScrollLeft
            // 
            this.btnScrollLeft.Location = new System.Drawing.Point(488, 81);
            this.btnScrollLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScrollLeft.Name = "btnScrollLeft";
            this.btnScrollLeft.Size = new System.Drawing.Size(56, 19);
            this.btnScrollLeft.TabIndex = 5;
            this.btnScrollLeft.Text = "←";
            this.btnScrollLeft.UseVisualStyleBackColor = true;
            this.btnScrollLeft.Click += new System.EventHandler(this.BtnScrollLeft_Click);
            // 
            // btnScrollRight
            // 
            this.btnScrollRight.Location = new System.Drawing.Point(562, 81);
            this.btnScrollRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScrollRight.Name = "btnScrollRight";
            this.btnScrollRight.Size = new System.Drawing.Size(56, 19);
            this.btnScrollRight.TabIndex = 6;
            this.btnScrollRight.Text = "→";
            this.btnScrollRight.UseVisualStyleBackColor = true;
            this.btnScrollRight.Click += new System.EventHandler(this.BtnScrollRight_Click);
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.Location = new System.Drawing.Point(525, 41);
            this.btnScrollUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.Size = new System.Drawing.Size(56, 19);
            this.btnScrollUp.TabIndex = 7;
            this.btnScrollUp.Text = "↑";
            this.btnScrollUp.UseVisualStyleBackColor = true;
            this.btnScrollUp.Click += new System.EventHandler(this.BtnScrollUp_Click);
            // 
            // btnScrollDown
            // 
            this.btnScrollDown.Location = new System.Drawing.Point(525, 122);
            this.btnScrollDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.Size = new System.Drawing.Size(56, 22);
            this.btnScrollDown.TabIndex = 8;
            this.btnScrollDown.Text = "↓";
            this.btnScrollDown.UseVisualStyleBackColor = true;
            this.btnScrollDown.Click += new System.EventHandler(this.BtnScrollDown_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(488, 162);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(56, 19);
            this.btnZoomIn.TabIndex = 9;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(562, 162);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(56, 19);
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 406);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnScrollDown);
            this.Controls.Add(this.btnScrollUp);
            this.Controls.Add(this.btnScrollRight);
            this.Controls.Add(this.btnScrollLeft);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.txtEquation);
            this.Controls.Add(this.chart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Построение графиков";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox txtEquation;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnScrollLeft;
        private System.Windows.Forms.Button btnScrollRight;
        private System.Windows.Forms.Button btnScrollUp;
        private System.Windows.Forms.Button btnScrollDown;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
    }
}
