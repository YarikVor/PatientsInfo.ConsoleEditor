using System.Collections.Generic;

using PatientsInfo.ConsoleEditor.Entities;

namespace PatientsInfo.ConsoleEditor.Data {
	public class DataSet {
		public List<Person> People { get; private set; }
		public List<Patient> Patients { get; private set; }
		public List<Disease> Diseases { get; private set; }

		public DataSet() {
			People = new List<Person>();
			Patients = new List<Patient>();
			Diseases = new List<Disease>();
		}
	}
}
