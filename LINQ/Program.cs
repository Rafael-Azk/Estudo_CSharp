
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
