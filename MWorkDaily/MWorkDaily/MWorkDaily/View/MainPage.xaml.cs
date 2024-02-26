using MWorkDaily.ViewModel;

namespace MWorkDaily.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }
    }

}
