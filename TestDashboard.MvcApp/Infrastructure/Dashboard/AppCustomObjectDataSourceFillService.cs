using System;
using System.Data;
using System.Globalization;
using System.Web;
using DevExpress.DashboardCommon;
using TestDashboard.MvcApp.DomainModel;

namespace TestDashboard.MvcApp.Infrastructure.Dashboard {
    public class AppCustomObjectDataSourceFillService : IObjectDataSourceCustomFillService {
        public object GetData(DashboardObjectDataSource dataSource, ObjectDataSourceFillParameters fillParameters) {
            if (dataSource.Name == DashboardUtilities.OBJECT_DATASOURCE_NAME) {
                return GetDataFmsDataSource(dataSource, fillParameters);
            }

            return null;
        }

        private object GetDataFmsDataSource(DashboardObjectDataSource dataSource, ObjectDataSourceFillParameters fillParameters) {
            if (fillParameters.DataFields == null || fillParameters.DataFields.Length == 0)
                return null;

            // Invocar metodo de negocio.
            var request = HttpContext.Current.Request;
            var headers = request.Headers;
            var idIndicador = int.Parse(headers["filtro_id_indicador"]); 
            var tipoIndicador = headers["filtro_tipo_indicador"]; 
            var fechaInicio = DateTime.ParseExact(headers["filtro_fecha_inicio"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var fechaFin = DateTime.ParseExact(headers["filtro_fecha_fin"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
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