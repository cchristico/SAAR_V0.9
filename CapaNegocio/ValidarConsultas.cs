using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAAR.Datos;

namespace SAAR.Negocio
{
    
   public class ValidarConsultas
    {
        CLSConsulta cst = new CLSConsulta();
        consultaDatos conDat = new consultaDatos();
        string error;
        
        /*#######Area Comun#####*/
        /*Insert*/
        public String insAreaComun(string tipo, string NomAreaCom, string Aforo, string Disp)
        {
            try
            {
                    DataTable DT = cst.consultar("select IDAREACOMUN from AREACOMUN order by IDAREACOMUN desc");
                    int IdArea = int.Parse(DT.Rows[0][0].ToString()) + 1;
                    string insert = "insert into AREACOMUN values (" + IdArea.ToString() + ",'" + tipo + "','" + NomAreaCom + "'," + Aforo + ",'" + Disp + "')";
                    cst.counsultaTodoTipo(insert);
            }
            catch {

                error = "\n No ingreso Datos";
                
            }
            return error;
        }
       /*eliminar*/

        public void eliminarArea(string idArea)
        {
            cst.consultar("delete from AREACOMUN where IDAREACOMUN="+idArea);
        }
       /*actualizar*/
        public void actualizar(string ID, string tipo, string nombreArea, string aforo, string disponibilidad)
        {
            cst.counsultaTodoTipo("update AREACOMUN set TIPO ='"+tipo+"', NOMBREAREA='"+nombreArea+"',AFORO="+aforo+",DISPONIBILIDAD='"+disponibilidad+"' where IDAREACOMUN="+ID);
           
        }
       /*Consulta NumExistente*/
     /*   public void cantAct(string IdActi)
        { 
            
        }*/
       /*Activo area comun*/
        public void ingActAreaCoun(string idActivo, string idArCom, string cant)
        {
            cst.counsultaTodoTipo("insert into EXISTENCIAS values(" + idActivo.Trim() + "," +idArCom.Trim()+ "," + cant.Trim()+ ")");
        }
    }   
}
