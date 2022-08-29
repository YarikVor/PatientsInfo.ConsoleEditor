using System.Collections.Generic;

namespace Methods {
	public static class Enumerable {
		/// <summary>
		/// Перевести IEnumerable в рядкову таблицю
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ts"></param>
		/// <param name="title"></param>
		/// <returns></returns>
		public static string ToLineList<T>(this IEnumerable<T> ts, string title) {
			return string.Concat(title, ":\n", string.Join("\n", ts), '\n');
		}


	}
}
