
using System;

namespace Team17.Domain.Entities
{
	public class Question : _EntityBase
	{
		public int QuestionId { get; set; }
		public string QuestionDesc { get; set; }
	}
}
