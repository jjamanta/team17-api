
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class QuestionOptionRepository : _RepositoryBase<QuestionOption>, IQuestionOptionRepository
	{
		public QuestionOptionRepository(IConfiguration config) : base(config) { }

		public IEnumerable<QuestionOption> List()
		{
			return ExecuteList("QuestionOptionList");
		}

		public QuestionOption List(string questionOptionId)
		{
			return ExecuteList("QuestionOptionList", new object[] {
					new SqlParameter("QuestionOptionId", questionOptionId)
			}).FirstOrDefault();
		}
		public QuestionOption Save(QuestionOption objQuestionOption)
		{
			_ReturnProc ret = ExecuteTuple("QuestionOptionSave", new object[] {
					new SqlParameter("QuestionOptionId", objQuestionOption.QuestionOptionId),
					new SqlParameter("QuestionId", objQuestionOption.QuestionId),
					new SqlParameter("OptionOrder", objQuestionOption.OptionOrder),
					new SqlParameter("OptionValue", objQuestionOption.OptionValue),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new QuestionOption
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("QuestionOptionList", new object[] {
					new SqlParameter("QuestionOptionId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string questionOptionId)
		{
			return ExecuteTuple("QuestionOptionDelete", new object[] {
					new SqlParameter("QuestionOptionId", questionOptionId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
