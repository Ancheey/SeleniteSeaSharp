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
        public ImmutableDictionary<string, ParamDescriptor> GetParams();
        public bool ApplyParam(string paramName, Variable value, out Exception? exception) => AddVariable($"Params.{paramName}", value, out exception);
        public ImmutableDictionary<string, Variable?> GetAppliedParamValues()
        {
            var dict = new Dictionary<string, Variable?>();
            foreach (var i in GetParams())
                if (Variables.TryGetValue(i.Key, out Variable? value))
                    dict.Add(i.Key, value);
            return dict.ToImmutableDictionary();
        }
        /// <summary>
        /// Used primarily for IDEs
        /// </summary>
        public record ParamDescriptor(VariableType ParamType, object? DefaultValue = null, string? Description = "");
    }
}
