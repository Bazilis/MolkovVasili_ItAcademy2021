using System.Collections.Generic;

namespace Hometask5.DAL.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}
