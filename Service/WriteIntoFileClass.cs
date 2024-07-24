/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 19.07.2024
 * Time: 13:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToolSelector2.Models;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of WriteToFileClass.
	/// </summary>
	internal class WriteIntoFileClass
	{
		private WordFileInfo wordFileInfo;
		private ReadFromWord readFromWord;
		private Word.Cell currentCell;
		
		internal WriteIntoFileClass(WordFileInfo wfi, ReadFromWord rfw)
		{
			wordFileInfo = wfi;
			readFromWord = rfw;
		}
		
		internal void WriteIntoWordFile()
		{
			List<string> textFromCells = new List<string>();
			List<Word.WdColor>colors = new List<Word.WdColor>();
			
			Word.Application newApp = new Word.Application();
			Word.Document doc = newApp.Documents.Open(wordFileInfo.filePath);
			
			foreach (Word.Table table in doc.Tables)
			{
				foreach (Word.Cell cell in table.Range.Cells)
				{
					Word.WdColor cellColor = (Word.WdColor)cell.Shading.BackgroundPatternColor;
					if (cellColor == (Word.WdColor)15773696) // Значение цвета RGB(0, 176, 240)					
					{
						currentCell = cell;
					}
					// Получаем цвет фона ячейки
                    Word.WdColor backgroundColor = cell.Shading.BackgroundPatternColor;
                    colors.Add(backgroundColor);
				}
			}
			
			foreach (var element in readFromWord.hashTools) 
			{
				currentCell.Range.Text += element + ", шт. - ";
			}
			
			doc.Save();
			doc.Close();
			newApp.Quit();
			
			MessageBox.Show("Записано!");
		}
	}
}
