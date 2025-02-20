namespace CC_project1
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
			this.txtInput = new System.Windows.Forms.RichTextBox();
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtError = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtScope = new System.Windows.Forms.RichTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtArray = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSuggestions = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.BackColor = System.Drawing.Color.Gainsboro;
			this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInput.Location = new System.Drawing.Point(47, 31);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(324, 211);
			this.txtInput.TabIndex = 0;
			this.txtInput.Text = "";
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.Color.Gainsboro;
			this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutput.Location = new System.Drawing.Point(47, 329);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(324, 192);
			this.txtOutput.TabIndex = 1;
			this.txtOutput.Text = "";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.MidnightBlue;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.button1.Location = new System.Drawing.Point(67, 259);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(736, 36);
			this.button1.TabIndex = 2;
			this.button1.Text = "Compile";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.Color.Gainsboro;
			this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtError.ForeColor = System.Drawing.Color.Red;
			this.txtError.Location = new System.Drawing.Point(387, 328);
			this.txtError.Name = "txtError";
			this.txtError.Size = new System.Drawing.Size(230, 193);
			this.txtError.TabIndex = 3;
			this.txtError.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label1.Location = new System.Drawing.Point(51, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Code";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label2.Location = new System.Drawing.Point(51, 304);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label3.Location = new System.Drawing.Point(389, 302);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Error List";
			// 
			// txtScope
			// 
			this.txtScope.BackColor = System.Drawing.Color.Gainsboro;
			this.txtScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtScope.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtScope.Location = new System.Drawing.Point(385, 31);
			this.txtScope.Name = "txtScope";
			this.txtScope.Size = new System.Drawing.Size(232, 211);
			this.txtScope.TabIndex = 7;
			this.txtScope.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label4.Location = new System.Drawing.Point(385, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Variables";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label5.Location = new System.Drawing.Point(635, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Array";
			// 
			// txtArray
			// 
			this.txtArray.BackColor = System.Drawing.Color.Gainsboro;
			this.txtArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtArray.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtArray.Location = new System.Drawing.Point(632, 31);
			this.txtArray.Name = "txtArray";
			this.txtArray.Size = new System.Drawing.Size(232, 211);
			this.txtArray.TabIndex = 9;
			this.txtArray.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label6.Location = new System.Drawing.Point(634, 302);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Suggestions";
			// 
			// txtSuggestions
			// 
			this.txtSuggestions.BackColor = System.Drawing.Color.Gainsboro;
			this.txtSuggestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSuggestions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSuggestions.Location = new System.Drawing.Point(629, 328);
			this.txtSuggestions.Name = "txtSuggestions";
			this.txtSuggestions.Size = new System.Drawing.Size(232, 193);
			this.txtSuggestions.TabIndex = 12;
			this.txtSuggestions.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(931, 533);
			this.Controls.Add(this.txtSuggestions);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtArray);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtScope);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtError);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.txtInput);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtInput;
		private System.Windows.Forms.RichTextBox txtOutput;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox txtError;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox txtScope;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox txtArray;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox txtSuggestions;
	}
}

