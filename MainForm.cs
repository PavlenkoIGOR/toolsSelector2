/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 17.07.2024
 * Time: 16:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSelector2.Models;
using ToolSelector2.Service;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private WordFileInfo wordFileInfo;
		private ReadFromWord readFromWord;
		private ShowRecentFilesClass showRecentFilesClass;
		private OpenCurrentFileClass openCurrentFileClass;
		private WriteIntoFileClass writeIntoFile;
		private CheckAndCloseWordFileClass checkAndCloseWordFileClass;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			wordFileInfo = new WordFileInfo();			
			openCurrentFileClass = new OpenCurrentFileClass(this.ChooseFileBttn, this.ChoosenFileLabel, wordFileInfo);
			showRecentFilesClass = new ShowRecentFilesClass(this.listBox1);
			readFromWord = new ReadFromWord(this.ChooseFileBttn, this.ChoosenFileLabel, this.richTextBox1, showRecentFilesClass, wordFileInfo);
			writeIntoFile = new WriteIntoFileClass(wordFileInfo, readFromWord);
			checkAndCloseWordFileClass = new CheckAndCloseWordFileClass(wordFileInfo);
			//
			checkAndCloseWordFileClass.CheckAndCloseWord();
			
			showRecentFilesClass.ShowRecentFiles();
			
			listBox1.DrawMode = DrawMode.OwnerDrawVariable;
			listBox1.MeasureItem += new MeasureItemEventHandler(listBox1_MeasureItem);
			listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);

			ChooseFileBttn.MouseClick += async (sender,e) => await readFromWord.ChooseWordWordFileMethod();
			StartReadBttn.MouseClick += async (sender, e) => await readFromWord.ReadFromWordFileMethod();	
			
			richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
			richTextBox1.DragDrop += new DragEventHandler (richTextBox1_DragDrop);
			
			listBox1.MouseDoubleClick += async (sender, e) => await Task.Run(() => {   //т.к. возникала ошибка что пытается обратиться к потоку в котором создан listBox1 из данного потока
				if (listBox1.InvokeRequired)
				{
					listBox1.Invoke(new MethodInvoker(() => listBox1_MouseDoubleClick(sender, e)));
				} 
				else
				{
					listBox1_MouseDoubleClick(sender, e);
				}
			});
			
			listBox1.MouseClick += async (sender, e) => await Task.Run(() => {   //т.к. возникала ошибка что пытается обратиться к потоку в котором создан listBox1 из данного потока
				if (listBox1.InvokeRequired)
				{
					listBox1.Invoke(new MethodInvoker(() => listBox1_MouseClick(sender, e)));
				} 
				else
				{
					listBox1_MouseClick(sender, e);
				}
			});
			
			OpenCurrebFileBttn.MouseClick += async (sender, e) => openCurrentFileClass.OpenWordFile();
			
			button1.MouseClick += CheckBlueCells;
			
			this.label2.Text = DescriptionsClass.Punct_1;
			this.label3.Text = DescriptionsClass.Punct_2;
		}
		
		#region методы для переноса строк в ListBox
		private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = (int)e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, listBox1.Width).Height;
		}
		
		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			
			e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
		}
		#endregion
		
		#region для перетаскивания файла
		private void richTextBox1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			//else
			//	e.Effect = DragDropEffects.None;
		}
		
		private void richTextBox1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			
			if (files.Length > 0)
			{				
				char [] delimeters = {'\\', '.'};
				List<string>pathElems = new List<string>();
				pathElems = files[0].Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
				
				wordFileInfo.fileName = pathElems[pathElems.Count-2];
				wordFileInfo.filePath = files[0];
				ChangeChooseBttnStyle changeChooseBttn = new ChangeChooseBttnStyle();
				changeChooseBttn.ChangeChooseBttnStyleMethod(this.ChooseFileBttn, wordFileInfo.fileName);
				changeChooseBttn.ChangeLabelTextMethod(this.ChoosenFileLabel, files[0]);
			}
		}
		#endregion
		
		#region doubleclick и одинарный click по элементу ListBox
		private async Task listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string selectedItem = listBox1.SelectedItem.ToString();
			int index = listBox1.IndexFromPoint(listBox1.PointToClient(Cursor.Position));
			wordFileInfo.filePath = showRecentFilesClass.wordFiles[index].filePath + '\\' + showRecentFilesClass.wordFiles[index].fileName;
			wordFileInfo.fileName = showRecentFilesClass.wordFiles[index].fileName;
			
			if (index != ListBox.NoMatches)
			{
				//string filePath = showRecentFilesClass.wordFiles[index].filePath + showRecentFilesClass.wordFiles[index].fileType;
				
				//toolTip.SetToolTip(listBox1, filePath);
			}
			DialogResult result = MessageBox.Show("Считать из \u00AB" + selectedItem + "\u00BB ?", "Выберите ответ", MessageBoxButtons.YesNoCancel);
			if (result == DialogResult.Yes) 
			{
				ChangeChooseBttnStyle changeChooseBttn = new ChangeChooseBttnStyle();
				changeChooseBttn.ChangeChooseBttnStyleMethod(this.ChooseFileBttn, wordFileInfo.fileName);
				changeChooseBttn.ChangeLabelTextMethod(this.ChoosenFileLabel, wordFileInfo.filePath);
				await readFromWord.ReadFromWordFileMethod();
			}
		}
		
		private async Task listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			string selectedItem = listBox1.SelectedItem.ToString();
			int index = listBox1.IndexFromPoint(listBox1.PointToClient(Cursor.Position));
			string filePath = showRecentFilesClass.wordFiles[index].filePath + '\\' + showRecentFilesClass.wordFiles[index].fileName;
			
			if (index != ListBox.NoMatches)
			{
				wordFileInfo.filePath = filePath;
				wordFileInfo.fileName = showRecentFilesClass.wordFiles[index].fileName;
			}
		}
		#endregion
		
		private void CheckBlueCells(object sender, MouseEventArgs e)
		{
			writeIntoFile.WriteIntoWordFile();
		}
	}
}
