using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Exceptions
{
    public abstract class SeleniteSeaException : Exception
    {
        public readonly List<int> ScopePositionMarkers = new();
        public readonly IScriptAction ThrowingAction;
        public SeleniteSeaException(string message, IScriptAction throwing) : base(message) { ThrowingAction = throwing; }
        public override string Message => $"at {string.Join(":", ScopePositionMarkers.Reverse<int>())}  {base.Message}";
    }
}
