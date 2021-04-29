using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;
using System.Data;

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
        public const string ASSEMBLY_PROYECT_NAME = "Initial";
        public const string ASSEMBLY_CLASS_NAME = "Conection";
        public const string ASSEMBLY_METHOD_NAME = "GetDataInformation";
        static void Main(string[] args)
        {
            Assembly asm = null;

            try
            {
                asm = Assembly.Load(ASSEMBLY_PROYECT_NAME);

                Console.WriteLine("-------------------------------------------------");
                string assemblyClassName = $"{ASSEMBLY_PROYECT_NAME}.{ASSEMBLY_CLASS_NAME}";

                getAssemblyData(asm, assemblyClassName, ASSEMBLY_METHOD_NAME);

                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assembly not found ", ex.Message);
                return;
            }

        }

        public static void getAssemblyData(Assembly asm, string className, string methodName)
        {
            if (asm != null)
            {
                // obtenemos el typo que no es mas que la clase con la que desemos trabajar
                Type objClass = asm.GetType(className);
                try
                {
                    //creamos la instancia
                    object obj = Activator.CreateInstance(objClass, new object[] { });
                    Console.WriteLine($"PROYECT NAME AND CLASS NAME {obj}");

                    //obtenemos el metodo
                    MethodInfo getInformation = objClass.GetMethod(methodName);

                    ////obtenemos las propiedades
                    //PropertyInfo resultado = objClass.GetProperty(propResult);

                    DataSet assemblyDts = new DataSet();

                    //invocamos al metodo 
                    int queryRange = 100;
                    getInformation.Invoke(obj, new object[] { $"select top { queryRange }  Id_Test, Name_Test, Description_Test, DataCreazione_Test from [test].[Add_Test]" , queryRange, assemblyDts });

                    Console.WriteLine("-------------------------------------------------");
                    foreach (DataRow row in assemblyDts.Tables[0].Rows)
                    {
                        Console.WriteLine($"{row.ItemArray[0]}  {row.ItemArray[1]}   {row.ItemArray[2]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }



    }
}
