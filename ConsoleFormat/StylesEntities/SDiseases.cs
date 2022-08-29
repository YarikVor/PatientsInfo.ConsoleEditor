using System.Collections.Generic;
using System.Linq;
using PatientsInfo.Entities;
using System;
namespace ConsoleFormat.StylesEntities {
	public class SDiseases : IStyleEntity{
		public ConsoleTable consoleTable {get; set;}
		public IEnumerable<Disease> diseases;
		public SDiseases(IEnumerable<Disease> diseases) {
			consoleTable =
				new ConsoleTable("Хвороби",
					new ConsoleStyle[]{
					new ConsoleStyle("Назва хвороби", 15),
					new ConsoleStyle("Код", 6),
					new ConsoleStyle("Коментар", 80, false)
			});

			this.diseases = diseases;
		}

		public void OutTable(bool shortOn = false, bool onlyRequired = false) {
			if (diseases != null) {
				consoleTable.onlyRequired = onlyRequired;

				consoleTable.countData = diseases.Count();

				var tmpDiseases = shortOn ?
					diseases.Skip(consoleTable.pos).Take(consoleTable.countView).ToArray() :
					diseases.ToArray();

				consoleTable.ShowFillLine(CTSymbol.ul, CTSymbol.hl, CTSymbol.ur);
				consoleTable.ShowTitle();
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.uc, CTSymbol.mr);

				consoleTable.ShowSubTitle(CTSymbol.vl, CTSymbol.vl, CTSymbol.vl);
				consoleTable.ShowFillLine(CTSymbol.ml, CTSymbol.mc, CTSymbol.mr);

				for (int i = 0; i < tmpDiseases.Length; i++) {
					this.OutRow((Disease)tmpDiseases[i]);
				}

				consoleTable.ShowFillLine(CTSymbol.bl, CTSymbol.bc, CTSymbol.br);
			}
		}

		public void OutRow(Disease disease) {
			consoleTable.OutCell(disease.Name);
			consoleTable.OutCell(disease.CodeICD);
			consoleTable.OutCell(disease.Description);
			consoleTable.OutEndRow();
		}
	}
}
