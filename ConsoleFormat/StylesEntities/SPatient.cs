using System.Collections.Generic;
using System.Linq;
using PatientsInfo.Entities;

namespace ConsoleFormat.StylesEntities {
	public class SPatient : IStyleEntity {
		public ConsoleTable consoleTable { get; set; }

		public IEnumerable<Patient> patients;

		public SPatient(IEnumerable<Patient> patients) {
			consoleTable = new ConsoleTable("Пацієнти",
				new ConsoleStyle[]{
					new ConsoleStyle("№", 5),
					new ConsoleStyle("ПІБ", 30),
					new ConsoleStyle("Назва хвороби", 15),
					new ConsoleStyle("Стан здоров'я", 10),
					new ConsoleStyle("Коментар", 70, false)
			});

			this.patients = patients;
		}

		public void OutTable(bool shortOn = false, bool onlyRequired = false) {
			if (patients != null) {
				consoleTable.onlyRequired = onlyRequired;

				consoleTable.countData = patients.Count();

				var tmpPatients = shortOn ?
					patients.Skip(consoleTable.pos).Take(consoleTable.countView).ToArray() : 
					patients.ToArray();
					

				consoleTable.ShowFillLine(CTSymbol.ul, CTSymbol.hl, CTSymbol.ur);
				consoleTable.ShowTitle();
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.uc, CTSymbol.mr);

				consoleTable.ShowSubTitle(CTSymbol.vl, CTSymbol.vl, CTSymbol.vl);
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.mc, CTSymbol.mr);

				for (int i = 0; i < tmpPatients.Length; i++) {
					this.OutRow(tmpPatients[i]);
				}

				consoleTable.ShowFillLine(CTSymbol.bl, CTSymbol.bc, CTSymbol.br);
			}
		}


		private void OutRow(Patient patient) {
			consoleTable.OutCell(patient.Id);
			consoleTable.OutCell(patient.Person?.FullName);
			consoleTable.OutCell(patient.disease?.Name);
			consoleTable.OutCell(patient.IsSick == null ? "---" : patient.IsSick.Value ? "Так" : "Ні");
			consoleTable.OutCell(patient.Comment);
			consoleTable.OutEndRow();
		}
	}
}
