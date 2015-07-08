using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAAR.Datos;
namespace SAAR.Negocio
{
   public class consultaDatos
    {
       CLSConsulta cts = new CLSConsulta();
           
        public string[] consultaArea(string areaComun)
        {
            DataTable DT = cts.consultar("select * from AREACOMUN where NOMBREAREA like'" +areaComun+ "'");
            string[] s = { DT.Rows[0][0].ToString(), DT.Rows[0][1].ToString(), DT.Rows[0][2].ToString(), DT.Rows[0][3].ToString(), DT.Rows[0][4].ToString() };
            return s;    
        }
    }
}
