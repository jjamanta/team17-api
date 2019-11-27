
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IRankProfileService : _IServiceBase<RankProfile>
	{
		IEnumerable<RankProfile> List();

		RankProfile List(int profileId);
		RankProfile Save(RankProfile objRankProfile);

		_ReturnProc Delete(int profileId);
	}
}
