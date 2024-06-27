using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Interfaces
{
    public interface IHasParams : IHasVariables
    {
        //This one can be changed whenever needed onlike other interfaces. It will suffice for changing the param list whenever project needs it
        //Then just recreate the object
        public Params Params { get; protected set; }
    }
    public class Params
    {
        private readonly Variables variables;
        public ImmutableDictionary<string, ParamDescriptor> Descriptors { get; protected set; }
        public Params(Variables variableList,Dictionary<string, ParamDescriptor> descriptors) { variables = variableList; Descriptors = descriptors.ToImmutableDictionary(); }

        
        public bool Apply(string paramName, Variable value, out Exception? exception) => variables.Add($"Params.{paramName}", value, out exception);
        public ImmutableDictionary<string, Variable?> GetAppliedParamValues()
        {
            var dict = new Dictionary<string, Variable?>();
            foreach (var i in Descriptors)
                if (variables.Get().TryGetValue($"Params.{i.Key}", out Variable? value))
                    dict.Add(i.Key, value);
            return dict.ToImmutableDictionary();
        }
        /// <summary>
        /// Used primarily for IDEs
        /// </summary>
        public record ParamDescriptor(VariableType ParamType, object? DefaultValue = null, string? Description = "");
    }
}
