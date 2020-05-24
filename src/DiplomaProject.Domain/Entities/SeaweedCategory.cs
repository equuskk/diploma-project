namespace DiplomaProject.Domain.Entities
{
    public class SeaweedCategory
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public SeaweedCategory(string title)
        {
            Title = title;
        }

        private SeaweedCategory()
        {
        }
    }
}