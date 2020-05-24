namespace DiplomaProject.Domain.Entities
{
    public class GroundType
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public GroundType(string title)
        {
            Title = title;
        }

        private GroundType()
        {
        }
    }
}