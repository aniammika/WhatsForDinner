using Microsoft.UI.Xaml;
using WhatsForDinner.Data;
using WhatsForDinner.ViewModel;


namespace WhatsForDinner
{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Customers App";
            ViewModel = new MainViewModel(new DinnerDataProvider());
            root.Loaded += Root_Loaded;
        }

        public MainViewModel ViewModel { get; }

        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }

    }
}
