using LINQ_FonteDeDados;
using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
//-------------------------------------LINQ-----------------------

//------PRINCIPAIS------

//Elemento:
//Fisrt()/FirstOrDefault(); //Retorna o primeiro elemento da coleção.
//ElementAt()/ElementAtOrDefault(); //Retorna o elemento de acordo com o index.
//Single()/SingleOrDefault(); //Retorna se tem apenas um certo elemento na coleção. Sem réplicas.
//Last()/LastOrDefault(); //Retorna o último elemento da coleção.

//Quantificação:
//Contains(); //Retorna se tem o elemento na coleção.
//Any() //Retorna se tem pelo menos um elemento na coleção(bool).
//All(); //Retorna se todos os elementos satisfazem a condição(bool).

//Agregação:
//Count(); //No lugar do Lenght.

//Particionamento:
//Skip(); //Pula quantidade de elementos da coleção.
//Take(); //Pega quantidade de elementos da coleção.
//(Obs: Usar ambos em conjunto para paginação. Ou direto Take com range (x..y)).

//Filtros:
//Where(); //Condição para filtrar os elementos da coleção. (Ex .Where(x => x < 10 || x > 0)).

//DICA:
//Usar .ToList() quando manipular as listas.





//Obs: IEnumerable é "ReadOnly".

IList<string> frutas = new List<string>() { "Laranja", "Banana", "Abacaxi", "Melancia", "Mexerica" };

//SINTAX CONSULTA QUERY:
var result = from f in frutas
             where f.ToLower().Contains("r")
             select f;
Console.WriteLine(string.Join(" - ", result));

//SINTAX CONSULTA METODO:
var result2 = frutas.Where(f => f.ToLower().Contains("m")); /* Um lambda baseado em Delegate Func,
                                                            * que retorna um booleano.*/
Console.WriteLine(string.Join(" - ", result2));

//-----------------SOBRE LAMBDA--------------------
var nomes = new list<string>() { "ana", "julia", "keila" };

//------metodo antigo de consulta:
string? resultado = nomes.find(nomenalista);
console.writeline(resultado);

static bool nomenalista(string _nome)
{
    return _nome.tolower().equals("keila");
}
//------metodo consulta delegate---
string? resultado2 = nomes.find(delegate (string nome)
                               { return nome.tolower().equals("keila"); });
console.writeline(resultado2);
//------metodo consulta lambda---
string? resultado3 = nomes.find(n => n.tolower().contains("keila"));
console.writeline(resultado3);

//--------------------LINQ - FILTROS:---------------------------------
//Obs: "Where" retorna dados de uma lista, com base em funções de predicado.
using LINQ_FonteDeDados;

var numeros = FonteDeDados.GetNumeros();
var resultado1 = numeros.Where(n => n > 20);
Console.WriteLine(string.Join(" ", resultado1));
var resultado2 = numeros.Where(n => n > 20 && n != 4);
Console.WriteLine(string.Join(" ", resultado2));

var listraNegra = FonteDeDados.GetListaNegra();
var resultado3 = numeros.Where(n => !listraNegra.Contains(n)); /*Como está negando, os números
                                                                * da lista na verdade não vão
                                                                * aparecer.*/
Console.WriteLine(string.Join(" ", resultado3));

var alunos = FonteDeDados.GetAlunos();
var resultado4 = alunos.Where(a => a.Nome.ToLower().StartsWith("m") && a.Idade <= 30);
foreach (var alu in resultado4)
{
    Console.WriteLine($"Nome: {alu.Nome} | Idade: {alu.Idade}");
}
/*Com método de consulta:
var filtro = from x in alunos
             where x.Nome.ToLower().StartsWith("m") && x.Idade <= 30
             select x;
foreach (var alu in filtro)
{
    Console.WriteLine($"Nome: {alu.Nome} | Idade: {alu.Idade}");
}*/

//-------------------------------LINQ: PROJEÇÃO----------------------------------------

////----------------- SELECT:

//Selecionar Select lista completa: (Select implicito)
IEnumerable<Aluno> alunos = FonteDeDados.GetAlunos().ToList(); //"ToList()" para retornar os dados de imediato.
foreach (var aluno in alunos)
{
    Console.WriteLine($"Nome: {aluno.Nome} - Idade: {aluno.Idade}");
}

//Selecionar Select propriedade específica:
IEnumerable<string> nomesAlunos = FonteDeDados.GetAlunos().Select(a => a.Nome);/*"Select" para ter
                                                                                * apenas uma propriedade.*/
foreach (var nome in nomesAlunos)
{
    Console.WriteLine($"{nome}");
}

//Para Select selecionar algumas propriedades da classe.
List<Aluno> lista = FonteDeDados.GetAlunos().Select(a => new Aluno()
{
    Nome = a.Nome,
    Idade = a.Idade
}).ToList();
foreach (var aluno in lista)
    Console.WriteLine($"{aluno.Nome} - {aluno.Idade}");

//Metodo Select com tipo anonimo:
var alunoTipoAnonimo = FonteDeDados.GetAlunos().Select(a => new
{
    Nome = a.Nome,
    Idade = a.Idade
}).ToList();
foreach (var aluno in alunoTipoAnonimo)
    Console.WriteLine($"{aluno.Nome} - {aluno.Idade}");

//Cálculos:
var listaFuncionarios = FonteDeDados.GetFuncionarios().Select(f => new
{
    Nome = f.Nome,
    SalarioAnual = (f.salario * 12).ToString("c")
}).ToList();
foreach (var f in listaFuncionarios)
{
    Console.WriteLine($"Nome: {f.Nome} - Salário anual: {f.SalarioAnual}");
}

//-----------SELECTMANY:
//Obs: Combina listas e/ou lista de listas -> (List<List<int>>>)

