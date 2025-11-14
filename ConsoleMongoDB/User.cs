using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsActive = true;
    }

    public override string? ToString()
    {
        return $"Id: {Id}\nLogin: {Login}\nPassword: {Password}" +
            $"\nDate of Creation: {CreatedAt}\nLast Update: {UpdatedAt}" +
            $"\nActive: {IsActive}";
    }
}
