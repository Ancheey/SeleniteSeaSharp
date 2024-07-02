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
    public class ProjectScope<T> : ScriptAction, IHasValue<T>, IHasVariables, IHasParams, IScope where T : Variable
    {
		private readonly string _name;
		public VariableType? ReturnType { get; private set; }
        public T? Value { get; set; } = null;
        public Interfaces.Variables Variables { get; init; } = new();
        public Scope Scope { get; init; } = new();
        public Params Params { get; set; }
        public ProjectScope(string projectTitle, Dictionary<string, ParamDescriptor> parameters) : base(null)
        {
            _name = projectTitle;
            Params = new Params(Variables, parameters);
        }
        public void ReadProjectData()
        {
            throw new NotImplementedException();
        }
        public override bool Execute(out Exception? exception)
        {
            foreach (var scope in Scope.GetActions())
                if (!scope.Execute(out exception))
                    return false;

            //Correct Execution of all Actions whthin the scope
            exception = null;
            return true;
        }
    }
}
