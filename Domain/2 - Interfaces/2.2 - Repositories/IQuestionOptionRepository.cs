
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IQuestionOptionRepository : _IRepositoryBase<QuestionOption>
	{
		IEnumerable<QuestionOption> List();

		QuestionOption List(string questionOptionId);
		QuestionOption Save(QuestionOption objQuestionOption);

		_ReturnProc Delete(string questionOptionId);
	}
}
