/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 19.07.2024
 * Time: 14:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ToolSelector2.Models;
using Word = Microsoft.Office.Interop.Word;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of CheckAndCloseWordFileClass.
	/// </summary>
	internal class CheckAndCloseWordFileClass
	{
		private WordFileInfo wordFileInfo;
		
		internal CheckAndCloseWordFileClass(WordFileInfo wfi)
		{
			wordFileInfo = wfi;
		}
		
		internal void CheckAndCloseWord()
		{
			string filePath = @"путь_к_файлу"; // Укажите здесь путь к файлу

            Word.Application wordApp = null;

            try
            {
                wordApp = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
            }
            catch (System.Exception)
            {

            }

            if (wordApp != null)
            {
                // Проверяем, открыт ли нужный файл
                foreach (Word.Document doc in wordApp.Documents)
                {
                    if (doc.FullName.Equals(wordFileInfo.filePath))
                    {
                        // Закрываем файл
                        doc.Close();
                        break;
                    }
                }
            }

            // Освобождаем ресурсы
            if (wordApp != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                wordApp = null;
                wordApp.Quit();
            }
		}
	}
}
