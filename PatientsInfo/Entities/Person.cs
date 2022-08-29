using System;
using System.Text.Json;
namespace PatientsInfo.Entities {
	/// <summary>
	/// Клас особи
	/// </summary>
	[Serializable]
	public class Person : Entity {
		/// <summary>
		/// Статичний персональний номер;
		/// </summary>
		static ulong PersonalNumberCount = 1;
		
		/// <summary>
		/// Незмінювальний персональний номер
		/// </summary>
		public new ulong Id { get; private set; }

		/// <summary>
		/// ПІБ
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Дата
		/// </summary>
		public DateTime DiseaseOnsetDate { get; set; }
		public DateTime DateBirth { get; set; }

	/// <summary>
	/// Стать
	/// </summary>
	public Enum.Gender Gender { get; set; }

		/// <summary>
		/// Номер телефона
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Місцепроживання
		/// </summary>
		public string ResidenceAddress { get; set; }

		/// <summary>
		/// Тип крові
		/// </summary>
		public string TypeBlood { get; set; }

		/// <summary>
		/// Коментар
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Стан здоров'я
		/// </summary>
		public Enum.HealthStatus HealthStatus { get; set; }


		public Person() {
			Id = PersonalNumberCount++;
		}

		public Person(
			string fullName,
			DateTime diseaseOnsetDate,
			DateTime dateBirth,
			Enum.Gender gender,
			Enum.HealthStatus healthStatus,
			string typeBlood,
			string comment = "",
			string phoneNumber = "",
			string residenceAddress = ""
		) : this(fullName, diseaseOnsetDate, dateBirth, gender, phoneNumber, residenceAddress, healthStatus, typeBlood, comment) { }

		public Person(
			string fullName,
			DateTime diseaseOnsetDate,
			DateTime dateBirth,
			Enum.Gender gender,
			string phoneNumber,
			string residenceAddress,
			Enum.HealthStatus healthStatus,
			string typeBlood,
			string comment
		) {
			Id = PersonalNumberCount++;
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
			return string.Format("{0, 5} {1,-30} {2,10:d} {3,10:d} {4} {5,-4} {6,-13} {7, 14} {8, -40} {9}", Id, FullName, DiseaseOnsetDate, DateBirth, Gender.ToStringUA(), TypeBlood, HealthStatus.ToStringUA(), PhoneNumber, ResidenceAddress, Comment);
		}

		public string ToShortString() {
			return string.Format("{0, 5} {1,-30} {2,10:d} {3,10:d} {4} {5,-4} {6}", Id, FullName, DiseaseOnsetDate, DateBirth, Gender.ToStringUA(), TypeBlood, HealthStatus.ToStringUA());
		}


	}
}
