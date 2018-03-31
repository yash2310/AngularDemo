namespace Web.ApplicationCore.Entities
{
    public class Setting : BaseEntity
    {
        public string Name { get; set; }
        public int Days { get; set; }
    }
}