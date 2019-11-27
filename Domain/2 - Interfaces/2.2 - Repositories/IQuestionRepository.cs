
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IQuestionRepository : _IRepositoryBase<Question>
	{
		IEnumerable<Question> List();

		Question List(string questionId);
		Question Save(Question objQuestion);

		_ReturnProc Delete(string questionId);
	}
}
