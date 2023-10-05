using Hold.ViewModels.Base;

namespace Hold.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase activeViewModel;

    public ViewModelBase ActiveViewModel
    {
        get => activeViewModel;
        set => base.PropertyChangeMethod(out activeViewModel, value);
    }
}
