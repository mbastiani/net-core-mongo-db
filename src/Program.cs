using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using NetCoreMongoDb.Data;
using NetCoreMongoDb.Models;
using System;
using System.Collections.Generic;

namespace NetCoreMongoDb
{
    class Program
    {
        private static AppDbContext _appDbContext;

        static void Main(string[] args)
        {
            //Instanciar a classe de contexto do banco (isso deve ser feito via injeção de dependência em uma aplicação real)
            _appDbContext = new AppDbContext();

            //Inserir um objeto
            var id = Inserir();

            //Selecionar objeto inserido
            var pessoa = Selecionar(id);

            //Atualizar o objeto
            Atualizar(id, pessoa);

            //Listar todos os objetos da coleção
            Listar();

            //Excluir um objeto
            Excluir(id);
        }

        public static string Inserir()
        {
            var pessoa = new Pessoa
            {
                Nome = "Pessoa teste",
                Salario = 100.50M,
                Endereco = new Endereco
                {
                    Cep = "17207000",
                    Logradouro = "Nome da rua da pessoa",
                    Numero = "123",
                    Bairro = "Bairro da pessoa",
                    Cidade = "Cidade da pessoa",
                    Uf = "SP"
                },
                Telefones = new List<Telefone>
                {
                    new Telefone{
                        Prefixo= "14",
                        Numero= "9123456789",
                        Tipo = TelefoneTipos.Celular
                    },
                    new Telefone{
                        Prefixo= "11",
                        Numero= "9987654321",
                        Tipo = TelefoneTipos.Comercial
                    },
                    new Telefone
                    {
                        Prefixo = "11",
                        Numero="36251487",
                        Tipo = TelefoneTipos.Fixo
                    }
                }
            };

            _appDbContext.Pessoas.InsertOne(pessoa);

            Console.WriteLine($"\nId da pessoa inserida:\n{pessoa.Id}\n");

            return pessoa.Id;
        }

        public static Pessoa Selecionar(string id)
        {
            var pessoa = _appDbContext.Pessoas.Find(x => x.Id == id).FirstOrDefault();

            Console.WriteLine($"\nPessoa selecionada:\n{pessoa.ToJson(new JsonWriterSettings { Indent = true })}\n");

            return pessoa;
        }

        public static void Atualizar(string id, Pessoa obj)
        {
            obj.Nome = "Nome atualizado";

            _appDbContext.Pessoas.FindOneAndReplace(x => x.Id == id, obj);

            var pessoa = _appDbContext.Pessoas.Find(x => x.Id == id).FirstOrDefault();

            Console.WriteLine($"\nPessoa atualizada:\n{pessoa.ToJson(new JsonWriterSettings { Indent = true })}\n");
        }

        public static void Listar()
        {
            var pessoas = _appDbContext.Pessoas.Find(x => true).ToList();

            Console.WriteLine($"\nLista de pessoas:\n{pessoas.ToJson(new JsonWriterSettings { Indent = true })}\n");
        }

        public static void Excluir(string id)
        {
            _appDbContext.Pessoas.FindOneAndDelete(x => x.Id == id);

            Console.WriteLine($"\nPessoa excluída com sucesso:\n{id}\n");
        }
    }
}