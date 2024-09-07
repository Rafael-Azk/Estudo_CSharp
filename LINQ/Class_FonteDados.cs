using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_FonteDeDados
{
    public class Aluno
    {
        public Aluno(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
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
            new Aluno("Maria", 25),
            new Aluno("Natália", 17),
            new Aluno("Carol", 18),
            new Aluno("Katy", 30),
            new Aluno("Marta", 30),
            new Aluno("Maria", 35)
            };
            return alunos;

        }
    }

}