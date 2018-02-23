using System.Data;

namespace CompareProj {
    class Program {
        static void Main() {
            string masterFile = @"C:\Users\msbz\Desktop\CompareTest\[VT_FRMLVALUES_00.txt";
            string testFile = @"C:\Users\msbz\Desktop\CompareTest\]VT_FRMLVALUES_00.txt";
            string comparedFile = @"C:\Users\msbz\Desktop\CompareTest\CompareResult.xml";
            char delimiter = '\t';
            DataTable master = new DataTable();
            DataTable test = new DataTable();
            DataTable compare = new DataTable();

            master = FileReader.ReadFileToTable(masterFile, delimiter);
            test = FileReader.ReadFileToTable(testFile, delimiter);
            Compare forCompare = new Compare(master, test);
            forCompare.ExecuteComparison();
            compare.WriteXml(comparedFile);
        }
    }
}
