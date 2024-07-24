/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 18.07.2024
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSelector2.Models;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of OpenCurrentFileClass.
	/// </summary>
	internal class OpenCurrentFileClass
	{
		internal string filePath;
		internal string fileName;
		internal Button chooseBttn;
		internal Label lbl;
		internal WordFileInfo wordFileInfo;
		
		internal OpenCurrentFileClass(Button choosebttn, Label lbl, WordFileInfo wfi)
		{
			chooseBttn = choosebttn;
			this.lbl = lbl;
			wordFileInfo = wfi;
		}
		
		internal void OpenWordFile()
		{
			Word.Application newWordApp = new Word.Application();
			try
			{				
				Word.Document doc = newWordApp.Documents.Open(wordFileInfo.filePath);
				MessageBox.Show(wordFileInfo.filePath);
				ChangeChooseBttnStyle changeChooseBttnStyle = new ChangeChooseBttnStyle();
				changeChooseBttnStyle.ChangeChooseBttnStyleMethod(chooseBttn, wordFileInfo.fileName);
				changeChooseBttnStyle.ChangeLabelTextMethod(lbl, wordFileInfo.filePath);	
				
			}
			catch(Exception)
			{
				newWordApp.Quit();
				MessageBox.Show("Файл не указан!");				
			}
		}
	}
}
