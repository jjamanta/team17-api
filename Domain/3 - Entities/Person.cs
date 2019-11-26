
using System;

namespace Team17.Domain.Entities
{
	public class Person : _EntityBase
	{
		public string PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime BirthDate { get; set; }
		public string Mobile { get; set; }
		public string AddressId { get; set; }
	}
}
