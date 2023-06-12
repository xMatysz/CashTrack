using CashTrack.ViewModel;

namespace CashTrack.View;

public partial class AddExpense : ContentPage
{
	public AddExpense(AddExpenseViewModel addExpensesViewModel)
	{
		InitializeComponent();
		BindingContext = addExpensesViewModel;
	}
}