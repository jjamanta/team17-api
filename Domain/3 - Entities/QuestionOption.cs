
using System;

namespace Team17.Domain.Entities
{
	public class QuestionOption : _EntityBase
	{
		public int QuestionOptionId { get; set; }
		public int QuestionId { get; set; }
		public byte OptionOrder { get; set; }
		public string OptionValue { get; set; }
	}
}
