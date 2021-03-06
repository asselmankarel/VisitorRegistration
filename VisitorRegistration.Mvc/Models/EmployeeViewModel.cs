namespace VisitorRegistration.Mvc.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
