namespace Screenshot.Forms
{
    partial class SnippetForm
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
            this.snippetBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.snippetBox)).BeginInit();
            this.SuspendLayout();
            // 
            // snippetBox
            // 
            this.snippetBox.Location = new System.Drawing.Point(0, 0);
            this.snippetBox.Name = "snippetBox";
            this.snippetBox.Size = new System.Drawing.Size(100, 50);
            this.snippetBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.snippetBox.TabIndex = 0;
            this.snippetBox.TabStop = false;
            this.snippetBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.snippetBox_MouseDown);
            this.snippetBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.snippetBox_MouseMove);
            this.snippetBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.snippetBox_MouseUp);
            // 
            // SnippetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 252);
            this.Controls.Add(this.snippetBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SnippetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SnippetForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SnippetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.snippetBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox snippetBox;
    }
}