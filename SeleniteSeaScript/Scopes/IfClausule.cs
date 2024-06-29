using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Scopes
{
    public class IfClausule : BasicScope, IHasParams
	{
        public Params Params { get; set; }
		public bool Evaluated { get; set; } = false;
		public bool Expected => ((BooleanVariable)Params["ExpectedValue"]).Value;
        public IfClausule(IScope? Parent = null, Interfaces.Variables? derived = null) : base(Parent, derived)
		{
			Params = new Params(Variables, new()
			{
				{ "BooleanStatement",new(VariableType.Boolean,new BooleanVariable(true),"Statement")},
                { "ExpectedValue",new(VariableType.Boolean,new BooleanVariable(true),"Required")}
            });
		}

        public new bool Execute(out Exception? exception)
		{
			Evaluated = ((BooleanVariable)Params["BooleanStatement"]).Value;
            if (Evaluated == Expected)
				return base.Execute(out exception);
			else
			{
				exception = null;
				return true; //Job's done!
			}
		}
	}
}
