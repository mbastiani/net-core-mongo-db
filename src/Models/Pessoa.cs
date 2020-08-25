using System.Runtime.Serialization;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NetCoreMongoDb.Models
{
    public class Pessoa
    {
        //Podemos configurar o mapeamento com o MongoDB através de Annotations também.
        //Por padrão, o MongoDB espera um objeto do tipo ObjectId para identificar o id da nossa classe
        //No caso, quero que esse id seja convertido para uma string

        [BsonId] //Definir que esse atributo será o id do nosso objeto
        [BsonRepresentation(BsonType.ObjectId)] //Definir que a nossa string irá representar o ObjectId do MongoDB
        public string Id { get; set; }

        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}