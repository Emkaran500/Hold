using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hold.ViewModels.Base;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void PropertyChangeMethod<T>(out T field, T value, [CallerMemberName] string callerName = "")
    {
        field = value;

        if (this.PropertyChanged != null)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
