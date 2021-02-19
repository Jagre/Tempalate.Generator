namespace MySQL.Repository.Generator
{
    public class Template
    {
        /// <summary>
        /// Repository interfaces
        /// {0}: namespace
        /// {1}: entity's name
        /// {2}: type of primary key
        /// </summary>
        public const string REPOSITORY_INTERFACE_TEMPLATE = @"
using MySDK.Dapper;

namespace {0} 
{
    public interface I{1}Repository: IDapperRepository<{1}, {2}>
    {
        
    }
}
";


        /// <summary>
        /// Repository base class
        /// {0}: namespace
        /// {1}: database name
        /// {2}: connection name
        /// </summary>
        public const string REPOSITORY_BASE_CLASS_TEMPLATE = @"
using MySDK.Dapper;

namespace {0} 
{
    public class {1}DBRepositoryBase<TTable, TKey>: MySqlDapperRepository<TTable, Key>
    {
        public {1}DBRepositoryBase()
            :base(MyServiceProvider.Configuration, {2})
        {
        }
    }
}
";


        /// <summary>
        /// Repository classes
        /// {0}: namespace
        /// {1}: entity's name
        /// {2}: type of primary key
        /// </summary>
        public const string REPOSITORY_CLASS_TEMPLATE = @"
using MySDK.Dapper;

namespace {0} 
{
    public class {1}Repository: MySqlDapperRepository<{1}, {2}>, I{1}Repository
    {
        
    }
}
";
    }
}
