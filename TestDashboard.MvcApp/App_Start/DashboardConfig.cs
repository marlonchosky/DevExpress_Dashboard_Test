using System.Data;
using System.Web.Routing;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using TestDashboard.MvcApp.Infrastructure.Dashboard;

namespace TestDashboard.MvcApp {
    public class DashboardConfig {
        public static void RegisterService(RouteCollection routes) {
            routes.MapDashboardRoute();

            DashboardConfigurator.Default.SetDashboardStorage(new AppCustomDashboardStorage());
            DashboardConfigurator.Default.SetObjectDataSourceCustomFillService(new AppCustomObjectDataSourceFillService());

            var dataSourceStorage = new DataSourceInMemoryStorage();
            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);
            var objDataSource = new DashboardObjectDataSource(DashboardUtilities.OBJECT_DATASOURCE_NAME, typeof(DataTable)) {
                DataSource = typeof(DataTable)
            };
            dataSourceStorage.RegisterDataSource(DashboardUtilities.OBJECT_DATASOURCE_ID, objDataSource.SaveToXml());
        }
    }
}