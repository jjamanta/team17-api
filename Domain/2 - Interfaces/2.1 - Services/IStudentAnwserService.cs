
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IStudentAnwserService : _IServiceBase<StudentAnwser>
	{
		IEnumerable<StudentAnwser> List();

		StudentAnwser List(int questionOptionId);
		StudentAnwser Save(StudentAnwser objStudentAnwser);

		_ReturnProc Delete(int questionOptionId);
	}
}
