﻿using SeleniteSeaScript.Exceptions;
using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;

namespace SeleniteSeaScript.Scopes
{
    public class ElseIfClausule : IfClausule
	{
		//This one requires a parent
		//Add something to check if previous is an elfeif not evaluated
        public ElseIfClausule(IScope? Parent, Interfaces.Variables? derived = null) : base(Parent, derived)
        {}

        public new bool Execute(out Exception? exception)
		{
			var ScopeActions = Parent?.Scope.GetActions();
			if (ScopeActions is null)
			{
				exception = new SeleniteSeaException("Else found itself without a scope! Impossible!", this);
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
                Evaluated = ((BooleanVariable)Params["BooleanStatement"]).Value;

                if (IFC.Expected != IFC.Evaluated && Expected == Evaluated) //Execute scope if the previous If or elseIF didn't execute AND evaluation of this object is correct
					return base.Execute(out exception);
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
