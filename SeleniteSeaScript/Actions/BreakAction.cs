using SeleniteSeaScript.Exceptions;
using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Scopes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Actions
{
    public class BreakAction : ScriptAction
    {
        public BreakAction(IScope? scope) : base(scope)
        {
        }
        public override bool Execute(out Exception? exception)
        {
            exception = null;
            var parent = Scope;
            while(parent is not LoopClausule)
            {
                if (parent is null || parent is not ScriptAction)
                {
                    exception = new SeleniteSeaException("Break couldn't locate a loop", this);
                    return false;
                }
                else
                    parent = (Scope as ScriptAction)?.Scope;
            }
            (parent as LoopClausule)?.Break();
            return true;
        }
    }
}