List<List<int>> listas = new List<List<int>>
{
    new List<int> { 1, 25, 33, 12, 25 },
    new List<int> {59},
    new List<int> {750, 918},
    new List<int> { 13, 15, 77 }
};
IEnumerable<int> resultado = listas.SelectMany(lista => lista);
foreach (var f in resultado) { Console.Write(f + " "); }
Console.WriteLine();
IEnumerable<int> resultado2 = listas.SelectMany(lista => lista.Distinct());/*"Distinct" remove
                                                                            * os elementos repetidos
                                                                            * de uma lista*/

foreach (var f in resultado2) { Console.Write(f + " "); }

//---------------EXEMPLO:
//SELECT: (Necessário 2 "foreach". Um acessa a lista, outro o valores)

IEnumerable<List<string>> retornoSelect = FonteDeDados.GetAlunos().Select(c => c.cursos);
foreach (List<string> listaCursos in retornoSelect)
{
    foreach (var curso in listaCursos)
    {
        Console.Write($"{curso} ");
    }
    Console.WriteLine();
}
Console.WriteLine();
//SELECTMANY: (Acessa os valores diretamente e concatena).
IEnumerable<string> retornoSelectMany = FonteDeDados.GetAlunos().SelectMany(c => c.cursos);

foreach (var curso in retornoSelectMany)
{
    Console.Write($"{curso} ");

}

//---------------------------------LINQ: CONJUNTO-----------------------------------
/*Distinct/DistinctBy - Remove valores duplicados de uma coleção.
 * Except/ExceptBy - Retorna todos os valores na lista "X" que não existem na lista "Y".
 * Intersect/IntersectBy - Retorna todos os valores iguais em ambas as listas X/Y.
 * Union/UnionBy - Une ambas as listas X/Y. Eliminando as repetições*/

//Distinct: 
var idades = new[] { 10, 50, 10, 9, 9, 33, 77 };
var idadesDistintas = idades.Distinct().ToArray();
var idadesDistintas2 = idades.Distinct().ToList();
var idadesDistintas3 = idades.Distinct();
foreach (var idade in idadesDistintas3) { Console.Write($"{idade} "); }
/*Sintaxe de consulta:
 * var result = (from num in idades
 *               select num).Distinct();*/

var nomes = new[] { "Maria", "Paula", "Maria", "Fernanda", "Melissa", "Fernanda" };
var nomesDistintos = nomes.Distinct(StringComparer.OrdinalIgnoreCase); /*Vai ignorar as diferenças de
                                                                        * digitação*/

foreach (var nome in nomesDistintos) { Console.Write($"{nome} "); }

////DistinctBy:
var alunos = FonteDeDados.GetAlunos().ToList();
var alunosIdadesDistintas = alunos.DistinctBy(a => a.Idade);//Não exibirá alunos com a mesma idade.
foreach (var a in alunosIdadesDistintas)
{
    Console.WriteLine($"Aluno: {a.Nome} - idades: {a.Idade}");
}

//Except:
var fonte1 = new List<string>() { "USA", "Brasil", "Mexico", "Russia" };
var fonte2 = new List<string>() { "usa", "mexico" };
var resultado = fonte1.Except(fonte2, StringComparer.OrdinalIgnoreCase).ToList(); //Não exibirá nums da lista 1 que se repetem na 2.
foreach (var i in resultado) { Console.Write(i + " "); }
//Exceptby:
var alunos = FonteDeDados.GetAlunos();
var alunosReprovados = new List<string>() { "lucia", "katy", "marta" };
var alunosAprovados = alunos.ExceptBy(alunosReprovados, n => n.Nome, StringComparer.OrdinalIgnoreCase);
foreach (var aluno in alunosAprovados) { Console.WriteLine(aluno.Nome + " "); }

//Intersect:
var num1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
var num2 = new List<int>() { 1, 3, 5, 8, 9, 10 };
var result = num1.Intersect(num2).ToList();    //Irá retornar os nums que se repetem nas duas listas.
foreach (var n in result) { Console.Write(n + " "); }
//Sintaxe de consulta:
var resultado = (from n in num1
                 select n).Intersect(num2).ToList();
foreach (var n in resultado) { Console.Write(n + " "); }
Console.WriteLine("\n");

IntersectBy:
Intersect comum -(Para comparar):
var turmaA = FonteDeDados.GetTurmaA();
var turmaB = FonteDeDados.GetTurmaB();
var consulta = turmaA.Select(p => p.Nascimento)//Intersect comum. Recebe apenas os anos.
                            .Intersect(turmaB.Select(p => p.Nascimento));
foreach (var ano in consulta) { Console.WriteLine(ano + " "); }
//By:
var alunosMesmoAnoNascimento = turmaA.IntersectBy(turmaB.Select(p => p.Nascimento),
                                                  p => p.Nascimento);/*Retorna nome e ano dos alunos
                                                                      *que nasceram na mesma época*/
foreach (var n in alunosMesmoAnoNascimento)
{
    Console.WriteLine($"Nome: {n.Nome} - Nascimento: {n.Nascimento}");
}

//Union:
var num1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
var num2 = new List<int>() { 1, 3, 5, 8, 9, 10 };
var result = num1.Union(num2).ToList();         //Une as duas listas. Eliminando repetições.
foreach (var n in result) { Console.Write(n + " "); }

UnionBy:
Union comum -(Para comparar):
var turmaA = FonteDeDados.GetTurmaA();
var turmaB = FonteDeDados.GetTurmaB();
var unionComum = turmaA.Select(x => x.Nome).Union(turmaB.Select(x => x.Nome), StringComparer.OrdinalIgnoreCase);
/*Retorna apenas nome, porque retorna uma lista*/

foreach (var n in unionComum) { Console.Write(n + " "); }

