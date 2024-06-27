using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
    public class IfClausule : BasicScope
	{
		protected readonly BooleanVariable booleanVariable;
		public bool ExpectedOutput { get;protected set; }
		public bool? EvaluatedOutput { get; protected set; } = null;
		public IfClausule(BooleanVariable booleanStatement, bool expectedOutput, IScope? Parent = null, Interfaces.Variables? derived = null) : base(Parent, derived)
		{
			booleanVariable = booleanStatement;
			ExpectedOutput = expectedOutput;
		}

        public new bool Execute(out Exception? exception)
		{
			if((EvaluatedOutput = booleanVariable.Value) == ExpectedOutput)
				return base.Execute(out exception);
			else
			{
				exception = null;
				return true; //Job's done!
			}
		}
	}
}
