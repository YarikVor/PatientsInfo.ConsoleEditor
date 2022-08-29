using System;
using System.Collections.Generic;
using System.Text;

namespace Methods {
	public class Date {
		/// <summary>
		/// Отримати вік по заданому даті народження
		/// </summary>
		/// <param name="birthDate"></param>
		/// <returns></returns>
		public static int GetAge(DateTime birthDate) {
			var now = DateTime.Today;
			return now.Year - birthDate.Year -
					((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 0 : 1);
		}
	}
}
