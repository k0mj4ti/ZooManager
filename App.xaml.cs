using ZooManager.Model;
using ZooManager.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ZooManager
{
    public partial class App : Application
    {
        private ZooModel _model;
        private ZooViewModel _viewModel;
        private MainWindow _window;

        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _model = new ZooModel();
            _viewModel = new ZooViewModel(_model);
            _window = new MainWindow();
            _window.DataContext = _viewModel;
            _window.Show();
        }
    }
}
