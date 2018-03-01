using System;
using System.Data;

namespace CompareProj {
    class Program {
        public static void PrintDataTable(DataTable dataTable) {
            DataRow[] currentRows = dataTable.Select(null, null, DataViewRowState.CurrentRows);
            if (currentRows.Length < 1)
                Console.WriteLine("No Current Rows Found");
            else {
                foreach (DataColumn column in dataTable.Columns)
                    Console.Write("\t{0}", column.ColumnName);

                Console.WriteLine("\tRowState");

                foreach (DataRow row in currentRows) {
                    foreach (DataColumn column in dataTable.Columns)
                        Console.Write("\t{0}", row[column]);

                    Console.WriteLine("\t" + row.RowState);
                }
            }
        }

        static void Main() {
            string masterFile = @"C:\Users\msbz\Desktop\CompareTest\[SD_KEYRATIOS_00.txt";
            string testFile = @"C:\Users\msbz\Desktop\CompareTest\]SD_KEYRATIOS_00.txt";
            string comparedFile = @"C:\Users\msbz\Desktop\CompareTest\CompareResult.xml";
            char delimiter = '\t';
            DataTable master = new DataTable("Master");
            DataTable test = new DataTable("Test");

            FileReader.GetDataSourceFromFile(masterFile, delimiter, master);
            FileReader.GetDataSourceFromFile(testFile, delimiter, test);

            //PrintDataTable(test);



            //Compare forCompare = new Compare(master, test);
            //forCompare.ExecuteComparison().WriteXml(comparedFile);
        }
    }
}
