using CashTrack.Model;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace CashTrack.Services
{
    public class ExpenseService
    {
        private readonly HttpClient _httpClient;

        private List<Expense> _expenseList = new();
        private List<string> _expenseCategoriesList = new();

        public ExpenseService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetExpensesCategoriesAsync()
        {

            if (_expenseCategoriesList.Any())
                return _expenseCategoriesList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("categories.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _expenseCategoriesList = JsonSerializer.Deserialize<List<string>>(contents);

            return _expenseCategoriesList;
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {

            if (_expenseList.Any())
                return _expenseList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _expenseList = JsonSerializer.Deserialize<List<Expense>>(contents);

            _expenseList.ForEach(x => x.Category = _expenseCategoriesList[int.Parse(x.Category)]);

            return _expenseList;
        }
    }
}