Console.WriteLine();
//By:
var turmaUnionBy = turmaA.UnionBy(turmaB, p => p.Nome, StringComparer.OrdinalIgnoreCase);
/*Retorna todos os parâmetros. Porque retorna objetos*/
foreach (var n in turmaUnionBy)
{
    Console.WriteLine($"Nome: {n.Nome} -  Nascimento: {n.Nascimento}");
}

//----------------------------LINQ: ORDENAÇÃO-----------------------------

//OrderBy/OrderByDescending - Ordena por ondem crescente ou decrescente:
var nomes = new List<string>() { "Carla", "Tania", "Roberta", "Amanda", "Alessandra" };
var lista = nomes.OrderBy(x => x).ToList();
foreach (var item in lista) { Console.Write(item + " "); }
Console.WriteLine();
var lista2 = nomes.OrderByDescending(x => x).ToList();
foreach (var item in lista2) { Console.Write(item + " "); }
Console.WriteLine();
//Sintaxe de consulta:
var lista3 = (from nome in nomes
              orderby nome descending //ascending se quiser ascendente.
              select nome).ToList();
foreach (var item in lista3) { Console.Write(item + " "); }

//Objetos complexos:
var alunos = FonteDeDados.GetAlunos().ToList();
var lista1 = alunos.OrderBy(x => x.Nome).ToList();
var lista2 = alunos.OrderByDescending(x => x.Nome).ToList();
//Múltiplas propriedades:
var lista3 = alunos.OrderBy(x => x.Nome).ThenBy(x => x.Idade).ToList();
var lista4 = alunos.OrderByDescending(x => x.Nome).ThenByDescending(x => x.Idade).ToList();
foreach (var item in lista4) { Console.WriteLine($"{item.Nome} - {item.Idade}"); }
//Sintaxe de consulta:
var listConsulta = (from a in alunos
                    orderby a.Nome, a.Idade
                    select new { a.Nome, a.Idade }).ToList();
foreach (var a in listConsulta) { Console.WriteLine(a + " "); }
Ordenação com filtro:
var listaFiltro = alunos.Where(a => a.Nome.ToLower().Contains("m"))
                                .OrderBy(x => x.Nome).ThenBy(x => x.Idade).ToList();
foreach (var i in listaFiltro) { Console.WriteLine($"{i.Nome} - {i.Idade}"); }

//--------------REVERSE:

var nums = new int[] { 1, 5, 25, 2, 4, 1, 500, 25, 300 };
var lista = nums.Reverse();
foreach (var num in lista) { Console.Write(num + " "); }
Console.WriteLine();
//Sintaxe de consulta:
var list = (from num in nums
            select num).Reverse();
foreach (var n in list) { Console.Write(n + " "); }

Para List<T> - (Tipos genericos):
var nomes = new List<string>() { "Paula", "Amanda", "Maria", "Bruna" };
nomes.Reverse();    //Aplica o reverse diretamente. Não numa variável.
foreach (var n in nomes) { Console.Write(n + " "); }
Console.WriteLine();
//Para usar reverse na variável de uma coleção:
IEnumerable<string> lista = nomes.AsEnumerable().Reverse();
IQueryable<string> lista2 = nomes.AsQueryable().Reverse();//Queryable, melhor para Banco de Dados.
foreach (var nome in lista2) { Console.Write(nome + " "); }

//---------------------------------LINQ: AGREGAÇÃO---------------------------------------

//Aggregate:
var cursos = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
string resultado = cursos.Aggregate((s1, s2) => s1 + "," + s2);/*Como lista vai concatenando 
                                                                 * s1 = s1+s2 (E s1 vai atualizando).*/
Console.WriteLine(resultado);
var numeros = new int[] { 3, 5, 7, 9, 10 };
int calculo = numeros.Aggregate((n1, n2) => n1 * n2); //É como n1 = n1*n2 (E n1 vai atualizando).   
Console.WriteLine(calculo);

//Aggregate com semente:
List<Aluno> alunos = new()
{
    new Aluno(){Nome = "Lilith", Idade = 25},
    new Aluno(){Nome = "Keyla", Idade=17 },
    new Aluno(){Nome="Kátia", Idade=18}
};
//string listaAlunos = alunos.Aggregate<Aluno, string>("Nomes: ", (semente, aluno) => 
//                                                        semente += aluno.Nome + ", ");
//Console.WriteLine(listaAlunos);//Mantém a última vírgula.
/
////Para remover a última vírgula:
//int indice = listaAlunos.LastIndexOf(",");
//listaAlunos = listaAlunos.Remove(indice);
//Console.WriteLine(listaAlunos);
//Remover vírgula com lambda:
string listaAlunos2 = alunos.Aggregate<Aluno, string, string>("Nomes: ", (semente, aluno) =>
                                                        semente += aluno.Nome + ", ",
                                                        resultado => resultado.Substring(0, resultado.Length - 1));
Console.WriteLine(listaAlunos2); //Já virá sem vírgula.

//Average: (Calcula média de valores numéricos em uma coleção).
List<Aluno> alunos = new()
{
    new Aluno(){Nome = "Lilith", Idade = 25},
    new Aluno(){Nome = "Keyla", Idade=17 },
    new Aluno(){Nome="Kátia", Idade=18}
};
var mediaIdades = alunos.Average(aluno => aluno.Idade);
Console.WriteLine($"Média de idade: {mediaIdades}");

//Count:(Retorna total de elementos em uma coleção):
var cursos = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
var totalCursos = cursos.Count();
Console.WriteLine($"Total de cursos: {totalCursos}");
//Sintaxe de consulta:
var nCursos = (from c in cursos
               select c).ToList().Count();

//Com filtro:
var cursos2 = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
var result1 = cursos2.Count(c => c.ToLower().Contains("p"));
var result2 = cursos2.Where(c => c.ToLower().Contains("c")).ToList().Count();
Console.WriteLine($"Número de cursos com C: {result2}");
//Sintaxe de consulta:
var nCursos2 = (from c in cursos2
                where c.ToLower().Contains("c")
                select c).ToList();

