using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
    public class ProjectScope<T> : ScriptAction, IHasValue<T>, IHasParams, IHasVariables, IScope where T : Variable
    {
		private readonly string _name;
		public VariableType? ReturnType { get; private set; }
		public Variable? DefaultReturnValue { get; private set; } = null;
		public Variable? ReturnValue { get; private set; } = null;
        Dictionary<string, Variable> IHasVariables.Variables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<ScriptAction> IScope.ScopeActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        T IHasValue<T>.Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProjectScope(string projectTitle) : base(null)
        {
            _name = projectTitle;
        }

        public override bool Execute(out Exception? exception)
        {
            throw new NotImplementedException();
        }

        public ImmutableDictionary<string, IHasParams.ParamDescriptor> GetParams()
        {
            throw new NotImplementedException(); //Add some way to read required params from the file and addition of em 
        }
    }
}
