using Skinet.Core.Entities.Base;

namespace Skinet.Core.Entities.Product
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}