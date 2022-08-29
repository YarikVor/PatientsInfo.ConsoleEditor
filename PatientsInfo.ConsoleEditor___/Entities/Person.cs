using System;

namespace PatientsInfo.ConsoleEditor.Entities {
	public class Person {
		static ulong PersonalNumberCount = 1;

		public ulong PersonalNumber { get; private set; }

		public string FullName;

		public DateTime
			DiseaseOnsetDate,
			DateBirth;

		public Enum.Gender Gender;

		public string
			PhoneNumber,
			ResidenceAddress,
			TypeBlood,
			Comment;

		public Enum.HealthStatus HealthStatus;

		public Person() {
			PersonalNumber = PersonalNumberCount++;
		}

		public Person(string fullName, DateTime diseaseOnsetDate, DateTime dateBirth, Enum.Gender gender, Enum.HealthStatus healthStatus, string typeBlood, string comment = "", string phoneNumber = "", string residenceAddress = "") {
			PersonalNumber = PersonalNumberCount++;
			FullName = fullName;
			DiseaseOnsetDate = diseaseOnsetDate;
			DateBirth = dateBirth;
			Gender = gender;
			PhoneNumber = phoneNumber;
			ResidenceAddress = residenceAddress;
			HealthStatus = healthStatus;
			TypeBlood = typeBlood;
			Comment = comment;
		}

		public Person(string fullName, DateTime diseaseOnsetDate, DateTime dateBirth, Enum.Gender gender, string phoneNumber, string residenceAddress, Enum.HealthStatus healthStatus, string typeBlood, string comment) {
			PersonalNumber = PersonalNumberCount++;
			FullName = fullName;
			DiseaseOnsetDate = diseaseOnsetDate;
			DateBirth = dateBirth;
			Gender = gender;
			PhoneNumber = phoneNumber;
			ResidenceAddress = residenceAddress;
			HealthStatus = healthStatus;
			TypeBlood = typeBlood;
			Comment = comment;
		}

		public override string ToString() {
			return string.Format("{0, 5} {1,-30} {2,10:d}  {3,10:d} {4,-6} {5,5} {6,-13} {7, 14} {8, -40} {9}", PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender.ToStringUA(), TypeBlood, HealthStatus.ToStringUA(), PhoneNumber, ResidenceAddress, Comment);
		}

		public string ToShortString() {
			return string.Format("{0, 5} {1, 30} {2,10:d}  {3:10:d} {4,6} {5,5} {6,10}", PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender.ToStringUA(), TypeBlood, HealthStatus.ToStringUA());
		}
	}
}
