using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TestDashboard.MvcApp.DomainModel {
    public class TabIndicadorRepository {
        private readonly string connectionString;

        public TabIndicadorRepository() {
            connectionString = WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        }

        public TabIndicador ListarDashboardPorId(int id, string tipo) {
            var result = new TabIndicador();
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (var cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_select_dashboard_by_id";
                    cmd.Parameters.Add("@p_idindicador", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@p_tipo", SqlDbType.VarChar).Value = tipo;

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            result = new TabIndicador {
                                IdIndicador = (int)reader["IdIndicador"],
                                Descripcion = (string)reader["Descripcion"],
                                XML_Stream = (string)reader["XML_Stream"],
                            };
                        }
                    }
                }
            }

            return result;
        }
    }
}