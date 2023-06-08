using CashTrack.ViewModel;

namespace CashTrack.View;

public partial class MainPage : ContentPage
{
    public MainPage(ExpensesViewModel expensesViewModel)
    {
        InitializeComponent();
        BindingContext = expensesViewModel;
    }
}