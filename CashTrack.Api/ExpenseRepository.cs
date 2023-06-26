namespace CashTrack.Api;

public class ExpenseRepository
{
	private readonly Dictionary<Guid, Expense> _expenses = new();

	private void Init()
	{
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 24.11, Category = "Home", Date = DateTime.Now, Name = "Name1"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 14.63, Category = "Restaurant", Date = DateTime.Now, Name = "Name2"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 26.25, Category = "Shopping", Date = DateTime.Now, Name = "Name3"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 31.23, Category = "Home", Date = DateTime.Now, Name = "Name4"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 22.23, Category = "Restaurant", Date = DateTime.Now, Name = "Name5"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 64.23, Category = "Shopping", Date = DateTime.Now, Name = "Name6"});
		_expenses.Add(Guid.NewGuid(), new Expense { Amount = 7.2, Category = "Restaurant", Date = DateTime.Now, Name = "Name7"});
	}
	public List<Expense> GetAll()
	{
		if (!_expenses.Any())
			Init();

		return _expenses.Values.ToList();
	}
}