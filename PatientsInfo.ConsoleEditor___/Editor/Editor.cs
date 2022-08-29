using System;
using System.Collections.Generic;

using PatientsInfo.ConsoleEditor.Data;
using PatientsInfo.ConsoleEditor.Entities;
using static PatientsInfo.ConsoleEditor.ConsoleIO.Entering;

namespace PatientsInfo.ConsoleEditor.Editor {
	public partial class Editor {
		private DataContext dataContext;

		IEnumerable<Person>  sortingPeople;
		IEnumerable<Patient> sortingPatients;
		IEnumerable<Disease> sortingDiseases;

		public Editor(DataContext dataContext) {
			this.dataContext = dataContext;
			sortingDiseases = dataContext.Diseases;
			sortingPatients = dataContext.Patients;
			sortingPeople   = dataContext.People;
			Init();
		}

		private CommandInfo[] commandsInfo;

		private void Init() {
			commandsInfo = new CommandInfo[]{
				new CommandInfo("Вийти", null),
				new CommandInfo("Створити тестові дані", dataContext.CreateTestingData),
				new CommandInfo("Додати запис про особу", AddPerson),
				new CommandInfo("Додати запис про пацієнта", AddPatient),
				new CommandInfo("Додати запис про захворювання", AddDiseases),
				new CommandInfo("Видалити запис про особу", RemovePerson),
				new CommandInfo("Видалити запис про пацієнта", RemovePatient),
				new CommandInfo("Видалити запис про хворобу", RemoveDisease),
				new CommandInfo("Видалити усі записи", dataContext.Clear),
				new CommandInfo("Сортувати пацієнтів за ID", SortPatientByID),
				new CommandInfo("Сортувати осіб за ПІБ", SortPeopleByFullName),
				new CommandInfo("Сортувати осіб за станом здоров'я", SortPeopleByHealthStatus),
				new CommandInfo("Сортувати осіб за персональним номером", SortPeopleByPersonalNumber),
				new CommandInfo("Сортувати хвороби за МКХ", SortDiseaseByCodeICD)
			};
		}

		public void Run() {
			Command command;
			while (true) {
				Console.Clear();
				Console.WriteLine("Реалізація класів для предметної області");
				OutData();
				Console.WriteLine();
				ShowCommandsMenu();
				command = EnterCommand();
				if (command == null) return;
				command();
			}
		}

		private void ShowCommandsMenu() {
			Console.WriteLine("Список команд меню");
			for (int i = 0; i < commandsInfo.Length; i++) {
				Console.WriteLine("\t{0, 2} - {1}", i, commandsInfo[i].title);
			}
		}

		private Command EnterCommand() {
			Console.WriteLine();
			return commandsInfo[EnterULong("Введіть номер команди", 0, (ulong)commandsInfo.Length - 1)].command;
		}

	}
}
