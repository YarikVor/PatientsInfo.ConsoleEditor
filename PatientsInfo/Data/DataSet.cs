using System.Collections.Generic;
using System;
using PatientsInfo.Entities;


namespace PatientsInfo.Data {
	/// <summary>
	/// Клас для створення списків сутностей
	/// </summary>
	[Serializable]
	public class DataSet {
		public List<Person> People { get; set; }
		public List<Patient> Patients { get; set; }
		public List<Disease> Diseases { get; set; }

		public DataSet() {
			People = new List<Person>();
			Patients = new List<Patient>();
			Diseases = new List<Disease>();
		}
	}
}
