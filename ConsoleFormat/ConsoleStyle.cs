using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleFormat {
	public class ConsoleStyle {
		public string title;
		public int width;
		public bool isRequired;

		public ConsoleStyle(string title, int width) : this(title, width, true){}
		public ConsoleStyle(string title, int width, bool isMandatory) {
			this.title = title;
			this.width = width;
			this.isRequired = isMandatory;
		}
	}
}
