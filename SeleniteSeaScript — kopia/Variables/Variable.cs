using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public abstract class Variable
	{
		public VariableType? Type { get; private set; }
		public object? Value { get; protected set; }
		public Variable(VariableType? type, object? value)
		{
			Type = type;
			Value = value;
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
