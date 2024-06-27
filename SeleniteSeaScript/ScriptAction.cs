using SeleniteSeaScript.Interfaces;
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
        public IScope? Scope { get; set; }

		public ScriptAction(IScope? scope)
		{
			Scope = scope;
		}
		public abstract bool Execute(out Exception? exception);
	}
}
