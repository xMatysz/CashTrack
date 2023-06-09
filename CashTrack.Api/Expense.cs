﻿namespace CashTrack.Api;

public class Expense
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Category { get; set; }

	public double Amount { get; set; }

	public DateTime Date { get; set; }
}