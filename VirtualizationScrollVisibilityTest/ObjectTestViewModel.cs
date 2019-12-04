namespace VirtualizationScrollVisibilityTest
{
    public class ObjectTestViewModel
    {
        public bool IsPropAVisible => false;
        public bool IsPropBVisible => true;
        public bool IsPropCVisible => false;
        public bool IsPropDVisible => false;
        public bool IsHeightTest { get; set; }

        public ObjectTestViewModel(bool isHeightTest)
        {
            IsHeightTest = isHeightTest;
        }
    }
}