# Bulk upload into SQL Server using SQLBulkCopy and C#
In this article I am going to write about SQLBulkCopy and its major properties and methods. This article will give you the code for high performance transfer of rows from XML file to SQL server with SQLBulkCopy and C#.

SQLBulkCopy introduced as part of .Net framework 2.0. It is simple and easy tool to transfer complicated or simple data from one data source to other. You can read data from any data source as long as that data can be load to DataTable or read by IDataReader and transfer the data with high performance to SQL Server using SQLBulkCopy.

## Files

1. **CustomerBulkUpload/Program.cs** - has all required code to read XML file and copy to SQL Server using SQLBulkCopy.
1. **CustomerBulkUpload/BulkUploadOrders.xml** - XML file used by SQLBulkCopy to read data.

For more details visit - https://geeksarray.com/blog/bulk-upload-into-sql-server-using-sqlbulkcopy-and-c-sharp
