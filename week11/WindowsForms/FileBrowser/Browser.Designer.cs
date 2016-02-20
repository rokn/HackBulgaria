namespace FileBrowser
{
	partial class Browser
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
			if(disposing && (components != null))
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
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.folderExplorer = new System.Windows.Forms.TreeView();
			this.fileExplorer = new System.Windows.Forms.ListView();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.folderExplorer);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.fileExplorer);
			this.mainSplitContainer.Size = new System.Drawing.Size(707, 494);
			this.mainSplitContainer.SplitterDistance = 248;
			this.mainSplitContainer.TabIndex = 0;
			// 
			// folderExplorer
			// 
			this.folderExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.folderExplorer.Location = new System.Drawing.Point(0, 0);
			this.folderExplorer.Name = "folderExplorer";
			this.folderExplorer.Size = new System.Drawing.Size(248, 494);
			this.folderExplorer.TabIndex = 0;
			// 
			// fileExplorer
			// 
			this.fileExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileExplorer.Location = new System.Drawing.Point(0, 0);
			this.fileExplorer.Name = "fileExplorer";
			this.fileExplorer.Size = new System.Drawing.Size(455, 494);
			this.fileExplorer.TabIndex = 0;
			this.fileExplorer.UseCompatibleStateImageBehavior = false;
			// 
			// Browser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(707, 494);
			this.Controls.Add(this.mainSplitContainer);
			this.Name = "Browser";
			this.Text = "1";
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.TreeView folderExplorer;
		private System.Windows.Forms.ListView fileExplorer;
	}
}

