namespace ToDoList.WindowsFormApp.Forms
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
			this.useTitleCheckBox = new System.Windows.Forms.CheckBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// useTitleCheckBox
			// 
			this.useTitleCheckBox.AutoSize = true;
			this.useTitleCheckBox.Location = new System.Drawing.Point(13, 13);
			this.useTitleCheckBox.Name = "useTitleCheckBox";
			this.useTitleCheckBox.Size = new System.Drawing.Size(119, 17);
			this.useTitleCheckBox.TabIndex = 0;
			this.useTitleCheckBox.Text = "Use title in notes list";
			this.useTitleCheckBox.UseVisualStyleBackColor = true;
			this.useTitleCheckBox.CheckedChanged += new System.EventHandler(this.useTitleCheckBox_CheckedChanged);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(12, 415);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.useTitleCheckBox);
			this.Name = "SettingsForm";
			this.Text = "SettingsForm";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox useTitleCheckBox;
		private System.Windows.Forms.Button saveButton;
	}
}