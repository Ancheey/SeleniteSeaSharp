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
        protected Dictionary<string, Variable> Variables { get; set; }
        public bool AddVariable(string variableName, Variable variable, out Exception? exception)
        {
            if (Variables.ContainsKey(variableName))
            {
                exception = new DuplicateNameException($"Attempted a creation of a duplicate variable of name \"{variableName}\"");
                return false;
            }
            Variables.Add(variableName, variable);
            exception = null;
            return true;
        }
        public bool RemoveVariable(string variableName) => Variables.Remove(variableName);
        /// <returns>An immutable collection of variables this scope considers local. These variables may be managed via adding or removing</returns>
        public ImmutableDictionary<string, Variable> GetVariables() => Variables.ToImmutableDictionary();
    }
}
