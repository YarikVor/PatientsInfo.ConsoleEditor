namespace PatientsInfo.ConsoleEditor.Entities {
	public class Disease {
		public string Name;
		public string CodeICD;
		public string Description;
		//public string link;

		public Disease() { }
		public Disease(string name, string codeICD, string description) {
			Name = name;
			CodeICD = codeICD;
			Description = description;
		}

		public override string ToString() {
			return string.Format("{0, 15} {1,6}\t{2}\n", Name, CodeICD, Description);
		}
	}
}
