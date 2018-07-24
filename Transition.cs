namespace RecursiveReflectionTest
{
    public class Transition : ResourceData
    {
        private string _transitionName;

        public Transition(string transitionName)
        {
            TransitionName = transitionName;
        }

        private string TransitionName
        {
            set => SetProperty(ref _transitionName, value);
        }
    }
}