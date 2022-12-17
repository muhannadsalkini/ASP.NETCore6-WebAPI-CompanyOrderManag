namespace CompanyOrderManag.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool state { get; set; }
        public TimeSpan PomationStartTime { get; set; }
        public TimeSpan PromationEndTime { get; set; }
    }
}
