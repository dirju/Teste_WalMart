using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Site.Models.DL
{
    public class DLEstado : BaseData 
    {
        public void IncluirEstado(MySqlTransaction myTransaction, Models.Estado estado)
        {
            StringBuilder strCommand = null;

            try
            {
                strCommand = new StringBuilder();

                strCommand = new StringBuilder(" insert into estado(pais, nome, sigla, regiao) values ('");
                strCommand.Append(estado.Pais);
                strCommand.Append("','");
                strCommand.Append(estado.Nome);
                strCommand.Append("','");
                strCommand.Append(estado.Sigla);
                strCommand.Append("','");
                strCommand.Append(estado.Regiao);
                strCommand.Append("');");

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

        public void AlterarEstado(Models.Estado estado)
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();

            try
            {
                strCommand = new StringBuilder();

                strCommand = new StringBuilder(" update estado set pais = '");
                strCommand.Append(estado.Pais);
                strCommand.Append("', nome = '");
                strCommand.Append(estado.Nome);
                strCommand.Append("', sigla = '");
                strCommand.Append(estado.Sigla);
                strCommand.Append("', regiao = '");
                strCommand.Append(estado.Regiao);
                strCommand.Append("' where codigo = ");
                strCommand.Append(estado.Codigo);

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);
                commandMySql.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public List<Models.Estado> ListarEstados()
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();
            Models.Estado estado = null;
            List<Models.Estado> listEstados = null;

            try
            {
                strCommand = new StringBuilder("select codigo, pais, nome, sigla, regiao, (select count(*) from cidade where cidade.estado = estado.codigo) qtdcidade from estado order by nome ");

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);

                MySqlDataAdapter da = new MySqlDataAdapter(commandMySql);
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    listEstados = new List<Models.Estado>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        estado = new Models.Estado();
                        estado.Codigo = Convert.ToInt32(dr["codigo"].ToString());
                        estado.Nome = dr["nome"].ToString();
                        estado.Pais = dr["pais"].ToString();
                        estado.Regiao = dr["regiao"].ToString();
                        estado.Sigla = dr["sigla"].ToString();
                        estado.QtdCidade = Convert.ToInt32(dr["qtdcidade"]);
                        listEstados.Add(estado);
                    }
                }

                return listEstados;
            }
            catch
            {
                throw;
            }
        }

        public Models.Estado ObterEstado(int id)
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();
            Models.Estado estado = null;
            DataRow dr = null;

            try
            {
                strCommand = new StringBuilder("select codigo, pais, nome, sigla, regiao from estado where codigo = ");
                strCommand.Append(id);
                strCommand.Append(" order by nome ");

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);

                MySqlDataAdapter da = new MySqlDataAdapter(commandMySql);
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    estado = new Models.Estado();
                    estado.Codigo = Convert.ToInt32(dr["codigo"].ToString());
                    estado.Nome = dr["nome"].ToString();
                    estado.Pais = dr["pais"].ToString();
                    estado.Regiao = dr["regiao"].ToString();
                    estado.Sigla = dr["sigla"].ToString();
                }

                return estado;
            }
            catch
            {
                throw;
            }
        }

        public void DeletarEstado(int id)
        {
            StringBuilder strCommand = null;
            DataTable dt = new DataTable();

            try
            {
                strCommand = new StringBuilder();
                strCommand.Append(" select count(*) from cidade where estado = ");
                strCommand.Append(id);

                commandMySql = new MySqlCommand(strCommand.ToString(), conexaoMySQL);

                MySqlDataAdapter da = new MySqlDataAdapter(commandMySql);
                da.Fill(dt);

                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    throw new ArgumentException("Não é possível excluir esse Estado pois ele está relacionado a cidades já cadastradas.");
                }

                strCommand = new StringBuilder(" delete from estado where codigo = ");
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
