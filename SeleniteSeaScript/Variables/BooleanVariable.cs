

namespace SeleniteSeaScript.Variables
{
	public class BooleanVariable : Variable
	{
		public BooleanVariable(bool? value) : base(VariableType.Boolean, value)
		{}
		public new bool Value
		{
			get => (bool?)base.Value ?? false;
			set => base.Value = value;
		}
		public static BooleanVariable operator ==(BooleanVariable l, BooleanVariable r) => new(l.Value == r.Value);
		public static BooleanVariable operator !=(BooleanVariable l, BooleanVariable r) => new(l.Value != r.Value);
		public static BooleanVariable operator ==(BooleanVariable l, NumericVariable r) => new(l.Value == (r.Value != 0)); //Equality if value is equal to whether int is not 0
		public static BooleanVariable operator !=(BooleanVariable l, NumericVariable r) => new(l.Value != (r.Value != 0)); //Equality if value is equal to whether int is not 0
		public static BooleanVariable operator !(BooleanVariable l) => new(!l.Value);

		public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);
		public override int GetHashCode() => Value.GetHashCode();
	}
	public enum BooleanComparers
	{
		Equal,
		NotEqual
	}
}
