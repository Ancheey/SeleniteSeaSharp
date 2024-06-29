using SeleniteSeaScript.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript
{
    public class ScriptRegistry
    {
        public ScriptRegistry() {
            //TODO FOR EDITOR
            //register all classes with descriptors
        }
        private readonly Dictionary<Type, ActionDescriptor> Scopes = new();
        private readonly Dictionary<Type, ActionDescriptor> Actions = new();
        private readonly Dictionary<Type, ActionDescriptor> Variables = new();//Change


        public record ActionDescriptor(string DisplayName, string EditorDescription, List<ParamDescriptor> Params);
        

    }
}
