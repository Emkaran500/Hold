using Hold.ViewModels.Base;

namespace Hold.Messages;

public class ChangeWindowMessage
{
    public readonly ViewModelBase DestinationViewModel;

    public ChangeWindowMessage(ViewModelBase destinationViewModel)
    {
        DestinationViewModel = destinationViewModel;
    }
}
