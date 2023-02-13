namespace FileStorageDbLibrary
{
    public interface ISqlDataAccess
    {
        Task SaveData(string storeProcedure, string connectionName, object parameters);
    }
}