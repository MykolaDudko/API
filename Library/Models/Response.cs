namespace ClassLibrary.Models;

public record Response<T>(int TotalItemsCount, IReadOnlyList<T> Items);

