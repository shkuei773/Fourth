using MWorkDaily.View;

namespace MWorkDaily
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));    
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

            GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
