//Escreva um programa para receber 3 números inteiros e calcular/exibir qual deles é o maior.
//int n1, n2, n3;

static void ColocarNumeros()
{
    Console.WriteLine("Put numbers");
}

//n1 = Convert.ToInt32(Console.ReadLine());
//n2 = Convert.ToInt32(Console.ReadLine());
//n3 = Convert.ToInt32(Console.ReadLine());

//if (n1 > n2 && n1 > n3)
//{
//    Console.WriteLine($"{n1} é o maior.");
//}
//else if (n2 > n1 && n2 > n3)
//{
//    Console.WriteLine($"{n2} é o maior.");
//}
//else if (n3 > n1 && n3 > n2)
//{
//    Console.WriteLine($"{n3} é o maior.");
//}
//else
//{
//    Console.WriteLine("Nenhum foi o maior");
//}
//------------------------------------------------------------------------------------

//Console.WriteLine("Put numbers");
//int n1 = Convert.ToInt32(Console.ReadLine());
//int n2 = Convert.ToInt32(Console.ReadLine());
//int n3 = Convert.ToInt32(Console.ReadLine());

//int[] valores = [n1, n2, n3];
//Array.Sort(valores);

//if (n1 == n2 || n1 == n3 || n3 == n2)
//{
//    Console.WriteLine("Não pode repetir números");
//}
//else
//{

//    Console.WriteLine($"O maior é {valores[2]}");
//}
//---------------------------------------------------------------------------------------

//Escreva um programa para calcular a raiz da equação quadrática: ax^2+bx+c=0
//ColocarNumeros();

//int a = Convert.ToInt32(Console.ReadLine());
//int b = Convert.ToInt32(Console.ReadLine());
//int c = Convert.ToInt32(Console.ReadLine());

//double delta = Math.Pow(b, 2) - 4 * a * c;
//double formulaPos = -b + Math.Sqrt(delta) / (2 * a);
//double formulaNeg = -b - Math.Sqrt(delta) / (2 * a);
//double raizIgual = -b / 2.0 * a;

//if (delta == 0)
//{
//    Console.Write("As duas raízes são iguais.\n");
//    Console.Write($"X1= {raizIgual} e X2= {raizIgual}\n");
//}
//else if (delta > 0)
//{
//    Console.WriteLine($"Raiz Real");
//    Console.WriteLine($"X+ = {(int)formulaPos} e X- = {(int)formulaNeg}");
//}
//else
//{
//    Console.WriteLine("Sem raiz real");
//}
//Console.ReadKey();

//----------------------------------------------------------------------------------
//Somam dos 10 primeiros números naturais com loops:

//int soma = 0;
//int i = 0;

//for (int j = 0; j <= 10; j++)
//{
//    soma += j;
//}
//Console.WriteLine($"A soma é {soma}");

//while (i <= 10)
//{
//    soma += i;
//    Console.WriteLine($"Soma: {soma}");
//    i++;
//}
//Console.WriteLine($"\nA soma total é: {soma}");

//do
//{
//    soma++;
//} while (soma <= 10);
//Console.WriteLine($"A soma é {soma}");
//-----------------------------------------------------------------------------------------

/*Escreva um programa para solicitar ao usuário que escolha a resposta correta de uma lista de opções de
resposta de uma pergunta. O usuário pode optar por continuar respondendo a pergunta ou parar de responder.*/

//Console.WriteLine("Morango é...?\n");
//Console.Write("a) Azul / b) Vermelho / c) Roxo / d) Amarelo\n");
//Console.WriteLine("(Aperte X pra sair)\n");

//string resposta;
//bool cond = true;

//while (cond == true)
//{
//    Console.WriteLine("Qual o certo?(Aperte X pra sair)\n");
//    resposta = Console.ReadLine().ToLower();
//    if (resposta == "c")
//    {
//        Console.WriteLine("Certa a resposta!");
//        cond = false;
//    }
//    else if (resposta == "x")
//    {
//        Console.WriteLine("Obrigado por participar");
//        break;
//    }
//    else
//    {
//        Console.WriteLine("Valor inválido\n");
//    }
//}

repeat:
Console.WriteLine("Morango é...?");
Console.Write("a) Azul / b) Vermelho / c) Roxo / d) Amarelo\n");
Console.WriteLine("(Aperte X pra sair)\n");

string resposta = Console.ReadLine().ToLower();


switch (resposta)
{
    case "a":
    case "b":
    case "d":
        Console.WriteLine("Errou!");
        break;
    case "c":
        Console.WriteLine("Certo!");
        break;
    default:
        Console.WriteLine("Digite uma opção correta\n");
        goto repeat;
}


//------------------------------------------------------------------------------------

//Exbir no console os números pares de 10 a 20, ambos incluídos, exceto 16.

//for (int i = 10; i <= 20; i++)
//{

//    if (i == 16)
//    {
//        continue;
//    }
//    if (i % 2 == 0)
//    {
//        Console.WriteLine(i);

//    }
//}

//for (int i = 10; i <= 20; i += 2)
//{

//    if (i == 16)
//    {
//        continue;
//    }
//    Console.WriteLine(i);
//}

//--------------------------------------------------------------------------------------

//Escreva um programa para exibir o padrão como triângulo de ângulo reto usando asterisco (*).

//int i, j, linhas;

//Console.Write("Informe o número de linhas : ");
//linhas = Convert.ToInt32(Console.ReadLine());

//for (i = 1; i <= linhas; i++)
//{
//    for (j = 1; j <= i; j++)
//        Console.Write("*");
//    Console.Write("\n");
//}

//---------------------------------------------------------------------------------------

//Escreva um programa para exibir as tabelas de multiplicação do 2 ao 6 usando.

//Com FOR:
//int num = 2;

//for (int i = 2; i <= 6; i++)
//{
//    for(int j = 1; j <= 10; j++)
//    {
//        Console.WriteLine($"{num} x {j} = {num*j}");
//    }
//    Console.WriteLine("\n");
//    num++;

//}
////Com DO/WHILE:
//int numero = 2;
//do
//{
//    int multiplicador = 1;
//    do
//    {
//        Console.WriteLine($"{numero} x {multiplicador} = {numero * multiplicador} ");
//        multiplicador++;
//    }
//    while (multiplicador <= 10);
//    Console.WriteLine(" ");
//    numero++;
//} while (numero <= 6);
//Console.ReadKey();

//-------------------------------------------------------------------------------------------

//Recebe na entrada de dados um número inteiro de 0 a 10 que representa a nota de um aluno. Mostre o resultado da avaliação.


//while (true)
//{
//    Console.WriteLine("Insira a nota do aluno. (Tecle 99 para sair.)");
//    int nota = Convert.ToInt32(Console.ReadLine());

//    if (nota < 0 || nota > 10 && nota != 99)
//    {
//        Console.WriteLine("Valor inválido\n");
//    }
//    else if (nota == 99)
//    {
//        Console.WriteLine("Obrigado pela visita!");
//        break;
//    }

//    switch (nota)
//    {
//        case 10:
//            Console.WriteLine("Nota A+");
//            break;
//        case 9:
//            Console.WriteLine("Nota A");
//            break;
//        case 8:
//        case 7:
//            Console.WriteLine("Nota b");
//            break;
//        case 6:
//            Console.WriteLine("Nota c");
//            break;
//        case 4:
//        case 3:
//        case 2:
//        case 1:
//        case 0:
//            Console.WriteLine("Nota F");
//            break;

//    }
//}







