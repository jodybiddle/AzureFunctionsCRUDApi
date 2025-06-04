using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCRUDApi.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Comment { get; set; }
    }
}
