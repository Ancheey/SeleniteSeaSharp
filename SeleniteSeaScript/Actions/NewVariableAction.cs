using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Actions
{
    public class NewVariableAction : ScriptAction, IHasParams
    {
        public NewVariableAction(IScope? ParentScope) : base(ParentScope)
        {
            Variables = new();
            Params = new(Variables, new()
            {
                {"VariableName", new(SeleniteSeaScript.Variables.VariableType.String,new StringVariable("New Variable"),"Name of the variable")},
                {"VariableType", new(SeleniteSeaScript.Variables.VariableType.String,new StringVariable("String"),"Variable Type")},
            });
        }

        public Interfaces.Variables Variables { get; init; }
        public Params Params { get; set; }

        public override bool Execute(out Exception? exception)
        {
            throw new NotImplementedException();
        }
    }
}
