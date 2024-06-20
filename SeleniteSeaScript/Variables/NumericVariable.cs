using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public abstract class NumericVariable : Variable
	{
		public NumericVariable(decimal? value) : base(VariableType.Integer, value)
		{
		}
		public new decimal Value
		{
			get => (decimal?)base.Value ?? 0;
			set => base.Value = value;
		}
		public enum Comparers
		{
			EQUAL,
			NOT_EQUAL,
			LESS_THAN,
			GREATER_THAN,
			GREATER_THAN_OR_EQUAL,
			LESS_THAN_OR_EQUAL,
		}

		public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
	}
}
