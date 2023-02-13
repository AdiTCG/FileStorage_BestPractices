namespace FileStorageDbLibrary
{
    internal interface ISqlDataAccess
    {
        Task SaveData(string storeProcedure, string connectionName, object parameters);
    }
}