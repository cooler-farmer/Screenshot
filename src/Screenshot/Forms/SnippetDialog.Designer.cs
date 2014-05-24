namespace Screenshot.Forms
{
    partial class SnippetDialog
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
            this.SuspendLayout();
            // 
            // SnippetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SnippetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SnippetForm";
            this.Load += new System.EventHandler(this.SnippetForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnippetDialog_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SnippetDialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SnippetDialog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SnippetDialog_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}