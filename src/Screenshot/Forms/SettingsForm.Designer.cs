namespace Screenshot.Forms
{
    partial class SettingsForm
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
            this.localCheckBox = new System.Windows.Forms.CheckBox();
            this.localText = new System.Windows.Forms.TextBox();
            this.localPathBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localCheckBox
            // 
            this.localCheckBox.AutoSize = true;
            this.localCheckBox.Location = new System.Drawing.Point(12, 22);
            this.localCheckBox.Name = "localCheckBox";
            this.localCheckBox.Size = new System.Drawing.Size(121, 17);
            this.localCheckBox.TabIndex = 0;
            this.localCheckBox.Text = "Save To Local Path";
            this.localCheckBox.UseVisualStyleBackColor = true;
            // 
            // localText
            // 
            this.localText.Location = new System.Drawing.Point(175, 20);
            this.localText.Name = "localText";
            this.localText.Size = new System.Drawing.Size(145, 20);
            this.localText.TabIndex = 1;
            // 
            // localPathBtn
            // 
            this.localPathBtn.Location = new System.Drawing.Point(323, 20);
            this.localPathBtn.Name = "localPathBtn";
            this.localPathBtn.Size = new System.Drawing.Size(30, 20);
            this.localPathBtn.TabIndex = 2;
            this.localPathBtn.Text = "...";
            this.localPathBtn.UseVisualStyleBackColor = true;
            this.localPathBtn.Click += new System.EventHandler(this.localPathBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(291, 81);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 116);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.localPathBtn);
            this.Controls.Add(this.localText);
            this.Controls.Add(this.localCheckBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox localCheckBox;
        private System.Windows.Forms.TextBox localText;
        private System.Windows.Forms.Button localPathBtn;
        private System.Windows.Forms.Button okBtn;

    }
}