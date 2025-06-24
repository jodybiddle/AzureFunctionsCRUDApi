using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Skill { get; set; }
        public string Comment { get; set; }
    }
}
