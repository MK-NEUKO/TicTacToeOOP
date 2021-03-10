using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MvvmFramework
{
    public static class AutoViewModelLocator
    {
        public static void SetAutoAttachViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoAttachViewModelProperty, value);
        }

        public static void SetAutoAttachViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoAttachViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoAttachViewModelProperty =
            DependencyProperty.RegisterAttached("AutoAttachViewModel",
                typeof(bool), typeof(AutoViewModelLocator),
                new PropertyMetadata(false, AutoAttachViewModelChanged));

        private static void AutoAttachViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                return;
            }
            Type viewType = d.GetType();
            string viewModelTypeName = viewType.FullName.Replace("View", "ViewModel");
            var assembliesForSearchingIn = AssemblySource.Instance;

            var allExportedTypes = new List<Type>();
            foreach (var assembly in assembliesForSearchingIn)
            {
                //CAN BE CACHED
                allExportedTypes.AddRange(assembly.GetExportedTypes());
            }
            Type viewModelType = allExportedTypes.Single(x => x.FullName == viewModelTypeName);
            object viewModel = IoC.GetInstance(viewModelType, null);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}
}
