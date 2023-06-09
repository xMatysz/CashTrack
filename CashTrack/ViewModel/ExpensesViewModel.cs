﻿using CashTrack.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CashTrack.Services;
using CashTrack.View;

namespace CashTrack.ViewModel
{
    public partial class ExpensesViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; } = new();
        public ObservableCollection<string> ExpenseCategories { get; set;  } = new();

        private readonly ExpenseService _expenseService;
        public ExpensesViewModel(ExpenseService service)
        {
            _expenseService = service;

            SetUp();
        }

        private async Task SetUp()
        {
            if (ExpenseCategories.Any())
                ExpenseCategories.Clear();

            var categories = await _expenseService.GetExpensesCategoriesAsync();

            foreach (var expenseCategory in categories)
            {
                ExpenseCategories.Add(expenseCategory);
            }
        }

        [ObservableProperty]
        private bool _isRefreshing;
        
        [RelayCommand]
        async Task GetExpenses()
        {
            try
            {
                IsBusy = true;

                if (Expenses.Any())
                    Expenses.Clear();

                var result = await _expenseService.GetExpensesAsync();

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

        [RelayCommand]
        async Task GoToAddExpense()
        {
            await Shell.Current.GoToAsync(nameof(AddExpense), true);
        }
    }
}
