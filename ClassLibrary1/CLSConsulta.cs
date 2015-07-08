using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAAR.Datos;


namespace SAAR.Datos
{
   public class CLSConsulta
    {
        CLSconexion conex = new CLSconexion();

        public DataTable consultar(String consulta)
        {
            DataSet DS = conex.ExecuteDataSet(consulta);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public void counsultaTodoTipo(String consulta)
        {
            DataSet DS = conex.ExecuteDataSet(consulta);
        }
    }
}
