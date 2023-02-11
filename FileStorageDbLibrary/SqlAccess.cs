﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FileStorageDbLibrary;

internal class SqlAccess
{
    private IConfiguration _configuration;

	public SqlAccess(IConfiguration configuration)
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
		connection.ExecuteAsync(
			storeProcedure, 
			parameters, 
			commandType: System.Data.CommandType.StoredProcedure);

	}
}