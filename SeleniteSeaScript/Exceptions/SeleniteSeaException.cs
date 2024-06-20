
namespace SeleniteSeaScript.Exceptions
{
    public class SeleniteSeaException : Exception
    {
        public readonly List<int> ScopePositionMarkers = new();
        public readonly ScriptAction ThrowingAction;
        public SeleniteSeaException(string message, ScriptAction throwing) : base(message) { ThrowingAction = throwing; }
        public override string Message => $"at {string.Join(":", ScopePositionMarkers.Reverse<int>())}  {base.Message}";
    }
}
