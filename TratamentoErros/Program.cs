//Classe base - Excepction.

//Message - Fornece detalhes.
//StackTrace - Rastreamento de pilha para determinar origem do erro. Inclui nome do arquivo e linha.
//Source - Define o nome do aplicativo ou objeto que causou o erro.
//HelpLink - Contém URL para arquivo de ajuda que fornece informações sobre a exceção.
//InnerException - Criar e preservar exceções durante o tratamento.

//------------------------------------------------------------------------
//TRY/CATCH/FINALLY:

//try
//{
//    Console.WriteLine("Informe o valor");
//    int num = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("Informe o divisor");
//    int div = Convert.ToInt32(Console.ReadLine());

//    int result = num / div;
//    Console.WriteLine($"{num} / {div} = {result}");
//}
////catch (Exception ex)
////{
////    Console.WriteLine($"{ex.GetType()} Detalhes: {ex.Message}");
////    Console.WriteLine($"\n{ex.Message}");
////    Console.WriteLine($"\n{ex.Source}");
////    Console.WriteLine($"\n{ex.StackTrace}");
////}
//catch (FormatException)
//{
//    Console.WriteLine("\n Informe um valor inteiro.");
//}
//catch (OverflowException)
//{
//    Console.WriteLine("\nValor inteiro entre 1 e 999999");

//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("\nNão existe divisão por zero");
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}


//Console.ReadKey();

//------------------------------------------------------------------------

Console.WriteLine();

