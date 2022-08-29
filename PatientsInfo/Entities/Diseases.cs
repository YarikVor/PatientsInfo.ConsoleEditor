using System;

namespace PatientsInfo.Entities {
	/// <summary>
	/// Сутність хвороби
	/// </summary>
	[Serializable]
	public class Disease {
		/// <summary>
		/// Назва хвороби
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Код ICD
		/// </summary>
		public string CodeICD { get; set; }
		/// <summary>
		/// Опис
		/// </summary>
		public string Description { get; set; }

		public Disease() { }
		public Disease(string name, string codeICD, string description) {
			Name = name;
			CodeICD = codeICD;
			Description = description;
		}

		public override string ToString() {
			return string.Format("{0,-20} {1,-6}\n{2}\n", Name, CodeICD, Description);
		}
		public string ToShortString() {
			return string.Format("{0,-20} {1,-6}", Name, CodeICD);
		}
	}
}
