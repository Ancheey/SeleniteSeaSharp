using SeleniteSeaScript.Variables;
using System.Collections.Immutable;

namespace SeleniteSeaScript.Scopes
{
	public class BasicScope : ScriptAction, IScope
	{

		public string GetScopeTitle() => "Basic Scope";
		protected readonly Dictionary<string, Variable> derivedVariables;
		protected readonly Dictionary<string, Variable> localVariables = new();
		protected List<ScriptAction> scriptActions = new();
		public BasicScope(IScope? Parent, Dictionary<string, Variable> derivedVariables) : base(Parent)
		{
			this.derivedVariables = derivedVariables;
		}
		/// <summary>
		/// Scopes are actions too! (Just calls ExecuteScope)
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
		/// <summary>
		/// Execute all the actions within the scope
		/// </summary>
		/// <param name="exception">Exception that might have been encountered during execution. Only available if returned value is false</param>
		/// <returns>true if the Scope executed succesfully</returns>
		public bool ExecuteScope(out Exception? exception)
		{
			foreach (var scope in GetScopeActions())
				if (!scope.Execute(out exception))
					return false;

			//Correct Execution of all Actions whthin the scope
			exception = null;
			return true;
		}

		public ImmutableDictionary<string, Variable> GetDerivedVariables() => derivedVariables.ToImmutableDictionary();
		public List<ScriptAction> GetScopeActions() => scriptActions;
		public ImmutableDictionary<string, Variable> GetScopeVariables() => localVariables.ToImmutableDictionary();
		public bool RemoveScopeVariable(string variableName)
			=> variableName is not null && localVariables.Remove(variableName);
		public bool AddScopeAction(ScriptAction action) {
			try
			{
				action.Scope = this;
				scriptActions.Add(action);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool RemoveScopeAction(ScriptAction action) 
		{
			if (scriptActions.Remove(action))
			{
				action.Scope = null;
				return true;
			}
			return false;
		}
		public bool RemoveScopeAction(int actionid)
		{
			try
			{
				var action = scriptActions[actionid];
				if (scriptActions.Remove(action))
				{
					action.Scope = null;
					return true;
				}
				return false;
			}
			catch 
			{
				return false;
			}
		}

		//This one doesn't need anything so return empty
		public override ImmutableDictionary<string, ScriptActionParam> GetActionParams() 
			=> new Dictionary<string, ScriptActionParam>().ToImmutableDictionary();
	}
}
