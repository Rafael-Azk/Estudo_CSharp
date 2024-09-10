using LINQ_FonteDeDados;
using System.Runtime.CompilerServices;
//-------------------------------------LINQ-----------------------


//IList<string> frutas = new List<string>() { "Laranja", "Banana", "Abacaxi", "Melancia", "Mexerica" };

////SINTAX CONSULTA QUERY:
//var result = from f in frutas
//             where f.ToLower().Contains("r")
//             select f;
//Console.WriteLine(string.Join(" - ", result));

////SINTAX CONSULTA METODO:
//var result2 = frutas.Where(f => f.ToLower().Contains("m")); /* Um lambda baseado em Delegate Func,
//                                                            * que retorna um booleano.*/
//Console.WriteLine(string.Join(" - ", result2));

//-----------------SOBRE LAMBDA--------------------
//var nomes = new List<string>() { "Ana", "Julia", "Keila" };

////------METODO ANTIGO DE CONSULTA:
//string? resultado = nomes.Find(NomeNaLista);
//Console.WriteLine(resultado);

//static bool NomeNaLista(string _nome)
//{
//    return _nome.ToLower().Equals("keila");
//}
////------METODO CONSULTA DELEGATE---
//string? resultado2 = nomes.Find(delegate (string nome)
//                               { return nome.ToLower().Equals("keila"); });
//Console.WriteLine(resultado2);
////------METODO CONSULTA LAMBDA---
//string? resultado3 = nomes.Find(n => n.ToLower().Contains("keila"));
//Console.WriteLine(resultado3);

//--------------------LINQ - FILTROS:---------------------------------
//Obs: "Where" retorna dados de uma lista, com base em funções de predicado.
//using LINQ_FonteDeDados;

//var numeros = FonteDeDados.GetNumeros();
//var resultado1 = numeros.Where(n => n > 20);
//Console.WriteLine(string.Join(" ", resultado1));
//var resultado2 = numeros.Where(n => n > 20 && n != 4);
//Console.WriteLine(string.Join(" ", resultado2));

//var listraNegra = FonteDeDados.GetListaNegra();
//var resultado3 = numeros.Where(n => !listraNegra.Contains(n)); /*Como está negando, os números
//                                                                * da lista na verdade não vão
//                                                                * aparecer.*/
//Console.WriteLine(string.Join(" ", resultado3));

//var alunos = FonteDeDados.GetAlunos();
//var resultado4 = alunos.Where(a => a.Nome.ToLower().StartsWith("m") && a.Idade <= 30);
//foreach (var alu in resultado4)
//{
//    Console.WriteLine($"Nome: {alu.Nome} | Idade: {alu.Idade}");
//}
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

////Selecionar Select lista completa: (Select implicito)
//IEnumerable<Aluno> alunos = FonteDeDados.GetAlunos().ToList(); //"ToList()" para retornar os dados de imediato.
//foreach (var aluno in alunos)
//{
//    Console.WriteLine($"Nome: {aluno.Nome} - Idade: {aluno.Idade}");
//}

////Selecionar Select propriedade específica:
//IEnumerable<string> nomesAlunos = FonteDeDados.GetAlunos().Select(a => a.Nome);/*"Select" para ter
//                                                                                * apenas uma propriedade.*/
//foreach (var nome in nomesAlunos)
//{
//    Console.WriteLine($"{nome}");
//}

////Para Select selecionar algumas propriedades da classe.
//List<Aluno> lista = FonteDeDados.GetAlunos().Select(a => new Aluno()
//{
//    Nome = a.Nome,
//    Idade = a.Idade
//}).ToList();
//foreach (var aluno in lista)
//    Console.WriteLine($"{aluno.Nome} - {aluno.Idade}");

////Metodo Select com tipo anonimo:
//var alunoTipoAnonimo = FonteDeDados.GetAlunos().Select(a => new
//{
//    Nome = a.Nome,
//    Idade = a.Idade
//}).ToList();
//foreach (var aluno in alunoTipoAnonimo)
//    Console.WriteLine($"{aluno.Nome} - {aluno.Idade}");

////Cálculos:
//var listaFuncionarios = FonteDeDados.GetFuncionarios().Select(f => new
//{
//    Nome = f.Nome,
//    SalarioAnual = (f.salario * 12).ToString("c")
//}).ToList();
//foreach(var f in listaFuncionarios)
//{
//    Console.WriteLine($"Nome: {f.Nome} - Salário anual: {f.SalarioAnual}" );
//}

//-----------SELECTMANY:
//Obs: Combina listas e/ou lista de listas -> (List<List<int>>>)

