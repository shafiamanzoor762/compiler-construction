using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_project1
{
	public class ScopeSymbolTable
	{ 
		public string Scope { get; set; }
		public List<SymbolTable> SymbolTable { get; set; }
	}
}
