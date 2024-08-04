using System.Data;
using WebApiUsingDotNet.Data;
using WebApiUsingDotNet.Model;
using Dapper;

namespace WebApiUsingDotNet.Services
{
    public class PokemonService
    {
        private readonly ApplicationDbContext _context;

        public PokemonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pokemon> GetAllPokemon()
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                return dbConnection.Query<Pokemon>("GetAllPokemon", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Pokemon GetPokemonById(int id)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                return dbConnection.Query<Pokemon>("GetPokemonById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void CreatePokemon(Pokemon pokemon)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Name", pokemon.Name, DbType.String);
                parameters.Add("Type", pokemon.Type, DbType.String);
                parameters.Add("Level", pokemon.Level, DbType.Int32);
                parameters.Add("Region", pokemon.Region, DbType.String);

                dbConnection.Execute("CreatePokemon", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", pokemon.Id, DbType.Int32);
                parameters.Add("Name", pokemon.Name, DbType.String);
                parameters.Add("Type", pokemon.Type, DbType.String);
                parameters.Add("Level", pokemon.Level, DbType.Int32);
                parameters.Add("Region", pokemon.Region, DbType.String);

                dbConnection.Execute("UpdatePokemon", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePokemon(int id)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                dbConnection.Execute("DeletePokemon", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
