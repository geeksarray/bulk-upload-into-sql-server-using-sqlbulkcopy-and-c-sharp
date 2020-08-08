using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;   

namespace CustomerBulkUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"<Your destination connection string>";
            
            DataSet ds = new DataSet();
            DataTable sourceData = new DataTable();
            ds.ReadXml(@"<enter path of BulkUploadOrders.xml>");
            sourceData = ds.Tables[0];
            int i = sourceData.Rows.Count;   

            // open the destination data
            using (SqlConnection destinationConnection =
                            new SqlConnection(connectionString))
            {
                // open the connection
                destinationConnection.Open();
                using (SqlBulkCopy bulkCopy =
                            new SqlBulkCopy(destinationConnection.ConnectionString,  SqlBulkCopyOptions.TableLock ))
                {
                    bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsTransfer);
                    bulkCopy.NotifyAfter = 100;
                    bulkCopy.BatchSize = 50;
                    bulkCopy.ColumnMappings.Add("OrderID", "NewOrderID");     
                    bulkCopy.DestinationTableName = "TopOrders";
                    bulkCopy.WriteToServer(sourceData);
                }
            }
        }

        private static void OnSqlRowsTransfer(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine("Copied {0} so far...", e.RowsCopied);
        }
    }
}
