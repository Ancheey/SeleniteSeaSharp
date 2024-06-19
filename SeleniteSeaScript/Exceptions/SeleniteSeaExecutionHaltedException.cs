using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniteSeaScript.Exceptions
{
	internal class SeleniteSeaExecutionHaltedException : SeleniteSeaException
	{
		public SeleniteSeaExecutionHaltedException(string message, ScriptAction throwing) : base(message, throwing)
		{
		}
	}
}
