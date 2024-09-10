using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_FonteDeDados
{
    public class Aluno
    {
        public Aluno(string nome, int idade, List<string> curso)
        {
            Nome = nome;
            Idade = idade;
            cursos = curso;

        }
        public Aluno(string nome, int idade, string cursoo)
        {
            Nome = nome;
            Idade = idade;
            Cursoo = cursoo;
        }
        public Aluno() { }
        public Aluno(string nome, int nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> cursos { get; set; } = new List<string>();
        public string Cursoo { get; set; }
        public int Nascimento { get; set; }
    }
    public class Funcionario
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, int idade, decimal salario)
        {
            Nome = nome;
            Idade = idade;
            this.salario = salario;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal salario { get; set; }
    }
    public class FonteDeDados
    {
        public static List<int> GetNumeros()
        {
            List<int> numeros = new List<int>()
        {
            1 , 10, 5, 25, 277, 399
        };
            return numeros;

        }
        public static List<int> GetListaNegra()
        {
            List<int> numeros = new List<int>()
            {
                1, 5
            };
            return numeros;
        }
        public static List<Aluno> GetAlunos()
        {
            List<Aluno> alunos = new() {
            new Aluno("Maria", 17, new List<string> {"Js", "Html"}),
            new Aluno("Natália", 17, new List<string> {"C#", "Unity"}),
            new Aluno("Carol", 18, new List<string> {"Html, Css"}),
            new Aluno("Lúcia", 30, new List<string> {"js","NodeJs", "Sql"}),
            new Aluno("Katy", 30, new List<string> {"Typescript, Html, Css"}),
            new Aluno("Marta", 30, new List<string> {"NodeJs", "Sql"}),
            new Aluno("Maria", 35, new List<string> {"C#, Unity"})
            };
            return alunos;

        }
        public static List<Aluno> GetAlunosB()
        {
            List<Aluno> alunos = new()
            {
                new Aluno{Nome = "Maria", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Katy", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Keyla", Idade = 17, Cursoo = "Java"},
                new Aluno{Nome = "Beatriz", Idade = 17, Cursoo = "C#"},
                new Aluno{Nome = "Bruna", Idade = 18, Cursoo = "C#"},
                new Aluno{Nome = "Maria", Idade = 18, Cursoo = "Java"},
                new Aluno{Nome = "Lúcia", Idade = 18, Cursoo = "C#"}
            };
            return alunos;
        }
        public static List<Aluno> GetTurmaA()
        {
            List<Aluno> alunos = new() {
            new Aluno("Maria", 1998),
            new Aluno("Natália", 2001),
            new Aluno("Carol", 2010),
            new Aluno("Katy", 1997)
            };
            return alunos;
        }
        public static List<Aluno> GetTurmaB()
        {
            List<Aluno> alunos = new() {
            new Aluno("Mulata", 1999),
            new Aluno("Ruiva", 2010),
            new Aluno("Negra", 2001),
            new Aluno("Azul", 2002),

            };
            return alunos;

        }
        public static List<Funcionario> GetFuncionarios()
        {
            List<Funcionario> funcionarios = new()
        {
            new Funcionario("Dai", 22, 2500),
            new Funcionario("Nat", 30, 1900),
            new Funcionario("Maria", 17, 2900),
            new Funcionario("Luiza", 30, 1500),
            new Funcionario("Marta", 17, 1500),
            new Funcionario("Keila", 17, 2300),
        };
            return funcionarios;
        }
    }
    public class ComparerAluno : IEqualityComparer<Aluno>
    {
        public bool Equals(Aluno? x, Aluno? y)
        {
            //Se ambas referencias do objeto forem iguais retorna true.
            if (object.ReferenceEquals(x, y))
                return true;
            //Se uma das referências for null, retorna false.
            if (x is null || y is null)
                return false;

            return x.Nome == y.Nome && x.Idade == y.Idade;
        }

        //Se Equals() retornar true. O GetHashCode terá o mesmo valor para os objetos.
        public int GetHashCode(Aluno obj)
        {
            //Se obj for null retorna 0.
            /*if (obj is null)
                return 0;*/ //Com if.

            int nomesHashCode = obj.Nome == null ? 0 : obj.Nome.GetHashCode();//Com ternário.
            int IdadesHashCode = obj.Idade.GetHashCode();
            return nomesHashCode ^ IdadesHashCode;
        }
    }
}