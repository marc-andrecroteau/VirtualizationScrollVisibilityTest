using System.Windows;
using System.Windows.Controls;

namespace VirtualizationScrollVisibilityTest.Controls
{
    public class AsyncVirtualizingContentControl : ContentControl
    {
        public AsyncVirtualizingContentControl()
        {
            SetContent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetContent();
        }

        private void SetContent()
        {
            if (DataContext is ObjectTestViewModel dataContext)
            {
                Content = dataContext;
                ContentTemplateSelector = new ObjectTestTemplateSelector();
            }
        }
    }
}