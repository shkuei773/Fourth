using MWorkDaily.Base;
using MWorkDaily.View;
using System.ComponentModel;
using System.Windows.Input;

namespace MWorkDaily.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly AsyncLock asyncLock = new AsyncLock();
    public ICommand logOutCommand { get; }


    public MainViewModel()
    {
        logOutCommand = new Command(async () => await SuperBaseLogOut());
    }

    private async Task SuperBaseLogOut()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void RaisePropertyChagned(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
