using CommunityToolkit.Mvvm.ComponentModel;

namespace CashTrack.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string title;

    private bool IsNotBusy => !IsBusy;

}
