using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Initial;
namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Assembly asmInitial = null;
            try
            {
                asmInitial = Assembly.Load("Initial");

                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------");

                getAssemblyData();

                Console.Read();
            }
            catch(Exception ex)
            {

            }  
        }

        public static void getAssemblyData()
        {
            try
            {
                string consulta = "select * from showmy.ads";
                Conection objConection = new Conection();

                DataSet dt = new DataSet();
                objConection.Consult(consulta);
                dt = objConection.dsDatos;
                DataSet dto = new DataSet();
                dto = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void getAssemblyData(Assembly asm, string nameClass, string nameMethod, string propResult)
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

                    DataSet respuesta = new DataSet();

                    //invocamos al metodo 
                    getInformation.Invoke(obj, new object[] { "select * from showmy.ads" });

                    respuesta = (DataSet)resultado.GetValue(obj);

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
