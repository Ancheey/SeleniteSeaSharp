using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Interfaces
{
    public interface IHasValue<T> where T : Variables.Variable
    {
        T Value { get; protected set; }
    }
}
