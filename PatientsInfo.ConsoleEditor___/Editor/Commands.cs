using System;
using System.Linq;

using PatientsInfo.ConsoleEditor.Methods;
using PatientsInfo.ConsoleEditor.Entities;
using static PatientsInfo.ConsoleEditor.RegexExpressions;
using static PatientsInfo.ConsoleEditor.ConsoleIO.Entering;
using static PatientsInfo.ConsoleEditor.Entities.Enum;

namespace PatientsInfo.ConsoleEditor.Editor {
	public partial class Editor {
		private void OutData() {
			OutPeopleData();
			OutPatientsData();
			OutDiseasesData();
		}

		private void OutPeopleData() {
			Console.WriteLine("Особи");
			foreach (var obj in sortingPeople) {
				Console.WriteLine(obj.ToString());
			}
			Console.WriteLine();
		}

		private void OutDiseasesData() {
			Console.WriteLine("Хвороби");
			foreach (var obj in sortingDiseases) {
				Console.WriteLine(obj.ToString());
			}
			Console.WriteLine();
		}

		private void OutPatientsData() {
			Console.WriteLine("Пацієнти");
			foreach (var obj in sortingPatients) {
				Console.WriteLine(obj.ToString());
			}
			Console.WriteLine();
		}

		public void AddPatient() {
			Patient inst = new Patient();

			inst.Person = SelectPatient();
			inst.disease = SelectDisease();

			inst.IsSick = EnterBoolNull("На даний час хворіє нею?(пропуск, якщо не відомо");

			dataContext.Patients.Add(inst);
		}

		public void AddDiseases() {
			Disease tmp = new Disease();

			tmp.Name = EnterString("Введіть назву захворювання");
			tmp.CodeICD = EnterString("Введіть МКХ", RCodeICD, "Латинська літера і дві цифри: A01, A04.1");
			tmp.Description = EnterString("Опишіть захворювання");

			dataContext.Diseases.Add(tmp);
		}

		private Person SelectPatient() {
			ulong id;
			Person patient;
				id = EnterULong("Введіть персональний номер особи");
				patient = dataContext.People.FirstOrDefault(e => e.PersonalNumber == id);			


			return patient;
		}

		private Disease SelectDisease() {
			Disease patient;
			string str = EnterString("Введіть назву хвороби");

			patient = dataContext.Diseases.FirstOrDefault(e => e.Name == str);
			return patient;
		}




		public void AddPerson() {
			Person inst = new Person();

			inst.FullName = EnterString("Введіть ПІБ", RFullName);
			inst.DiseaseOnsetDate = EnterDateTime("Введіть дату захворювання", DateTime.Now);
			inst.DateBirth = EnterDateTime("Введіть дата народження:", DateTime.Now);
			inst.Gender =  (Gender)EnterEnum("Введіть стать (Ч/Ж)", GenderShortNameUA);
			inst.PhoneNumber = EnterString("Введіть номер телефону (не обов.)", RPhoneNumber);
			inst.ResidenceAddress = EnterString("Введіть адресу", 1);
			inst.HealthStatus = (HealthStatus)EnterEnum("Введіть стан здоров'я", HealthStatusNameUA);
			inst.TypeBlood = EnterString("Введіть тип крові", RTypeBlood);
			inst.Comment = EnterString("Опишіть пацієнта");

			dataContext.People.Add(inst);
		}




		public void RemovePatient() {
			ulong id = EnterULong("Введіть ID пацієнта");
			dataContext.Patients.Remove(dataContext.Patients.FirstOrDefault(e => e.Key == id));
		}

		public void RemoveDisease() {
			string str = EnterString("Введіть назву хвороби");
			dataContext.Diseases.Remove(dataContext.Diseases.FirstOrDefault(e => e.Name == str));
		}

		public void RemovePerson() {
			ulong id = EnterULong("Введіть персональний номер особи");
			dataContext.People.Remove(dataContext.People.FirstOrDefault(e => e.PersonalNumber == id));
		}


		private void SortPatientByID() {
			sortingPatients = sortingPatients.OrderBy(e => e.Key);
		}
		private void SortPeopleByFullName() {
			sortingPeople = sortingPeople.OrderBy(e => e.FullName);
		}
		private void SortPeopleByHealthStatus() {
			sortingPeople = sortingPeople.OrderBy(e => e.HealthStatus);
		}
		private void SortPeopleByPersonalNumber() {
			sortingPeople = sortingPeople.OrderBy(e => e.PersonalNumber);
		}
		private void SortDiseaseByCodeICD() {
			sortingDiseases = sortingDiseases.OrderBy(e => e.CodeICD);
		}
	}
}
