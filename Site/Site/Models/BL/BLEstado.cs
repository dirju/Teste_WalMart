using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Models.DL;
using MySql.Data.MySqlClient;

namespace Site.Models.BL
{
    public class BLEstado
    {

        public void IncluirEstado(Models.Estado estado)
        {
            DLEstado dlEstado = null;
            MySqlTransaction transaction = null;
            try
            {
                dlEstado = new DLEstado();
                transaction = dlEstado.conexaoMySQL.BeginTransaction();

                dlEstado.IncluirEstado(transaction, estado);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void AlterarEstado(Models.Estado estado)
        {
            using (DLEstado dlEstado = new DLEstado())
            {
                dlEstado.AlterarEstado(estado);
            }
        }

        public List<Models.Estado> ListarEstados()
        {
            using (DLEstado dlEstado = new DLEstado())
            {
                return dlEstado.ListarEstados();
            }
        }

        public Models.Estado ObterEstado(int id)
        {
            using (DLEstado dlEstado = new DLEstado())
            {
                return dlEstado.ObterEstado(id);
            }
        }

        public void DeletarEstado(int id)
        {
            using (DLEstado dlEstado = new DLEstado())
            {
                dlEstado.DeletarEstado(id);
            }
        }
    }
}