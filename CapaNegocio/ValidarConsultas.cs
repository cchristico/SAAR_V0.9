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
            //int IdArea; 
            try
            {
               //     DataTable DT = cst.consultar("select IDAREACOMUN from AREACOMUN order by IDAREACOMUN desc");
               //     IdArea= int.Parse(DT.Rows[0][0].ToString()) + 1;
                    string insert = "insert into AREACOMUN values ('" + tipo + "','" + NomAreaCom + "'," + Aforo + ",'" + Disp + "')";
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
       /*Insertar Activo area comun*/
        public void ingActAreaCom(string nombreActivo, string idArCom, string cant)
        {
            //verificacion Nombre activo
            string IDactivo;
            DataTable DT = cst.consultar("select IDACTIVO from ACTIVOS where NOMBRE_ACT='" + nombreActivo + "'");
            IDactivo = DT.Rows[0][0].ToString();
            cst.counsultaTodoTipo("insert into EXISTENCIAS values(" + IDactivo.Trim() + "," + idArCom.Trim() + "," + cant.Trim() + ")");
        }
        /*Eliminar Activo area comun*/
        public void eliminarActAreaCom(string idActiv, string IdAreaCom)
        { 
            cst.counsultaTodoTipo("delete from EXISTENCIAS where IDACTIVO="+idActiv+" and IDAREACOMUN="+IdAreaCom);
        }
        /*Actualizar Activo area comun*/
        // 
        public void actualizarActAreaCom(string cant, string idAct, string idAreCom)
        {
            cst.counsultaTodoTipo("update EXISTENCIAS set CANTIDAD_EXISTENCIAS = "+cant +"where IDACTIVO ="+idAct+" and IDAREACOMUN="+idAreCom);
        }

       /*------------------Activos--------------------------*/
       /*IngresarActivos*/
        public void ingresarActivo(string nombreAct, string obsAct, string cant)
        {
            
            //int idActivo;
              //DataTable DT = cst.consultar("select IDACTIVO from ACTIVOS order by IDACTIVO desc");
             
                  //idActivo = int.Parse(DT.Rows[0][0].ToString()) + 1;
              
            cst.counsultaTodoTipo("insert into ACTIVOS values ('"+nombreAct+"','"+obsAct+"',"+cant+")");
        }
       /*Actualizar Activo*/
       public void actualizarAcivo(string idAct,string nombAct, string obsAct,string cantAct)
        {
            cst.counsultaTodoTipo("update ACTIVOS set NOMBRE_ACT ='"+nombAct+"',OBSERVACION_ACT='"+obsAct+"',CANTIDAD_ACT="+cantAct+"where IDACTIVO = "+idAct);
       }
       /*Elmianr Activo*/
       public void eliminarActivo(string idActivo)
       {
           cst.counsultaTodoTipo("delete from ACTIVOS where IDACTIVO="+ idActivo);
       }
       /*eliminar existencias---si se elimina activos se debe eliminar existencas*/
       public void eliminarExistenciaAct(string idActivo)
       {
           cst.counsultaTodoTipo("delete from EXISTENCIAS where IDACTIVO=" + idActivo);
       }
       /*------------------Personal---------------------*/
       /*Insertar*/
       public void insertarPersonal(string Nombre, string cedula)
       {
           cst.counsultaTodoTipo("insert into PERSONAL values('"+Nombre+"','"+cedula+"')");
       }
       /*Eliminar*/
       public void elimnarPersonal(string idPersonal)
       {
           cst.counsultaTodoTipo("delete from PERSONAL where idpersonal = "+idPersonal);
       }
   /*actualizar*/
       public void actualizarPersonal(string nomrePersonal,string idPersonal)
       {
           cst.counsultaTodoTipo("update PERSONAL set Apellido='"+nomrePersonal+"' where idpersonal ="+idPersonal);
       }


    /*----------------Manteniemiento-----------------------*/
       public void insertarManteniemiento(string idEmpleado, string idAreaComun, string fechaMant, string obser, string costo, string tiempo)

       {

           cst.counsultaTodoTipo("insert into MANTENIMIENTO values("+idEmpleado+","+idAreaComun+","+fechaMant+",'"+obser+"',cast("+costo+"as money),'"+tiempo+"')");
       }

       /*------------------Propietario---------------------*/
       /*Insertar*/
       public void insertarPropietario(string cedula, string Apellido, string Nombre)
       {
           cst.counsultaTodoTipo("insert into PROPIETARIOS values('" + cedula + "','" + Apellido + "','" + Nombre + "')");
       }
       /*Eliminar*/
       public void elimnarPropietario(string idPropietarios)
       {
           cst.counsultaTodoTipo("delete from PROPIETARIOS where IDPROP = " + idPropietarios);
       }
       /*actualizar*/
       public void actualizarPropietario(string cedula, string Apellido, string Nombre, string idPropietarios)
       {
           cst.counsultaTodoTipo("update PROPIETARIOS set CIPROP='" + cedula + "',APELLIDOPROP='" + Apellido + "',NOMBREPROP='" + Nombre + "' where IDPROP = " + idPropietarios);
       }

    }   
}
