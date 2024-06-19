using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public class BooleanVariable : Variable
	{
		public BooleanVariable(object? value) : base(VariableType.Boolean, value)
		{}
		public new bool Value
		{
			get => (bool?)base.Value ?? false;
			set => base.Value = value;
		}
	}
}
