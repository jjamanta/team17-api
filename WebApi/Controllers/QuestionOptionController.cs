 
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
	public class QuestionOptionController : _ApiBaseController
	{
		private readonly IQuestionOptionService m_QuestionOptionService;

		public QuestionOptionController(IQuestionOptionService questionoptionService)
		{
			m_QuestionOptionService = questionoptionService;
		}

		[HttpGet]
		public IEnumerable<QuestionOption> List()
		{
			m_QuestionOptionService.PersonId = this.PersonId;
			return m_QuestionOptionService.List();
		}

		[HttpGet("{id}")]
		public QuestionOption List(string id)
		{
			m_QuestionOptionService.PersonId = this.PersonId;
			return m_QuestionOptionService.List(id);
		}
		[HttpPost]
		public QuestionOption Save(QuestionOption objQuestionOption)
		{
			m_QuestionOptionService.PersonId = this.PersonId;
			return m_QuestionOptionService.Save(objQuestionOption);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_QuestionOptionService.PersonId = this.PersonId;
			return m_QuestionOptionService.Delete(id);
		}
	}
}
