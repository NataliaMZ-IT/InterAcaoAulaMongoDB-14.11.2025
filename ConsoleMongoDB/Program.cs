using MongoDB.Driver;

var client = new MongoClient("mongodb+srv://zamperlinin_db_user:ZfB58vQhhP9OJRps@interacaomongo.sqakavi.mongodb.net/");

var database = client.GetDatabase("InterAcaoMongoDB"); // use 'nomeDoBanco' - creates database if doesn't exist

var collection = database.GetCollection<User>("Usuarios");  // creates collection if doesn't exist

#region CRUD - Create
// Add one document (data register) with .InsertOne(document)
var newUser = new User("Felipe", "123@mudar");
collection.InsertOne(newUser);

// Add multiple documents with .InsertMany(listOfDocuments)
var newUsers = new List<User>();

newUsers.Add(new User("Maria", "123@mudar"));
newUsers.Add(new User("Joao", "123@mudar"));
newUsers.Add(new User("Ana", "123@mudar"));

collection.InsertMany(newUsers);
#endregion

#region CRUD - Read
// Read multiple documents with .Find()
var users = collection.Find(_ => true).ToList();  // _ is the parameter for anything in User

foreach (var person in users)
{
    Console.WriteLine(person);
    Console.WriteLine("-------------------------------");
}
Console.WriteLine("\n\n\n\n");

// Read multiple documents with .Find(filter) based on condition
var usersSpecific = collection.Find(x => x.Login == "Felipe").ToList();  // returns all occurrences in a list
foreach (var person in usersSpecific)
{
    Console.WriteLine(person);
    Console.WriteLine("-------------------------------");
}
Console.WriteLine("\n\n\n\n");

// Read one document with .Find(filter).FirstOrDefault
var user = collection.Find(x => x.Id == "69173975cb42f9c39d52f0c3").FirstOrDefault();  // returns only first occurrence; returns null if not found

Console.WriteLine(user);
#endregion

#region CRUD - Update
// Update one document with .Replace(filter, replacement)
user.Password = "456@mudar";

collection.ReplaceOne(x => x.Id == user.Id, user);  // replaces old user with parameter (in this case, updated user)

Console.WriteLine(collection.Find(x => x.Id == "69173975cb42f9c39d52f0c3").FirstOrDefault());

// Update one document with .Update(filter, .Update)
collection.UpdateOne(
    x => x.Id == "69173975cb42f9c39d52f0c4",
    Builders<User>.Update.Set(x => x.Password, "mudar@123"));
#endregion

#region CRUD - Delete
// Delete one document with .DeleteOne(filter)
collection.DeleteOne(x => x.Id == "69173975cb42f9c39d52f0c4");
#endregion