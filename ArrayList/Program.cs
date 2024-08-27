//SINTAXE BÁSICA:
//int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//string[] nomes = { "Ana", "Marta", "Carlos", "Diego" }; //Simplificado.

//Console.WriteLine(nomes[0]);
//Console.WriteLine(nomes[2]);

//for (int i = 0; i <= nomes.Length; i++)
//{
//    Console.WriteLine($"indice {i} e valor {nomes[i]} ");
//}

//foreach (var n in nomes)
//{
//    Console.WriteLine(n);
//}
//foreach (var i in numeros)
//{

//    Console.Write(i + " ");
//}
//---------------------------------------------------------------------------------------
//METODOS ARRAY:
//string[] nomes = { "Ana", "Marta", "Carlos", "Diego" };

//Console.WriteLine("Array original");
//ExibirArray(nomes);

//Console.WriteLine("\nArray reverso");
//Array.Reverse(nomes);
//ExibirArray(nomes);

//Console.WriteLine("\nArray reordenado");
//Array.Sort(nomes);
//ExibirArray(nomes);

//Console.WriteLine("\nEncontrando elemento no array");
//Console.WriteLine("Digite o valor");
//string n = Console.ReadLine();
//var index = Array.BinarySearch(nomes, n);

//if (index >= 0)
//{
//    Console.WriteLine($"O index no array é {index}");
//}
//else { Console.WriteLine("Valor não existe no array"); };

//Console.ReadKey();


//static void ExibirArray(string[] nomes)
//{
//    foreach (var i in nomes)
//    {
//        Console.Write(i + " ");
//    }
//}
//------------------------------------------------------------------------------------
//ARRAY EM PARAMETROS:

//int[] ex = { 10, 50, 60, 10 };

//var s1 = Calcular.Somar(ex);
//Console.WriteLine(s1);


//public class Calcular
//{
//    public static int Somar(int[] numeros)
//    {
//        int total = 0;

//        foreach (int n in numeros)
//        {
//            total += n;
//        }
//        return total;
//    }
//}

//COM MODIFICADOR PARAMS:

//var s1 = Calcular.Somar(10, 50, 60, 10);//Mais simples, valores direto no método.
//Console.WriteLine(s1);


//public class Calcular
//{
//    public static int Somar(params int[] numeros) //Se com outros parametros, deve ser colocado por ultimo.
//    {
//        int total = 0;

//        foreach (int n in numeros)
//        {
//            total += n;
//        }
//        return total;
//    }
//}
//----------------------------------------------------------------------------------
//ARRAYS MULTIDIMENSIONAIS:
//int[,] a = { { 50, 60, 30 },
//             { 25, 55, 32 },
//             { 26, 44, 58 }
//};

//Console.WriteLine(a[1, 2]);
//Console.WriteLine("\n");
////Percorrer array com For:
//for (int i = 0; i < a.GetLength(0); i++)
//{
//    for (int j = 0; j < a.GetLength(1); j++)
//    {
//        Console.Write($"{a[i, j]} ");
//    }
//    Console.WriteLine();
//}
//Console.WriteLine("\n");
////Percorrer array com Foreach:
//foreach (int i in a)
//{
//    Console.Write(i + " ");
//}
//Console.ReadKey();
//----------------------------------------------------------------------------------
//ARRAY LIST:
//using System.Collections;

//ArrayList list = new();
//ArrayList lista = new() { 1, 2, "Rafael", true, " ", null };

//lista.Add(4.5); // Adiciona valor no final da lista.
//lista.Insert(3, "Maria"); //Insere valor no index indicado (aqui o 3).

//int[] add = { 35, 50, 135 };

//lista.AddRange(add); // Adiciona os valores do array "add" no final do array "lista".
//lista.InsertRange(2, add); //Adiciona os valores do array "add" no index inserido para o array "lista".

//lista.Remove(null); //Remove o valor indicado (o primeiro no array, caso tenha mais de um).
//lista.RemoveAt(5); //Remove valor no index indicado.
//lista.RemoveRange(0, 5);//Esq:. Index / Dir:. Quantidade pra remover à partir do index.

