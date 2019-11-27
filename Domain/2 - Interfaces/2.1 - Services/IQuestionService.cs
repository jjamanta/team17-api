
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IQuestionService : _IServiceBase<Question>
	{
		IEnumerable<Question> List();

		Question List(string questionId);
		Question Save(Question objQuestion);

		_ReturnProc Delete(string questionId);
	}
}
