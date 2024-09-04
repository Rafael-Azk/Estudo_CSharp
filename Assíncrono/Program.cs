//PORGRAMAÇÃO ASSÍNCRONA:

//---------------------EXEMPLO SÍNCRONO-----------

//int espera = 4000; //4k milisegundos = 4 segundos.

//Console.WriteLine("Tecle algo para iniciar...");
//Console.ReadLine();

//RealizaTarefa(espera); /* O código abaixo não sera executado enquanto o método
//                        * não finalizar sua tarefa. (Thread bloqueada)*/

//Console.WriteLine($"\n Tempo gasto = {espera / 1000} segundos"); 
//Console.WriteLine("\n ### Fim do processamento...");


//static void RealizaTarefa(int tempo)
//{
//    Console.WriteLine("\nIniciando tarefa...");
//    Thread.Sleep(tempo); //Codigo para sincrono.
//    /*Task.Delay(TimeSpan.FromSeconds(tempo));*/ //Código para assincrono.
//    Console.WriteLine("\nTarefa concluída...");
//}

//------------------------ASSÍNCRONO--------------------------------
/* Task: Representa uma execução assíncrona. (Task/Task<T> - ValueTask/ValueTask<T> - Void).
 * Await: Aguarda uma operação.
 * Async: Sinaliza que um método é assíncrono.*/

//-------------------Sintaxe básica---------------------
//Task:
//await MetodoAsync(); //Chamada do metodo.
//static async Task MetodoAsync()
//{
//    await Task.Delay(1000);
//    Console.WriteLine("Operação assíncrona concluíida");
//}

//Task<T>:
//var result = await MetodoAsync();
//static async Task<int> MetodoAsync()
//{
//    await Task.Delay(1000);
//    Console.WriteLine("Operação assíncrona concluíida");
//    return 1;
//}

//--------------------------Exemplo:--------------

Console.WriteLine("## Café da manhã assíncrono...##");
CafeDaManhaAsync();

Console.ReadKey();

static async void CafeDaManhaAsync()
{
    Console.WriteLine("Preparar café...");
    var tarefaCafe = PrepararCafeAsync();
    Console.WriteLine("Preparar pão...");
    var tarefaPao = PrepararPaoAsync();

    var cafe = await tarefaCafe;
    var pao = await tarefaPao;

    ServirCafe(cafe, pao);
    ;
}
static void ServirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("Servindo café da manhã...");
    Thread.Sleep(3000);
    Console.WriteLine("Café servido...");

}

static async Task<Cafe> PrepararCafeAsync()
{
    Console.WriteLine("Fervendo água...");
    await Task.Delay(2000);
    Console.WriteLine("Coando café...");
    await Task.Delay(2000);
    Console.WriteLine("Adoçando açucar...");
    return new Cafe();
}
static async Task<Pao> PrepararPaoAsync()
{
    Console.WriteLine("Partir o pão...");
    await Task.Delay(2000);
    Console.WriteLine("Passar manteiga...");
    await Task.Delay(2000);
    Console.WriteLine("Tostar pão na chapa...");
    return new Pao();
}

public class Cafe { }
public class Pao { }