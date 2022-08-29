using System;
using System.Text;

namespace PatientsInfo.ConsoleEditor.ConsoleIO {
	public static class Setting {

		public static void SetConsoleParameters(string title = "") {
			Console.Title = title;
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			Console.Clear();
		}

		public static void Pause() {
			Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
			Console.ReadKey();
		}
	}
}
