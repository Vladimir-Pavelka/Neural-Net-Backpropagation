namespace Charting
{
    partial class LearningProgress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.liveChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // liveChart
            // 
            this.liveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveChart.Location = new System.Drawing.Point(12, 12);
            this.liveChart.Name = "liveChart";
            this.liveChart.Size = new System.Drawing.Size(828, 457);
            this.liveChart.TabIndex = 2;
            this.liveChart.Text = "cartesianChart1";
            // 
            // LearningProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 481);
            this.Controls.Add(this.liveChart);
            this.Name = "LearningProgress";
            this.Text = "LearningProgress";
            this.ResumeLayout(false);

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart liveChart;
    }
}