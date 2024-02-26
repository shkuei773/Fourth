using MWorkDaily.Base;
using MWorkDaily.Model;
using MWorkDaily.View;
using System.ComponentModel;
using System.Windows.Input;

namespace MWorkDaily.ViewModel;

public class LoginPageViewModel : INotifyPropertyChanged
{
    private bool _isEnable;
    private LoginModel _loginModel;
    private readonly AsyncLock asyncLock = new AsyncLock();

    public ICommand saveCommand { get; }

    public LoginPageViewModel()
    {
        _loginModel = new LoginModel();
        saveCommand = new Command(async () => await SuperBaseSave(), CanSave);
        _isEnable = true;

        _loginModel.superURL = AppConfig.SUPABASE_URL;
        _loginModel.superAPI = AppConfig.SUPABASE_KEY;
    }


    private async Task SuperBaseSave()
    {
        using (await asyncLock.LockAsync())
        {
            try
            {
                if (_isEnable == false) return;

                _isEnable = false;
                ((Command)saveCommand).ChangeCanExecute(); // 이 부분을 제거합니다.

                AppConfig.SUPABASE_URL = _loginModel.superURL;
                AppConfig.SUPABASE_KEY = _loginModel.superAPI;

                var currentRoute = Shell.Current.CurrentState?.Location?.ToString();
                await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            }
            finally
            {
                _isEnable = true;
                ((Command)saveCommand).ChangeCanExecute();
            }
        }
    }


    private bool CanSave()
    {
        return _isEnable;
    }

    public bool IsEnable
    {
        get { return _isEnable; }
        set { _isEnable = value; OnPropertychanged(nameof(IsEnable)); }
    }

    public string SuperURL
    {
        get { return _loginModel.superURL; }
        set { _loginModel.superURL = value; OnPropertychanged(nameof(SuperURL)); }
    }

    public string SuperAPI
    {
        get { return _loginModel.superAPI; }
        set { _loginModel.superAPI = value; OnPropertychanged(nameof(SuperAPI)); }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertychanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
