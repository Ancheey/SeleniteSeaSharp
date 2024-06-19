using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
	public abstract class ScriptScope : ScriptAction, IScope
	{
		
		public abstract string GetScopeTitle();
		private readonly Dictionary<string, Variable> derivedVariables;
		private readonly Dictionary<string, Variable> localVariables = new();
		protected List<ScriptAction> scriptActions = new();
		public ScriptScope(IScope? Parent, Dictionary<string, Variable> derivedVariables) : base(Parent)
		{
			this.derivedVariables = derivedVariables;
		}

		/// <summary>
		/// Scopes are actions too!
		/// </summary>
		/// <param name="exception">Exceptions that might or might not appear during the execution of said action</param>
		/// <returns>false if an exception was encountered during execution of the scope</returns>
		public override bool Execute(out Exception? exception) => ExecuteScope(out exception);
		public bool AddScopeVariable(string variableName, Variable variable, out Exception? exception)
		{
			exception = null;
			if (derivedVariables.ContainsKey(variableName) || localVariables.ContainsKey(variableName))
			{
				exception = new Exception($"Variable {variableName} already exists within this scope");
				return false;
			}
			return true;
		}

		public bool ExecuteScope(out Exception? exception)
		{
			foreach (var scope in GetScopeActions()) 
				if (!scope.Execute(out exception))
					return false;

			//Correct Execution of All 
			exception = null;
			return true;
		}

		public ImmutableDictionary<string, Variable> GetDerivedVariables() => derivedVariables.ToImmutableDictionary();
		public List<ScriptAction> GetScopeActions() => scriptActions;
		public ImmutableDictionary<string, Variable> GetScopeVariables() => localVariables.ToImmutableDictionary();
		public bool RemoveScopeVariable(string variableName) 
			=> variableName is not null && localVariables.Remove(variableName);
		public abstract bool AddScopeAction(ScriptAction action);
		public abstract bool RemoveScopeAction(ScriptAction action);
		public abstract bool RemoveScopeAction(int actionid);
	}
}
