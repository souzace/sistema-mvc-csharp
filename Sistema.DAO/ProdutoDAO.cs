using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAO
{
    public class ProdutoDAO
    {
        public int Inserir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "INSERT INTO produtos ([nome], [descricao], [valor]) VALUES(@nome, @descricao, @valor)";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * FROM produtos WHERE nome like @nome";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome + "%";
                cn.Connection = con;

                SqlDataReader dr;
                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }

        public int Editar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "UPDATE produtos SET nome = @nome, descricao = @descricao, valor = @valor WHERE id = @id";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public int Excluir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "DELETE FROM produtos WHERE id = @id";
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;

            }
        }

        public List<ProdutoEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * FROM produtos ORDER BY id DESC";

                cn.Connection = con;

                SqlDataReader dr;
                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }
    }
}
