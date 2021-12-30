namespace LibraryWda.API.Models
{
    public class PublishingCompany
    {
        public PublishingCompany() { }
        public PublishingCompany(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
    }
}
