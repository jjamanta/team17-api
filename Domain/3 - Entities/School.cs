
using System;

namespace Team17.Domain.Entities
{
	public class School : _EntityBase
	{
		public string SchoolId { get; set; }
		public string SchoolName { get; set; }
		public string AddressId { get; set; }
		public string DirectorId { get; set; }
	}
}
