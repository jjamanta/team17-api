
using System;

namespace Team17.Domain.Entities
{
	public class Student : Person
    {
		public string StudentId { get; set; }
		public string SchoolId { get; set; }
		public byte GradeId { get; set; }
		public string Notes { get; set; }
	}
}
