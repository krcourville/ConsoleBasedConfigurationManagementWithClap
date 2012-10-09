/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SimpleCRM.UI.WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SimpleCRM.Data;
using SimpleCRM.Data.Contracts;
using SimpleCRM.Data.Helpers;
using System.Data.Entity;

namespace SimpleCRM.UI.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<RepositoryFactories>();
            SimpleIoc.Default.Register<ISimpleCrmUow, SimpleCrmUow>();
            SimpleIoc.Default.Register<IRepositoryProvider, RepositoryProvider>();


            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                Database.SetInitializer(new SimpleCrmSampleDataInitializer());
            }
            else
            {

            }

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}