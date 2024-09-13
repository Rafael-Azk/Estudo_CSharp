//SINTAXE BASICA:
//NomeTipo<T> - "T" é parametro.

public class ClasseGeneric<T>
{

}
IInterfaceGeneric<T>
{

}
public void MetodoGeneric<T>(T x)
{

}
//Podem ter mais de um parametro - <T1, T2>
//------------------------------------------Restrição------
public void MetodoGeneric<T>(T x) where T : class //Obrigatório parametro <T> ser uma Class.
{

}
public class ClassGeneric<T1, T2> where T1 : struct where T2 : class
{

}
//---------------Tipos mais Usados:-----

//Collection<T>
//List<T> --- Versão genérica e tipada de ArrayList.
//Dictionary<Tkey, Tvalue> --- Chave/Valor (Chave é única).
//Queue<T> --- Fila
//Stack<T> ---- Pilha.
//HashSet<T> --- Lista com valores distintos, sem repetir.

//---------------------------------------------------------------------------------------------------
//EXEMPLO GENERIC EM METODO/CLASS:

//Teste<int, int> teste1 = new Teste<int, int>(); //Exemplo com Generic na classe.

Teste teste = new Teste();

int i1 = 1;
double i2 = 1.2565;
teste.Comparar(i1, i2);
int i3 = 10;
int i4 = 10;
teste.Comparar(i3, i4);
string s1 = "haha";
string s2 = "hehe";
teste.Comparar(s1, s2);

class Teste // Teste<T1, T2> - exemplo com Generic na classe.
{
    public void Comparar<T>(T x, T y) //Apenas (T1 x, T2 y), se com Generic na Classe.
    {
        Console.WriteLine($"x:{x.GetType()} e y:{y.GetType()}");
        var resultado = x.Equals(y); //Equals() compara o tipo E o valor.
        Console.WriteLine($"x:{x} e y:{y} são de tipos e valor iguais: {resultado}");
    }
}

//---class Teste<T1, T2> where T1 : struct where T2 : struct
//(Obriga os valores a ser do tipo STRUCT, que é tipo de valor.Ex: Int, Float, etc).

//---------------------------------------------------------------------------------------------

//LIST<T>: - (Versão genérica de ArrayList).
//(Obs: Metodos parar add e remover semelhante ao ArrayList).

//List<string> pessoas = new()
//{
//    "Rafael A.", "Nanda M.", "Dai S.", "Rafael B."
//};
//var findAll = pessoas.FindAll(i => i.ToLower().Contains('r')); //lAMBDA
//foreach (var item in findAll)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("Index");
//Console.WriteLine(pessoas.IndexOf("Rafael B."));

//----------------------------------------------------------------------
//EQUALS E GETHASHCODE - COMPORTAMENTO PADRÃO:
string a = "João";
string b = "João";
int x = 7;
int y = 7;
Console.WriteLine(a.Equals(b));
Console.WriteLine(x.Equals(y)); //Retornam True pois valor e tipo são iguais.

Console.WriteLine(a.GetHashCode());
Console.WriteLine(b.GetHashCode());
Console.WriteLine(x.GetHashCode());
Console.WriteLine(y.GetHashCode());//Retorna HashCode igual pois são objetos iguais.

var pessoa1 = new Pessoa("Ana", 777);
var pessoa2 = new Pessoa("Ana", 777);
Console.WriteLine(pessoa1.Equals(pessoa2));//Retornam False pois os objetos tem referência diferente.

Console.WriteLine(pessoa1.GetHashCode());
Console.WriteLine(pessoa2.GetHashCode());//Retorna HashCode diferente. Mas tem a chance de ser igual.

public class Pessoa
{
    string? nome { get; set; }
    int id { get; set; }

    public Pessoa(string? nome, int id)
    {
        this.nome = nome;
        this.id = id;
    }
}
//----METODO "SOBRESCREVER" EQUALS/GETHASHCODE: PARA COMPARAR OBJETOS COM BASE EM UMA PROPRIEDADE-------

var pessoa1 = new Pessoa(225577, "Dai");
var pessoa2 = new Pessoa(225577, "Dai");
var pessoa3 = new Pessoa(756987, "Dai");

Console.WriteLine($"Pessoa1 CPF:{pessoa1.cpf} - Passeoa1 Nome:{pessoa1.nome}");
Console.WriteLine($"Pessoa2 CPF:{pessoa2.cpf} - Passeoa2 Nome:{pessoa2.nome}");
Console.WriteLine($"Pessoa3 CPF:{pessoa3.cpf} - Passeoa3 Nome:{pessoa3.nome}");

