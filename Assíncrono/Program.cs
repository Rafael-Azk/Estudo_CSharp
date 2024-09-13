//PORGRAMAÇÃO ASSÍNCRONA:

//---------------------EXEMPLO SÍNCRONO-----------

int espera = 4000; //4k milisegundos = 4 segundos.

Console.WriteLine("Tecle algo para iniciar...");
Console.ReadLine();

RealizaTarefa(espera); /* O código abaixo não sera executado enquanto o método
                        * não finalizar sua tarefa. (Thread bloqueada)*/

Console.WriteLine($"\n Tempo gasto = {espera / 1000} segundos");
Console.WriteLine("\n ### Fim do processamento...");


static void RealizaTarefa(int tempo)
{
    Console.WriteLine("\nIniciando tarefa...");
    Thread.Sleep(tempo); //Codigo para sincrono.
    /*Task.Delay(TimeSpan.FromSeconds(tempo));*/ //Código para assincrono.
    Console.WriteLine("\nTarefa concluída...");
}

//------------------------ASSÍNCRONO--------------------------------
/* Task: Representa uma execução assíncrona. (Task/Task<T> - ValueTask/ValueTask<T> - Void).
 * Await: Aguarda uma operação.
 * Async: Sinaliza que um método é assíncrono.*/

//-------------------Sintaxe básica---------------------
//Task:
await MetodoAsync(); //Chamada do metodo.
static async Task MetodoAsync()
{
    await Task.Delay(1000);
    Console.WriteLine("Operação assíncrona concluíida");
}

//Task<T>:
var result = await MetodoAsync();
static async Task<int> MetodoAsync()
{
    await Task.Delay(1000);
    Console.WriteLine("Operação assíncrona concluída");
    return 1;
}

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

//-------------------------------------------------------------------------
// VALUE TASK - VALUE TASK<T>:
/* Vai para a memória Stack, não Heap. E não usa Garbage Collector.
 *  - Cenários para uso: -
 * 1- Quando o resultado da operação executada pelo método assíncrono já estiver 
 * disponível no momento da espera.
 * 2- Quando temos cenários assíncronos no qual o armazenamento em buffer esta presente.
 * 3- Quando o resultado da operação for concluída de forma síncrona.*/


Console.WriteLine("Iniciando operação async...");
await MetodoSemRetornoAsync();

Console.WriteLine("\nIniciando operação async com retorno...");
var result = await MetodoRetornaValorAsync(50);
Console.WriteLine($"Resultado: {result}");


static async ValueTask MetodoSemRetornoAsync()
{
    Console.WriteLine("Metodo que não retorna valor...");
    await Task.Delay(2000);
}
static async ValueTask<int> MetodoRetornaValorAsync(int valor)
{
    Console.WriteLine("Metodo que retorna valor...");
    await Task.Delay(2000);
    return valor * 2;
}

//------------------EX: 2--------------------

int num1 = 500;
int num2 = 3000;
Console.WriteLine("Iniciando cáuculo...");

var Soma = await CalculaSoma(num1, num2);

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"\n{num1} + {num2} = {Soma}");

static async ValueTask<int> CalculaSoma(int n1, int n2)
{
    if (n1 == 0 && n2 == 0) //Essa operação será SÍNCRONA graças ao ValueTask.
        return 0;
    return await Task.Run(() => n1 + n2); /* Task.Run() finaliza a operação em uma nova Thread
                                           * separada da Thread principal. Indicado para operações
                                           * longas.*/

}

//----------------CANCELAMENTO DE TAREFAS-------------

//---FORMA COMUM (SEM CANCELAMENTO):
await ExecutaTaskAsync(50);

static Task<int> OperacaoLongaDuracao(int valor)
{
    return Task.Run(() =>
    {
        var result = 0;
        for (int i = 0; i < valor; i++)
        {
            Thread.Sleep(50); //Simula o tempo de uma operação.
            result += i;
        }
        return result;
    });
}
static async Task ExecutaTaskAsync(int valor)
{
    Console.WriteLine("Resultado 0", await OperacaoLongaDuracao(valor));
}

//---USANDO CANCELAMENTO DE TAREFAS:

