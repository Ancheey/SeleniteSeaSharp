using SeleniteSeaScript.Actions;
using SeleniteSeaScript.Interfaces;
using SeleniteSeaScript.Scopes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript
{
    public static class ScriptRegistry
    {
        static ScriptRegistry() {
            //TODO FOR EDITOR
            //register all classes with descriptors
            //Add IsScope, IsAction, IsVariable etc
            Scopes.Add(typeof(BasicScope), new("Basic Scope", "A default scope without any special effects", new List<ParamDescriptor>()));
            Actions.Add(typeof(NewVariableAction), new("Variable Creation", "A Way to create Variables", new List<ParamDescriptor>()));
        }
        public static readonly Dictionary<Type, ActionDescriptor> Scopes = new();
        public static readonly Dictionary<Type, ActionDescriptor> Actions = new();
        public static readonly Dictionary<Type, ParamDescriptor> Variables = new();//Change


        public record ActionDescriptor(string DisplayName, string EditorDescription, List<ParamDescriptor> Params);
        

    }
}
