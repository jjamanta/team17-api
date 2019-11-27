 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class QuestionOptionService : _ServiceBase<QuestionOption>, IQuestionOptionService
	{
		private readonly IQuestionOptionRepository m_QuestionOptionRepository;

		public QuestionOptionService(IQuestionOptionRepository questionoptionRepository)
			: base(questionoptionRepository)
		{
			m_QuestionOptionRepository = questionoptionRepository;
		}

		public IEnumerable<QuestionOption> List()
		{
			m_QuestionOptionRepository.PersonId = this.PersonId;
			return m_QuestionOptionRepository.List();
		}

		public QuestionOption List(string questionOptionId)
		{
			m_QuestionOptionRepository.PersonId = this.PersonId;
			return m_QuestionOptionRepository.List(questionOptionId);
		}
		public QuestionOption Save(QuestionOption objQuestionOption)
		{
			m_QuestionOptionRepository.PersonId = this.PersonId;
			return m_QuestionOptionRepository.Save(objQuestionOption);
		}

		public _ReturnProc Delete(string questionOptionId)
		{
			m_QuestionOptionRepository.PersonId = this.PersonId;
			return m_QuestionOptionRepository.Delete(questionOptionId);
		}
	}
}
