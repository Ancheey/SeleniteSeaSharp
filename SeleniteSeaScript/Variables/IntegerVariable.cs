using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public class IntegerVariable : NumericVariable
	{
		public IntegerVariable(int? value) : base(value)
		{
		}
		public IntegerVariable(decimal? value) : base(value)
		{
		}
		public new int Value
		{
			get => (int?)base.Value ?? 0;
			set => base.Value = value;
		}
		public static IntegerVariable operator +(IntegerVariable l, NumericVariable r)
		{
			return new IntegerVariable(l.Value + r.Value);
		}
		public static IntegerVariable operator -(IntegerVariable l, NumericVariable r)
		{
			return new IntegerVariable(l.Value - r.Value);
		}
		public static IntegerVariable operator *(IntegerVariable l, NumericVariable r)
		{
			return new IntegerVariable(l.Value * r.Value);
		}
		public static IntegerVariable operator /(IntegerVariable l, NumericVariable r)
		{
			return new IntegerVariable(l.Value / r.Value);
		}
		public static BooleanVariable operator <(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value < r.Value);
		}
		public static BooleanVariable operator >(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value > r.Value);
		}
		public static BooleanVariable operator <=(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value <= r.Value);
		}
		public static BooleanVariable operator >=(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value >= r.Value);
		}
		public static BooleanVariable operator ==(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value == r.Value);
		}
		public static BooleanVariable operator !=(IntegerVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value != r.Value);
		}

		public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}
