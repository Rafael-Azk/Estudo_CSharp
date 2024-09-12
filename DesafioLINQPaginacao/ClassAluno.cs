using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Aluno
{
    public class Aluno
    {

        public Aluno(string nome, int idade, string cursoo)
        {
            Nome = nome;
            Idade = idade;
            Cursoo = cursoo;
        }
        public Aluno() { }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> cursos { get; set; } = new List<string>();
        public string Cursoo { get; set; }

        public static List<Aluno> GetAlunos()
        {
            List<Aluno> alunos = new()
            {
                new Aluno{Nome = "Maria", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Katy", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Keyla", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Beatriz", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Bruna", Idade = 18, Cursoo = "C#"},
                new Aluno{Nome = "Karla", Idade = 18, Cursoo = "Java"},
                new Aluno{Nome = "Lúcia", Idade = 18, Cursoo = "C#"},
                 new Aluno{Nome = "Débora", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Paula", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Nat", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Regina", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Roberta", Idade = 18, Cursoo = "C#"},
                new Aluno{Nome = "Laura", Idade = 18, Cursoo = "Java"},
                new Aluno{Nome = "Lua", Idade = 18, Cursoo = "C#"},
                new Aluno{Nome = "Ana Clara", Idade = 18, Cursoo = "C#"},


            };
            return alunos;
        }
    }
    


}

