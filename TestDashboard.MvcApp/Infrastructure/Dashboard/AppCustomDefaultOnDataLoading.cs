using System;
using System.Data;
using System.Globalization;
using System.Web;
using DevExpress.DashboardWeb;
using TestDashboard.MvcApp.DomainModel;

namespace TestDashboard.MvcApp.Infrastructure.Dashboard {
    public static class AppCustomDefaultOnDataLoading {
        public static void DefaultOnDataLoading(object sender, DataLoadingWebEventArgs e) {
            if (e.DataSourceName == DashboardUtilities.OBJECT_DATASOURCE_NAME) {
                e.Data = GetData(e);
            }
        }

        private static object GetData(DataLoadingWebEventArgs e) {
            var request = HttpContext.Current.Request;
            var headers = request.Headers;
            var idIndicador = int.Parse(headers["filtro_id_indicador"]); 
            var tipoIndicador = headers["filtro_tipo_indicador"]; 
            var fechaInicio = DateTime.ParseExact(headers["filtro_fecha_inicio"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var fechaFin = DateTime.ParseExact(headers["filtro_fecha_fin"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var idPlataforma = headers["filtro_id_plataforma"];

            var result = new DataTable();
            var repo = new TabIndicadorRepository();
            if (string.IsNullOrEmpty(tipoIndicador)) {
                return result;
            }
            if (tipoIndicador == "U") {
                result = repo.ListarResultIndicator_Ind(idIndicador, fechaInicio, fechaFin);
            }

            return result;
        }
    }
}