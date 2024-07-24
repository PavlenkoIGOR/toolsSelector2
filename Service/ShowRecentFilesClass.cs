/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 18.07.2024
 * Time: 8:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToolSelector2.Models;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of ShowRecentFilesClass.
	/// </summary>
	internal class ShowRecentFilesClass
	{
		internal WordFileInfo wordFileInfo;
		internal ListBox recent_LB;
		internal List<WordFileInfo> wordFiles;
		
		internal ShowRecentFilesClass(ListBox lb1)
		{
			recent_LB = lb1;
			wordFiles = new List<WordFileInfo>();
		}
		
		internal void ShowRecentFiles()
		{
			char [] delimeters = {'.'};
			
			Word.Application newWordApp = new Word.Application();
			Word.RecentFiles recentFiles = newWordApp.RecentFiles;  
			
			foreach (Word.RecentFile recentFile in recentFiles)
			{
				string filePath = recentFile.Path;
				string fileName = recentFile.Name;
				string fileType = '.' + fileName.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
				
				WordFileInfo tempWordFileInfo = new WordFileInfo(fileName, filePath, fileType);
					
				wordFiles.Add(tempWordFileInfo);
				recent_LB.Items.Add(tempWordFileInfo.filePath + '\\' + tempWordFileInfo.fileName);
			}
			
			newWordApp.Quit();
		}
	}
}
