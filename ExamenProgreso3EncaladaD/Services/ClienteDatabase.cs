using SQLite;
using ExamenProgreso3EncaladaD.Models;

namespace ExamenProgreso3EncaladaD.Services
{
    public class ClienteDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public ClienteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Cliente>().Wait();
        }

        public Task<List<Cliente>> GetClientesAsync() => _database.Table<Cliente>().ToListAsync();

        public Task<int> AddClienteAsync(Cliente cliente) => _database.InsertAsync(cliente);
    }
}
