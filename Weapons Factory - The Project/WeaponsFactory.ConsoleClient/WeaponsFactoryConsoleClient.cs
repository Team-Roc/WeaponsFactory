namespace WeaponsFactory.ConsoleClient
{
    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var weaponsFactoryModule = new WeaponsFactoryModule();

            WeaponsFactoryModule.MoveMongoDbDataToSqlDb();
            //WeaponsFactoryModule.LoadDataFromExcelInSqlDb();
            //WeaponsFactoryModule.GeneratePDFReport();
            //WeaponsFactoryModule.GenerateXmlReport();
            //WeaponsFactoryModule.GenerateJsonReport();
            //WeaponsFactoryModule.SaveJsonInMySqlDb();
            //WeaponsFactoryModule.LoadDataFromXmlInMongoDb();
            //WeaponsFactoryModule.GenerateExcelReportFromSQLiteAndMySqlDb();
        }
    }
}
