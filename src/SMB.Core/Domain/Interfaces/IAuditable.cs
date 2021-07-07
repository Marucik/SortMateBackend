using System;

namespace SMB.Core.Domain.Interfaces
{
	/// <summary>
	/// Interfejs pozwalający na audytowanie danych.
	/// </summary>
	public interface IAuditable
	{
		DateTimeOffset CreatedAt { get; }
		DateTimeOffset ModifiedAt { get; }
	}
}