namespace AutoCorrect
{
	partial class Correcter
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
			this.mainTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// mainTextBox
			// 
			this.mainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainTextBox.Location = new System.Drawing.Point(12, 12);
			this.mainTextBox.Name = "mainTextBox";
			this.mainTextBox.Size = new System.Drawing.Size(514, 412);
			this.mainTextBox.TabIndex = 0;
			this.mainTextBox.Text = "";
			this.mainTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainTextBox_KeyPress);
			// 
			// Correcter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(538, 436);
			this.Controls.Add(this.mainTextBox);
			this.Name = "Correcter";
			this.Text = "Correcter";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox mainTextBox;
	}
}

