using CashTrack.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;
using CashTrack.Services;

namespace CashTrack.ViewModel
{
    public partial class ExpensesViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; } = new();
        public ObservableCollection<string> ExpenseCategories { get; set;  } = new();

        private ExpenseService expenseService;
        public ExpensesViewModel(ExpenseService service)
        {
            expenseService = service;

            SetUp();
        }

        private async Task SetUp()
        {
            if (ExpenseCategories.Any())
                ExpenseCategories.Clear();

            var categories = await expenseService.GetExpensesCategoriesAsync();

            foreach (var expenseCategory in categories)
            {
                ExpenseCategories.Add(expenseCategory);
            }
        }

        [ObservableProperty]
        private bool isRefreshing;
        
        [RelayCommand]
        async Task GetExpenses()
        {
            try
            {
                IsBusy = true;

                if (Expenses.Any())
                    Expenses.Clear();

                var result = await expenseService.GetExpensesAsync();

                foreach (var item in result)
                {
                    Expenses.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
