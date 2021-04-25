using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

/*
* Title:Class programan
* Author:Roberto Soliz
* Date:25/04/2021
* Purpose:Use of reflections and implementation in projects
* add Snippet custom
*/

namespace AppReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asmInitial = null;
            Assembly asmBus = null;
            try
            {
                //cargamos el asembly
                asmInitial = Assembly.Load("Business");
                asmBus = Assembly.Load("Initial");

          
                getAssembly(asmInitial, "Business.Employees", "getInformation", "result", new Person
                {
                    name = "Marcela",
                    surName = "Antelo",
                    ci = "895612",
                    city = "Santa Cruz",
                    country = "Bolivia"
                });
               
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------");
                var item = new Person
                {
                    name = "Juan",
                    surName = "Perez",
                    ci = "689524",
                    city = "Cancun",
                    country = "Mexico"
                };
                getAssembly(asmBus, "Initial.Customer", "getInformation", "result", item);
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assembly not found ", ex.Message);
                return;
            }

        }

        public static void getAssembly(Assembly asm, string nameClass, string nameMethod, string propResult, Person item)
        {
            if (asm != null)
            {
                // obtenemos el typo que no es mas que la clase con la que desemos trabajar
                Type objClass = asm.GetType(nameClass);
                try
                {
                    //creamos la instancia
                    object obj = Activator.CreateInstance(objClass, new object[] { });
                    Console.WriteLine("Tenemos instancia de {0}", obj);

                    //obtenemos el metodo
                    MethodInfo getInformation = objClass.GetMethod(nameMethod);

                    //obtenemos las propiedades
                    PropertyInfo resultado = objClass.GetProperty(propResult);

                    string respuesta = string.Empty;

                    //invocamos al metodo 
                    getInformation.Invoke(obj, new object[] { item.name, item.surName, item.ci, item.city, item.country });

                    respuesta = (string)resultado.GetValue(obj);

                    //Imprimimos la respuesta
                    Console.WriteLine("El resultado es: {0} ", respuesta);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
