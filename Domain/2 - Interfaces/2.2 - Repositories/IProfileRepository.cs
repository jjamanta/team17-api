
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IProfileRepository : _IRepositoryBase<Profile>
	{
		IEnumerable<Profile> List();

		Profile List(string profileId);
		Profile Save(Profile objProfile);

		_ReturnProc Delete(string profileId);
	}
}
