using CashTrack.Services;
using CashTrack.View;
using CashTrack.ViewModel;

namespace CashTrack;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ExpenseService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<ExpensesViewModel>();

		builder.Services.AddSingleton<AddExpense>();
		builder.Services.AddSingleton<AddExpenseViewModel>();

        return builder.Build();
	}
}
