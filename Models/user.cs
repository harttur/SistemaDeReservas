using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaDeReservas.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!; // Usar null! para indicar que será inicializado

        public string Name { get; set; } = null!; // Usar null! para indicar que será inicializado

        public string Email { get; set; } = null!; // Usar null! para indicar que será inicializado

        public User() { } // Construtor padrão

        // Você pode adicionar um construtor com parâmetros, se necessário
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
