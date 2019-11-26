
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IStudentRepository : _IRepositoryBase<Student>
	{
		IEnumerable<Student> List();

		Student List(string studentId);
		Student Save(Student objStudent);

		_ReturnProc Delete(string studentId);
	}
}
