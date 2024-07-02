using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public class NumericVariable : Variable
	{
		public NumericVariable(double? value) : base(VariableType.Number, value)
		{
		}
		public new double Value
		{
			get => (double?)base.Value ?? 0;
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

		public static NumericVariable operator +(NumericVariable l, NumericVariable r)
		{
			return new NumericVariable(l.Value + r.Value);
		}
		public static NumericVariable operator -(NumericVariable l, NumericVariable r)
		{
			return new NumericVariable(l.Value - r.Value);
		}
		public static NumericVariable operator *(NumericVariable l, NumericVariable r)
		{
			return new NumericVariable(l.Value * r.Value);
		}
		public static NumericVariable operator /(NumericVariable l, NumericVariable r)
		{
			return new NumericVariable(l.Value / r.Value);
		}
		public static BooleanVariable operator <(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value < r.Value);
		}
		public static BooleanVariable operator >(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value > r.Value);
		}
		public static BooleanVariable operator <=(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value <= r.Value);
		}
		public static BooleanVariable operator >=(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value >= r.Value);
		}
		public static BooleanVariable operator ==(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value == r.Value);
		}
		public static BooleanVariable operator !=(NumericVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value != r.Value);
		}

		public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);

		public override int GetHashCode() => Value.GetHashCode();
	}
}
