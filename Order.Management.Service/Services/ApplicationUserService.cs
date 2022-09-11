using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using Order.Management.Core.Model;
using Order.Management.Core.Repositories;
using Order.Management.Core.Services;
using Order.Management.Core.UnitOfWork;
using Order.Management.DataAccess.Repositories;
using Order.Management.Service.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Service.Services
{
    public class ApplicationUserService : Service<ApplicationUser>,IApplicationUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IConfiguration _configuration;
        public ApplicationUserService(IGenericRepository<ApplicationUser> repository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IApplicationUserRepository applicationUserRepository, IConfiguration configuration) : base(repository, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _applicationUserRepository = applicationUserRepository;
            _configuration = configuration;
        }

        public string Authenticate(AuthenticateRequest model)
        {
            var user = _applicationUserRepository.GetAll(i=>i.IsActive==Active.Active).ToList().FirstOrDefault(i=>i.Username==model.Username && i.Password==model.Password);
            if (user!=null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                    new Claim(ClaimTypes.Name,user.Username)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;

        }

        public ApplicationUser GetById(int id)
        {
            return  _applicationUserRepository.GetByIdAsync(id).Result;
                
        }
        
    }
}