//List<List<int>> listas = new List<List<int>>
//{
//    new List<int> { 1, 25, 33, 12, 25 },
//    new List<int> {59},
//    new List<int> {750, 918},
//    new List<int> { 13, 15, 77 }
//};
//IEnumerable<int> resultado = listas.SelectMany(lista => lista);
//foreach (var f in resultado) { Console.Write(f + " "); }
//Console.WriteLine();
//IEnumerable<int> resultado2 = listas.SelectMany(lista => lista.Distinct());/*"Distinct" remove
//                                                                            * os elementos repetidos
//                                                                            * de uma lista*/

//foreach (var f in resultado2) { Console.Write(f + " "); }

//---------------EXEMPLO:
////SELECT: (Necessário 2 "foreach". Um acessa a lista, outro o valores)

//IEnumerable<List<string>> retornoSelect = FonteDeDados.GetAlunos().Select(c => c.cursos);
//foreach (List<string> listaCursos in retornoSelect)
//{
//    foreach (var curso in listaCursos)
//    {
//        Console.Write($"{curso} ");
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();
////SELECTMANY: (Acessa os valores diretamente e concatena).
//IEnumerable<string> retornoSelectMany = FonteDeDados.GetAlunos().SelectMany(c => c.cursos);

//foreach (var curso in retornoSelectMany)
//{
//    Console.Write($"{curso} ");

//}

//---------------------------------LINQ: CONJUNTO-----------------------------------
/*Distinct/DistinctBy - Remove valores duplicados de uma coleção.
 * Except/ExceptBy - Retorna todos os valores na lista "X" que não existem na lista "Y".
 * Intersect/IntersectBy - Retorna todos os valores iguais em ambas as listas X/Y.
 * Union/UnionBy - Une ambas as listas X/Y. Eliminando as repetições*/

////Distinct: 
//var idades = new[] { 10, 50, 10, 9, 9, 33, 77 };
//var idadesDistintas = idades.Distinct().ToArray();    
//var idadesDistintas2 = idades.Distinct().ToList();
//var idadesDistintas3 = idades.Distinct();
//foreach (var idade in idadesDistintas3) { Console.Write($"{idade} "); }
///*Sintaxe de consulta:
// * var result = (from num in idades
// *               select num).Distinct();*/

//var nomes = new[] { "Maria", "Paula", "Maria", "Fernanda", "Melissa", "Fernanda" };
//var nomesDistintos = nomes.Distinct(StringComparer.OrdinalIgnoreCase); /*Vai ignorar as diferenças de
//                                                                        * digitação*/

//foreach (var nome in nomesDistintos) { Console.Write($"{nome} "); }

////DistinctBy:
//var alunos = FonteDeDados.GetAlunos().ToList();
//var alunosIdadesDistintas = alunos.DistinctBy(a => a.Idade);//Não exibirá alunos com a mesma idade.
//foreach(var a in alunosIdadesDistintas) { 
//    Console.WriteLine($"Aluno: {a.Nome} - idades: {a.Idade}"); }

////Except:
//var fonte1 = new List<string>() { "USA", "Brasil", "Mexico", "Russia" };
//var fonte2 = new List<string>() { "usa", "mexico" };
//var resultado = fonte1.Except( fonte2, StringComparer.OrdinalIgnoreCase).ToList(); //Não exibirá nums da lista 1 que se repetem na 2.
//foreach(var i in resultado) { Console.Write(i + " "); }
////Exceptby:
//var alunos = FonteDeDados.GetAlunos();
//var alunosReprovados = new List<string>() { "lucia", "katy", "marta" };
//var alunosAprovados = alunos.ExceptBy(alunosReprovados, n => n.Nome, StringComparer.OrdinalIgnoreCase);
//foreach(var aluno in alunosAprovados) { Console.WriteLine(aluno.Nome + " "); }

//Intersect:
//var num1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
//var num2 = new List<int>() { 1, 3, 5, 8, 9, 10 }; 
//var result = num1.Intersect(num2).ToList();    //Irá retornar os nums que se repetem nas duas listas.
//foreach(var n in result) { Console.Write(n + " "); }
////Sintaxe de consulta:
//var resultado = (from n in num1
//                 select n ).Intersect(num2).ToList();
//foreach(var n in resultado) { Console.Write(n + " "); }
//Console.WriteLine("\n");

