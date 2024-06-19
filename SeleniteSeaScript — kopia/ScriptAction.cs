using SeleniteSeaScript.Scopes;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript
{
	public abstract class ScriptAction
	{
		public abstract ImmutableDictionary<string,ScriptActionParam> GetActionParams();
		public IScope? Scope { get; set; }

		public ScriptAction(IScope? scope)
		{
			Scope = scope;
		}
		public abstract bool Execute(out Exception? exception);
	}

	/// <summary>
	/// Used primarily for IDEs
	/// </summary>
	public record ScriptActionParam(VariableType ParamType, object? Value, bool Required, string Description);

}
