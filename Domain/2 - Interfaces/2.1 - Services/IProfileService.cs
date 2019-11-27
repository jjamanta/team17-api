
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IProfileService : _IServiceBase<Profile>
	{
		IEnumerable<Profile> List();

		Profile List(string profileId);
		Profile Save(Profile objProfile);

		_ReturnProc Delete(string profileId);
	}
}