Console.WriteLine("\nComparando objetos - GetHashCode");
Console.WriteLine(pessoa1.GetHashCode());
Console.WriteLine(pessoa2.GetHashCode());
Console.WriteLine(pessoa3.GetHashCode());

Console.WriteLine("\nComparando objetos - Equals");
Console.WriteLine(pessoa1.Equals(pessoa2));
Console.WriteLine(pessoa2.Equals(pessoa3));

class Pessoa
{
    public Pessoa(int cpf, string? nome)
    {
        this.cpf = cpf;
        this.nome = nome;
    }
    public int cpf { get; set; }
    public string? nome { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Pessoa) return false; // Pode ser (!(obj is Pessoa))
        var other = (Pessoa)obj;
        return cpf.Equals(other.cpf);
    }
    public override int GetHashCode()
    {
        return cpf.GetHashCode();
    }
}
//-----------------------------------------------------------------------------------
//COLEÇÃO DICTIONARY:

//SINTAXE BÁSICA:
Dictionary<string, int> dict1 = new Dictionary<string, int>();  //Atribuido a classe.
IDictionary<int, string> dict2 = new Dictionary<int, string>(); //Atribuido a uma interface.
//<Chave, Valor> - Chave deve ser exclusiva.

/*
 * Count() - Numero total de elementos.
 * ISReadOnly - booleano indicando se o Dictionary é somente leitura.
 * Item[] - Obtém ou define elemento com a chave indicada.
 * Keys - Retorna a coleção de chaves.
 * Values - Retorna a coleção de valores.
 * Comparer - Obtém "IEqualityComparer<T>" , usado para determinar igualdade de chaves para o Dict.
 * 
 * Add<TKey, TValue> - Adiciona um valor no dict. Lança exceção caso já exista a chave.
 * TryAdd<TKey, TValue> - Tenta add chave-valor no dict, mas sem lançat erro caso já exista a chave.
 * Clear() - Remove tudo de um dict.
 * ContainsKey(TKey) - Verifica se tem a chave especificada.
 *ContainsValue(TValue) - Verifica se contém valor especificado.
 *Remove(TKey) - Remove o valor da chave especificada.
 *TryGetValue<TKey, TValue> - Se a chave existir, retorna o valor em TValue (out value).
 */
//--------------------------Exemplo de uso------------------------------

Dictionary<int, int> dic1 = new Dictionary<int, int>();
dic1.Add(1, 20);
dic1.Add(3, 100);
dic1.Add(2, 100);
dic1.TryAdd(6, 500);

var dict3 = new Dictionary<int, int>()
{
    {1, 100 },
    {2, 300 },
    {3, 500 }
};

if (!(dic1.ContainsKey(5))) //ContainsKey
{
    dic1.Add(5, 550); //Add
}
Console.WriteLine(dic1[5]);

if (dic1.ContainsValue(700)) //ContainsValue
{
    Console.WriteLine("Contém o valor");
}
else
{
    Console.WriteLine("Não contém o valor");
}

Console.WriteLine("Valor atual key5: " + dic1[5]);
if (dic1.ContainsKey(5))
{
    dic1[5] = 65000; //Add
}
Console.WriteLine("Valor novo key5: " + dic1[5]);

if (dic1.TryGetValue(2, out var valor)) //TryGetValue, não lança exception.
{
    Console.WriteLine("Valor da chave 2: " + valor); //Caso a chave exista, mostra seu valor.
}
else
{
    Console.WriteLine("Chave não encontrada");//Caso a chave não exista.
}
Console.WriteLine("\nLista:");
foreach (var item in dic1)
{
    Console.WriteLine($"{item.Key} {item.Value}");
}
Console.WriteLine();

Console.WriteLine("Lista ordenada:");
/* var dic1Ordenado = new SortedDictionary<int, int>(dic1); //Ordernar padrão. */
var dic1Ordenado = dic1.OrderBy(x => x.Key); //Ordenar com LINQ.
foreach (var item in dic1Ordenado)
{
    Console.WriteLine($"{item.Key} {item.Value}");
}

Console.WriteLine("Total de chaves:");
Console.WriteLine(dic1.Count); //Mostra a quantidade total de chaves.
Console.ReadKey();
//---------------------------------------------------------------------------------
//COLEÇÃO SortedDictionary:
/* Tudo indêntico ao Dictionary, mas a varredura é feita ordenada. (por isso, mais lento) */

