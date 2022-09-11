using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Management.Core.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(ApplicationUser user, string token)
        {
            Id = user.Id;
            Username = user.Username;
             Token = token;
        }
    } }
