/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 17.07.2024
 * Time: 16:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using ToolSelector2.Models;
namespace ToolSelector2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button ChooseFileBttn;
		private System.Windows.Forms.Button StartReadBttn;
		private System.Windows.Forms.Button OpenCurrebFileBttn;
		private System.Windows.Forms.Label ChoosenFileLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ChooseFileBttn = new System.Windows.Forms.Button();
			this.StartReadBttn = new System.Windows.Forms.Button();
			this.OpenCurrebFileBttn = new System.Windows.Forms.Button();
			this.ChoosenFileLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.Location = new System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(275, 378);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// listBox1
			// 
			this.listBox1.AllowDrop = true;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(13, 397);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(506, 229);
			this.listBox1.TabIndex = 1;
			// 
			// ChooseFileBttn
			// 
			this.ChooseFileBttn.BackColor = System.Drawing.Color.Salmon;
			this.ChooseFileBttn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ChooseFileBttn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.ChooseFileBttn.Location = new System.Drawing.Point(293, 12);
			this.ChooseFileBttn.Name = "ChooseFileBttn";
			this.ChooseFileBttn.Size = new System.Drawing.Size(226, 74);
			this.ChooseFileBttn.TabIndex = 2;
			this.ChooseFileBttn.Text = "Выбрать файл";
			this.ChooseFileBttn.UseVisualStyleBackColor = false;
			// 
			// StartReadBttn
			// 
			this.StartReadBttn.Location = new System.Drawing.Point(294, 218);
			this.StartReadBttn.Name = "StartReadBttn";
			this.StartReadBttn.Size = new System.Drawing.Size(226, 55);
			this.StartReadBttn.TabIndex = 3;
			this.StartReadBttn.Text = "Начать считывание из файла";
			this.StartReadBttn.UseVisualStyleBackColor = true;
			// 
			// OpenCurrebFileBttn
			// 
			this.OpenCurrebFileBttn.Enabled = false;
			this.OpenCurrebFileBttn.Location = new System.Drawing.Point(293, 340);
			this.OpenCurrebFileBttn.Name = "OpenCurrebFileBttn";
			this.OpenCurrebFileBttn.Size = new System.Drawing.Size(226, 50);
			this.OpenCurrebFileBttn.TabIndex = 4;
			this.OpenCurrebFileBttn.Text = "Открыть файл для дальнейшей работы\r\n(Кнопка не работает. Ведутся ремотные работы." +
	")";
			this.OpenCurrebFileBttn.UseVisualStyleBackColor = true;
			// 
			// ChoosenFileLabel
			// 
			this.ChoosenFileLabel.Location = new System.Drawing.Point(294, 89);
			this.ChoosenFileLabel.Name = "ChoosenFileLabel";
			this.ChoosenFileLabel.Size = new System.Drawing.Size(225, 126);
			this.ChoosenFileLabel.TabIndex = 6;
			this.ChoosenFileLabel.Text = "Файл не выбран";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(293, 279);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(225, 55);
			this.button1.TabIndex = 7;
			this.button1.Text = "Записать в файл";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(522, 89);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(283, 235);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
			this.pictureBox2.Location = new System.Drawing.Point(522, 397);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(282, 175);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 9;
			this.pictureBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(522, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(281, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "Для корректной работы программы необходимо:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(522, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(279, 53);
			this.label2.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(522, 348);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(283, 42);
			this.label3.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(629, 327);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 21);
			this.label4.TabIndex = 13;
			this.label4.Text = "Рис.1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(629, 575);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 21);
			this.label5.TabIndex = 14;
			this.label5.Text = "Рис.2";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(522, 603);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(286, 23);
			this.label6.TabIndex = 15;
			this.label6.Text = "3. Сохранить и закрыть файл.";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 636);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.ChoosenFileLabel);
			this.Controls.Add(this.OpenCurrebFileBttn);
			this.Controls.Add(this.StartReadBttn);
			this.Controls.Add(this.ChooseFileBttn);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.richTextBox1);
			this.Name = "MainForm";
			this.Text = "ToolSelector2";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
