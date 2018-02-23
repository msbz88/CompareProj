using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace CompareProj {
    public class FileReader {
        public static DataTable ReadFileToTable(string path, char delimiter) {
            DataTable table = new DataTable();

            using (StreamReader steamReader = new StreamReader(path)) {
                string[] headers = steamReader.ReadLine().Split(delimiter);
                foreach (string header in headers) {
                    table.Columns.Add(header);
                }
                while (!steamReader.EndOfStream) {
                    string[] rows = steamReader.ReadLine().Split(delimiter);
                    DataRow dr = table.NewRow();
                    for (int i = 0; i < headers.Length; i++) {
                        dr[i] = rows[i];
                    }
                    table.Rows.Add(dr);
                }
            }
            return table;
        }
    }
}