//Console.WriteLine(lista.Contains("Rafael")); //Verifica se contém (True) o valor indicado. (Pode armazenar em variável, ao invés do CW direto).
//lista.Clear();//Limpa o conteudo do array.
//-------------------------------------------------------------------------------------
//LIST<T>:
//Metodos para add e remover igual ao array list.

//List<string> lista = new()
//{
//    "Rafael", "Azk", "Azzl", "Azkeel"
//};

//for (int i = 0; i < lista.Count; i++)
//{
//    Console.WriteLine(lista[i]);
//}
//foreach (string str in lista)
//{
//    Console.WriteLine(str);
//}

//Metodo Find com expressão Lambda:
//Console.WriteLine(lista.Find(i => i.Contains('k'))); //Encontra o primeiro valor que contém a letra.
//Console.WriteLine(lista.FindLast(i=>i.Contains("k")));//Encontra o ultimo valor que contém a letra.
//Console.WriteLine(lista.FindIndex(i=>i.Contains('k')));//Encontra o primeiro index que contém a letra.
//Console.WriteLine(lista.FindLastIndex(i=>i.Contains('k')));//Encontra o ultimo index que contém a letra.
//var findAll = lista.FindAll(i=>i.Contains('k'));//Encontra TODOS os valores que contém a letra.
//foreach(var item in findAll)
//{
//    Console.Write(item + " ");
//}
////Metodo Find com predicado:
//Console.WriteLine(lista.Find(procura));

//static bool procura(string item)
//{
//    return item.Contains('l');
//}
//-------------------------------------------------------------------------
//INDEXADORES:

//Time time = new();

//time[1] = "Corinthians";
//time[2] = "Santos";
//time[-1] = "Vasco";
//time[100] = "Botafogo";

//Console.WriteLine(time[1]);
//Console.WriteLine(time[-1]); 

//string valor1 = time[1];
//string valor2 = time[2];
//string valor3 = time[-1];
//string valor4 = time[100];

//Console.WriteLine(valor1);
//Console.WriteLine(valor2);
//Console.WriteLine(valor3);
//Console.WriteLine(valor4);


//public class Time
//{
//    string[] valor = new string[10];

//    public string this[int i]
//    {
        //get
        //{
        //    if (i >= 0 && i < valor.Length)
        //    {
        //        return valor[i];
        //    }
        //    return "ERROR";

        //}
        //set
        //{
        //    if (i >= 0 && i <= valor.Length)
        //    {
        //        valor[i] = value;   
        //    }
        //}


//    }
//}
//------------------------------------------------------------------------------------
//RANDOM() - (NÚMEROS ALEATÓRIOS):

//Random aleat = new Random();

//Console.WriteLine(aleat.Next()); //Numero aleatorio padrão
//Console.WriteLine(aleat.Next(20));//Numero aleatório com o máximo no parametro.
//Console.WriteLine(aleat.Next(10, 20));// Aleatorio entre os numeros do parametro.
//Console.WriteLine(aleat.NextDouble());//Aleatorio 0.0 <> 1.0
//Console.WriteLine(aleat.NextInt64());//Aleatorio 0 <> 9bi

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(aleat.Next(0, 1000));
//}
//byte[] randByte = new byte[10];
//Random randNum = new Random();
//randNum.NextBytes(randByte); //.NextByte - Aleatorio para array de bytes.

//Mega Sena:

Random sorteio = new Random();
int[] numerosRandom = new int[6];

for (int i = 0; i < 6; i++)

{
    int numeroAleat;

    do
    {
        numeroAleat = sorteio.Next(1, 61);
    }

    while (numerosRandom.Contains(numeroAleat));

    numerosRandom[i] = numeroAleat;

}
Console.WriteLine("Numeros sorteados:");
Array.Sort(numerosRandom);
Console.WriteLine(string.Join(" ", numerosRandom));