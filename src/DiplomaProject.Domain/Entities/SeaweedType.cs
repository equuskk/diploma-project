namespace DiplomaProject.Domain.Entities
{
    public class SeaweedType
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public SeaweedType(string title)
        {
            Title = title;
        }

        private SeaweedType()
        {
        }
    }
}