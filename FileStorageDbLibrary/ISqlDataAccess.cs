namespace FileStorageDbLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T>(string storeProcedure, string connectionName, object? parameters);
        Task SaveData(string storeProcedure, string connectionName, object parameters);
    }
}