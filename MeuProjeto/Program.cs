//Data
DateTime data = new DateTime(1993, 02, 03);
double? nota = 7.80; // Nulavel
DateTime data2 = DateTime.Now;
Console.WriteLine(data);
Console.WriteLine(nota);
Console.WriteLine(data2);

//Conversão explicita de tipos:
double varDouble = 12.5685;
int varInt = (int)varDouble;
Console.WriteLine(varInt);

int num1 = 16;
int num2 = 5;

float resultado = (float)num1 / num2;
Console.WriteLine(resultado);

int valor = 10;
Convert.ToString(valor);
Console.WriteLine(valor);
int idade = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Sua idade é {idade}");

Console.ReadKey();

//-----------------------------Função Texto-----------------

//TRIM() e ToUpper/ToLower

string empresa = "  Microsoft Corporation  ";
Console.WriteLine("-------Funções de Texto-------");

Console.WriteLine("TRIM - Retira espaços em branco na expressão");
Console.WriteLine($"Nome sem espaços: {empresa.Trim()}");
Console.WriteLine($"Tamanho do texto {empresa.Length}"); // Tamanhio texto antes do TRIM
empresa = empresa.Trim();
Console.WriteLine($"Tamanho do texto depois do TRIM {empresa.Length}"); // Tamanho do texto depois do TRIM
Console.WriteLine($"TUpper para deixar maiusculo: {empresa.ToUpper()}"); //ToUpper deixa maiusculo. ToLower faz o contrário.

//REMOVE:

Console.WriteLine($"Texto esquerdo: {empresa.Remove(12)}"); //lê quantidade x de caracteres à partir da esquerda.

string[] nomes = { "Rafael de Almeida Soares", "Daiane dos Santos", "Natacha Francelina dos Santos" };
foreach (var n in nomes)
{
    Console.WriteLine($"{n.Remove(n.IndexOf(" "))}"); // Remove tudo após o primeiro espaço em branco. Resultando apenas no primeiro nome.
}

string nome = "Rafael de Almeida Soares Jardim";
int firstPos = nome.IndexOf(" ");
string first = nome.Remove(firstPos); //Vai eliminar tudo à partir do valor indicado no index.
Console.WriteLine(first);


