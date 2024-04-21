using System.Data.SqlClient;
using WebApplicationAnimal.Models;

namespace WebApplicationAnimal.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {

        private IConfiguration _configuration;
        public AnimalsRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public IEnumerable<Animal> FetchAnimals(string orderBy)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"SELECT Id, Name, Description, Category, Area FROM Animals ORDER BY {orderBy}";

            var dr = cmd.ExecuteReader();
            var animals = new List<Animal>();
            while (dr.Read())
            {
                var animal = new Animal
                {
                    Id = (int)dr["Id"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString(),
                };
                animals.Add(animal);
            }

            return animals;
        }

        public int AddAnimal(Animal newAnimal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animals(Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
            cmd.Parameters.AddWithValue("@Name", newAnimal.Name);
            if (newAnimal.Description != null)
            {
                cmd.Parameters.AddWithValue("@Description", newAnimal.Description);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Description", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@Category", newAnimal.Category);
            cmd.Parameters.AddWithValue("@Area", newAnimal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
    }
}
