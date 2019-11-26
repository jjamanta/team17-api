
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IStudentService : _IServiceBase<Student>
	{
		IEnumerable<Student> List();

		Student List(string studentId);
		Student Save(Student objStudent);

		_ReturnProc Delete(string studentId);
	}
}
