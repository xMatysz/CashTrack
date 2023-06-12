using CashTrack.Model;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace CashTrack.Services
{
    public class ExpenseService
    {
        private readonly HttpClient httpClient;

        private List<Expense> expenseList = new();
        private List<string> expenseCategoriesList = new();

        public ExpenseService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<string>> GetExpensesCategoriesAsync()
        {

            if (expenseCategoriesList.Any())
                return expenseCategoriesList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("categories.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            expenseCategoriesList = JsonSerializer.Deserialize<List<string>>(contents);

            return expenseCategoriesList;
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {

            if (expenseList.Any())
                return expenseList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            expenseList = JsonSerializer.Deserialize<List<Expense>>(contents);

            expenseList.ForEach(x => x.Category = expenseCategoriesList[int.Parse(x.Category)]);

            return expenseList;
        }
    }
}
