using Hold.Messages.Base;
using Hold.ViewModels.Base;

namespace Hold.Messages;

public class ChangeInnerWindowMessage : IMessage
{
    public readonly ViewModelBase DestinationViewModel;

    public ChangeInnerWindowMessage(ViewModelBase destinationViewModel)
    {
        this.DestinationViewModel = destinationViewModel;
    }
}
