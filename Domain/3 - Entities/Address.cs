
using System;

namespace Team17.Domain.Entities
{
	public class Address : _EntityBase
	{
		public string AddressId { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string Neighbourhood { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public int CountryId { get; set; }
	}
}
