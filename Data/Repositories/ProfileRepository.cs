
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class ProfileRepository : _RepositoryBase<Profile>, IProfileRepository
	{
		public ProfileRepository(IConfiguration config) : base(config) { }

		public IEnumerable<Profile> List()
		{
			return ExecuteList("ProfileList");
		}

		public Profile List(string profileId)
		{
			return ExecuteList("ProfileList", new object[] {
					new SqlParameter("ProfileId", profileId)
			}).FirstOrDefault();
		}
		public Profile Save(Profile objProfile)
		{
			_ReturnProc ret = ExecuteTuple("ProfileSave", new object[] {
					new SqlParameter("ProfileId", objProfile.ProfileId),
					new SqlParameter("ProfileDesc", objProfile.ProfileDesc),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new Profile
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("ProfileList", new object[] {
					new SqlParameter("ProfileId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string profileId)
		{
			return ExecuteTuple("ProfileDelete", new object[] {
					new SqlParameter("ProfileId", profileId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
