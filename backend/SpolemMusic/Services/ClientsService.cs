using SpolemMusic.Data;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.Models;

namespace SpolemMusic.Server.Services
{
    public class ClientsService
    {
        private AppDBContext _context;

        public ClientsService(AppDBContext context) { _context = context; }

        public List<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }

        public Client AddClient(ClientDTO client)
        {
            var _client = new Client()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                PasswordHash = client.PasswordHash,
            };
            _context.Clients.Add(_client);
            _context.SaveChanges();

            return _client;
        }

        public void UpdateClient(ClientDTO client, int id)
        {
            var _client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (_client != null)
            {
                _client.FirstName = client.FirstName;
                _client.LastName = client.LastName;
                _client.Address = client.Address;
                _client.Email = client.Email;
                _client.PhoneNumber = client.PhoneNumber;
                _client.PasswordHash = client.PasswordHash;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteClient(int id)
        {
            var _client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (_client != null)
            {
                _context.Clients.Remove(_client);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
