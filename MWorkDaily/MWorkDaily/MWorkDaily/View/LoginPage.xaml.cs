using DevExpress.Maui.Editors;
using MWorkDaily.Base;
using MWorkDaily.ViewModel;

namespace MWorkDaily.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        this.BindingContext = new LoginPageViewModel();

        var textediturl = new TextEdit();  
        textediturl.SetBinding(TextEdit.TextProperty, nameof(LoginPageViewModel.SuperURL));
        
        var textediapi = new TextEdit();  
        textediapi.SetBinding(TextEdit.TextProperty, nameof(LoginPageViewModel.SuperAPI));
    }
}