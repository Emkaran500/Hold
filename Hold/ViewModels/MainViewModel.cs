using Hold.Mediator.Base;
using Hold.Messages;
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

    private readonly IMessenger mediator;

    public MainViewModel(IMessenger messenger)
    {
        this.mediator = messenger;

        this.mediator.Subscribe<ChangeWindowMessage>
        (
            (message) =>
            {
                if (message is ChangeWindowMessage changeWindowMessage)
                {
                    this.ActiveViewModel = changeWindowMessage.DestinationViewModel;
                }
            }
        );
    }
}
