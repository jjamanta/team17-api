﻿ 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Team17.Library;
using Microsoft.Extensions.Options;

namespace Team17.Domain.Services
{
	public class PersonService : _ServiceBase<Person>, IPersonService
	{
		private readonly IPersonRepository m_PersonRepository;

        private readonly AppSettings m_AppSettings;

        public PersonService(IPersonRepository personRepository, IOptions<AppSettings> appSettings)
			: base(personRepository)
		{
			m_PersonRepository = personRepository;
            m_AppSettings = appSettings.Value;
        }

        public Person Authenticate(string email, string password)
        {
            Person person = m_PersonRepository.Authenticate(email, password);

            // return null if user not found
            if (person == null)
            {
                return null;
            }
                
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(m_AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, person.PersonId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            User user = new User
            {
                AddressId = person.AddressId,
                BirthDate = person.BirthDate,
                Email = person.Email,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonId = person.PersonId,
                Token = tokenHandler.WriteToken(token),
                // remove password before returning
                Password = null
                //Director =
                //Student = 
            };

            return user;
        }

        public IEnumerable<Person> List()
		{
			m_PersonRepository.PersonId = this.PersonId;
			return m_PersonRepository.List();
		}

		public Person List(string personId)
		{
			m_PersonRepository.PersonId = this.PersonId;
			return m_PersonRepository.List(personId);
		}
		public Person Save(Person objPerson)
		{
			m_PersonRepository.PersonId = this.PersonId;
			return m_PersonRepository.Save(objPerson);
		}

		public _ReturnProc Delete(string personId)
		{
			m_PersonRepository.PersonId = this.PersonId;
			return m_PersonRepository.Delete(personId);
		}
	}
}
