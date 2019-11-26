
using System;

namespace Team17.Domain.Entities
{
    public class User : Person
    {
        public bool Student { get; set; }
        public bool Director { get; set; }
        public string Token { get; set; }

    }
}
