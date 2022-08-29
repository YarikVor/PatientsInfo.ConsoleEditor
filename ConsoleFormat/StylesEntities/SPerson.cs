using System.Collections.Generic;
using System.Linq;
using PatientsInfo.Entities;

namespace ConsoleFormat.StylesEntities {
	public class SPerson : IStyleEntity {
		public ConsoleTable consoleTable { get; set; }

		public IEnumerable<Person> people;

		public SPerson(IEnumerable<Person> people) {
			consoleTable =
				new ConsoleTable("Особи",
					new ConsoleStyle[]{
					new ConsoleStyle("№", 5),
					new ConsoleStyle("ПІБ", 30),
					new ConsoleStyle("Дата звернення", 10),
					new ConsoleStyle("Дата народ", 10),
					new ConsoleStyle("Стать", 6),
					new ConsoleStyle("Стан здоров'я", 14),
					new ConsoleStyle("Номер телефона", 13, false),
					new ConsoleStyle("Місцепроживання", 20, false),
					new ConsoleStyle("Коментар", 50, false)
			});

			this.people = people;
		}

		public void OutTable(bool shortOn = false, bool onlyRequired = false) {
			if (people != null) {
				consoleTable.onlyRequired = onlyRequired;

				consoleTable.countData = people.Count();

				Person[] tmpPeople = shortOn ?
					people.Skip(consoleTable.pos).Take(consoleTable.countView).ToArray() :
					people.ToArray();

				consoleTable.ShowFillLine(CTSymbol.ul, CTSymbol.hl, CTSymbol.ur);
				consoleTable.ShowTitle();
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.uc, CTSymbol.mr);

				consoleTable.ShowSubTitle(CTSymbol.vl, CTSymbol.vl, CTSymbol.vl);
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.mc, CTSymbol.mr);

				for (int i = 0; i < tmpPeople.Length; i++) {
					this.OutRow(tmpPeople[i]);
				}

				consoleTable.ShowFillLine(CTSymbol.bl, CTSymbol.bc, CTSymbol.br);
			}
		}


		private void OutRow(Person person) {
			consoleTable.OutCell(person.Id);
			consoleTable.OutCell(person.FullName);
			consoleTable.OutCell(person.DateBirth);
			consoleTable.OutCell(person.DiseaseOnsetDate);
			consoleTable.OutCell(person.Gender);
			consoleTable.OutCell(person.HealthStatus);
			consoleTable.OutCell(person.PhoneNumber);
			consoleTable.OutCell(person.ResidenceAddress);
			consoleTable.OutCell(person.Comment);
			consoleTable.OutEndRow();
		}
	}
}
