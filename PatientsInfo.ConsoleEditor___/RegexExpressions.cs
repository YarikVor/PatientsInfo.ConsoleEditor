using System.Text.RegularExpressions;

namespace PatientsInfo.ConsoleEditor {
	
	public static class RegexExpressions {
		public static Regex
			RCodeICD      = new Regex(@"^[A-Z][0-9]{2}(.[0-9])?$"),
			RFullName     = new Regex(@"^([А-ЯІЇҐЄ][а-яіїґє']+\s?){3}$"),
			RPhoneNumber  = new Regex(@"^\+380[0-9]{9}| $"),
			RTypeBlood    = new Regex(@"^([I]{1,3}[+-])|(IV[+-])$");
	}
}
