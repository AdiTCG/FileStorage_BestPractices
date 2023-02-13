﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FileStorageDbLibrary;

internal class SqlDataAccess
{
    private IConfiguration _configuration;

	public SqlDataAccess(IConfiguration configuration)
	{
		_configuration= configuration;
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