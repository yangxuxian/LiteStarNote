namespace LiteStarNote
{
    partial class EditTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTypeForm));
            typeSave = new Button();
            edit_type_text = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // typeSave
            // 
            resources.ApplyResources(typeSave, "typeSave");
            typeSave.Name = "typeSave";
            typeSave.UseVisualStyleBackColor = true;
            typeSave.Click += typeSave_Click;
            // 
            // edit_type_text
            // 
            resources.ApplyResources(edit_type_text, "edit_type_text");
            edit_type_text.Name = "edit_type_text";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // EditTypeForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(edit_type_text);
            Controls.Add(typeSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTypeForm";
            Load += editTypeForm_load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button typeSave;
        private RichTextBox edit_type_text;
        private Label label1;
    }
}