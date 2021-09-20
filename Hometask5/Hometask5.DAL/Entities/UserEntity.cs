namespace Hometask5.DAL.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CompanyEntity Company { get; set; }
    }
}
