using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System.Collections.Immutable;

namespace SeleniteSeaScript.Scopes
{
    public class BasicScope : ScriptAction, IScope, IHasVariables
	{
        public Scope Scope { get; init; } = new Scope();
		public Interfaces.Variables Variables { get; init; }
		public BasicScope(IScope? Parent = null, Interfaces.Variables ? derived = null) : base(Parent) { Variables = new(derived); }
        public override bool Execute(out Exception? exception)
        {
			foreach (var scope in Scope.GetActions())
				if (!scope.Execute(out exception))
					return false;

			//Correct Execution of all Actions whthin the scope
			exception = null;
			return true;
		}
    }
}
