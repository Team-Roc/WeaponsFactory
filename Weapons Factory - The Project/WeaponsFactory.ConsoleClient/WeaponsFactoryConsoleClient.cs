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

            WeaponsFactoryModule.GeneratePDFReport();

            //WeaponsFactoryModule.GenerateXmlReport();
            System.Console.Write("SqlDb to Json... ");
            WeaponsFactoryModule.GenerateJsonReport();
            System.Console.WriteLine("Done!");

            System.Console.Write("Json to MySql... ");
            WeaponsFactoryModule.SaveJsonInMySqlDb();
            System.Console.WriteLine("Done!");
            //WeaponsFactoryModule.LoadDataFromXmlInMongoDb();
            //WeaponsFactoryModule.GenerateExcelReportFromSQLiteAndMySqlDb();
        }
    }
}
