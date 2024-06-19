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

		public new string Value
		{
			get => (string?)base.Value??"";
			set => base.Value = value;
		}
		public IEnumerable<string> GetRequiredValuesForParsing()
		{
			List<string> values = new();
			//Redo
			return values.AsEnumerable();
		}
	}
}
