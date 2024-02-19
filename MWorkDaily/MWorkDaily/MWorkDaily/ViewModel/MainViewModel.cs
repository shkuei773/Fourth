using System.ComponentModel;

namespace MWorkDaily.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel() { }

    protected void RaisePropertyChagned(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
