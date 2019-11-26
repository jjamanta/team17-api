
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class PersonRepository : _RepositoryBase<Person>, IPersonRepository
	{
		public PersonRepository(IConfiguration config) : base(config) { }

		public IEnumerable<Person> List()
		{
			return ExecuteList("PersonList");
		}

		public Person List(string personId)
		{
			return ExecuteList("PersonList", new object[] {
					new SqlParameter("PersonId", personId)
			}).FirstOrDefault();
		}
		public Person Save(Person objPerson)
		{
			_ReturnProc ret = ExecuteTuple("PersonSave", new object[] {
					new SqlParameter("PersonId0", objPerson.PersonId),
					new SqlParameter("FirstName", objPerson.FirstName),
					new SqlParameter("LastName", objPerson.LastName),
					new SqlParameter("Email", objPerson.Email),
					new SqlParameter("Password", objPerson.Password),
					new SqlParameter("BirthDate", objPerson.BirthDate),
					new SqlParameter("Mobile", objPerson.Mobile),
					new SqlParameter("AddressId", objPerson.AddressId),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new Person
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("PersonList", new object[] {
					new SqlParameter("PersonId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string personId)
		{
			return ExecuteTuple("PersonDelete", new object[] {
					new SqlParameter("PersonId0", personId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

        public Person Authenticate(string email, string password)
        {
            password = Encrypt(password, email);

            return ExecuteList("UserAuthenticate", new object[] {
                    new SqlParameter("email", email),
                    new SqlParameter("password", password)
            }).FirstOrDefault();
        }
    }
}
