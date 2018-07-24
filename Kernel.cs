using System.Collections.Generic;

namespace RecursiveReflectionTest
{
    public class Kernel : ResourceData
    {
        private string _kernelName;

        public Kernel(string kernelName)
        {
            KernelName = kernelName;
        }

        public List<State> States { get; set; }

        private string KernelName
        {
            set => SetProperty(ref _kernelName, value);
        }
    }
}