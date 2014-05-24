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
            this.CustomFilenameTextBox = new System.Windows.Forms.TextBox();
            this.CustomFilenameCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomFilenameInfoBtn = new System.Windows.Forms.Button();
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
            this.localPathBtn.Location = new System.Drawing.Point(326, 19);
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
            // CustomFilenameTextBox
            // 
            this.CustomFilenameTextBox.Location = new System.Drawing.Point(175, 44);
            this.CustomFilenameTextBox.Name = "CustomFilenameTextBox";
            this.CustomFilenameTextBox.Size = new System.Drawing.Size(145, 20);
            this.CustomFilenameTextBox.TabIndex = 4;
            // 
            // CustomFilenameCheckBox
            // 
            this.CustomFilenameCheckBox.AutoSize = true;
            this.CustomFilenameCheckBox.Location = new System.Drawing.Point(12, 46);
            this.CustomFilenameCheckBox.Name = "CustomFilenameCheckBox";
            this.CustomFilenameCheckBox.Size = new System.Drawing.Size(124, 17);
            this.CustomFilenameCheckBox.TabIndex = 5;
            this.CustomFilenameCheckBox.Text = "Use custom filename";
            this.CustomFilenameCheckBox.UseVisualStyleBackColor = true;
            // 
            // CustomFilenameInfoBtn
            // 
            this.CustomFilenameInfoBtn.Location = new System.Drawing.Point(326, 43);
            this.CustomFilenameInfoBtn.Name = "CustomFilenameInfoBtn";
            this.CustomFilenameInfoBtn.Size = new System.Drawing.Size(30, 20);
            this.CustomFilenameInfoBtn.TabIndex = 6;
            this.CustomFilenameInfoBtn.Text = "i";
            this.CustomFilenameInfoBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 116);
            this.Controls.Add(this.CustomFilenameInfoBtn);
            this.Controls.Add(this.CustomFilenameCheckBox);
            this.Controls.Add(this.CustomFilenameTextBox);
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
        private System.Windows.Forms.TextBox CustomFilenameTextBox;
        private System.Windows.Forms.CheckBox CustomFilenameCheckBox;
        private System.Windows.Forms.Button CustomFilenameInfoBtn;

    }
}