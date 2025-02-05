namespace LiteStarNote
{
    partial class ChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            panel_type = new Panel();
            text_type = new RichTextBox();
            plotView_type = new OxyPlot.WindowsForms.PlotView();
            panel_state = new Panel();
            text_state = new RichTextBox();
            plotView_state = new OxyPlot.WindowsForms.PlotView();
            panel_day = new Panel();
            text_day = new RichTextBox();
            plotView_day = new OxyPlot.WindowsForms.PlotView();
            panel_month = new Panel();
            text_month = new RichTextBox();
            plotView_month = new OxyPlot.WindowsForms.PlotView();
            buttonSwitchShow = new Button();
            panel_type.SuspendLayout();
            panel_state.SuspendLayout();
            panel_day.SuspendLayout();
            panel_month.SuspendLayout();
            SuspendLayout();
            // 
            // panel_type
            // 
            resources.ApplyResources(panel_type, "panel_type");
            panel_type.Controls.Add(text_type);
            panel_type.Controls.Add(plotView_type);
            panel_type.Name = "panel_type";
            // 
            // text_type
            // 
            resources.ApplyResources(text_type, "text_type");
            text_type.Name = "text_type";
            text_type.ReadOnly = true;
            // 
            // plotView_type
            // 
            resources.ApplyResources(plotView_type, "plotView_type");
            plotView_type.Name = "plotView_type";
            plotView_type.PanCursor = Cursors.Hand;
            plotView_type.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView_type.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView_type.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // panel_state
            // 
            resources.ApplyResources(panel_state, "panel_state");
            panel_state.Controls.Add(text_state);
            panel_state.Controls.Add(plotView_state);
            panel_state.Name = "panel_state";
            // 
            // text_state
            // 
            resources.ApplyResources(text_state, "text_state");
            text_state.Name = "text_state";
            text_state.ReadOnly = true;
            // 
            // plotView_state
            // 
            resources.ApplyResources(plotView_state, "plotView_state");
            plotView_state.Name = "plotView_state";
            plotView_state.PanCursor = Cursors.Hand;
            plotView_state.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView_state.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView_state.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // panel_day
            // 
            resources.ApplyResources(panel_day, "panel_day");
            panel_day.Controls.Add(text_day);
            panel_day.Controls.Add(plotView_day);
            panel_day.Name = "panel_day";
            // 
            // text_day
            // 
            resources.ApplyResources(text_day, "text_day");
            text_day.Name = "text_day";
            text_day.ReadOnly = true;
            // 
            // plotView_day
            // 
            resources.ApplyResources(plotView_day, "plotView_day");
            plotView_day.Name = "plotView_day";
            plotView_day.PanCursor = Cursors.Hand;
            plotView_day.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView_day.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView_day.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // panel_month
            // 
            resources.ApplyResources(panel_month, "panel_month");
            panel_month.Controls.Add(text_month);
            panel_month.Controls.Add(plotView_month);
            panel_month.Name = "panel_month";
            // 
            // text_month
            // 
            resources.ApplyResources(text_month, "text_month");
            text_month.Name = "text_month";
            text_month.ReadOnly = true;
            // 
            // plotView_month
            // 
            resources.ApplyResources(plotView_month, "plotView_month");
            plotView_month.Name = "plotView_month";
            plotView_month.PanCursor = Cursors.Hand;
            plotView_month.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView_month.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView_month.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // buttonSwitchShow
            // 
            resources.ApplyResources(buttonSwitchShow, "buttonSwitchShow");
            buttonSwitchShow.Name = "buttonSwitchShow";
            buttonSwitchShow.UseVisualStyleBackColor = true;
            buttonSwitchShow.Click += buttonSwitchShow_Click;
            // 
            // ChartForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSwitchShow);
            Controls.Add(panel_month);
            Controls.Add(panel_day);
            Controls.Add(panel_state);
            Controls.Add(panel_type);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChartForm";
            panel_type.ResumeLayout(false);
            panel_state.ResumeLayout(false);
            panel_day.ResumeLayout(false);
            panel_month.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_type;
        private Panel panel_state;
        private Panel panel_day;
        private OxyPlot.WindowsForms.PlotView plotView_type;
        private OxyPlot.WindowsForms.PlotView plotView_day;
        private OxyPlot.WindowsForms.PlotView plotView_state;
        private Panel panel_month;
        private OxyPlot.WindowsForms.PlotView plotView_month;
        private RichTextBox text_type;
        private Button buttonSwitchShow;
        private RichTextBox text_state;
        private RichTextBox text_day;
        private RichTextBox text_month;
    }
}