var brics = new SortedDictionary<int, string>()
{
    {50, "Brasil" },
    {20, "Rússia" },
    {10, "Africa do Sul" },
    {30, "China" },
    {40, "India" }
};
foreach (var item in brics) //Exibirá já ordenado.
{
    Console.WriteLine($"{item.Key} {item.Value}");
}

//--------------------------------------------------------------------------------------
//COLEÇÃO SET (HASHSET / SORTEDSET): - (Apenas valores distintos, que não se repetem).
//HASHSET:

//Criação:
HashSet<int> numeros = new HashSet<int>() { 1, 5, 10 };
HashSet<string> frutas = new HashSet<string>() { "Banana", "Laranja" };

var lista = new List<int>() { 1, 5, 6, 10 };
var Lista = new HashSet<int>(lista);
var pares = new int[] { 1, 5, 20, 50, 100 };
var Pares = new HashSet<int>(pares);

//---------------------------Exemplo de uso-----------------------------------
var timeSp = new HashSet<string>() { "Corinthians", "Santos", "Palmeiras" };
var timeSp2 = new HashSet<string>() { "Corinthians", "Santos", "Palmeiras" };
var timeRio = new HashSet<string>() { "Botafogo", "Vasco", "Flamengo" };
var timeMundial = new HashSet<string>() { "Corinthians", "Santos", "Flamengo" };

//Adicionar:
if (!timeSp.Contains("Portuguesa"))
{
    timeSp.Add("Portuguesa");
    timeSp.Add("Santos"); //Não vai add;
}
foreach (var item in timeSp)
{
    Console.WriteLine(item);
}
Console.WriteLine();

//Remover:
timeRio.Remove("Vasco");
foreach (var item in timeRio)
{
    Console.WriteLine(item);
}
Console.WriteLine();

//
if (timeSp.IsSubsetOf(timeMundial))//Subconjunto
{
    Console.WriteLine("SP é SubConjunto de Mundial. ");
}
if (timeMundial.IsSupersetOf(timeSp))//Superconjunto.
{
    Console.WriteLine("Mundial é SuperConjunto de SP");
}
if (timeRio.Overlaps(timeMundial))//Tem algum valor em comum.
{
    Console.WriteLine("RJ tem valores em comum com Mundial.");
}
if (!timeSp.SetEquals(timeMundial))//Não é totalmente igual.
{
    Console.WriteLine("SP não é igual a Mundial.");
}
if (timeSp.SetEquals(timeSp2))//É totalmente igual, (se não add a Portuguesa em timeSP).
{
    Console.WriteLine("SP é igual a SP2.");
}


timeSp.UnionWith(timeRio); //Unir o HashSet (nesse caso, "timeSp"), com outros.
Exibir(timeSp);
Console.WriteLine();
Exibir(timeRio);//"timeRio" continua intacto.
Console.WriteLine();

var listaOrdenada = new SortedSet<string>(timeSp); //-----Ordena a lista.(SortedSet)
Exibir(listaOrdenada);
Console.WriteLine();

timeSp.IntersectWith(timeMundial);//Mantém apenas os valores em comum.
Exibir(timeSp);

timeMundial.ExceptWith(timeSp);//Elimina os valores em comum.
Exibir(timeMundial);

timeSp.SymmetricExceptWith(timeMundial);//Mantém valores que não estão em ambas as listas.
Exibir(timeSp);

timeSp.Clear();//Elimina tudo.

static void Exibir<T>(IEnumerable<T> colecao)
{
    foreach (var item in colecao)
    {
        Console.WriteLine(item);
    }
}
//-----SortedSet -> Identico ao HashSet, porém ordena a lista

//----------------------------------------------------------------------------------------
//STACK<T> - (Pilha).
//Obs: Aceita valor repetido.
Stack<string> DiaSemana = new Stack<string>();
var diaSemana = new Stack<string>();//Não aceita construir direto com os parametros, precisa usar o Push.
diaSemana.Push("Domingo");
diaSemana.Push("Segunda");
diaSemana.Push("Sábado");

int[] array1 = new int[] { 1, 10, 50, 100 };
Stack<int> nums = new Stack<int>(array1); //Aceita variavel como parametro

var lista = new List<string>() { "Banana", "Laranja", "Melancia", "Mexerica" };
var frutas = new Stack<string>(lista);

var impares = new Stack<int>(3);//Determina a capacidade inicial.
impares.Push(1);
impares.Push(2);
impares.Push(3);
impares.Push(1);

//Metodos:
impares.Push(4); //Adiciona elemento no topo da pilha.
Exibir(impares);
Console.WriteLine();

