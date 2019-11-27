
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class StudentAnwserRepository : _RepositoryBase<StudentAnwser>, IStudentAnwserRepository
	{
		public StudentAnwserRepository(IConfiguration config) : base(config) { }

		public IEnumerable<StudentAnwser> List()
		{
			return ExecuteList("StudentAnwserList");
		}

		public StudentAnwser List(int questionOptionId)
		{
			return ExecuteList("StudentAnwserList", new object[] {
					new SqlParameter("QuestionOptionId", questionOptionId)
			}).FirstOrDefault();
		}
		public StudentAnwser Save(StudentAnwser objStudentAnwser)
		{
			_ReturnProc ret = ExecuteTuple("StudentAnwserSave", new object[] {
					new SqlParameter("QuestionOptionId", objStudentAnwser.QuestionOptionId),
					new SqlParameter("StudentId", objStudentAnwser.StudentId),
					new SqlParameter("QuestionOptionId", objStudentAnwser.QuestionOptionId),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new StudentAnwser
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("StudentAnwserList", new object[] {
					new SqlParameter("StudentAnwserId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(int questionOptionId)
		{
			return ExecuteTuple("StudentAnwserDelete", new object[] {
					new SqlParameter("QuestionOptionId", questionOptionId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
