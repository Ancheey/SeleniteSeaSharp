using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        readonly public Guid paramguid;
        private readonly Variables variables;
        public ImmutableDictionary<string, ParamDescriptor> Descriptors { get; protected set; }

        /// <summary>
        /// THIS CREATES A LIST OF PARAMS REQUIRED FOR THIS ACTION.
        /// ACTIONS ARE REQUIRED TO HAVE A DEFAULT CONSTRUCTOR WITH ONLY PARENT ADN DERIVED
        /// PASSING VARIABLES TO ACTIONS IS DONE VIA THIS THING
        /// 
        /// GUID IS REQUIRED CAUSE PARAMS ARE VARIABLES SO THEY ARE DERIVED
        /// GUID MAKES SURE PARAMS NAME ISN'T CONFUSED
        /// 
        /// </summary>
        public Params(Variables variableList,Dictionary<string, ParamDescriptor> descriptors) 
        { 
            paramguid = Guid.NewGuid();
            variables = variableList; 
            Descriptors = descriptors.ToImmutableDictionary();
            foreach(var desc in descriptors)
            {
                if (!variables.Add($"{paramguid}.{desc.Key}", desc.Value.DefaultValue, out _))
                    break;
            }
        }

        
        public bool Apply(string paramName, Variable value, out Exception? exception) {
            try
            {
                variables[$"{paramguid}.{paramName}"].Value = value.Value;
                exception = null;
                return true;
            }
            catch (Exception ex) { exception = ex; return false; }
        }
        public Variable this[string name]
        {
            get => variables.Get()[$"{paramguid}.{name}"];
            set => Apply(name, value, out _);
        }
        public ImmutableDictionary<string, Variable?> GetAppliedParamValues()
        {
            var dict = new Dictionary<string, Variable?>();
            foreach (var i in Descriptors)
                if (variables.Get().TryGetValue($"{paramguid}.{i.Key}", out Variable? value))
                    dict.Add(i.Key, value);
            return dict.ToImmutableDictionary();
        }
        /// <summary>
        /// Used primarily for IDEs
        /// </summary>
        
    }
    public record ParamDescriptor(VariableType ParamType, Variable DefaultValue, string Description = "");
}
