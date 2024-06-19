using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	internal class StringVariable : Variable
	{
		public StringVariable(object? value) : base(VariableType.String, value) { }

		public string Value
		{
			get => (string?)value??"";
			set => this.value = value;
		}
		public IEnumerable<string> GetRequiredValuesForParsing()
		{
			List<string> values = new List<string>();
			//Redo
			return values.AsEnumerable();
		}
	}
}
