namespace SeleniteSeaScript.Variables
{
	internal class StringVariable : Variable
	{
		public StringVariable(string? value) : base(VariableType.String, value) { }

		public new string Value
		{
			get => (string?)base.Value??"";
			set => base.Value = value;
		}
		public int Length => Value.Length;
		public char[] ToArray => Value.ToCharArray();

		public static StringVariable operator +(StringVariable a, Variable b) => new(a.Value + b.Value?.ToString());
		public static StringVariable operator *(StringVariable a, IntegerVariable b) 
		{
			string os = "";
			for(int i = 0; i < b.Value; i++)
				os += a.Value.ToString();
			return new(os);
		}
		public static BooleanVariable operator ==(StringVariable a, StringVariable b) => new(a.Value == b.Value);
		public static BooleanVariable operator !=(StringVariable a, StringVariable b) => new(a.Value != b.Value);

		public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);

		public override int GetHashCode() => Value.GetHashCode();
	}
}
