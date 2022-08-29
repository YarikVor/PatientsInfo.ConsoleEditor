using System.Collections.Generic;

using PatientsInfo.ConsoleEditor.Entities;
using PatientsInfo.ConsoleEditor.Methods;

namespace PatientsInfo.ConsoleEditor.Data {
	public partial class DataContext {
		readonly DataSet dataSet = new DataSet();

		public ICollection<Person> People {
			get { return dataSet.People; }
		}

		public ICollection<Patient> Patients {
			get => dataSet.Patients;
		}

		public ICollection<Disease> Diseases {
			get => dataSet.Diseases;
		}

		public override string ToString() {
			return string.Concat("Інформація про \"Облік пацієнтів\"",
				People.ToLineList("Особи"),
				Patients.ToLineList("Пацієнти"),
				Diseases.ToLineList("Захворювання"));
		}

		public void Clear() {
			People.Clear();
			Patients.Clear();
			Diseases.Clear();
		}

		public void CreateTestingData() {
			CreateDiseases();
			CreatePeople();
			CreatePatients();
		}
	}
}
