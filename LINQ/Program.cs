using LINQ_FonteDeDados;
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
//Union omum - (Para comparar):
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