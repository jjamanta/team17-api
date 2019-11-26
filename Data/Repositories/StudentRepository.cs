
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class StudentRepository : _RepositoryBase<Student>, IStudentRepository
	{
		public StudentRepository(IConfiguration config) : base(config) { }

		public IEnumerable<Student> List()
		{
			return ExecuteList("StudentList");
		}

		public Student List(string studentId)
		{
			return ExecuteList("StudentList", new object[] {
					new SqlParameter("StudentId", studentId)
			}).FirstOrDefault();
		}
		public Student Save(Student objStudent)
		{
			_ReturnProc ret = ExecuteTuple("StudentSave", new object[] {
					new SqlParameter("StudentId", objStudent.StudentId),
					new SqlParameter("SchoolId", objStudent.SchoolId),
					new SqlParameter("GradeId", objStudent.GradeId),
					new SqlParameter("Notes", objStudent.Notes),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new Student
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("StudentList", new object[] {
					new SqlParameter("StudentId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string studentId)
		{
			return ExecuteTuple("StudentDelete", new object[] {
					new SqlParameter("StudentId", studentId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
