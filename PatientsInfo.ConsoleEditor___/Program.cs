using static PatientsInfo.ConsoleEditor.ConsoleIO.Setting;
using PatientsInfo.ConsoleEditor.Data;

namespace PatientsInfo.ConsoleEditor {
	public static class Program {

		static DataContext dataContext;
		static Editor.Editor editor;

		static void Main(string[] args) {
			SetConsoleParameters("PatientsInfo.ConsoleEditor (Воробйов Я. І.)");

			dataContext = new DataContext();
			editor = new Editor.Editor(dataContext);
			editor.Run();

			Pause();
		}
	}
}
