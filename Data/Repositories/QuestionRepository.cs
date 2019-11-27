
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class QuestionRepository : _RepositoryBase<Question>, IQuestionRepository
	{
		public QuestionRepository(IConfiguration config) : base(config) { }

		public IEnumerable<Question> List()
		{
			return ExecuteList("QuestionList");
		}

		public Question List(string questionId)
		{
			return ExecuteList("QuestionList", new object[] {
					new SqlParameter("QuestionId", questionId)
			}).FirstOrDefault();
		}
		public Question Save(Question objQuestion)
		{
			_ReturnProc ret = ExecuteTuple("QuestionSave", new object[] {
					new SqlParameter("QuestionId", objQuestion.QuestionId),
					new SqlParameter("QuestionDesc", objQuestion.QuestionDesc),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new Question
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("QuestionList", new object[] {
					new SqlParameter("QuestionId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string questionId)
		{
			return ExecuteTuple("QuestionDelete", new object[] {
					new SqlParameter("QuestionId", questionId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
