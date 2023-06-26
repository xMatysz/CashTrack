namespace CashTrack.Api;

public class ExpenseRepository
{
	private readonly Dictionary<Guid, Expense> _expenses = new();

	private void Init()
	{
		var gui = Guid.NewGuid();
		_expenses.Add(gui, new Expense { Id = gui, Amount = 24.11, Category = "Home", Date = DateTime.Now, Name = "Name1"});
		var gu2 = Guid.NewGuid();
		_expenses.Add(gu2, new Expense { Id = gu2, Amount = 14.63, Category = "Restaurant", Date = DateTime.Now, Name = "Name2"});
		var gu3 = Guid.NewGuid();
		_expenses.Add(gu3, new Expense { Id = gu3, Amount = 26.25, Category = "Shopping", Date = DateTime.Now, Name = "Name3"});
		var gu4 = Guid.NewGuid();
		_expenses.Add(gu4, new Expense { Id = gu4, Amount = 31.23, Category = "Home", Date = DateTime.Now, Name = "Name4"});
		var gu5 = Guid.NewGuid();
		_expenses.Add(gu5, new Expense { Id = gu5, Amount = 22.23, Category = "Restaurant", Date = DateTime.Now, Name = "Name5"});
		var gu6 = Guid.NewGuid();
		_expenses.Add(gu6, new Expense { Id = gu6, Amount = 64.23, Category = "Shopping", Date = DateTime.Now, Name = "Name6"});
		var gu7 = Guid.NewGuid();
		_expenses.Add(gu7, new Expense { Id = gu7, Amount = 7.2, Category = "Restaurant", Date = DateTime.Now, Name = "Name7"});
	}
	public List<Expense> GetAll()
	{
		if (!_expenses.Any())
			Init();

		return _expenses.Values.ToList();
	}

	public Expense GetById(Guid id)
	{
		return _expenses[id];
	}

	public void Create(Expense expense)
	{
		if (expense is null)
		{
			return;
		}

		_expenses[expense.Id] = expense;
	}
}