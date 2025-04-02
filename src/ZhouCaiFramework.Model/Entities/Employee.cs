using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// Ô±¹¤
    /// </summary>
    public class Employee
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        [SugarColumn(Length = 50)]
        public string Name { get; set; }

        [SugarColumn(Length = 20)]
        public string Phone { get; set; }

        [SugarColumn(Length = 50)]
        public string Position { get; set; }

        [SugarColumn(Length = 50)]
        public string Department { get; set; }

        public int Status { get; set; }

        [SugarColumn(Length = 50)]
        public string Email { get; set; }

        public DateTime JoinDate { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LeaveDate { get; set; }

        [SugarColumn(Length = 500)]
        public string Responsibilities { get; set; }

        [SugarColumn(Length = 50)]
        public string EmployeeNumber { get; set; }

        [SugarColumn(Length = 100)]
        public string ProfileImg { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public string Salt { get; set; }

        [SugarColumn(Length = 50)]
        public string Role { get; set; }
    }
}