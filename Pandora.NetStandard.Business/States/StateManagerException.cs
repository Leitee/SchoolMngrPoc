using System;

namespace Pandora.NetStandard.Business.States
{
    public class StateManagerException : Exception
    {
        public StateManagerException(string message) : base($"Invalid student-state management. {message}")
        {
        }
    }
}
