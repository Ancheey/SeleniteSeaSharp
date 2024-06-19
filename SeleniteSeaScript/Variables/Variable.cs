using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public class Variable
	{
		protected VariableType? type;
		protected object? value;
		public Variable(VariableType? type, object? value)
		{
			this.type = type;
			this.value = value;
		}
	}
	public enum VariableType
	{
		Object,
		String,
		Integer,
		Decimal,
		Boolean,
		Array
	}
}
