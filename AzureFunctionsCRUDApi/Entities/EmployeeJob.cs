using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Entities
{
    public class EmployeeJob : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int JobId { get; set; }
    }
}
