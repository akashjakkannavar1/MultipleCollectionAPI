using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDbAPI.Models
{
    public class MultipleDbAPIDatabaseSettings:IMultipleDbAPIDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string employeeCollectionName { get; set; }
        public string departmentCollectionName { get; set; }
    }
    public interface IMultipleDbAPIDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string employeeCollectionName { get; set; }
        string departmentCollectionName { get; set; }
    }
}
