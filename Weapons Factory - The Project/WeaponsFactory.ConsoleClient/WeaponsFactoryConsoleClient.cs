namespace WeaponsFactory.ConsoleClient
{
    using System;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            try
            {
                WeaponsFactoryFacade.InitializeData();
                WeaponsFactoryFacade.MoveMongoDbDataToSqlDb();
                WeaponsFactoryFacade.LoadDataFromExcelInSqlDb();
                WeaponsFactoryFacade.GeneratePDFReport();
                WeaponsFactoryFacade.GenerateXmlReport();
                WeaponsFactoryFacade.GenerateJsonReport();
                WeaponsFactoryFacade.SaveJsonInMySqlDb();
                WeaponsFactoryFacade.LoadDataFromXmlInSqlAndMongoDb();
                WeaponsFactoryFacade.GenerateExcelReportFromSQLiteAndMySqlDb();
            }
            catch (Exception ex)
            {
                WeaponsFactoryConsoleWriter.Error(ex.Message);
            }
        }
    }
}
