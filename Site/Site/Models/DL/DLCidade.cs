using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Site.Models.DL
{
    public class DLCidade : BaseData 
    {
        public void IncluirCidade(MySqlTransaction myTransaction, Models.Cidade cidade)
        {
            StringBuilder strCommand = null;

            try
            {
                strCommand = new StringBuilder();

                strCommand = new StringBuilder(" insert into cidade(estado, nome, capital) values (");
                strCommand.Append(cidade.Estado.Codigo);
                strCommand.Append(",'");
                strCommand.Append(cidade.Nome);
                strCommand.Append("',");
                strCommand.Append(cidade.Capital);
                strCommand.Append(");");

                commandMySql = conexaoMySQL.CreateCommand();
                commandMySql.Transaction = myTransaction;
                commandMySql.CommandText = strCommand.ToString();
                commandMySql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void AlterarCidade(Models.Cidade cidade)
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();

            try
            {
                strCommand = new StringBuilder();

                strCommand = new StringBuilder(" update cidade set estado = ");
                strCommand.Append(cidade.Estado.Codigo);
                strCommand.Append(", nome = '");
                strCommand.Append(cidade.Nome);
                strCommand.Append("', capital = ");
                strCommand.Append(cidade.Capital);
                strCommand.Append(" where codigo = ");
                strCommand.Append(cidade.Codigo);

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);
                commandMySql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public List<Models.Cidade> ListarCidades()
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();
            Models.Cidade cidade = null;
            List<Models.Cidade> listCidade = null;

            try
            {
                strCommand = new StringBuilder("select a.codigo, a.nome, a.capital, b.codigo codigoEstado, b.nome nomeEstado, b.sigla siglaEstado, b.pais paisEstado, b.regiao regiaoEstado from cidade a, estado b where a.estado = b.codigo order by a.nome ");

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);

                MySqlDataAdapter da = new MySqlDataAdapter(commandMySql);
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    listCidade = new List<Models.Cidade>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cidade = new Models.Cidade();
                        cidade.Codigo = Convert.ToInt32(dr["codigo"].ToString());
                        cidade.Nome = dr["nome"].ToString();
                        cidade.Capital = Convert.ToBoolean(dr["capital"]);
                        cidade.Estado = new Models.Estado();
                        cidade.Estado.Codigo = Convert.ToInt32(dr["codigoEstado"].ToString());
                        cidade.Estado.Nome = dr["nomeEstado"].ToString();
                        cidade.Estado.Pais = dr["paisEstado"].ToString();
                        cidade.Estado.Regiao = dr["regiaoEstado"].ToString();
                        cidade.Estado.Sigla = dr["siglaEstado"].ToString();
                        listCidade.Add(cidade);
                    }
                }

                return listCidade;
            }
            catch
            {
                throw;
            }
        }

        public Models.Cidade ObterCidade(int id)
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();
            Models.Cidade cidade = null;
            DataRow dr = null;

            try
            {
                strCommand = new StringBuilder("select a.codigo, a.nome, a.capital, b.codigo codigoEstado, b.nome nomeEstado, b.sigla siglaEstado, b.pais paisEstado, b.regiao regiaoEstado from cidade a, estado b where a.estado = b.codigo ");
                strCommand.Append(" and a.codigo = ");
                strCommand.Append(id);

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);

                MySqlDataAdapter da = new MySqlDataAdapter(commandMySql);
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    cidade = new Models.Cidade();
                    cidade.Codigo = Convert.ToInt32(dr["codigo"].ToString());
                    cidade.Nome = dr["nome"].ToString();
                    cidade.Capital = Convert.ToBoolean(dr["capital"]);
                    cidade.Estado = new Models.Estado();
                    cidade.Estado.Codigo = Convert.ToInt32(dr["codigoEstado"].ToString());
                    cidade.Estado.Nome = dr["nomeEstado"].ToString();
                    cidade.Estado.Pais = dr["paisEstado"].ToString();
                    cidade.Estado.Regiao = dr["regiaoEstado"].ToString();
                    cidade.Estado.Sigla = dr["siglaEstado"].ToString();
                }

                return cidade;
            }
            catch
            {
                throw;
            }
        }

        public void DeletarCidade(int id)
        {
            StringBuilder strCommand = null;

            try
            {
                strCommand = new StringBuilder();

                strCommand = new StringBuilder(" delete from cidade where codigo = ");
                strCommand.Append(id);

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);
                commandMySql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
