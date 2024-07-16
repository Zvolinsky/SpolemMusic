using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpolemMusic.Auth.Models;
using SpolemMusic.Auth.Services;
using SpolemMusic.Data;
using SpolemMusic.Data.Models;
using System.Security.Cryptography;

namespace SpolemMusic.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly EmailSender _emailSender;

        public ClientController(AppDBContext context, EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ClientRegisterRequest request)
        {
            if(_context.Clients.Any(u => u.Email == request.Email)) 
            {
                return BadRequest("Użytkownik z tym adresem e-mail już istnieje.");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var client = new Client
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            var subject = "SpołemMusic - weryfikacja konta";
            var content = $"Twój token to: {client.VerificationToken}";

            _emailSender.SendVerificationEmail(client.Email, subject, content);

            return Ok("Użytkownik zarejestrowany.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(ClientLoginRequest request)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(u => u.Email == request.Email);
            if(client == null)
            {
                return BadRequest("User not found.");
            }
            if(!VerifyPasswordHash(request.Password, client.PasswordHash, client.PasswordSalt))
            {
                return BadRequest("Something is incorrent.");
            }
            if(client.VerifiedAt == null)
            {
                return BadRequest("Not verified.");
            }
            
            return Ok(client);
        }
        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if(client == null)
            {
                return BadRequest("Nieprawidłowy token.");
            }
            
            client.VerifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            
            return Ok("Użytkownik zweryfikowany.");
        }

        
    }
}
/*
{
  "firstName": "Fabian",
  "lastName": "Farian",
  "address": "Rymanowska 27",
  "phoneNumber": "630157783",
  "email": "ffarian@gmail.com",
  "password": "Beach777!",
  "confirmPassword": "Beach777!"
}
 */