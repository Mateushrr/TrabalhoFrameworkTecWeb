using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecWeb.Dao
{
    public class Conexao
    {
        private string db = "Database=dbcrud; Data Source=localhost; User Id=root; Password=root";
        protected MySqlConnection conexao = null;
        protected MySqlCommand comando = null;

        protected void Abrir()
        {
            try
            {
                conexao = new MySqlConnection(db);
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Fechar()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}