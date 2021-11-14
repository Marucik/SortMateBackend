namespace SMB.Infrastructure.Mongo
{
  /// <summary>
  /// Klasa przechowująca ustawienia połaczenia do bazy danych.
  /// </summary>
  public class MongoDbSettings
  {
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
  }
}