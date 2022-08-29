using System.Collections.Generic;

namespace PatientsInfo.ConsoleEditor.Methods {
	public static class Enumerable {
		public static string ToLineList<T>(this IEnumerable<T> ts, string title) {
			return string.Concat(title, ":\n", string.Join("\n", ts), '\n');
		}
	}
}