Sum: (Soma os valores da coleção):
int[] numeros = { 1, 50, 150, 300, 700, 900, 777000 };
int resultado = numeros.Sum();
Console.WriteLine(resultado);

//Com filtro:
var result1 = numeros.Where(n => n < 100).Sum(); //Opção 1.
var result2 = numeros.Sum(n =>
{
    if (n < 10)
        return n;
    else
        return 0;
}
); //Opção 2.
Console.WriteLine(result1);

//Min/Max: (Melhor para coleções simples):
decimal[] salario = { 1900.00m, 3500.00m, 800700.00m };

var maiorSalario = salario.Max();
var menorSalario = salario.Min();
Console.WriteLine($"Maior salario: {maiorSalario.ToString("c")} - Menor salario: {menorSalario.ToString("c")}");
//Sintaxe de consulta:
var res = (from f in salario
           select f).Max();
Console.WriteLine(res);

//MaxBy/MinBy: (Melhor para objetos complexos):
List<Funcionario> funcionarios = new()
{
    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
};
var maiVelho = funcionarios.MaxBy(f => f.Idade);
var maisNovo = funcionarios.MinBy(f => f.Idade);
//Jeito antigo:
var velho = funcionarios.OrderBy(f => f.Idade).First();
var novo = funcionarios.OrderByDescending(f => f.Idade).First();
Console.WriteLine($"Novinha: {maisNovo?.Nome} - Idade: {maisNovo?.Idade}\nMais velha: {maiVelho?.Nome} - Idade{maiVelho?.Idade}");

//----------------------------------LINQ: QUANTIFICAÇÃO--------------------------------
/*All() - Determina se todos os elementos satisfaz a condição;
 *Any() - Determina se pelo menos um elemento satisfaz a condição;
 *Contains() - Determina se a coleção contém um valor específico*/

//All:
int[] nums = { 2, 54, 306, 90 };
var result = nums.All(x => x % 2 == 0);//True se todos os números são pares.  
Console.WriteLine($"{(result ? "Todos são pares" : "Nem todos são pares")}");

List<Funcionario> funcionarios = new()
{
    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
};
var salariosAcima = funcionarios.All(x => x.salario > 1000.00m);
var nomesComLetra = funcionarios.All(x => x.Nome.Contains("i"));
Console.WriteLine($"Salarios acima de 2k? {salariosAcima} - Todos nomes tem 'i'? {nomesComLetra}");

//Sintaxe de consulta:
var result2 = (from s in funcionarios
               select s).All(s => s.salario > 2000);

//Any:
int[] nums = { 3, 54, 307, 91 };
var result = nums.Any(x => x % 2 == 0);//True se todos os números são pares.  
Console.WriteLine($"{(result ? "Ao menos um é par" : "Nenhum é par")}");

List<Funcionario> funcionarios = new()
{
    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
};
var elemento = funcionarios.Any(); //Verifica se tem algum elemento na coleção. 
var salariosAcima = funcionarios.Any(x => x.salario < 1000.00m && x.Idade > 30);
var nomesComLetra = funcionarios.Any(x => x.Nome.ToUpper().Contains("I"));
Console.WriteLine($"Algum salarios abaixo de 1k? {salariosAcima} - Algum nome tem 'I'? {nomesComLetra}");
Console.WriteLine(elemento);

//Contains:

//------------CONTAINS PARA OBJETOS COMPLEXOS!!!!!:
var alunos = FonteDeDados.GetAlunos();
ComparerAluno comparador = new ComparerAluno(); //Comparer feito modificando Equals e GetHashCode.

var alunoBuscado = new Aluno() { Nome = "Katy", Idade = 30 };
var resultado = alunos.Contains(alunoBuscado, comparador);
Console.WriteLine($"Aluno existe? {resultado}");

//Contains para objeto simples:
int[] nums = { 1, 2, 50, 70, 90 };
Console.WriteLine(nums.Contains(90));

//--------------------------------------AGRUPAMENTO-----------------
//GroupBy:
var funcionarios = FonteDeDados.GetFuncionarios();
var grupos = funcionarios.GroupBy(a => a.Idade).OrderBy(c => c.Key);//ORDER É OPCIONAL.

/*Sintaxe de consulta ordenada:
var grupos2 = (from f in funcionarios
               group f by f.Idade into grupo
               orderby grupo.Key
               select grupo);*/
/*Sintaxe de consulta simples:
var grupos2 = (from f in funcionarios
               group f by f.Idade);*/

foreach (var grupo in grupos)
{
    Console.WriteLine($"Idade: {grupo.Key} - Qtd. Funcionários: {grupo.Count()} ");
    foreach (var funcionario in grupo)
    {
        Console.WriteLine($"\t{funcionario.Nome} {funcionario.salario.ToString("c")}");
    }
}

//------COMPLEXO! PELOS CURSOS:

var alunos = FonteDeDados.GetAlunosB();
var grupos = alunos.GroupBy(a => a.Cursoo)
                            .OrderBy(c => c.Key)
                            //Primeiro ordena os dados baseado na chave curso:
                            .Select(std => new
                            {
                                Key = std.Key,
                                //Ordena os dados baseado no nome:
                                Alunos = std.OrderBy(x => x.Nome)
                            }).ToList();
foreach (var grupo in grupos)
{
    Console.WriteLine($"Curso: {grupo.Key} (Alunos: {grupo.Alunos.Count()}) ");
    foreach (var aluno in grupo.Alunos)
    {
        Console.WriteLine($"\tAluno: {aluno.Nome} - Idade: {aluno.Idade}");
    }
}
Console.WriteLine();

