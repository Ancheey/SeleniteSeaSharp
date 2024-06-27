using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;

namespace SeleniteSeaScript.Scopes
{
    internal class LoopClausule : BasicScope
    {
        BooleanVariable DoWhile { get; set; }
        private bool _isLoopBroken = false;
        public LoopClausule(BooleanVariable booleanStatement, IScope? Parent = null, Interfaces.Variables? derived = null) : base(Parent, derived)
        {
            DoWhile = booleanStatement;
        }
        public void Break() => _isLoopBroken = true;
        public new bool Execute(out Exception? exception)
        {
            exception = null;
            while (DoWhile.Value == false && !_isLoopBroken)
            {
                foreach (var scope in Scope.GetActions()) {
                    if (_isLoopBroken)
                        return true;
                    if (!scope.Execute(out exception))
                        return false;
                }
            }
            return true;
        }
    }
}
