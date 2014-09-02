namespace WeaponsFactory.ConsoleClient
{
    using System;

    using WeaponsFactory.Data;
    using WeaponsFactory.Models;
    using WeaponsFactory.DataAccess;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var data = new WeaponsFactoryData();

            foreach (var v in data.Vendors.All())
            {
                Console.WriteLine(v.Name + " - " + v.Address);
            }

            data.GenerateJsonReports();

            WeaponsFactoryModel.UpdateDatabase();
        }
    }
}
