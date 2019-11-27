
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class RankProfileRepository : _RepositoryBase<RankProfile>, IRankProfileRepository
	{
		public RankProfileRepository(IConfiguration config) : base(config) { }

		public IEnumerable<RankProfile> List()
		{
			return ExecuteList("RankProfileList");
		}

		public RankProfile List(int profileId)
		{
			return ExecuteList("RankProfileList", new object[] {
					new SqlParameter("ProfileId", profileId)
			}).FirstOrDefault();
		}
		public RankProfile Save(RankProfile objRankProfile)
		{
			_ReturnProc ret = ExecuteTuple("RankProfileSave", new object[] {
					new SqlParameter("ProfileId", objRankProfile.ProfileId),
					new SqlParameter("QuestionOptionId", objRankProfile.QuestionOptionId),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new RankProfile
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("RankProfileList", new object[] {
					new SqlParameter("RankProfileId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(int profileId)
		{
			return ExecuteTuple("RankProfileDelete", new object[] {
					new SqlParameter("ProfileId", profileId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
