﻿namespace FileStorageApp.Data;

public class CustomerModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = "User1";
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FileName { get; set; }

}
