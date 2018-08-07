using System;
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
                try {
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
                } finally {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return result;
        }

        public DataTable ListarResultIndicator_Ind(int idIndicador, DateTime fechaInicio, DateTime fechaFin) {
            var dt = new DataTable();
            using (var connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();
                    using (var cmd = connection.CreateCommand()) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.usp_select_result_indicator_ind";
                        cmd.Parameters.Add("@p_idindicador", SqlDbType.Int).Value = idIndicador;
                        cmd.Parameters.Add("@p_fecha_inicio", SqlDbType.DateTime).Value = fechaInicio;
                        cmd.Parameters.Add("@p_fecha_fin", SqlDbType.DateTime).Value = fechaFin;

                        var adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                } finally {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return dt;
        }
    }
}