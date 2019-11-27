 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class QuestionService : _ServiceBase<Question>, IQuestionService
	{
		private readonly IQuestionRepository m_QuestionRepository;

		public QuestionService(IQuestionRepository questionRepository)
			: base(questionRepository)
		{
			m_QuestionRepository = questionRepository;
		}

		public IEnumerable<Question> List()
		{
			m_QuestionRepository.PersonId = this.PersonId;
			return m_QuestionRepository.List();
		}

		public Question List(string questionId)
		{
			m_QuestionRepository.PersonId = this.PersonId;
			return m_QuestionRepository.List(questionId);
		}
		public Question Save(Question objQuestion)
		{
			m_QuestionRepository.PersonId = this.PersonId;
			return m_QuestionRepository.Save(objQuestion);
		}

		public _ReturnProc Delete(string questionId)
		{
			m_QuestionRepository.PersonId = this.PersonId;
			return m_QuestionRepository.Delete(questionId);
		}
	}
}
