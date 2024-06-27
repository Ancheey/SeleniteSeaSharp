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
        public Scope Scope { get; init; }
    }
    public class Scope
    {
        protected List<ScriptAction> Actions { get; set; } = new List<ScriptAction>();
        public ImmutableList<ScriptAction> GetActions() => Actions.ToImmutableList();

        public void AddAction(ScriptAction action) => Actions.Add(action);
        public void AddAction(ScriptAction action, int index) => Actions.Insert(index, action);
        public void MoveAction(int indexA, int targetIndex)
        {
            var a = Actions[indexA];
            Actions.RemoveAt(indexA);
            Actions.Insert(targetIndex, a);
        }
        public bool RemoveAction(ScriptAction action) => Actions.Remove(action);
        public bool RemoveAction(int index, out Exception? exception)
        {
            if (index > Actions.Count)
            {
                exception = new IndexOutOfRangeException($"Cannot remove action no. {index}. Index out of range. (max {Actions.Count})");
                return false;
            }
            Actions.RemoveAt(index);
            exception = null;
            return true;
        }
    }
}
