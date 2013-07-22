using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Models.DL;
using MySql.Data.MySqlClient;

namespace Site.Models.BL
{
    public class BLCidade
    {

        public void IncluirCidade(Models.Cidade cidade)
        {
            DLCidade dlCidade = null;
            MySqlTransaction transaction = null;
            try
            {
                dlCidade = new DLCidade();
                transaction = dlCidade.conexaoMySQL.BeginTransaction();

                dlCidade.IncluirCidade(transaction, cidade);
                //wservice.
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void AlterarCidade(Models.Cidade cidade)
        {
            using (DLCidade dlCidade = new DLCidade())
            {
                dlCidade.AlterarCidade(cidade);
            }
        }

        public List<Models.Cidade> ListarCidades()
        {
            using (DLCidade dlCidade = new DLCidade())
            {
                return dlCidade.ListarCidades();
            }
        }

        public Models.Cidade ObterCidade(int id)
        {
            using (DLCidade dlCidade = new DLCidade())
            {
                return dlCidade.ObterCidade(id);
            }
        }

        public void DeletarCidade(int id)
        {
            using (DLCidade dlCidade = new DLCidade())
            {
                dlCidade.DeletarCidade(id);
            }
        }
    }
}