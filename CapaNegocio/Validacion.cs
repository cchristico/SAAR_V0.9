using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAAR.Negocio
{
    class Validacion
    {
        public string Verificar_Cedula(String CI)
        {
            string Mensaje = "";
            if (CI.Length == 10)
            {
                // Busqueda del tercer digito
                int tercerDigito = int.Parse(CI.Substring(2, 1));
                if (tercerDigito <= 6)
                {
                    int[] coefValCedula = { 2, 1, 2, 1, 2, 1, 2, 1, 2 }; // vetor
                    int verificador = int.Parse(CI.Substring(9, 1)); // El decimo digito se
                    // lo considera dígito verificador
                    int suma = 0;
                    int digito = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        digito = int.Parse(CI.Substring(i, 1)) * coefValCedula[i];
                        suma += ((digito % 10) + (digito / 10));
                    }

                    // Validacion de numero existente comprobnado con el
                    // numero verificador , que es el de la posicon 10
                    if ((suma % 10 == 0) && (suma % 10 == verificador))
                    {

                    }
                    else if ((10 - (suma % 10)) == verificador)
                    {

                    }
                    else
                    {

                        Mensaje += "Numero verificador (ultimo numero) es Incorrecto\n";
                    }
                }
                else
                {
                    // si el tercer digito no es menor
                    // q 6 la cedula no existe
                    Mensaje += "El tercer numero debe ser menor que 6\n";
                }
            }
            else
            {

                Mensaje += "Verifique la longitud del número de cedula";
            }


            return Mensaje;
        }


    }
}
