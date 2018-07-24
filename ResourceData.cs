namespace RecursiveReflectionTest
{
    public abstract class ResourceData  
    {
        protected ResourceData()
        {
            CreateResourceId();
        }

        private static int _idCount;
        private string _resourceId;

        private string ResourceId
        {
            get => _resourceId;
            set => SetProperty(ref _resourceId, value);
        }

        public void CreateResourceId()
        {
            ResourceId = $"id_{_idCount++}"; 
        }

        protected static void SetProperty(ref string old, string newStr)
        {
            if (old == null || old != newStr)
            {
                old = newStr;
            } 
        }
    }
}