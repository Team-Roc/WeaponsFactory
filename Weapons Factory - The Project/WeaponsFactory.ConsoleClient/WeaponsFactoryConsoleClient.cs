namespace WeaponsFactory.ConsoleClient
{
    using System;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            Console.Write("Database initializing... ");
            WeaponsFactoryFacade.InitializeData();
            Console.WriteLine("Done!");

            Console.Write("MongoDb to SqlDb... ");
            WeaponsFactoryFacade.MoveMongoDbDataToSqlDb();
            Console.WriteLine("Done!");

            Console.Write("Excel to SqlDb... ");
            WeaponsFactoryFacade.LoadDataFromExcelInSqlDb();
            Console.WriteLine("Done!");

            Console.Write("SqlDb to PDF... ");
            WeaponsFactoryFacade.GeneratePDFReport();
            Console.WriteLine("Done!");

            //Console.Write("SqlDb to Xml... ");
            //WeaponsFactoryModule.GenerateXmlReport();
            //Console.WriteLine("Done!");

            Console.Write("SqlDb to Json... ");
            WeaponsFactoryFacade.GenerateJsonReport();
            Console.WriteLine("Done!");

            Console.Write("Json to MySql... ");
            WeaponsFactoryFacade.SaveJsonInMySqlDb();
            Console.WriteLine("Done!");

            //Console.Write("Json to MySql... ");
            //WeaponsFactoryModule.LoadDataFromXmlInMongoDb();
            //Console.WriteLine("Done!");

            Console.Write("Json to MySql... ");
            WeaponsFactoryFacade.GenerateExcelReportFromSQLiteAndMySqlDb();
            Console.WriteLine("Done!");
        }
    }
}
