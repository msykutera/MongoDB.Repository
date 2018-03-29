using System;

namespace MongoDB.Repository.Example
{
    [CollectionName("Categories")]
    public class Category : Entity
    {
        public string Name { get; set; }

        public int Status { get; set; }

        //public DateTime CreatedOn { get; set; } = DateTime.Now;

        //public DateTime? Modified { get; set; }
    }
}