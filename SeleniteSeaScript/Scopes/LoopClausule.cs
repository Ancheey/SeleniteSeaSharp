using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
    internal class LoopClausule : BasicScope
    {
        BooleanVariable DoWhile { get; set; }
        private bool _isLoopBroken = false;
        public LoopClausule(BooleanVariable booleanStatement,IScope? Parent, Dictionary<string, Variable> derivedVariables) : base(Parent, derivedVariables)
        {
            DoWhile = booleanStatement;
        }
        public void Break() => _isLoopBroken = true;
        public new bool ExecuteScope(out Exception? exception)
        {
            exception = null;
            while (DoWhile.Value == false && !_isLoopBroken)
            {
                foreach (var scope in GetScopeActions()) {
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
