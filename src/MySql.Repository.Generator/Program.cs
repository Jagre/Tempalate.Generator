using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Generator
{
    public class Program
    {
        static void Main(string[] args)
        {

            var generator = new Generator();
            var path = string.Empty;
            var interfaceNamespace = string.Empty;
            var classNamespace = string.Empty;
            var entityNamespace = string.Empty;
            var count = generator.Generating(path, interfaceNamespace, classNamespace, entityNamespace);
            Console.WriteLine($"Total created {count} repositories, Done, Done, Done !!!");
        }
    }
}
