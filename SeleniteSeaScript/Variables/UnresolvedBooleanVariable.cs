using SeleniteSeaScript.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Variables
{
	public abstract class UnresolvedBooleanVariable : BooleanVariable
	{
		//This is going to be a builder class
		protected UnresolvedBooleanVariable() : base(null){}
		public static UnresolvedBooleanVariable Create(NumericVariable A, NumericVariable.Comparers comparer, NumericVariable B) 
			=> new UnresolvedNumbersBooleanVariable(A, comparer, B);
		public static UnresolvedBooleanVariable Create(StringVariable A, BooleanComparers comparer, StringVariable B)
			=> new UnresolvedStringBooleanVariable(A, comparer, B);
		public static UnresolvedBooleanVariable Create(Func<bool> A, BooleanComparers comparer, Func<bool> B)
			=> new UnresolvedActionBoolBooleanVariable(A, comparer, B);
		public static UnresolvedBooleanVariable Create(Func<BooleanVariable> A, BooleanComparers comparer, Func<BooleanVariable> B)
			=> new UnresolvedActionVarBooleanVariable(A, comparer, B);
		protected class UnresolvedNumbersBooleanVariable : UnresolvedBooleanVariable
		{
			private readonly NumericVariable A;
			private readonly NumericVariable B;
			private readonly NumericVariable.Comparers Comparer;

			public UnresolvedNumbersBooleanVariable(NumericVariable a, NumericVariable.Comparers comparer, NumericVariable b) : base()
			{
				A = a;
				B = b;
				Comparer = comparer;
			}
			public new bool Value
			{
				get => Comparer switch
				{
					NumericVariable.Comparers.EQUAL					=> (A == B).Value,
					NumericVariable.Comparers.NOT_EQUAL				=> (A != B).Value,
					NumericVariable.Comparers.GREATER_THAN			=> (A > B).Value,
					NumericVariable.Comparers.GREATER_THAN_OR_EQUAL => (A >= B).Value,
					NumericVariable.Comparers.LESS_THAN				=> (A < B).Value,
					NumericVariable.Comparers.LESS_THAN_OR_EQUAL	=> (A <= B).Value,
					_ => throw new InvalidOperationException($"Comparer not found when comparing variables with values of {A.Value} and {B.Value}")
				};
				set { base.Value = value; } //in case somebody tries to use this bool var as a basic bool var and not and unresolved one
			}
		}
		protected class UnresolvedStringBooleanVariable : UnresolvedBooleanVariable
		{
			private readonly StringVariable A;
			private readonly StringVariable B;
			private readonly BooleanComparers Comparer;

			public UnresolvedStringBooleanVariable(StringVariable a, BooleanComparers comparer, StringVariable b) : base()
			{
				A = a;
				B = b;
				Comparer = comparer;
			}
			public new bool Value
			{
				get => Comparer switch
				{
					BooleanComparers.Equal => (A == B).Value,
					BooleanComparers.NotEqual => (A != B).Value,
					_ => throw new InvalidOperationException($"Comparer not found when comparing variables with values of {A.Value} and {B.Value}")
				};
				set { base.Value = value; } //in case somebody tries to use this bool var as a basic bool var and not and unresolved one
			}
		}
		protected class UnresolvedActionBoolBooleanVariable : UnresolvedBooleanVariable
		{
			private readonly Func<bool> A;
			private readonly Func<bool> B;
			private readonly BooleanComparers Comparer;

			public UnresolvedActionBoolBooleanVariable(Func<bool> a, BooleanComparers comparer, Func<bool> b) : base()
			{
				A = a;
				B = b;
				Comparer = comparer;
			}
			public new bool Value
			{
				get => Comparer switch
				{
					BooleanComparers.Equal => A.Invoke() == B.Invoke(),
					BooleanComparers.NotEqual => A.Invoke() != B.Invoke(),
					_ => throw new InvalidOperationException($"Comparer not found when comparing variables with values of two functions")
				};
				set { base.Value = value; } //in case somebody tries to use this bool var as a basic bool var and not and unresolved one
			}
		}
		protected class UnresolvedActionVarBooleanVariable : UnresolvedBooleanVariable
		{
			private readonly Func<BooleanVariable> A;
			private readonly Func<BooleanVariable> B;
			private readonly BooleanComparers Comparer;

			public UnresolvedActionVarBooleanVariable(Func<BooleanVariable> a, BooleanComparers comparer, Func<BooleanVariable> b) : base()
			{
				A = a;
				B = b;
				Comparer = comparer;
			}
			public new bool Value
			{
				get => Comparer switch
				{
					BooleanComparers.Equal => (A.Invoke() == B.Invoke()).Value,
					BooleanComparers.NotEqual => (A.Invoke() != B.Invoke()).Value,
					_ => throw new InvalidOperationException($"Comparer not found when comparing variables with values of two functions")
				};
				set { base.Value = value; } //in case somebody tries to use this bool var as a basic bool var and not and unresolved one
			}
		}
	}
	
}
