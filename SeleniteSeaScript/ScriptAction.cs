using SeleniteSeaScript.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript
{
	public abstract class ScriptAction
	{
		public IScope? Scope { get; private set; }
		public ScriptAction(IScope? scope)
		{
			Scope = scope;
		}
		public abstract bool Execute(out Exception? exception);
	}
}
