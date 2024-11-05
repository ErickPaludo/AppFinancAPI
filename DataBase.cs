using Oracle.ManagedDataAccess.Client;
using WebApplication1.Entities;
using WebApplication1.Objetos;

namespace WebApplication1
{
    public static class DataBase
    {
        private static string connectionString = "Data Source=localhost:1521/freepdb1;User Id =PldGastos_for_dev;Password=PldGastos_for_dev;";
        public static void GravarConta(Contas contasPost)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand cmd = new OracleCommand("prc_gastos", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_value", contasPost.Valor);
                        cmd.Parameters.Add("p_titulo", contasPost.Titulo);
                        cmd.Parameters.Add("p_tipo", contasPost.Tipo);
                        cmd.Parameters.Add("p_data", contasPost.Data);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }
        public static ContasList<ContasPost> ColetarDados(int type)
        {
            var cont = new ContasList<ContasPost>();
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $"Select * From tb_gastos where id = {type}";
                    if(type == 0)
                    {
                        query = $"Select * From tb_gastos";
                    }
                   
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cont.ContasLista.Add(new ContasPost
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Valor = Convert.ToInt32(reader["valor"]),
                                    Titulo = reader["titulo"].ToString(),
                                    Tipo = Convert.ToInt32(reader["tipo"]),
                                    Data = Convert.ToDateTime(reader["data"])
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return cont;
            }
            catch (Exception ex)
            {
                return new ContasList<ContasPost>();
            }
        }
        public static void Delete(int id)
        {
            var cont = new List<ContasPost>();
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $"delete from tb_gastos where id = {id}";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.ExecuteReader(); 
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
             
            }
        }
        public static void AtualizaContas(Contas contasPost,int id)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand cmd = new OracleCommand("prc_update", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("id", id);
                        cmd.Parameters.Add("p_value", contasPost.Valor);
                        cmd.Parameters.Add("p_titulo", contasPost.Titulo);
                        cmd.Parameters.Add("p_tipo", contasPost.Tipo);
                        cmd.Parameters.Add("p_data", contasPost.Data);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
