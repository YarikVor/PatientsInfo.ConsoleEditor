namespace PatientsInfo.ConsoleEditor.Entities {
	public class Patient {
		public static ulong KeyCount = 1;

		public ulong Key { get; private set; }
		public Entities.Person Person;
		public Disease disease;
		public bool? IsSick;
		public string Comment;

		public Patient() {
			Key = KeyCount++;
		}
		public Patient(Entities.Person person, Disease disease) : this(person, disease, null, "") { }

		public Patient(Entities.Person person, Disease disease, bool? isSick) : this(person, disease, isSick, null) { }

		public Patient(Entities.Person person, Disease disease, string comment) : this(person, disease, null, comment) { }

		public Patient(Entities.Person person, Disease disease, bool? isSick, string comment) {
			Key = KeyCount++;
			Person = person;
			this.disease = disease;
			IsSick = isSick;
			Comment = comment;
		}

		public override string ToString() {
			return string.Format("{0,7} {1,-20} {2,7} {3}", Person?.PersonalNumber, disease?.Name, (IsSick == null) ? "---" : (IsSick == true) ? "Так" : "Ні", Comment);
		}

	}
}
