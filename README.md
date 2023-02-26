# FileStorage_BestPractices
## File upload, handle, storage in sql best practices via C# web API

Create a blazor server or WebAssebbly app, with default templates. In this learning we will create a blazor server app.

#### Upload files in client
* Its better randomized the file name, maybe keeping the same extention to avoid added unwanted risk (sql)
* Add file type filters helps choosing right types of files
* Work on Errors as they helps user to understand the issue better, also prevent exposing internals.

FileStorageDbLibrary serves the data from db. We have created a local db with SQL server  object explorer.
FileStorageApp is accessing data using the FileStorageDbLibrary.

Feathing data from sql:


### Tips:
* Dont trust the user
	- Rename the file name
* Use relative path
* Always associate file with user (logged-in) data, or at least captcha
* Dont store file with source code, have a dedicate part or blob storage
* Create a backup policy of data (backup and restore)
* Limit types