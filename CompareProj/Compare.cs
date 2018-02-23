using System.Data;
using System.Linq;

namespace CompareProj {
    class Compare {
        DataTable MasterTable { get; set; }
        DataTable TestTable { get; set; }
        DataTable CompareTable { get; set; }
        string[] TableHeaders { get; set; }

        public Compare(DataTable master, DataTable test) {
            this.MasterTable = master;
            this.TestTable = test;
            InitializeTableHeaders();
            CreateCompareTable();
        }

        private void InitializeTableHeaders() {
            this.TableHeaders = (from columns in MasterTable.Columns.Cast<DataColumn>()
                                    select columns.ColumnName).ToArray();
        }

        private void CreateCompareTable() {
            CompareTable = new DataTable("Compare");
            foreach (string header in this.TableHeaders) {
                CompareTable.Columns.Add(header);
            }
        }

        public DataTable ExecuteComparison() {
            DataRow compareRow;
            foreach (DataRow masterRow in MasterTable.Rows) {
                foreach (DataRow testRow in TestTable.Rows) {
                    compareRow = CompareTable.NewRow();
                    for (int i = 0; i < this.TableHeaders.Length; i++) {
                        if (masterRow[this.TableHeaders[i]].ToString().Equals(testRow[this.TableHeaders[i]].ToString())) {
                            compareRow[this.TableHeaders[i]] = "0";
                        }
                        else {
                            compareRow[this.TableHeaders[i]] = masterRow[this.TableHeaders[i]].ToString() + " | " + testRow[this.TableHeaders[i]].ToString();
                        }
                    }
                    CompareTable.Rows.Add(compareRow);
                }
            }
            return CompareTable;
        }
    }
}
