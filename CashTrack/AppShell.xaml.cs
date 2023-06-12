using CashTrack.View;

namespace CashTrack;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AddExpense), typeof(AddExpense));
    }
}
