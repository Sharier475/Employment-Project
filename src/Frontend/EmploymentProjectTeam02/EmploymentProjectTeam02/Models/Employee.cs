namespace EmploymentProjectTeam02.Models
{
    public class Employee
    {
        int id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? gender { get; set; }
        public int departmentId { get; set; }
        public Department? department { get; set; }
        public DateTime joiningdate { get; set; }
        public Boolean ssc { get; set; }
        public Boolean hsc { get; set; }
        public Boolean bsc { get; set; }
        public Boolean msc { get; set; }
        public string? picture { get; set; }
        public int countryId { get; set; }
        public Country? country { get; set; }
        public int stateId { get; set; }
        public State? state { get; set; }
        public int cityId { get; set; }
        public City? city { get; set; }
    }
}
