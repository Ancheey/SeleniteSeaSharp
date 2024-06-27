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
		public bool expectedOutput { get;protected set; }
		public bool? evaluatedOutput { get; protected set; } = null;
		public IfClausule(BooleanVariable booleanStatement,bool expectedOutput, IScope? Parent, Dictionary<string, Variable> derivedVariables) : base(Parent, derivedVariables)
		{
			booleanVariable = booleanStatement;
			this.expectedOutput = expectedOutput;
		}
		public new bool ExecuteScope(out Exception? exception)
		{
			if((evaluatedOutput = booleanVariable.Value) == expectedOutput)
				return base.ExecuteScope(out exception);
			else
			{
				exception = null;
				return true; //Job's done!
			}
		}
	}
}
