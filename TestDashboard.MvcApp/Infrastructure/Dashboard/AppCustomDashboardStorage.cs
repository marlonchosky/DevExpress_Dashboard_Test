using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using DevExpress.DashboardWeb;
using TestDashboard.MvcApp.DomainModel;

namespace TestDashboard.MvcApp.Infrastructure.Dashboard {
    public class AppCustomDashboardStorage : IEditableDashboardStorage {
        XDocument IDashboardStorage.LoadDashboard(string dashboardID) {
            var repo = new TabIndicadorRepository();
            var model = repo.ListarDashboardPorId(int.Parse(dashboardID), "U"); // This 'U' must come from client.
            var data = Encoding.UTF8.GetBytes(model.XML_Stream);
            var stream = new MemoryStream(data);

            return XDocument.Load(stream);
        }

        string IEditableDashboardStorage.AddDashboard(XDocument dashboard, string dashboardName) {
            return null;
        }

        void IDashboardStorage.SaveDashboard(string dashboardID, XDocument dashboard) {
        }

        IEnumerable<DashboardInfo> IDashboardStorage.GetAvailableDashboardsInfo() {
            return null;
        }
    }
}