//IntersectBy:
//Intersect comum - (Para comparar):
//var turmaA = FonteDeDados.GetTurmaA();
//var turmaB = FonteDeDados.GetTurmaB();
//var consulta = turmaA.Select(p => p.Nascimento)//Intersect comum. Recebe apenas os anos.
//                            .Intersect(turmaB.Select(p => p.Nascimento));
//foreach (var ano in consulta) { Console.WriteLine(ano + " "); }
////By:
//var alunosMesmoAnoNascimento = turmaA.IntersectBy(turmaB.Select(p => p.Nascimento),
//                                                  p => p.Nascimento);/*Retorna nome e ano dos alunos
//                                                                      *que nasceram na mesma época*/
//foreach (var n in alunosMesmoAnoNascimento) { 
//    Console.WriteLine($"Nome: {n.Nome} - Nascimento: {n.Nascimento}"); }

//Union:
//var num1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
//var num2 = new List<int>() { 1, 3, 5, 8, 9, 10 };
//var result = num1.Union(num2).ToList();         //Une as duas listas. Eliminando repetições.
//foreach(var n in result) { Console.Write(n + " "); }

//UnionBy:
//Union comum - (Para comparar):
//var turmaA = FonteDeDados.GetTurmaA();
//var turmaB = FonteDeDados.GetTurmaB();
//var unionComum = turmaA.Select(x => x.Nome).Union(turmaB.Select(x => x.Nome), StringComparer.OrdinalIgnoreCase);
///*Retorna apenas nome, porque retorna uma lista*/

//foreach (var n in unionComum) { Console.Write(n + " "); }

//Console.WriteLine();
////By:
//var turmaUnionBy = turmaA.UnionBy(turmaB, p => p.Nome, StringComparer.OrdinalIgnoreCase);
///*Retorna todos os parâmetros. Porque retorna objetos*/
//foreach (var n in turmaUnionBy)
//{
//    Console.WriteLine($"Nome: {n.Nome} -  Nascimento: {n.Nascimento}");
//}

//----------------------------LINQ: ORDENAÇÃO-----------------------------

//OrderBy/OrderByDescending - Ordena por ondem crescente ou decrescente:
//var nomes = new List<string>() { "Carla", "Tania", "Roberta", "Amanda", "Alessandra" };
//var lista = nomes.OrderBy(x => x).ToList();
//foreach (var item in lista) { Console.Write(item + " "); }
//Console.WriteLine();
//var lista2 = nomes.OrderByDescending(x => x).ToList();
//foreach (var item in lista2) { Console.Write(item + " "); }
//Console.WriteLine();
////Sintaxe de consulta:
//var lista3 = (from nome in nomes
//              orderby nome descending //ascending se quiser ascendente.
//              select nome).ToList();
//foreach (var item in lista3) { Console.Write(item + " "); }

//Objetos complexos:
//var alunos = FonteDeDados.GetAlunos().ToList();
//var lista1 = alunos.OrderBy(x => x.Nome).ToList();
//var lista2 = alunos.OrderByDescending(x => x.Nome).ToList(); 
////Múltiplas propriedades:
//var lista3 = alunos.OrderBy(x=>x.Nome).ThenBy(x=> x.Idade).ToList();
//var lista4 = alunos.OrderByDescending(x => x.Nome).ThenByDescending(x => x.Idade).ToList();
//foreach (var item in lista4) { Console.WriteLine($"{item.Nome} - {item.Idade}"); }
////Sintaxe de consulta:
//var listConsulta = (from a in alunos
//            orderby a.Nome, a.Idade
//            select new {a.Nome, a.Idade}).ToList();
//foreach(var a in listConsulta) { Console.WriteLine(a + " "); }
//Ordenação com filtro:
//var listaFiltro = alunos.Where(a => a.Nome.ToLower().Contains("m"))
//                                .OrderBy(x=>x.Nome).ThenBy(x=> x.Idade).ToList();
//foreach(var i in listaFiltro) {  Console.WriteLine($"{i.Nome} - {i.Idade}"); }

//--------------REVERSE:

//var nums = new int[] { 1, 5, 25, 2, 4, 1, 500, 25, 300 };
//var lista = nums.Reverse();
//foreach(var num in lista) { Console.Write(num + " "); }
//Console.WriteLine();
////Sintaxe de consulta:
//var list = (from num in nums
//            select num).Reverse(); 
//foreach(var n in list) { Console.Write(n + " "); }

//Para List<T> - (Tipos genericos):
//var nomes = new List<string>() { "Paula", "Amanda", "Maria", "Bruna" };
//nomes.Reverse();    //Aplica o reverse diretamente. Não numa variável.
//foreach(var n in nomes) { Console.Write(n + " "); }
//Console.WriteLine();
////Para usar reverse na variável de uma coleção:
//IEnumerable<string> lista = nomes.AsEnumerable().Reverse(); 
//IQueryable<string> lista2 = nomes.AsQueryable().Reverse();//Queryable, melhor para Banco de Dados.
//foreach(var nome in lista2) { Console.Write(nome + " "); }