//Retornar o valor no topo da pilha, sem remover. (Peek).
Console.WriteLine($"Valor obtido e mostrado com peek: {impares.Peek()}");
//Retornar o valor no topo da pilha, e remover. (Pop).
Console.WriteLine($"Valor obtido e removido com pop: {impares.Pop()}");
Console.WriteLine("Pilha atual:");
Exibir(impares);

if (impares.Contains(3))//Retorna se o valor está na pilha.
{
    Console.WriteLine("O valor está na pilha");
}
else
{
    Console.WriteLine("Valor não encontrado");
}

var copia = new Stack<int>(impares.ToArray());//Copia os valores da stack para outra variavel.
Console.WriteLine("Pilha Copiada:");
Exibir(copia);

impares.Clear();//Retira todo o conteudo da pilha.
Console.WriteLine($"Lista limpada. {impares.Count()} items na pilha.");
Console.ReadKey();



static void Exibir<T>(IEnumerable<T> impares)
{
    foreach (var item in impares)
    {
        Console.WriteLine(item);
    }
}

//--------------------------------------------------------------------------------
//QUEUE<T> - (Fila).
//Obs: Aceita valor repetido.
Queue<string> DiaSemana = new Queue<string>();
var diaSemana = new Queue<string>();//Não aceita construir direto com os parametros, precisa usar o Enqueue.
diaSemana.Enqueue("Domingo");
diaSemana.Enqueue("Segunda");
diaSemana.Enqueue("Sábado");

int[] array1 = new int[] { 1, 10, 50, 100 };
Queue<int> nums = new Queue<int>(array1); //Aceita variavel como parametro.

var lista = new List<string>() { "Banana", "Laranja", "Melancia", "Mexerica" };
var frutas = new Queue<string>(lista);

var impares = new Queue<int>(3);//Determina a capacidade inicial.
impares.Enqueue(1);
impares.Enqueue(2);
impares.Enqueue(3);
impares.Enqueue(1);

//Metodos:
impares.Enqueue(4); //Adiciona elemento no inicio da fila.
ExibirFila(impares);
Console.WriteLine();

//Retornar o valor no inicio da fila, sem remover. (Peek).
Console.WriteLine($"Valor obtido e mostrado com peek: {impares.Peek()}");
//Retornar o valor no inicio da fila, e remover. (Dequeue).
Console.WriteLine($"Valor obtido e removido com Dequeue: {impares.Dequeue()}");
Console.WriteLine("Fila atual:");
ExibirFila(impares);

if (impares.Contains(3))//Retorna se o valor está na fila..
{
    Console.WriteLine("O valor está na fila");
}
else
{
    Console.WriteLine("Valor não encontrado");
}

var copia = new Stack<int>(impares.ToArray());//Copia os valores da fila para outra variavel.
Console.WriteLine("Fila Copiada:");
ExibirFila(copia);

impares.Clear();//Retira todo o conteudo da fila.
Console.WriteLine($"Lista limpada. {impares.Count()} items na fila.");
Console.ReadKey();



static void ExibirFila<T>(IEnumerable<T> fila)
{
    foreach (var item in fila)
    {
        Console.WriteLine(item);
    }
}

//---------------------------------------------------------------------------------------------
//ReadOnlyCOLLECTION<T>: --> (Apenas leitura).
//(Obs: Existem outras. EX: ReadOnlyDictionary<T>).

using System.Collections.ObjectModel;

var planetas = new List<string>() { "Terra", "Marte", "Saturno" };
//var lista = new ReadOnlyCollection<string>(planetas); //Apenas leitura da lista.
var listaPlanetas = planetas.AsReadOnly(); //Metodo compacto.

Console.WriteLine("Iteração:");
foreach (var planeta in listaPlanetas)
{
    Console.WriteLine(planeta);
}

Console.WriteLine($"\nTotal de planetas: {listaPlanetas.Count}\n");

Console.WriteLine("Netuno está na lista?");
Console.WriteLine(listaPlanetas.Contains("Netuno") ? "Sim\n" : "Não\n");

Console.WriteLine($"Planeta de indice 2: {listaPlanetas[2]}\n");

Console.WriteLine($"Indice da Terra: {listaPlanetas.IndexOf("Terra")}\n");

Console.WriteLine("Copiado para String:");
string[] planetasArray = new string[listaPlanetas.Count];//Array com tamanho igual ao listaPlanetas.
listaPlanetas.CopyTo(planetasArray, 0); //Copia a lista para um array à partir do index indicado (aqui 0).

foreach (var planet in planetasArray)
{
    Console.WriteLine(planet);
}

