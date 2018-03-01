using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompareProj {
    public class FileReader {
        public static DataTable ReadFileToTable(string path, char delimiter, DataTable dataTable) {
            string[] AllLines = null;
            int max = File.ReadLines(path).Count();

            using (StreamReader steamReader = new StreamReader(path)) {
                string[] headers = steamReader.ReadLine().Split(delimiter);
                foreach (string header in headers) {
                    dataTable.Columns.Add(header);
                }
            }

            AllLines = new string[max];
            AllLines = File.ReadAllLines(path);
            AllLines = AllLines.Skip(1).ToArray();

            foreach (var item in AllLines) {
                DataRow newRow = dataTable.NewRow();
                newRow[0] = item.ToString();
                dataTable.Rows.Add(newRow);
            }

            /*
            while (!steamReader.EndOfStream) {
                string[] rows = steamReader.ReadLine().Split(delimiter);
                DataRow newRow = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++) {
                    newRow[i] = rows[i];
                }
                dataTable.Rows.Add(newRow);
            }
            */

            return dataTable;
        }

        public static DataTable GetDataSourceFromFile(string path, char delimiter, DataTable dataTable) {
            string[] columns = null;

            var lines = File.ReadAllLines(path);

            // assuming the first row contains the columns information
            if (lines.Count() > 0) {
                columns = lines[0].Split(new char[] { delimiter });

                foreach (var column in columns)
                    dataTable.Columns.Add(column);
            }

            // reading rest of the data
            for (int i = 1; i < lines.Count(); i++) {
                DataRow dr = dataTable.NewRow();
                string[] values = lines[i].Split(new char[] { delimiter });

                for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    dr[j] = values[j];

                dataTable.Rows.Add(dr);
            }
            Console.WriteLine("File loaded");
            return dataTable;
        }
    }
}
