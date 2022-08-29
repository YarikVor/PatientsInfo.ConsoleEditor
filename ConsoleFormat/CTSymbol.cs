using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleFormat {
	static class CTSymbol {
		/*
	* l - left
	* c - center
	* r - rigth
	* 
	* u - up
	* m - middle
	* b - bottom
	* 
	 l c r
	u┌ ┬ ┐
	m├ ┼ ┤
	b└ ┴ ┘
	╎ - vl
	╌ - hl
*/
		public const char
			ul = '┌',	uc = '┬',	ur = '┐',
			ml = '├',	mc = '┼', mr = '┤',
			bl = '└',	bc = '┴', br = '┘',
			vl = '╎', hl = '╌';
	}
}
