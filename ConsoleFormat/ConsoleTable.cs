using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleFormat {

	public class ConsoleTable {
		public ConsoleStyle[] consoleStyle;
		public string title;
		public int width = 0;
		public int minWidth = 0;
		public int count;
		public bool onlyRequired = false;
		public int index = 0;
		public int pos = 0;
		public int countView = 3;
		public int countData = 0;
		public ConsoleTable(string title, ConsoleStyle[] consoleStyle) {
			this.title = title;
			this.consoleStyle = consoleStyle;
			for (int i = 0; i < consoleStyle.Length; i++) {
				width += consoleStyle[i].width + 1;
				if (consoleStyle[i].isRequired == true) {
					minWidth += consoleStyle[i].width + 1;
				}
			}
			width++;
			minWidth++;
			count = consoleStyle.Length - 1;
		}

		public void OutCell(object obj) {
			ConsoleStyle style = consoleStyle[index];
			if (onlyRequired == false || style.isRequired == true) {
				string str = "";
				if (obj != null) {
					str = obj.ToString();
				}
				Console.Write(CTSymbol.vl + str.Substring(0, (style.width > str.Length) ? str.Length : style.width).Replace('\n', ' ').PadRight(style.width));
			}
			index++;
		}

		public void OutEndRow() {
			Console.WriteLine(CTSymbol.vl);
			this.index = 0;
		}

		public void ShowSubTitle(char left, char middle, char right) {
			Console.Write(left);
			int last = 0;

			for (int i = 1; i <= count; i++) {
				if (onlyRequired == false || consoleStyle[i].isRequired) {
					Console.Write(consoleStyle[last].title.Substring(0, (consoleStyle[last].width > consoleStyle[last].title.Length) ? consoleStyle[last].title.Length : consoleStyle[last].width).PadRight(consoleStyle[last].width));
					Console.Write(middle);

					last = i;
				}
			}
			Console.Write(consoleStyle[last].title.Substring(0, (consoleStyle[last].width > consoleStyle[last].title.Length) ? consoleStyle[last].title.Length : consoleStyle[last].width).PadRight(consoleStyle[last].width));
			Console.WriteLine(right);
		}
		public void ShowFillLine(char left, char middle, char right, char fill = CTSymbol.hl) {
			Console.Write(left);
			int last = 0;
			for (int i = 1; i <= count; i++) {
				if (onlyRequired == false || consoleStyle[i].isRequired) {
					Console.Write(new string(fill, consoleStyle[last].width));
					Console.Write(middle);
					last = i;
				}
			}
			Console.Write(new string(fill, consoleStyle[last].width));
			Console.WriteLine(right);
		}

		public void ShowTitle(char left = CTSymbol.vl) {
			int width = onlyRequired ? minWidth : this.width;
			Console.WriteLine(left + title.PadLeft((width - title.Length) / 2).PadRight(width - 2) + left);
		}


		public void Next() {
			if (pos + countView < countData) {
				pos += countView;
			}
		}

		public void Back() {
			pos -= countView;
			if (pos < 0) pos = 0;
		}
		public void AddCountView() {
			countView++;
		}
		public void RemCountView() {
			if (countView > 1) countView--;
		}

	}
}
