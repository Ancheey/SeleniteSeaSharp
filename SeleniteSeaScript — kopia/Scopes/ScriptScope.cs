using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
	public class ScriptScope : BasicScope
	{
		private readonly string _name;
		public VariableType? ReturnType { get; private set; }
		public Variable? DefaultReturnValue { get; private set; } = null;
		public Variable? ReturnValue { get; private set; } = null;
		public Dictionary<string, ScriptActionParam> ScriptParams = new();
		public ScriptScope(string projectTitle, Dictionary<string, ScriptActionParam> requiredParams) : base(null, new())
		{
			_name = projectTitle;
			ScriptParams = requiredParams;
		}
		public bool AddParamValue(string name, Variable variable)
		{
			if (!ScriptParams.ContainsKey(name))
				return false; //Not on ScriptParams list
			if (ScriptParams[name].ParamType != variable.Type)
				return false; //Not a valid type
			if (derivedVariables.ContainsKey(name))
				return false; //Already in the collection
			derivedVariables.Add(name, variable);
			return true;
		}
		public new string GetScopeTitle() => _name;
	}
}
