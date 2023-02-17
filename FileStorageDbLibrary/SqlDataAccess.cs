using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FileStorageDbLibrary;

public class SqlDataAccess : ISqlDataAccess
{
    private IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<T>> LoadData<T>(
        string storeProcedure,
        string connectionName,
        object? parameters)
    {
        string connectionString = _configuration.GetConnectionString(connectionName)
            ?? throw new Exception($"Missing connection string at {connectionName}");

        using var connection = new SqlConnection(connectionString);
        var rows = await connection.QueryAsync<T>(
            storeProcedure,
            parameters,
            commandType: System.Data.CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task SaveData(
    string storeProcedure,
    string connectionName,
    object parameters)
    {
        string connectionString = _configuration.GetConnectionString(connectionName)
            ?? throw new Exception($"Missing connection string at {connectionName}");

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(
            storeProcedure,
            parameters,
            commandType: System.Data.CommandType.StoredProcedure);

    }
}
