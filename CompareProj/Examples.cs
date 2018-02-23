using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareProj {
    class Examples {

        /*


                    Console.WriteLine("Option 3");
                    var con2 = getDifferentRecords(master, test);
                    foreach (DataRow row in con2.AsEnumerable()) {
                        Console.WriteLine("{0} {1} {2} {3}",
                            row["TRANSEX"], row["SECNO"], row["ARGDATE"], row["BALNUMVAL"]);
                    }
                    Console.WriteLine("Option 4");
                    var con3 = CompareTwoDataTable(master, test);
                    foreach (DataRow row in con3.AsEnumerable()) {
                        Console.WriteLine("{0} {1} {2} {3}",
                            row["TRANSEX"], row["SECNO"], row["ARGDATE"], row["BALNUMVAL"]);
                    }
                }

                public static DataTable CompareTwoDataTable(DataTable dt1, DataTable dt2) {
                    dt1.Merge(dt2);
                    DataTable d3 = dt2.GetChanges();
                    return d3;
                }

                public static DataTable getDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable) {

                    //Create Empty Table  
                    DataTable ResultDataTable = new DataTable("ResultDataTable");

                    //use a Dataset to make use of a DataRelation object  
                    using (DataSet ds = new DataSet()) {
                        //Add tables  
                        ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });

                        //Get Columns for DataRelation  
                        DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                        for (int i = 0; i < firstColumns.Length; i++) {
                            firstColumns[i] = ds.Tables[0].Columns[i];
                        }

                        DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                        for (int i = 0; i < secondColumns.Length; i++) {
                            secondColumns[i] = ds.Tables[1].Columns[i];
                        }
                        //Create DataRelation  
                        DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                        ds.Relations.Add(r1);

                        DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                        ds.Relations.Add(r2);

                        //Create columns for return table  
                        for (int i = 0; i < FirstDataTable.Columns.Count; i++) {
                            ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                        }

                        //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.  
                        ResultDataTable.BeginLoadData();
                        foreach (DataRow parentrow in ds.Tables[0].Rows) {
                            DataRow[] childrows = parentrow.GetChildRows(r1);
                            if (childrows == null || childrows.Length == 0)
                                ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                        }

                        //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.  
                        foreach (DataRow parentrow in ds.Tables[1].Rows) {
                            DataRow[] childrows = parentrow.GetChildRows(r2);
                            if (childrows == null || childrows.Length == 0)
                                ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                        }
                        ResultDataTable.EndLoadData();
                    }

                    return ResultDataTable;
                }     

            static void CompareRows(DataTable table1, DataTable table2) {
                    foreach (DataRow row1 in table1.Rows) {
                        foreach (DataRow row2 in table2.Rows) {
                            var array1 = row1.ItemArray;
                            var array2 = row2.ItemArray;


                            if (array1.SequenceEqual(array2)) {
                                Console.WriteLine(0);
                            }
                            else {
                                Console.WriteLine(row1["TRANSEX"] + " | " + row2["TRANSEX"]);
                                Console.WriteLine(row1["SECNO"] + " | " + row2["SECNO"]);
                                Console.WriteLine(row1["ARGDATE"] + " | " + row2["ARGDATE"]);
                                Console.WriteLine(row1["BALNUMVAL"] + " | " + row2["BALNUMVAL"]);
                            }
                        }
                    }
                }
                public static DataTable getLinq(DataTable dt1, DataTable dt2) {
                    DataTable dtMerged =
                    (from a in dt1.AsEnumerable()
                     join b in dt2.AsEnumerable()
                                 on
                             a["Query"].ToString() equals b["Query"].ToString()
                                 into g
                     where g.Count() > 0
                     select a).CopyToDataTable();
                    return dtMerged;
                }
                */
    }
}
