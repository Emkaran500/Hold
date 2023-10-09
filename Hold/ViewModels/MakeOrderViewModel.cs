using Hold.Commands.Base;
using Hold.Mediator.Base;
using Hold.Messages;
using Hold.ViewModels.Base;

namespace Hold.ViewModels;

public class MakeOrderViewModel : ViewModelBase
{
    private ViewModelBase innerActiveViewModel;

    public ViewModelBase InnerActiveViewModel
    {
        get => innerActiveViewModel;
        set => base.PropertyChangeMethod(out this.innerActiveViewModel, value);
    }

    private readonly IMessenger mediator;

    public MakeOrderViewModel(IMessenger messenger)
    {
        this.mediator = messenger;
        this.InnerActiveViewModel = new PossibleOrdersViewModel();

        this.mediator.Subscribe<ChangeWindowMessage>
        (
            (message) =>
            {
                if (message is ChangeWindowMessage changeWindowMessage)
                {
                    this.InnerActiveViewModel = changeWindowMessage.DestinationViewModel;
                }
            }
        );
    }

    private CommandBase restaurantCommand;
    public CommandBase RestaurantCommand => this.restaurantCommand ??= new CommandBase
        (
            execute: () =>
            {
                this.InnerActiveViewModel = App.Container.GetInstance<PossibleOrdersViewModel>();
            },
            canExecute: () => true
        );
}
