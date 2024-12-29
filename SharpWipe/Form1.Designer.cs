namespace SharpWipe
{
	partial class Form1
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
			this.buttWipe = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.displayFileName = new System.Windows.Forms.TextBox();
			this.buttOpenFile = new System.Windows.Forms.Button();
			this.buttonOpenFolder = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttWipe
			// 
			this.buttWipe.Location = new System.Drawing.Point(299, 77);
			this.buttWipe.Name = "buttWipe";
			this.buttWipe.Size = new System.Drawing.Size(53, 23);
			this.buttWipe.TabIndex = 0;
			this.buttWipe.Text = "Xóa";
			this.buttWipe.UseVisualStyleBackColor = true;
			this.buttWipe.Click += new System.EventHandler(this.buttWipe_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(12, 47);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(35, 13);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "lblInfo";
			// 
			// displayFileName
			// 
			this.displayFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.displayFileName.Location = new System.Drawing.Point(12, 15);
			this.displayFileName.Name = "displayFileName";
			this.displayFileName.Size = new System.Drawing.Size(801, 20);
			this.displayFileName.TabIndex = 3;
			// 
			// buttOpenFile
			// 
			this.buttOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttOpenFile.Location = new System.Drawing.Point(595, 41);
			this.buttOpenFile.Name = "buttOpenFile";
			this.buttOpenFile.Size = new System.Drawing.Size(81, 23);
			this.buttOpenFile.TabIndex = 4;
			this.buttOpenFile.Text = "Chọn file lẻ";
			this.buttOpenFile.UseVisualStyleBackColor = true;
			this.buttOpenFile.Click += new System.EventHandler(this.buttOpenFile_Click);
			// 
			// buttonOpenFolder
			// 
			this.buttonOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenFolder.Location = new System.Drawing.Point(718, 42);
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.Size = new System.Drawing.Size(78, 23);
			this.buttonOpenFolder.TabIndex = 5;
			this.buttonOpenFolder.Text = "Chọn folder";
			this.buttonOpenFolder.UseVisualStyleBackColor = true;
			this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 112);
			this.Controls.Add(this.buttonOpenFolder);
			this.Controls.Add(this.buttOpenFile);
			this.Controls.Add(this.displayFileName);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.buttWipe);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SharpWipe";
			this.TopMost = true;
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttWipe;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.TextBox displayFileName;
		private System.Windows.Forms.Button buttOpenFile;
		private System.Windows.Forms.Button buttonOpenFolder;
	}
}

