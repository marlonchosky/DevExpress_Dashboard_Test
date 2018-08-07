using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml.Linq;
using DevExpress.DashboardWeb;
using TestDashboard.MvcApp.DomainModel;

namespace TestDashboard.MvcApp.Infrastructure.Dashboard {
    public class AppCustomDashboardStorage : IEditableDashboardStorage {
        XDocument IDashboardStorage.LoadDashboard(string dashboardID) {
            var request = HttpContext.Current.Request;
            var headers = request.Headers;
            var tipoIndicador = headers["filtro_tipo_indicador"];

            var repo = new TabIndicadorRepository();
            var model = repo.ListarDashboardPorId(int.Parse(dashboardID), tipoIndicador); // This 'U' must come from client.
            var data = Encoding.UTF8.GetBytes(model.XML_Stream);
            var stream = new MemoryStream(data);

            return XDocument.Load(stream);
        }

        string IEditableDashboardStorage.AddDashboard(XDocument dashboard, string dashboardName) {
            return "1";
        }

        void IDashboardStorage.SaveDashboard(string dashboardID, XDocument dashboard) {
        }

        IEnumerable<DashboardInfo> IDashboardStorage.GetAvailableDashboardsInfo() {
            return null;
        }
    }
}