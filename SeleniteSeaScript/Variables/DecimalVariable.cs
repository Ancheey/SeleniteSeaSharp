using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	internal class DecimalVariable : NumericVariable
	{
		public DecimalVariable(decimal? value) : base(value)
		{}
		public static DecimalVariable operator +(DecimalVariable l, NumericVariable r)
		{
			return new DecimalVariable(l.Value + r.Value);
		}
		public static DecimalVariable operator -(DecimalVariable l, NumericVariable r)
		{
			return new DecimalVariable(l.Value - r.Value);
		}
		public static DecimalVariable operator *(DecimalVariable l, NumericVariable r)
		{
			return new DecimalVariable(l.Value * r.Value);
		}
		public static DecimalVariable operator /(DecimalVariable l, NumericVariable r)
		{
			return new DecimalVariable(l.Value / r.Value);
		}
		public static BooleanVariable operator <(DecimalVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value < r.Value);
		}
		public static BooleanVariable operator >(DecimalVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value > r.Value);
		}
		public static BooleanVariable operator <=(DecimalVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value <= r.Value);
		}
		public static BooleanVariable operator >=(DecimalVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value >= r.Value);
		}
		public static BooleanVariable operator ==(DecimalVariable l, NumericVariable r)
		{
			return new BooleanVariable(l.Value == r.Value);
		}
		public static BooleanVariable operator !=(DecimalVariable l, NumericVariable r)
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