//---GorupBy com múltiplas chaves:
var alunos2 = FonteDeDados.GetAlunosB();
var grupos2 = alunos2.GroupBy(a => new { a.Cursoo, a.Idade }).
                                OrderByDescending(c => c.Key.Cursoo)
                                .ThenBy(x => x.Key.Idade)//Não é obrigatório.
                                .Select(x => new
                                {
                                    Curso = x.Key.Cursoo,
                                    Idade = x.Key.Idade,
                                    Alunos = x.OrderBy(x => x.Nome)
                                });
foreach (var grupo in grupos2)
{
    Console.WriteLine($"Curso: {grupo.Curso} - Idade: {grupo.Idade} (Alunos: {grupo.Alunos.Count()})");
    //Itera cada grupo de alunos:
    foreach (var aluno in grupo.Alunos)
    {
        Console.WriteLine($"\t{aluno.Nome}");
    }
}

/*ToLookUp() - pode substituir todos os métodos GroupBy(). A diferença
 *é que a execução ocorrerá de forma imediata*/

//------------------------------------LINQ: JUNÇÃO------------------------------

//----------INNERJOIN/JOIN:
//(OBS: Simulando a junção de dados externos (db) com dados internos (Setor).
//(Obs2: As listas internas simuladas não podem ter null. Na externa, pra junção com db, pode conter).

var funcionarios = FonteDeDados.GetFuncionariosB(); //Dados externos simulado.
var setores = FonteDeDados.GetSetor();

var innerJoin = funcionarios
    .Join(setores,
    funcionario => funcionario.SetorID,
    setor => setor.SetorId,
    (funcionario, setor) => new
    {
        NomeFuncionario = funcionario.Nome,
        NomeSetor = setor.SetorNome,
        CargoFuncionario = funcionario.Cargo,
    }).ToList();
Console.WriteLine("Funcionario:\tCargo:\t\t\tSetor:");
foreach (var funcionario in innerJoin)
{
    Console.WriteLine($"{funcionario.NomeFuncionario}" +
                      $"\t\t{funcionario.CargoFuncionario}" +
                      $"\t\t{funcionario.NomeSetor}");
}
//Obs: A diretora não vai aparecer. Seu ID privado não existe na lista do setor.

////Sintaxe de consulta:
var innerJoin2 = (from f in funcionarios
                  join s in setores
                  on f.SetorID equals s.SetorId
                  select new
                  {
                      NomeFuncionario = f.Nome,
                      NomeSetor = s.SetorNome,
                      CargoFuncionario = f.Cargo,
                  }).ToList();

//----LEFTJOIN:

var funcionarios = FonteDeDados.GetFuncionariosB();
var setores = FonteDeDados.GetSetor();

var leftJoin = (from f in funcionarios
                join s in setores
                on f.SetorID equals s.SetorId
                into funciSetorGrupo
                from setor in funciSetorGrupo.DefaultIfEmpty()
                select new
                {
                    NomeFuncionario = f.Nome,
                    CargoFuncionario = f.Cargo,
                    NomeSetor = setor.SetorNome,
                }).ToList();

Console.WriteLine("Funcionario:\tCargo:\t\t\tSetor:");
foreach (var funcionario in leftJoin)
{
    Console.WriteLine($"{funcionario.NomeFuncionario}" +
                      $"\t\t{funcionario.CargoFuncionario}" +
                      $"\t\t{funcionario.NomeSetor}");
}

//----RIGHTJOIN:
var funcionarios = FonteDeDados.GetFuncionariosB();
var setores = FonteDeDados.GetSetor();

var rightJoin = (from s in setores
                 join f in funcionarios
                 on s.SetorId equals f.SetorID
                 into SetorFunciGrupo
                 from funcionario in SetorFunciGrupo.DefaultIfEmpty()
                 select new
                 {
                     NomeFuncionario = funcionario.Nome,
                     CargoFuncionario = funcionario.Cargo,
                     NomeSetor = s.SetorNome,
                 }).ToList();

Console.WriteLine("Funcionario:\tCargo:\t\t\tSetor:");
foreach (var funcionario in rightJoin)
{
    Console.WriteLine($"{funcionario.NomeFuncionario}" +
                      $"\t\t{funcionario.CargoFuncionario}" +
                      $"\t\t{funcionario.NomeSetor}");
}

//----FULLJOIN:

var funcionarios = FonteDeDados.GetFuncionariosB();
var setores = FonteDeDados.GetSetor();

var leftJoin = (from f in funcionarios
                join s in setores
                on f.SetorID equals s.SetorId
                into funciSetorGrupo
                from setor in funciSetorGrupo.DefaultIfEmpty()
                select new
                {
                    NomeFuncionario = f.Nome,
                    CargoFuncionario = f.Cargo,
                    NomeSetor = setor.SetorNome,
                }).ToList();

var rightJoin = (from s in setores
                 join f in funcionarios
                 on s.SetorId equals f.SetorID
                 into SetorFunciGrupo
                 from funcionario in SetorFunciGrupo.DefaultIfEmpty()
                 select new
                 {
                     NomeFuncionario = funcionario.Nome,
                     CargoFuncionario = funcionario.Cargo,
                     NomeSetor = s.SetorNome,
                 }).ToList();

var unionJoin = leftJoin.Union(rightJoin);

Console.WriteLine("Funcionario:\tCargo:\t\t\tSetor:");
foreach (var funcionario in unionJoin)
{
    Console.WriteLine($"{funcionario.NomeFuncionario}" +
                      $"\t\t{funcionario.CargoFuncionario}" +
                      $"\t\t{funcionario.NomeSetor}");
}

//-----CROSSJOIN:

var funcionarios = FonteDeDados.GetFuncionariosB();
var setores = FonteDeDados.GetSetor();

var crossJoin = from f in funcionarios
                from s in setores
                select new
                {
                    Nome = f.Nome,
                    Cargo = f.Cargo,
                    setor = s.SetorNome
                };

