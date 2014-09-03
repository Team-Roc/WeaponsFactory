namespace WeaponsFactory.ConsoleClient
{
    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var weaponsFactoryModule = new WeaponsFactoryModule();

            System.Console.Write("MongoDb to SqlDb... ");
            WeaponsFactoryModule.MoveMongoDbDataToSqlDb();
            System.Console.WriteLine("Done!");

            System.Console.Write("Excel to SqlDb... ");
            WeaponsFactoryModule.LoadDataFromExcelInSqlDb();
            System.Console.WriteLine("Done!");

            //WeaponsFactoryModule.GeneratePDFReport();

            //WeaponsFactoryModule.GenerateXmlReport();
            //WeaponsFactoryModule.GenerateJsonReport();
            //WeaponsFactoryModule.SaveJsonInMySqlDb();
            //WeaponsFactoryModule.LoadDataFromXmlInMongoDb();
            //WeaponsFactoryModule.GenerateExcelReportFromSQLiteAndMySqlDb();
        }
    }
}