using System;
using System.Threading;
using System.Threading.Tasks;

// Cria CancellationTokenSource e obtém o Token:
var cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

var task = Task.Run(() => DoWork(token));

// Simula um atraso antes de solicitar o cancelamento
await Task.Delay(2000);

// Solicita o cancelamento
cts.Cancel();

//Tratamento do cancelamento:
try
{
    // Espera a tarefa completar
    await task;
}
catch (OperationCanceledException)
{
    Console.WriteLine("A operação foi cancelada.");
}

static async Task DoWork(CancellationToken token)
{
    for (int i = 0; i < 10; i++)
    {
        // Verifica se o cancelamento foi solicitado
        if (token.IsCancellationRequested)
        {
            Console.WriteLine("Cancelamento detectado.");
            // Lança uma exceção se o cancelamento for solicitado
            token.ThrowIfCancellationRequested();
        }

        // Simula trabalho
        await Task.Run(() => Console.WriteLine("Trabalhando..."));
        Thread.Sleep(500);
    }
}

//-----------------------------------------------------------------
//TRATAMENTO MÚLTIPLAS EXCEÇÕES:

await LancaMultiplasExcecoesAsync();

Console.ReadKey();
static async Task LancaMultiplasExcecoesAsync()
{
    Task? tarefas = null;
    try
    {
        var primeiraTask = Task.Run(() =>
        {
            Task.Delay(1000);
            throw new IndexOutOfRangeException
            ("IndexOutOfRangeException lançada explicitamente.");
        });
        var segundaTask = Task.Run(() =>
        {
            Task.Delay(1000);
            throw new InvalidOperationException
            ("InvalidOperationException lançada explicitamente");
        });

        tarefas = Task.WhenAll(primeiraTask, segundaTask);
        await tarefas;
    }
    catch
    {
        Console.WriteLine("Ocorreram as seguintes exceções :-\n");
        AggregateException TodasExceptions = tarefas.Exception;

        foreach (var ex in TodasExceptions.InnerExceptions)
        {
            Console.WriteLine(ex.GetType().ToString());
        }
    }
}

//---------------------------------------------------------------------------
//STREAMS ASSÍNCRONOS:

await Executa();


static async Task Executa()
{
    await foreach (var mes in GeraMeses())
    {
        Console.WriteLine(mes);
    }
}

static async IAsyncEnumerable<string> GeraMeses()
{
    yield return "Janeiro";
    yield return "Fevereiro";
    await Task.Delay(2000);
    yield return "Março";
    yield return "Abril";
}

//---------------------------------------------------------------------------
//SEMAPHORE / SEMAPHORESLIM:
//using System.Runtime.CompilerServices;
//using System.Runtime.ExceptionServices;

for (int i = 0; i < 10; i++)
{
    Thread ThreadObj = new Thread(new ThreadStart(ProcessarOperacao));

    ThreadObj.Name = "Thread" + i;
    ThreadObj.Start();
}
Console.ReadLine();



static void ProcessarOperacao()
{
    Semaforo.semaforo.WaitOne();
    Console.WriteLine($"Thread : {Thread.CurrentThread.Name} entrou na sessão critica...");

    Thread.Sleep(1000);

    Semaforo.semaforo.Release();
    Console.WriteLine($"Thread  {Thread.CurrentThread.Name} foi liberada...");
}
class Semaforo
{
    public static Semaphore semaforo = new Semaphore(3, 5);
}

//-----------------SEMAPHORESLIM:

for (int i = 0; i < 10; i++)
{

    string name = "Thread" + i;
    int espera = 2 + 2 * i;

    var t = new Thread(() => ProcessarOperacao(name, espera));
    t.Start();
}


static void ProcessarOperacao(string nome, int seconds)
{
    SemaforoSlim.semaforoSlim.Wait();
    Console.WriteLine($"{nome} entrou na sessão critica...");

    Thread.Sleep(2000);

    SemaforoSlim.semaforoSlim.Release();
    Console.WriteLine($"{nome} foi liberada...");
}
class SemaforoSlim
{
    public static SemaphoreSlim semaforoSlim = new SemaphoreSlim(4);
}













