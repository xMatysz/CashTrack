﻿using CashTrack.Model;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace CashTrack.Services
{
    public class ExpenseService
    {
        private readonly HttpClient httpClient;

        private List<Expense> expenseList = new();

        public ExpenseService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {

            if (expenseList.Any())
                return expenseList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("Data.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            expenseList = JsonSerializer.Deserialize<List<Expense>>(contents);

            return expenseList;
        }
    }
}