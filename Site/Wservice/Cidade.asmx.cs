using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Xml.Serialization;

namespace Wservice
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Cidade : System.Web.Services.WebService
    {

        [WebMethod]
        public void AdicionarCidade()
        {
            
        }

        [WebMethod]
        public void AlterarCidade()
        {

        }

        [WebMethod]
        public void ExcluirCidade()
        {

        }

        [WebMethod]
        public void ConsultarCidade()
        {

        }
    }
}