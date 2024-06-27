using SeleniteSeaScript.Exceptions;
using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;

namespace SeleniteSeaScript.Scopes
{
    internal class ElseClausule : BasicScope
	{
		public ElseClausule(IScope? Parent, Dictionary<string, Variable> derivedVariables) : base(Parent, derivedVariables)
		{}
		public new bool ExecuteScope(out Exception? exception)
		{
			var ScopeActions = Scope?.GetScopeActions();
			if (ScopeActions is null) {
				exception = new SeleniteSeaException("Else found itself without a scope! Impossible!",this);
				return false;
			}
			int ScopeActionIDOfThis = ScopeActions.IndexOf(this);
			if (ScopeActionIDOfThis == 0)
			{
				exception = new SeleniteSeaException("Else at the begining of a scope", this);
				return false;
			}
			if (ScopeActions[ScopeActionIDOfThis - 1] is IfClausule IFC)
			{
				if (IFC.expectedOutput != IFC.evaluatedOutput) //Execute scope if the previous If or elseIF didn't execute
					return base.ExecuteScope(out exception);
				else
				{
					exception = null;
					return true; //Job's done!
				}
			}
			else
			{
				exception = new SeleniteSeaException("Else clausule not directly after an if or else if clausule", this);
				return false;
			}
		}
	}
}
