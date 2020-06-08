using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TecWeb.Models;

namespace TecWeb.Dao
{
    public class pessoaDAO : Conexao
    {
        public void Salvar(Pessoa p)
        {
            try
            {
                Abrir();

                String query = "INSERT INTO pessoa (cpf, nome, idade, email) VALUES (" +
                    "'" + p.cpf + "', " +
                    "'" + p.nome + "', " +
                    "'" + int.Parse(p.idade) + "', " +
                    "'" + p.email + "'" +
                    ")";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public void Editar(Pessoa pessoa)
        {
            try
            {
                Abrir();
                String query = "UPDATE pessoa SET cpf ='" 
                    + pessoa.cpf + "', nome='" 
                    + pessoa.nome + "', idade='" 
                    + int.Parse(pessoa.idade) + "', email='" 
                    + pessoa.email + "' WHERE id='" + pessoa.id + "'";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public void Deletar(int id)
        {
            try
            {
                Abrir();
                String query = "DELETE FROM pessoa where id = '" + id + "'";
                comando = new MySqlCommand(query);
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }
        }
        public Pessoa BuscarPessoa(int id)
        {
            Pessoa pessoa = new Pessoa();

            try
            {
                Abrir();
                String query = "SELECT * FROM pessoa where id = '" + id + "'";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;

                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    pessoa.id = int.Parse(reader.GetString(0));
                    pessoa.cpf = reader.GetString(1);
                    pessoa.nome = reader.GetString(2);
                    pessoa.idade = reader.GetString(3);
                    pessoa.email = reader.GetString(4);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }

            return pessoa;
        }
        public List<Pessoa> Listar()
        {
            List<Pessoa> pessoa = new List<Pessoa>();

            try
            {
                Abrir();
                String query = "SELECT * FROM pessoa";

                comando = new MySqlCommand(query);
                comando.Connection = conexao;

                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pessoa p = new Pessoa();
                    p.id = int.Parse(reader.GetString(0));
                    p.cpf = reader.GetString(1);
                    p.nome = reader.GetString(2);
                    p.idade = reader.GetString(3);
                    p.email = reader.GetString(4);

                    pessoa.Add(p);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                Fechar();
            }

            return pessoa;
        }
    }
}