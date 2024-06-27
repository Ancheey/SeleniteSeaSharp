using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Interfaces
{
    public interface IScope
    {
        protected List<ScriptAction> ScopeActions { get; set; }
        public ImmutableList<ScriptAction> GetScopeActions() => ScopeActions.ToImmutableList();

        public void AddScopeAction(ScriptAction action) => ScopeActions.Add(action);
        public void AddScopeAction(ScriptAction action, int index) => ScopeActions.Insert(index, action);
        public void MoveAction(int indexA,int targetIndex)
        {
            var a = ScopeActions[indexA];
            ScopeActions.RemoveAt(indexA);
            ScopeActions.Insert(targetIndex, a);
        }
        public bool RemoveScopeAction(ScriptAction action) => ScopeActions.Remove(action);
        public bool RemoveScopeAction(int index, out Exception? exception)
        {
            if (index > ScopeActions.Count)
            {
                exception = new IndexOutOfRangeException($"Cannot remove action no. {index}. Index out of range. (max {ScopeActions.Count})");
                return false;
            }
            ScopeActions.RemoveAt(index);
            exception = null;
            return true;
        }
    }
}
