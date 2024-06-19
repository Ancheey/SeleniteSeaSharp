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
	public interface IScope
	{
		public string GetScopeTitle();
		public bool ExecuteScope(out Exception? exception);
		public List<ScriptAction> GetScopeActions();
		public bool AddScopeVariable(string variableName, Variable variable, out Exception? exception);
		public bool RemoveScopeVariable(string variableName);
		/// <returns>An immutable collection of all variables derived from higher level scopes and globals into this scope</returns>
		public ImmutableDictionary<string,Variable> GetDerivedVariables();
		/// <returns>An immutable collection of variables this scope considers local. These variables may be managed via adding or removing</returns>
		public ImmutableDictionary<string, Variable> GetScopeVariables();
		public bool AddScopeAction(ScriptAction action);
		public bool RemoveScopeAction(ScriptAction action);
		public bool RemoveScopeAction(int actionid);
	}
}
