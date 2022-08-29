namespace PatientsInfo.Entities {
	public static class Enum {
		public static string[] HealthStatusNameUA = {
			"Відмінний",
			"Добрий",
			"Задовільний",
			"Середній",
			"Важкий",
			"Вкрай важкий"
		};

		public static string[] GenderNameUA = {
			"Чоловік",
			"Жінка"
		};

		public static string[] GenderShortNameUA = {
			"Ч",
			"Ж"
		};

		/// <summary>
		/// Стать
		/// </summary>
		public enum Gender : byte{
			Male,  // Чоловік
			Female // Жінка
		};

		/// <summary>
		/// Життєві показники
		/// </summary>
		public enum HealthStatus : byte {
			/// <summary> Відмінний </summary>
			Excellent,
			/// <summary> Добрий </summary>
			Good,
			/// <summary> Задовільний </summary>
			Satisfactory,
			/// <summary> Середньої важкості </summary>
			Moderate,     // Середньої важкості
			/// <summary> Важкий </summary>
			Severe,
			/// <summary> Вкрай важкий </summary>
			Extremely     
		};

		

		public static string ToStringUA(this HealthStatus healthStatus) {
			if (healthStatus >= 0 && (int)healthStatus < HealthStatusNameUA.Length) return HealthStatusNameUA[(int)healthStatus];
			return "---";
		}

		public static string ToStringUA(this Gender gender) {
			if (gender >= 0 && (int)gender < GenderShortNameUA.Length) return GenderShortNameUA[(int)gender];
			return "---";
		}
	}
}