//---------------------------------LINQ: AGREGAÇÃO---------------------------------------

//Aggregate:
//var cursos = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
//string resultado = cursos.Aggregate((s1, s2)  => s1 + "," + s2);/*Como lista vai concatenando 
//                                                                 * s1 = s1+s2 (E s1 vai atualizando).*/
//Console.WriteLine(resultado);
//var numeros = new int[] {3,5,7,9,10};
//int calculo = numeros.Aggregate((n1, n2) => n1 * n2); //É como n1 = n1*n2 (E n1 vai atualizando).   
//Console.WriteLine(calculo);

//Aggregate com semente:
//List<Aluno> alunos = new()
//{
//    new Aluno(){Nome = "Lilith", Idade = 25},
//    new Aluno(){Nome = "Keyla", Idade=17 },
//    new Aluno(){Nome="Kátia", Idade=18}
//};
////string listaAlunos = alunos.Aggregate<Aluno, string>("Nomes: ", (semente, aluno) => 
////                                                        semente += aluno.Nome + ", ");
////Console.WriteLine(listaAlunos);//Mantém a última vírgula.
///
//////Para remover a última vírgula:
////int indice = listaAlunos.LastIndexOf(",");
////listaAlunos = listaAlunos.Remove(indice);
////Console.WriteLine(listaAlunos);
////Remover vírgula com lambda:
//string listaAlunos2 = alunos.Aggregate<Aluno, string, string>("Nomes: ", (semente, aluno) =>
//                                                        semente += aluno.Nome + ", ",
//                                                        resultado=> resultado.Substring(0,resultado.Length-1));
//Console.WriteLine(listaAlunos2); //Já virá sem vírgula.

//Average: (Calcula média de valores numéricos em uma coleção).
//List<Aluno> alunos = new()
//{
//    new Aluno(){Nome = "Lilith", Idade = 25},
//    new Aluno(){Nome = "Keyla", Idade=17 },
//    new Aluno(){Nome="Kátia", Idade=18}
//};
//var mediaIdades = alunos.Average(aluno => aluno.Idade);
//Console.WriteLine($"Média de idade: {mediaIdades}");

//Count:(Retorna total de elementos em uma coleção):
//var cursos = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
//var totalCursos = cursos.Count();
//Console.WriteLine($"Total de cursos: {totalCursos}");
////Sintaxe de consulta:
//var nCursos = (from c in cursos
//               select c).ToList().Count();

//Com filtro:
//var cursos2 = new string[] { "C#", "Java", "PHP", "C", "Assembly" };
//var result1 = cursos2.Count(c => c.ToLower().Contains("p"));
//var result2 = cursos2.Where(c => c.ToLower().Contains("c")).ToList().Count();
//Console.WriteLine($"Número de cursos com C: {result2}");
////Sintaxe de consulta:
//var nCursos2 = (from c in cursos2
//                where c.ToLower().Contains("c")
//                select c).ToList();

//Sum: (Soma os valores da coleção):
//int[] numeros = { 1, 50, 150, 300, 700, 900, 777000 };
//int resultado = numeros.Sum();
//Console.WriteLine(resultado);

////Com filtro:
//var result1 = numeros.Where(n => n < 100).Sum(); //Opção 1.
//var result2 = numeros.Sum(n =>
//{
//    if (n < 10)
//        return n;
//    else
//        return 0;
//}
//); //Opção 2.
//Console.WriteLine(result1);

//Min/Max: (Melhor para coleções simples):
//decimal[] salario = {1900.00m, 3500.00m, 800700.00m };

//var maiorSalario = salario.Max();
//var menorSalario = salario.Min();
//Console.WriteLine($"Maior salario: {maiorSalario.ToString("c")} - Menor salario: {menorSalario.ToString("c")}");
////Sintaxe de consulta:
//var res = (from f in salario
//           select f).Max();
//Console.WriteLine(res);

//MaxBy/MinBy: (Melhor para objetos complexos):
//List<Funcionario> funcionarios = new()
//{
//    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
//    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
//    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
//};
//var maiVelho = funcionarios.MaxBy(f => f.Idade);
//var maisNovo = funcionarios.MinBy(f => f.Idade);
////Jeito antigo:
//var velho = funcionarios.OrderBy(f => f.Idade).First();
//var novo = funcionarios.OrderByDescending(f => f.Idade).First();
//Console.WriteLine($"Novinha: {maisNovo?.Nome} - Idade: {maisNovo?.Idade}\nMais velha: {maiVelho?.Nome} - Idade{maiVelho?.Idade}");

