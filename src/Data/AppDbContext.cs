using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using NetCoreMongoDb.Models;

namespace NetCoreMongoDb.Data
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _database;

        //Obter a coleção do objeto Pessoa, que será chamada "pessoas"
        public IMongoCollection<Pessoa> Pessoas => _database.GetCollection<Pessoa>("pessoas");

        public AppDbContext()
        {
            //Podemos definir algumas convenções antes de instanciar o client do MongoDB
            //Ou podemos utilizar annotations nas classes
            //Irei demonstrar as duas formas

            //Aqui vamos algumas convenções que serão aplicadas a todos os objetos 
            var conventionPack = new ConventionPack
            {
                //Definir que o nome dos atributos devem ser salvos no formato camelCase 
                new CamelCaseElementNameConvention(),
                
                //Definir que todo ENUM deve ser salvo como string no banco 
                new EnumRepresentationConvention(BsonType.String),
            };

            //Registrar as convenções
            ConventionRegistry.Register("conventions", conventionPack, _ => true);



            //Por padão, o MongoDB salva os objetos DateTime como UTC
            //Para selecionarmos um DateTime e ele converter para o horário local, devemos registrar um Serializer
            BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);

            //Criar o client do MongoDB passando a url de conexão
            var client = new MongoClient("mongodb://localhost:27017/");

            //Definir qual o nome do banco de dados que nossa aplicação irá utilizar
            _database = client.GetDatabase("net-core-mongo-db");
        }
    }
}