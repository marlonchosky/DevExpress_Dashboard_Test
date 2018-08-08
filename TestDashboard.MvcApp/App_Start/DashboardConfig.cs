using System.Web.Routing;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using TestDashboard.MvcApp.Infrastructure.Dashboard;

namespace TestDashboard.MvcApp {
    public class DashboardConfig {
        public static void RegisterService(RouteCollection routes) {
            //routes.MapDashboardRoute();
            routes.MapDashboardRoute("api/dashboardControl");

            DashboardConfigurator.Default.SetDashboardStorage(new AppCustomDashboardStorage());

            var dataSourceStorage = new DataSourceInMemoryStorage();
            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);
            var objDataSource = new DashboardObjectDataSource(DashboardUtilities.OBJECT_DATASOURCE_NAME);
            dataSourceStorage.RegisterDataSource(DashboardUtilities.OBJECT_DATASOURCE_ID, objDataSource.SaveToXml());

            //DashboardConfigurator.Default.SetObjectDataSourceCustomFillService(new AppCustomObjectDataSourceFillService());
            DashboardConfigurator.Default.DataLoading += AppCustomDefaultOnDataLoading.DefaultOnDataLoading;
        }
    }
}