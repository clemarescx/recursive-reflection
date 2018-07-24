using System.Collections.Generic;

namespace RecursiveReflectionTest
{
    public class State : ResourceData
    {
        private string _stateName;

        public State(string stateName)
        {
            StateName = stateName;
        }

        private string StateName
        {
            set => SetProperty(ref _stateName, value);
        }

        public List<Transition> Transitions { get; set; }
    }
}