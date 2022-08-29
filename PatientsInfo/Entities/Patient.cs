using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
namespace PatientsInfo.Entities {
	/// <summary>
	/// Сутність пацієнта
	/// </summary>
	[Serializable]
	public class Patient : Entity  {

		public static ulong KeyCount = 1;

		/// <summary>
		/// Ключ
		/// </summary>
		public new ulong Id { get; private set; }
		
		/// <summary>
		/// Особа
		/// </summary>
				public Entities.Person Person { get; set; }
		/// <summary>
		/// Хвороба
		/// </summary>
		public Disease disease { get; set; }
		/// <summary>
		/// Чи хворіє
		/// </summary>
		/// 


	
		public bool? IsSick { get; set; }
		/// <summary>
		/// Коментарі
		/// </summary>
		public string Comment { get; set; }



public Patient() {
			Id = KeyCount++;
		}
		public Patient(Entities.Person person, Disease disease) : this(person, disease, null, "") { }

		public Patient(Entities.Person person, Disease disease, bool? isSick) : this(person, disease, isSick, "") { }

		public Patient(Entities.Person person, Disease disease, string comment) : this(person, disease, null, comment) { }

		public Patient(Entities.Person person, Disease disease, bool? isSick, string comment) {
			Id = KeyCount++;
			Person = person;
			this.disease = disease;
			IsSick = isSick;
			Comment = comment;
		}

		public override string ToString() {
			return string.Format("{0,4} {1,-30} {2,-20} {3,7} {4}", Id , Person?.FullName, disease?.Name, (IsSick == null) ? "---" : (IsSick == true) ? "Так" : "Ні", Comment);
		}
		public string ToShortString() {
			return string.Format("{0,4} {1,-20} {2,7} {3}", Id, disease?.Name, (IsSick == null) ? "---" : (IsSick == true) ? "Так" : "Ні", Comment);
		}

	}
}
