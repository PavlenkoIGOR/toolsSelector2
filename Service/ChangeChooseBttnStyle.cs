/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 17.07.2024
 * Time: 16:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace ToolSelector2.Service
{
	/// <summary>
	/// Description of ChangeChooseBttnStyle.
	/// </summary>
	internal class ChangeChooseBttnStyle
	{
		
		internal ChangeChooseBttnStyle()
		{
		}
		
		internal void ChangeChooseBttnStyleMethod(Button chooseBttn, string fName)
		{
			chooseBttn.BackColor = System.Drawing.Color.LightGreen;
			chooseBttn.Text = "Файл: " + fName;
		}
		internal void ChangeLabelTextMethod(Label lbl,  string fPath)
		{
			lbl.Text = "Выбран файл: " + fPath;
		}
	}
}
