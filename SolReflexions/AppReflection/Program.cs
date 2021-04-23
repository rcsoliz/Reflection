using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;
 
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Assembly not found ", ex.Message);
                return;
            }

            if (asmInitial != null)
            {
                // obtenemos el typo que no es mas que la clase con la que desemos trabajar
                Type employess = asmInitial.GetType("Business.Employees");

                try
                {
                    //creamos la instancia
                    object obj = Activator.CreateInstance(employess, new object[] { });
                    Console.WriteLine("Tenemos instancia de {0}", obj);

                    //obtenemos el metodo
                    MethodInfo getInformation = employess.GetMethod("getInformation");

                    //obtenemos las propiedades
                    PropertyInfo resultado = employess.GetProperty("result");

                    string respuesta = string.Empty;

                    //invocamos al metodo 
                    getInformation.Invoke(obj, new object[] { "Marcela", "Antelo", "895612", "Santa Cruz", "Bolivia" });

                    respuesta = (string)resultado.GetValue(obj);

                    //Imprimimos la respuesta
                    Console.WriteLine("El resultado es: {0} ", respuesta);


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            
            if(asmBus != null)
            {
                // obtenemos el typo que no es mas que la clase con la que desemos trabajar
                Type customer = asmBus.GetType("Initial.Customer");
                try
                {
                    //creamos la instancia
                    object obj = Activator.CreateInstance(customer, new object[] { });
                    Console.WriteLine("Tenemos instancia de {0}", obj);

                    //obtenemos el metodo
                    MethodInfo getInformation = customer.GetMethod("getInformation");

                    //obtenemos las propiedades
                    PropertyInfo resultado = customer.GetProperty("result");

                    string respuesta = string.Empty;

                    //invocamos al metodo 
                    getInformation.Invoke(obj, new object[] { "Juan", "Perez", "689524", "Cancun", "Mexico" });

                    respuesta = (string)resultado.GetValue(obj);

                    //Imprimimos la respuesta
                    Console.WriteLine("El resultado es: {0} ", respuesta);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.Read();


        }
    }
}
