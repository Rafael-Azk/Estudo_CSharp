//string[] nomes = { "Renata", "Maria", "Rafael", "Eduarda", "Rafaela" };
//double[] notas = { 10, 5, 7, 8, 9 };

//double soma = 0;

//foreach (string s in nomes)
//{
//    Console.Write(s + " ");

//}
//Console.WriteLine("\n");
//foreach (double i in notas)
//{
//    Console.Write(i + " ");
//}

//for (int i = 0; i < notas.Length; i++)
//{
//    soma += notas[i];
//}

//double media = soma / notas.Length;
//Console.WriteLine("\n");
//Console.WriteLine($"A media aritmetica foi {media}");

//Console.ReadKey();
//------------------------------------------------------------------------------------

//string[] names = new string[5];
//double[] notes = new double[5];

//for (int i = 0; i < names.Length; i++)
//{
//    Console.WriteLine("Digite o nome:");
//    string? nome = Console.ReadLine();
//    names[i] = nome;
//}
//for (int i = 0; i < notes.Length; i++)
//{
//    Console.WriteLine("Digite a nota:");
//    double? note = Convert.ToDouble(Console.ReadLine());
//    notes[i] = (double)note;
//}
//foreach (string name in names)
//{
//    Console.Write($"{name} ");
//}
//Console.WriteLine("\n");
//var somaNotas = 0.0;
//var totalNotas = notes.Count(); //Metodos para total de indexes (similar "length")
//foreach (double note in notes)
//{
//    somaNotas += note;
//    Console.Write($"{note} ");
//}
//Console.WriteLine($"\nMedia aritmetica: {somaNotas/notes.Length}");

//-------------------------------------------------------------------------------------
//ARRAY MULTIDIMENSIONAL:
string[,] alunos = new string[2, 5];

for (int i = 0; i < alunos.GetLength(0); i++)
{
    Console.WriteLine("Digite os nomes");
    for (int j = 0; j < alunos.GetLength(1); j++)
    {

        alunos[i, j] = Console.ReadLine().ToLower();
    }
}
Console.WriteLine();
for (int i = 0; i < alunos.GetLength(0); i++)
{
    for (int j = 0; j < alunos.GetLength(1); j++)
    {
        Console.Write($"[{i},{j}] = {alunos[i, j]}\t ");

    }
    Console.WriteLine();
}