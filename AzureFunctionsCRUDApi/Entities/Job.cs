using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Entities
{
    public class Job : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Comment { get; set; }
    }
}