Console.WriteLine("Funcionario:\tCargo:\t\t\tSetor:");
foreach (var funcionario in crossJoin)
{
    Console.WriteLine($"{funcionario.Nome}" +
                      $"\t\t{funcionario.Cargo}" +
                      $"\t\t{funcionario.setor}");
}

//---GROUPJOIN:

var funcionarios = FonteDeDados.GetFuncionariosB();
var setores = FonteDeDados.GetSetor();

var groupJoin = setores.GroupJoin(funcionarios,
                s => s.SetorId, f => f.SetorID,
                (f, funcionariosGrupo) => new
                {
                    Funcionarios = funcionariosGrupo,
                    NomeSetor = f.SetorNome,
                }).ToList();

foreach (var item in groupJoin)
{
    Console.WriteLine(item.NomeSetor);
    foreach (var func in item.Funcionarios)
    {
        Console.WriteLine($"\t{func.Nome}");
    }
}

//---------------------------------------------
/*Simulação de consulta com 3 parametros:
var consulta = from a in alunos
               join endereco in endereços
               on a.EndereçoID equals endereco.ID
               join curso in cursos
               on a.CursoID equals curso.ID
               select new
               {
                   ID = a.ID,
                   AlunoNome = a.Nome,
                   CursoNome = curso.Nome,
                   Endereco = endereco.Local
               };
foreach (var item in consulta)
{
    Console.WriteLine($"{item.ID}\t{item.AlunoNome}\t{item.CursoNome}\t{item.Endereco}");
}*/

//---------------------------------LINQ ELEMENTO:---------------------------
//OBS: "...orDefault" não lançará excessão se o elemento não existir.

//----ELEMENTAT/ELEMENTATORDEFAULT:

//Simples:
var numeros = new List<int>() { 1, 30, 50, 40, 60, 99, 333, 777 };
int resultado = numeros.ElementAt(5);
Console.WriteLine(resultado);

//Sintaxe de consulta:
int result = (from nums in numeros
              select nums).ElementAtOrDefault(20); //Não lançã excessão se o index não existir.
//Complexo:
var aluno = FonteDeDados.GetAlunosB().ElementAt(3);//Retorna um objeto.
Console.WriteLine($"Nome: {aluno.Nome} - Idade: {aluno.Idade} - Curso: {aluno.Cursoo}");

//Complexo com elemento do objeto:
var alunoNome = FonteDeDados.GetAlunosB().Select(n => n.Nome).ElementAtOrDefault(3);
//Retorna um elemento do obj. --- Não lançará excessão se o index não existir.
Console.WriteLine(alunoNome);

//----FIRST:
SImples:
var numeros2 = new List<int>() { 1, 30, 50, 40, 60, 99, 333, 777 };
int resultado2 = numeros2.First();
int resultado2_1 = numeros2.First(n => n >= 50); //Permite condição lógica.
Console.WriteLine(resultado2);
Console.WriteLine(resultado2_1);

//Complexo:
var aluno2 = FonteDeDados.GetAlunosB().FirstOrDefault(a => a.Cursoo == "Java");
Console.WriteLine(aluno2?.Cursoo);

//Sintaxe de consulta semelhante ao ElementAt.

//---LAST:
//SImples:
var numeros3 = new List<int>() { 1, 30, 50, 40, 60, 99, 333, 777 };
int resultado3 = numeros2.Last();
int result3 = numeros2.Last(n => n < 60); //Permite condição lógica.
Console.WriteLine(resultado3);
Console.WriteLine(result3);

//Complexo:
var aluno3 = FonteDeDados.GetAlunosB().LastOrDefault(a => a.Cursoo == "Java");
Console.WriteLine(aluno3?.Cursoo);

//---SINGLE
var numeros4 = new List<int>() { 50 };
int resultado4 = numeros4.Single();
Console.WriteLine(resultado4);
var nums4 = new List<int>() { 50, 60, 40 };
int resultado4_1 = nums4.SingleOrDefault(n => n < 50);
Console.WriteLine(resultado4_1);

//Obs: Lança excessão se tiver mais de um item pedido, ou nenhum item. Para evitar, usar  "SingleOrDefault".

//---DEFAULTIFEMPTY:
var numeros5 = new List<int>() { };
IEnumerable<int> resultado5 = numeros5.DefaultIfEmpty(404);
foreach (int n in resultado5)
{
    Console.WriteLine(n);
}

//OBS: Quando lista vazia, retorna 0 ou um valor definido no parâmetro.

//-----------------------------------------LINQ: CONVERSÃO-----------------------------------

//--TOLIST:

string[] paises = { "Russia", "USA", "Brasil", "UK" };
var result = paises.ToList(); //Converte string para lista
foreach (string pais in result)
{
    Console.WriteLine(pais);
}

//-----

var alunos = FonteDeDados.GetAlunosC(); //Retorna um IEnumerable<Aluno>

var lista = alunos.Where(a => a.Nome.Contains("M")).ToList(); //--> Converte par List<Aluno>.
foreach (var a in lista)
{
    Console.WriteLine(a.Nome);
}

//OBS: IEnumerable<T> é Read-Only. List<T> aloca tudo na memória e pode ser modificado.

//---TOARRAY:

var alunosB = FonteDeDados.GetAlunosC(); //Retorna um IEnumerable<Aluno>

var listaB = alunosB.Where(a => a.Nome.Contains("M")).ToArray(); //--> Converte para Array "Aluno[]".

foreach (var a in listaB)
{
    Console.WriteLine(a.Nome);
}
////----

var funcionarios = FonteDeDados.GetFuncionarios(); //Recebe um List<T>.
string[] nomes = funcionarios.Select(a => a.Nome).ToArray(); //Converte elemento do objeto em List para Array.
foreach (var n in nomes)
{
    Console.WriteLine(n);
}

//---TODICTIONARY:

