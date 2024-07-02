using SeleniteSeaScript.Exceptions;
using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Scopes;

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
            var parent = Parent;
            while(parent is not LoopClausule)
            {
                if (parent is null || parent is not ScriptAction)
                {
                    exception = new SeleniteSeaException("Break couldn't locate a loop", this);
                    return false;
                }
                else
                    parent = (Parent as ScriptAction)?.Parent;
            }
            (parent as LoopClausule)?.Break();
            return true;
        }
    }
}
