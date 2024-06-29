using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;

namespace SeleniteSeaScript.Scopes
{
    internal class LoopClausule : BasicScope, IHasParams
    {
        public Params Params { get; set; }
        private bool _isLoopBroken = false;
        public bool DoWhile => ((BooleanVariable)Params["BooleanStatement"]).Value;
        public LoopClausule(IScope? Parent = null, Interfaces.Variables? derived = null) : base(Parent, derived)
        {
            Params = new Params(Variables, new()
            {
                {"BooleanStatement",new(VariableType.Boolean,new BooleanVariable(true),"Loop as long as this Variable is TRUE") }
            });
        }
        public void Break() => _isLoopBroken = true;
        public new bool Execute(out Exception? exception)
        {
            exception = null;
            while (DoWhile == false && !_isLoopBroken)
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
