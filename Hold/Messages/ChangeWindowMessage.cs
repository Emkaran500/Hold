using Hold.Messages.Base;
using Hold.ViewModels.Base;

namespace Hold.Messages;

public class ChangeWindowMessage : IMessage
{
    public readonly ViewModelBase DestinationViewModel;

    public ChangeWindowMessage(ViewModelBase destinationViewModel)
    {
        this.DestinationViewModel = destinationViewModel;
    }
}
