/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 17.07.2024
 * Time: 16:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ToolSelector2.Models
{
	/// <summary>
	/// Description of WordFileInfo.
	/// </summary>
	internal class WordFileInfo
	{
		internal string fileName;
		internal string filePath;
		internal string fileType;
		internal DateTime fileDate;
		
		internal WordFileInfo()
		{
			
		}
		internal WordFileInfo(string fName, string fPath, string fType)
		{
			fileName = fName;
			filePath = fPath;
			fileType = fType;
		}
	}
}
