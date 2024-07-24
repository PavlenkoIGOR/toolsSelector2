/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 17.07.2024
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSelector2.Models;
using ToolSelector2.Service;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of ReadFromWord.
	/// </summary>
	internal class ReadFromWord
	{
		internal string filePath;
		internal string fileName;
		internal WordFileInfo wordFileInfo;
		internal ShowRecentFilesClass showRecentFiles;
		internal Button ChooseFileBttn;
		internal Label Lbl;
		internal RichTextBox Rtb;
		internal List<string> textFromCells; //HashSet не позволяет хранить дубликаты элементов, но может хранить несколько копий строки, если они имеют разный адрес в памяти, что и происходит с Interop.
		
		internal HashSet<string> hashTools;
		
		internal ReadFromWord(Button cfBttn, Label label, RichTextBox rTB, ShowRecentFilesClass recFiles, WordFileInfo wfi)
		{
			ChooseFileBttn = cfBttn;
			Lbl = label;
			Rtb = rTB;
			textFromCells = new List<string>();		
			hashTools = new HashSet<string>();
			showRecentFiles = recFiles;
			wordFileInfo = wfi;
		}
		
		
		internal async Task ChooseWordWordFileMethod()
		{
			char[]delimeters = {'\\', '.'};
			
			using (OpenFileDialog ofd = new OpenFileDialog()) 
			{				
				//ofd.InitialDirectory = "d:\\";
				ofd.Title = "Выберите файл";
				ofd.Filter = "Текстовые файлы (.doc, .docx)|*.doc;*.docx";
				if (ofd.ShowDialog() == DialogResult.OK)
				{					
					List<string>elemsFromSafeFileName = new List<string>();
					elemsFromSafeFileName = ofd.SafeFileName.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
						
					wordFileInfo.fileName = elemsFromSafeFileName[elemsFromSafeFileName.Count-2];
					wordFileInfo.filePath = ofd.FileName;
					wordFileInfo.fileType = '.' + elemsFromSafeFileName[elemsFromSafeFileName.Count-1];
					
					ChangeChooseBttnStyle changeChooseBttnStyle = new ChangeChooseBttnStyle();
					changeChooseBttnStyle.ChangeChooseBttnStyleMethod(ChooseFileBttn, wordFileInfo.fileName);
					changeChooseBttnStyle.ChangeLabelTextMethod(Lbl, wordFileInfo.filePath);
				}
			}
		}
		
		internal async Task ReadFromWordFileMethod()
		{
			if (wordFileInfo.filePath == null) 
			{
				MessageBox.Show("Файл не выбран!");
				return;
			}
			else
			{
				Rtb.Clear();
				hashTools.Clear();
				textFromCells.Clear();
				
				Word.Application newWordApp = new Word.Application();
				Word.Document doc = await Task.Run(()=>newWordApp.Documents.Open(wordFileInfo.filePath));
				
				foreach (Word.Table table in doc.Tables)
				{
					foreach (Word.Cell cell in table.Range.Cells)
					{
						if (cell.Shading.BackgroundPatternColor == Word.WdColor.wdColorYellow)
						{
							//string cellText = cell.Range.Text.TrimEnd('\r', '\n', '').Trim();
							string cellText = cell.Range.Text.Replace('\a', ' ').Trim();
							textFromCells.Add(cellText);
						}
					}
				}
				doc.Close();
				newWordApp.Quit();
				
									ChangeChooseBttnStyle changeChooseBttnStyle = new ChangeChooseBttnStyle();
					changeChooseBttnStyle.ChangeChooseBttnStyleMethod(ChooseFileBttn, wordFileInfo.fileName);
					changeChooseBttnStyle.ChangeLabelTextMethod(Lbl, wordFileInfo.filePath);
				
				foreach (var element in textFromCells)
				{
					foreach (var elementTemp in element.Split(new char[]{'\r'}, StringSplitOptions.RemoveEmptyEntries))
					{
						
						hashTools.Add(elementTemp);
					}
				}
				
				foreach (string element in hashTools)
				{
					Rtb.AppendText(String.Format(element + ", шт. - " + "\n"));
				}
			}
		}
	}
}