var funcionariosID = FonteDeDados.GetFuncionariosID();

var listDic = funcionariosID.ToDictionary<Funcionario, int>(a => (int)a.ID);
foreach (var chave in listDic.Keys)
{
    Console.WriteLine($"ID: {chave} - Funcionário: {(listDic[chave] as Funcionario).Nome}");//Cast
}
//EXPLICAÇÂO:
/*"ID" - é a chave, que deve ser única para cada membro. <TKey>
 *"Funcionario"  é a classe definida como valor.  <TValue>
 *"listadic" - recebe um Dictionary<int, Funcionario>/<TKey, TValue>.
 *"listadic.Keys" - é a coleção de chaves.
 *"(listadic[chave] as Funcionario).Nome" - é um cast realizado para poder obter outras propriedades
 *da classe/objeto Funcionario. (Em Dictionary o índice é a chave, pode ser qualquer valor).*/

//----TOLOOKUP:

var funcionariosSetor = FonteDeDados.GetFuncionariosB();

var listaLookUp = funcionariosSetor.ToLookup(x => x.SetorID);
foreach (var kvp in listaLookUp)
{
    Console.WriteLine($"Setor ID {kvp.Key}");
    foreach (var item in listaLookUp[kvp.Key])
    {
        Console.WriteLine($"\t{item.Nome} - {item.Cargo}");
    }
}

/*OBS: Semelhante ao Dictionary, porém a Key não precisa ser única por membro. 
 * Serve para coleção de chaves. (Ex: ID de setor/Cidades/etc comportam vários funcionários
 * e podem ser TKey do ToLookUp).*/

//-----------------------------------LINQ: PARTICIONAMENTO-------------------------------

//---TAKE:
// Take(3) -- Take(..5)(os 5 últimos) -- Take(3..10)(Pega nesse range especifico)

//Exemplo de Take:
var nmrs = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result = nmrs.Take(5).ToList(); //Pega os 5 primeiro elementos da lista.
foreach (var item in result)
{
    Console.WriteLine(item);
}
//Exemplo de Take com Order:
var nmrs2 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result2 = nmrs2.OrderByDescending(n => n).Take(5).ToList(); /*Invertee pega os 5 
                                                                     * primeiro elementos da lista.*/
foreach (var item in result2)
{
    Console.WriteLine(item);
}
//Exemplo de Take com Order e Filtro:
var nmrs3 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result3 = nmrs3.OrderBy(n => n)
                          .Where(n => n >= 50).Take(4).ToList(); /*Invertee, Filtra e pega os 4 
                                                                  *elementos da lista de acordo
                                                                  *com o Filtro.*/
foreach (var item in result3)
{
    Console.WriteLine(item);
}

//Sintaxe de consulta:
List<int> res = (from n in nmrs3
                 select n).Take(4).ToList();

//---TAKEWHILE:
/*OBS: "TakeWhile" aplica a condição de acordo com o valor e TAMBÉM com a posição no indice.
 *Já o "Where" aplica a condição de acordo com todos os valores da lista (na ordem posicionada).*/

var n1 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };

List<int> r1 = n1.TakeWhile(n => n < 50).ToList(); /*Age TAMBÉM acordo com a posição do elemento, e 
                                                     *não somente dos valores*/
foreach (var r in r1)
{
    Console.Write(r + " "); //1, 20
}
Console.WriteLine();
//Exemplo Where:
var n2 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };

List<int> r2 = n2.Where(n => n < 50).ToList(); /*Age SOMENTE nos valores da lista,
                                                *Na ordem de posição*/
foreach (var r in r2)
{
    Console.Write(r + " "); //1, 20, 2, 5, 7, 3, 9
}

//TakeWhile com sobrecarga de método:

var nomes = new List<string>() { "Paula", "ísis", "Amanda", "Jay", "Naís" };

List<string> result = nomes.TakeWhile((n, index) => n.Length > index).ToList();
/*Lógica: Retornará os nomes até que o tamanho seja igual ao índice. (Jay - 3 letras/Index 3).*/
foreach (var nome in result)
{
    Console.WriteLine(nome);
}

//---SKIP:
/*Contrário do Take(). Ignora quantidade "n" de valores e retorna o restante.*/

var nmrs = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result = nmrs.Skip(5).ToList();
foreach (var item in result)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Exemplo de Take com Order:
var nmrs2 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result2 = nmrs2.OrderByDescending(n => n).Skip(5).ToList(); /*Invertee pega os 5 
                                                                     * primeiro elementos da lista.*/
foreach (var item in result2)
{
    Console.Write(item + " ");
}
Console.WriteLine();
//Exemplo de Take com Order e Filtro:
var nmrs3 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };
List<int> result3 = nmrs3.OrderBy(n => n)
                          .Where(n => n > 50).Skip(2).ToList(); /*Invertee, Filtra e pega os 4 
                                                                  *elementos da lista de acordo
                                                                  *com o Filtro.*/
foreach (var item in result3)
{
    Console.Write(item + " ");
}

//SKIPWHILE:

var n1 = new List<int>() { 1, 20, 68, 50, 100, 98, 2, 5, 7, 3, 9 };

List<int> r1 = n1.SkipWhile(n => n < 50).ToList(); /*Age TAMBÉM acordo com a posição do elemento, e 
                                                     *não somente dos valores*/
foreach (var r in r1)
{
    Console.Write(r + " "); //1, 20
}
Console.WriteLine();

var nomes = new List<string>() { "Paula", "ísis", "Amanda", "Jay", "Naís" };

List<string> result = nomes.SkipWhile((n, index) => n.Length > index).ToList();
///*Lógica: Retornará os nomes à partir daquele que tem tamanho igual ao índice. (Jay - 3 letras/Index 3).*/
foreach (var nome in result)
{
    Console.WriteLine(nome);
}


//-------------------------------------LINQ: GERAÇÃO----------------------------------

