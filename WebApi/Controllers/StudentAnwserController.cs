 
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
	public class StudentAnwserController : _ApiBaseController
	{
		private readonly IStudentAnwserService m_StudentAnwserService;

		public StudentAnwserController(IStudentAnwserService studentanwserService)
		{
			m_StudentAnwserService = studentanwserService;
		}

		[HttpGet]
		public IEnumerable<StudentAnwser> List()
		{
			m_StudentAnwserService.PersonId = this.PersonId;
			return m_StudentAnwserService.List();
		}

		[HttpGet("{id}")]
		public StudentAnwser List(int id)
		{
			m_StudentAnwserService.PersonId = this.PersonId;
			return m_StudentAnwserService.List(id);
		}
		[HttpPost]
		public StudentAnwser Save(StudentAnwser objStudentAnwser)
		{
			m_StudentAnwserService.PersonId = this.PersonId;
			return m_StudentAnwserService.Save(objStudentAnwser);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(int id)
		{
			m_StudentAnwserService.PersonId = this.PersonId;
			return m_StudentAnwserService.Delete(id);
		}
	}
}
