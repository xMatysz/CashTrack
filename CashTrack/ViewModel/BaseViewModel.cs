using CommunityToolkit.Mvvm.ComponentModel;

namespace CashTrack.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty]
    private string _title;

    private bool IsNotBusy => !IsBusy;

}
