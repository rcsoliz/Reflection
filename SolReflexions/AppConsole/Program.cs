using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asmInitial = null;
            try
            {
                //cargamos el asembly
                asmInitial = Assembly.Load("Business");
                encuentraTipos(asmInitial);
                
                Console.Read();
            }catch(Exception ex)
            {
                Console.WriteLine("Assembly not found ", ex.Message);
            }
        }
        private static void encuentraTipos(Assembly asm)
        {
            //Monstramos el nombre del Assembly
            Console.WriteLine("The types found in {0} are: " , asm.FullName );

            //Obtenemos los tipos
            Type[] types = asm.GetTypes();

            //Los despleagamos
            foreach (Type t in types)
                Console.WriteLine(t);
        }

    }
}
