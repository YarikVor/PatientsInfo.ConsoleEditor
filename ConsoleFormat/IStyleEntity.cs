using System;
using System.Collections.Generic;
using System.Text;

using PatientsInfo.Entities;

namespace ConsoleFormat {
	public interface IStyleEntity {
		ConsoleTable consoleTable { get; set; }

		void OutTable(bool shortOn = false, bool onlyRequired = false);
	}
}
