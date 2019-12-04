using System.Windows;
using System.Windows.Controls;

namespace VirtualizationScrollVisibilityTest
{
    public class ObjectTestTemplateSelector : DataTemplateSelector
    {
        
        #region Properties

        public DataTemplate TemplateADataTemplate { get; set; }
        public DataTemplate TemplateBDataTemplate { get; set; }

        #endregion

        #region Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null) return null;

            if (item is ObjectTestViewModel objectTestViewModel && objectTestViewModel.IsHeightTest)
                return GetDataTemplateByComponentName(nameof(ObjectTestViewModel) + "Height", element);

            return GetDataTemplateByComponentName(nameof(ObjectTestViewModel), element);
        }

        private static DataTemplate GetDataTemplateByComponentName(string componentName, FrameworkElement element)
        {
            var resourceKey = componentName + "DataTemplate";
            return element.TryFindResource(resourceKey) as DataTemplate;
        }

        #endregion

    }
}