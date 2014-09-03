namespace WeaponsFactory.ConsoleClient
{
    using System;
    using WeaponsFactory.Modules;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            Console.Write("Database initializing... ");
            WeaponsFactoryModule.InitializeData();
            Console.WriteLine("Done!");

            Console.Write("MongoDb to SqlDb... ");
            WeaponsFactoryModule.MoveMongoDbDataToSqlDb();
            Console.WriteLine("Done!");

            Console.Write("Excel to SqlDb... ");
            WeaponsFactoryModule.LoadDataFromExcelInSqlDb();
            Console.WriteLine("Done!");

            Console.Write("SqlDb to PDF... ");
            WeaponsFactoryModule.GeneratePDFReport();
            Console.WriteLine("Done!");

            //Console.Write("SqlDb to Xml... ");
            //WeaponsFactoryModule.GenerateXmlReport();
            //Console.WriteLine("Done!");

            Console.Write("SqlDb to Json... ");
            WeaponsFactoryModule.GenerateJsonReport();
            Console.WriteLine("Done!");

            Console.Write("Json to MySql... ");
            WeaponsFactoryModule.SaveJsonInMySqlDb();
            Console.WriteLine("Done!");

            //Console.Write("Json to MySql... ");
            //WeaponsFactoryModule.LoadDataFromXmlInMongoDb();
            //Console.WriteLine("Done!");

            //Console.Write("Json to MySql... ");
            //WeaponsFactoryModule.GenerateExcelReportFromSQLiteAndMySqlDb();
            //Console.WriteLine("Done!");
        }
    }
}