//----------------------------------LINQ: QUANTIFICAÇÃO--------------------------------
/*All() - Determina se todos os elementos satisfaz a condição;
 *Any() - Determina se pelo menos um elemento satisfaz a condição;
 *Contains() - Determina se a coleção contém um valor específico*/

//All:
//int[] nums = { 2, 54, 306, 90 };
//var result = nums.All(x => x % 2 == 0);//True se todos os números são pares.  
//Console.WriteLine($"{(result ? "Todos são pares" : "Nem todos são pares")}");

//List<Funcionario> funcionarios = new()
//{
//    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
//    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
//    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
//};
//var salariosAcima = funcionarios.All(x => x.salario > 1000.00m);
//var nomesComLetra = funcionarios.All(x => x.Nome.Contains("i"));
//Console.WriteLine($"Salarios acima de 2k? {salariosAcima} - Todos nomes tem 'i'? {nomesComLetra}");

//Sintaxe de consulta:
//var result2 = (from s in funcionarios
//               select s).All(s => s.salario > 2000);

//Any:
//int[] nums = { 3, 54, 307, 91 };
//var result = nums.Any(x => x % 2 == 0);//True se todos os números são pares.  
//Console.WriteLine($"{(result ? "Ao menos um é par" : "Nenhum é par")}");

//List<Funcionario> funcionarios = new()
//{
//    new Funcionario(){Nome = "Lilith", Idade = 25, salario= 1900.00m},
//    new Funcionario(){Nome = "Keyla", Idade=17, salario= 2800.00m },
//    new Funcionario(){Nome="Kátia", Idade=22, salario=800700.00m}
//};
//var elemento = funcionarios.Any(); //Verifica se tem algum elemento na coleção. 
//var salariosAcima = funcionarios.Any(x => x.salario < 1000.00m && x.Idade > 30);
//var nomesComLetra = funcionarios.Any(x => x.Nome.ToUpper().Contains("I"));
//Console.WriteLine($"Algum salarios abaixo de 1k? {salariosAcima} - Algum nome tem 'I'? {nomesComLetra}");
//Console.WriteLine(elemento);

//Contains:

//------------CONTAINS PARA OBJETOS COMPLEXOS!!!!!:
//var alunos = FonteDeDados.GetAlunos();
//ComparerAluno comparador = new ComparerAluno(); //Comparer feito modificando Equals e GetHashCode.

//var alunoBuscado = new Aluno() { Nome = "Katy", Idade = 30 };
//var resultado = alunos.Contains(alunoBuscado, comparador);
//Console.WriteLine($"Aluno existe? {resultado}");

////Contains para objeto simples:
//int[] nums = { 1, 2, 50, 70, 90 };
//Console.WriteLine(nums.Contains(90));

//--------------------------------------AGRUPAMENTO-----------------
//GroupBy:
//var funcionarios = FonteDeDados.GetFuncionarios();
//var grupos = funcionarios.GroupBy(a => a.Idade).OrderBy(c => c.Key);//ORDER É OPCIONAL.

///*Sintaxe de consulta ordenada:
//var grupos2 = (from f in funcionarios
//               group f by f.Idade into grupo
//               orderby grupo.Key
//               select grupo);*/
///*Sintaxe de consulta simples:
//var grupos2 = (from f in funcionarios
//               group f by f.Idade);*/

//foreach (var grupo in grupos)
//{
//    Console.WriteLine($"Idade: {grupo.Key} - Qtd. Funcionários: {grupo.Count()} ");
//    foreach (var funcionario in grupo)
//    {
//        Console.WriteLine($"\t{funcionario.Nome} {funcionario.salario.ToString("c")}");
//    }
//}

//------COMPLEXO! PELOS CURSOS:

//var alunos = FonteDeDados.GetAlunosB();
//var grupos = alunos.GroupBy(a=> a.Cursoo)
//                            .OrderBy(c=> c.Key)
//                             //Primeiro ordena os dados baseado na chave curso:
//                            .Select(std => new
//                            {
//                                Key = std.Key,
//                                //Ordena os dados baseado no nome:
//                                Alunos = std.OrderBy(x => x.Nome)
//                            }).ToList();
//foreach (var grupo in grupos)
//{
//    Console.WriteLine($"Curso: {grupo.Key} (Alunos: {grupo.Alunos.Count()}) ");
//    foreach (var aluno in grupo.Alunos)
//    {
//        Console.WriteLine($"\tAluno: {aluno.Nome} - Idade: {aluno.Idade}");
//    }
//}
//Console.WriteLine();

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














