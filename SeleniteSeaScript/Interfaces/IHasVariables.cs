using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Interfaces
{
    public interface IHasVariables
    {
        public Variables Variables { get; init; }
    }
    public class Variables
    {
        public Variables(Variables? derived = null)
        {
            if (derived is null)
                return;
            foreach(var i in derived.Get())
                VarData.Add(i.Key, i.Value);
        }
        protected Dictionary<string, Variable> VarData { get; set; } = new Dictionary<string, Variable>();
        public bool Add(string variableName, Variable variable, out Exception? exception)
        {
            if (VarData.ContainsKey(variableName))
            {
                exception = new DuplicateNameException($"Attempted a creation of a duplicate variable of name \"{variableName}\"");
                return false;
            }
            VarData.Add(variableName, variable);
            exception = null;
            return true;
        }
        public bool Remove(string variableName) => VarData.Remove(variableName);
        /// <returns>An immutable collection of variables this scope considers local. These variables may be managed via adding or removing</returns>
        public ImmutableDictionary<string, Variable> Get() => VarData.ToImmutableDictionary();
    }
}
