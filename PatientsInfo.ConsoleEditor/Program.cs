using static ConsoleIO.Setting;
using PatientsInfo.Data;
using ConsoleEditor;

using FileIO;
using FileIO.Json;

using ConsoleEditor.CMD;

namespace PatientsInfo.ConsoleEditor {
	public static class Program {

		static DataContext dataContext;
		static EnterCMD enterCMDEditor;
		static Editor editor;
		static XmlFileIoController xmlController = new XmlFileIoController();
		static BinarySerializationController binarySerializationController = new BinarySerializationController();
		static IConsoleEditor consoleEditor;
		static void Main(string[] args) {
			SetConsoleParameters("PatientsInfo.ConsoleEditor (Воробйов Я. І.)");
			dataContext = new DataContext();

			enterCMDEditor = new EnterCMD(dataContext, xmlController, binarySerializationController);
			editor = new Editor(dataContext, xmlController, binarySerializationController);

			bool isEditor = true;
			consoleEditor = editor;

				

		
			int res;
			while((res = consoleEditor.Run()) == 2){
				isEditor = !isEditor;
				if (isEditor) {
					consoleEditor = editor;
				} else {
					consoleEditor = enterCMDEditor;
				}
			};

			Pause();
		}
	}
}
