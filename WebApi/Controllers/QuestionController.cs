 
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;

namespace Team17.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : _ApiBaseController
	{
		private readonly IQuestionService m_QuestionService;

		public QuestionController(IQuestionService questionService)
		{
			m_QuestionService = questionService;
		}

		[HttpGet]
		public IEnumerable<Question> List()
		{
			m_QuestionService.PersonId = this.PersonId;
			return m_QuestionService.List();
		}

		[HttpGet("{id}")]
		public Question List(string id)
		{
			m_QuestionService.PersonId = this.PersonId;
			return m_QuestionService.List(id);
		}
		[HttpPost]
		public Question Save(Question objQuestion)
		{
			m_QuestionService.PersonId = this.PersonId;
			return m_QuestionService.Save(objQuestion);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_QuestionService.PersonId = this.PersonId;
			return m_QuestionService.Delete(id);
		}
	}
}
