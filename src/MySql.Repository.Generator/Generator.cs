using Dapper.Contrib.Extensions;
using Test.Entities;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Entity.Generator
{
    public class Generator
    {
        private string _interfaceTemplate = @"
using {3};
using MySDK.Dapper;
using MySDK.Dapper.Extensions;

namespace {2}
{
    public partial interface I{0}Repository : IDapperRepository<{0}, {1}>
    {
    }
}";

        private string _classTempate = @"
using {3};

namespace {2}
{
    public partial class {0}Repository: MySqlDapperRepository<{0}, {1}>, I{0}Repository
    {
    }
}
";


        public int Generating(string path, string interfaceNamespace = "Test.Repository", string classNamespace = "Test.Repository", string entityNamespace = "Test.Entities")
        {
            var effectCount = 0;
            var assembly = typeof(Order).Assembly;
            var types = assembly.GetTypes();
            Console.WriteLine($"Tables({types.Count()})");

            foreach (var t in types)
            {
                var name = t.Name;
                var key = string.Empty;
                var props = t.GetProperties();
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttributes(typeof(KeyAttribute), true)?.Any() == true || prop.GetCustomAttributes(typeof(ExplicitKeyAttribute), true)?.Any() == true)
                    {
                        key = prop.PropertyType.Name;
                        switch (key)
                        {
                            case "String":
                                key = "string";
                                break;
                            case "Int16":
                            case "Int32":
                                key = "int";
                                break;
                            case "Int64":
                                key = "long";
                                break;
                            default:
                                key = prop.PropertyType.FullName;
                                break;
                        }
                        break;
                    }
                }
                try
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        if (Writing(path, name, key, interfaceNamespace, classNamespace, entityNamespace))
                        {
                            Console.WriteLine($"{name}'s repository created. [OK]");
                            effectCount++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] The entity \"{name}\" don't specify primary key");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
            }
            return effectCount;
        }

        private bool Writing(string dirPath, string name, string key, string interfaceNamespace, string classNamespace, string entityNamespace)
        {
            var interfaceFilePath = Path.Combine(dirPath, "Interface", "I" + name + "Repository.cs");
            if (File.Exists(interfaceFilePath) == false)
            {
                using (var fs = File.Create(interfaceFilePath))
                {
                    var it = _interfaceTemplate.Replace(@"{0}", name)
                        .Replace(@"{1}", key)
                        .Replace(@"{2}", interfaceNamespace)
                        .Replace(@"{3}", entityNamespace);
                    byte[] itb = Encoding.UTF8.GetBytes(it);
                    fs.Write(itb, 0, itb.Length);
                }
            }
            var implementFilePath = Path.Combine(dirPath, "Implement", name + "Repository.cs");
            if (File.Exists(implementFilePath) == false)
            {
                using (var fs = File.Create(implementFilePath))
                {
                    var ct = _classTempate.Replace(@"{0}", name)
                        .Replace(@"{1}", key)
                        .Replace(@"{2}", classNamespace)
                        .Replace(@"{3}", entityNamespace);
                    byte[] ctb = Encoding.UTF8.GetBytes(ct);
                    fs.Write(ctb, 0, ctb.Length);
                }
            }
            return true;
        }

    }
}
