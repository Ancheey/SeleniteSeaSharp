using SeleniteSeaScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Interfaces
{
    public interface IHasValue<T> where T : Variable
    {
        T? Value { get; protected set; }
    }
}