//---RANGE:

IEnumerable<int> numeros = Enumerable.Range(1, 10);//.Reverse(), por exemplo.
foreach (int n in numeros)
{
    Console.Write(n + " ");
}
Console.WriteLine();
//Com filtros:
var pares = Enumerable.Range(10, 30).Where(x => x % 2 == 0);
foreach (int p in pares)
{
    Console.Write(p + " ");
}
Console.WriteLine();
var quadrado = Enumerable.Range(1, 10).Select(x => x * x);
foreach (int q in quadrado)
{
    Console.Write(q + " ");
}

//---REPEAT:

var repetirNome = Enumerable.Repeat("Azkeel", 5);
foreach (string s in repetirNome)
{
    Console.WriteLine(s);
}

var repetirNumero = Enumerable.Repeat(999999999, 10);
foreach (var n in repetirNumero)
{
    Console.WriteLine(n);
}

//---EMPTY<T>:

//Não retornará excessão. Serve para objetos e listas.
var vazio = Enumerable.Empty<Aluno>();
var vazio2 = Enumerable.Empty<string>();
foreach (var aluno in vazio)
{
    Console.WriteLine(aluno);
}
Console.WriteLine("Concluído");

Console.WriteLine(vazio.Count());
Console.WriteLine(vazio.GetType().Name);

//var Data = GetData() ?? Enumerable.Empty<Aluno>(); //Simulando uma busca de dados retornando null.
//// "??" verifica se é null, e se for rertorna a coleção vazia. Não lança exception.

//----------------LINQ: APPEND<T>, PREPEND<T>, ZIP--------------------------------

//---APPEND<T>:
//Lança valor no final da lista sem alterá-la. Pois vai para uma cópia.

var nums = new List<int>() { 1, 2, 3, 4 };

//Sintaxe 1:
nums.Append(5);
Console.WriteLine(string.Join(", ", nums.Append(5)));

//Sintaxe 2:
var copia = nums.Append(5);//.ToList() para declaração explicita.
Console.WriteLine(string.Join(", ", copia));

//---PREPEND<T>:
//Lança valor no começo da lista sem alterá-la. Pois vai para uma cópia.

var nums2 = new List<int>() { 1, 2, 3, 4 };

//Sintaxe 1:
nums2.Prepend(5);
Console.WriteLine(string.Join(", ", nums2.Prepend(5)));

//Sintaxe 2:
var copia2 = nums2.Prepend(5).ToList();
Console.WriteLine(string.Join(", ", copia2));

//---ZIP:

//Mescla as duas listas, de acordo com o index semelhante.

int[] nums = { 10, 20, 30, 40, 50 };
string[] words = { "Dez", "Vinte", "Trinta", "Quarenta" };

var resultado = nums.Zip(words, (prim, seg) => prim + " " + seg);

foreach (var item in resultado)
{
    Console.WriteLine(item); //Não terá o "50" pois não tem index correspondente na outra lista.
}

//Com cálculo:
int[] nums2 = { 10, 20, 30, 40, 50 };
int[] nums3 = { 10, 20, 30, 40, 50 };

var resultado2 = nums2.Zip(nums3, (x, y) => x * y);

foreach (var item in resultado2)
{
    Console.WriteLine(item);
}


//------------------------------------LINQ: CONVERSÃO PT2-------------------------------------------

/* OBS: IEnumerable - Ideal para consultar List, Array, etc. (Dados na memória).
 *      IQueryable - Ideal para consultar DB, Paginação, Serviços, etc. (dados externos).*/


//---AsENUMERABLE - (Converte uma lista em seu tipo equivalente IEnumerable):

int[] nums = { 1, 20, 35, 87, 999 };
var copiaAsEnumerable = nums.AsEnumerable();
foreach (int i in copiaAsEnumerable)
{
    Console.WriteLine(i);
}

string[] nomes = { "AA", "ZZ", "kk" };
var result = nomes.AsEnumerable();
foreach (string s in nomes)
{
    Console.WriteLine(s);
}

//---AsQueryable - (Converte um IEnumerable em IQueryable):

var nmrs = new List<int>() { 1, 50, 60, 80, 100 };
IQueryable<int> result = nmrs.AsQueryable();

Expression expressionTree = result.Expression;
Console.WriteLine($"NodeType da árvore: {expressionTree.NodeType.ToString()}");
Console.WriteLine($"Tipo da árvore: {expressionTree.Type.Name}");

foreach (var item in result)
{
    Console.WriteLine(item);
}

//---CAST - (Tenta converter os items de uma coleção em outro tipo).

var ArrayList = new ArrayList { 1, 20, 50, 80, 7890 };
var conversao = ArrayList.Cast<int>();  //Variavel recebe uma conversão para List<int>.
var conversao2 = ArrayList.Cast<object>();  //Variavel recebe uma conversão para List<object>.

ArrayList.Add("80"); /* Lança excessão convertido para List<int>. Pois não suporta diferentes tipos.
                      * Não lança excessão convertido para List<object>.*/

foreach (var item in conversao2)
{
    Console.WriteLine(item);
}

//---OfType: - (Filtra o tipo desejado para retornar em uma lista com mais de um tipo).

var ListaVariada = new List<object>() { 10, 1, "Maria", 50, "Lúcia", 5, 60, 70, 80, "Ana Clara", 90 };

var listaFiltrada = ListaVariada.OfType<int>();

foreach (var item in listaFiltrada)
{
    Console.Write(item + " ");
}
Console.WriteLine();
//Com mais filtros:
var listaFiltrada2 = ListaVariada.OfType<int>().Where(x => x >= 50).ToList();
foreach (var n in listaFiltrada2)
{
    Console.Write(n + " ");
}

//Sintaxe de consulta:
var consulta = (from item in ListaVariada
                where item is int
                select item).ToList();


















