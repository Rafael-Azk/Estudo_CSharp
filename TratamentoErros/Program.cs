//Exception() - Classe base de todas as exceções.

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

//THROW:

/*
 * Exception() - Classe base de todas as exceções.
 * "throw new exception() - Chamada.
 * Exemplos:
 * NotImplementedException() - Um metodo não está implementado.
 * ArgumentException() - 
 * NullReferenceException() - Indica eferencia nula.
 * FormatException() - Formatação inválida.
 * IndexOutOfRangeException() - Indice fora do intervalo.
 * OverFlowException() - Excedeu capacidade de processamento.
 * FileNotFoundException() - Arquivo não localizado.
 * InvalidCastException() - Não foi possível fazer conversão de valores.
 * StackOverFlowException() - Capacidade da pilha excedida.
 * 
 * Ex manual: throw new Exception("Lançamento manual de excessão").
 */

//Test.Processar();
//class Test
//{
//    public static void Processar()
//    {
//        throw new NotImplementedException("Função não implementada");
//    }
//}

//----------------------------------------------------------------------------
//FILTROS DE EXCEÇÃO:
/*Executa blocos try/catch com base condições pré-definidas. */

//Exemplo direcionando para uma página da web:
//public void Page_Load(object sender, EventArgs e)
//{
//    try
//    {
//        //Chamando uma página que pode não existir  
//        Response.Redirect("~/Admin/Login.aspx");
//    }
//    catch (HttpException hex) if(hex.GetHashCode == 400)
//    {
//        lblMessage.Text = "Este página não foi encontrada !";
//    }
//    catch (HttpException hex) if(hex.GetHashCode == 500)
//    {
//        lblMessage.Text = "Erro interno do servidor !";
//    }
//}

//---------------------------------EXEMPLO DE USO:

//try
//{
//    Console.WriteLine("Acessar arquivo poesia.txt em https://macoratti.net/dados\n");
//    Console.WriteLine("Nome do arquivo: Informar");
//    string? arquivo = Console.ReadLine(); //Busca arquivo.
//    Console.WriteLine("URL do site: Informar");
//    string? url = Console.ReadLine(); //Busca URL.
//    Console.WriteLine("\nAguarde...\n");

//    HttpClient client = new HttpClient();
//    HttpResponseMessage response = client.GetAsync(url + "/" + arquivo).Result;//Obtém na variável o resultado da Busca/Resposta do servidor.

//    if (response.IsSuccessStatusCode)
//    {
//        Console.WriteLine("Acesso realizado com sucesso!");
//        Console.WriteLine("Cód de status: " + response.StatusCode);
//    }
//    else
//    {
//        throw new HttpRequestException("Erro: " + (int)response.StatusCode);//Cód convertido para int (Ex: 404).  
//    }
//}
//catch (HttpRequestException ex) when (ex.Message.Contains("404"))
//{
//    Console.WriteLine("Página não encontrada");
//}
//catch (HttpRequestException ex) when (ex.Message.Contains("401"))
//{
//    Console.WriteLine("Acesso não autorizado");
//}
//catch (HttpRequestException ex) when (ex.Message.Contains("400"))
//{
//    Console.WriteLine("Requisição inválida");
//}
//catch (HttpRequestException ex) when (ex.Message.Contains("500"))
//{
//    Console.WriteLine("Erro interno do servidor");
//}
//catch (Exception ex) //Sempre usar exceção ex genérica.
//{
//    Console.WriteLine("Erro: " + ex.Message);
//}
//finally
//{
//    Console.WriteLine("\nProcessamento concluído");
//}

//----------------------------------------------------------------------------------
//EXCEÇÃO PERSONALIZADA:

//try
//{
//    var c1 = new Conta(12345, "Maria", 200);
//    Console.WriteLine(c1.ToString());
//    c1.Depositar(100);
//    Console.WriteLine($"Saldo atual: {c1.Saldo}");
//    c1.Sacar(500);
//    Console.WriteLine($"Saldo atual: {c1.Saldo}");
//}
//catch (SaldoInsuficienteException ex)
//{
//    Console.WriteLine(ex.Message);
//    Console.WriteLine(ex.HelpLink);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//    Console.WriteLine(ex.StackTrace);
//}



//public class Conta
//{
//    public Conta(int numero, string? nome, decimal saldo)
//    {
//        Numero = numero;
//        Nome = nome;
//        Saldo = saldo;
//    }
//    public int Numero { get; set; }
//    public string? Nome { get; set; }
//    public decimal Saldo { get; set; }

//    public decimal Depositar(decimal valor)
//    {
//        Saldo += valor;
//        Console.WriteLine($"Depositou {valor.ToString("c")}");
//        return Saldo;
//    }
//    public decimal Sacar(decimal valor)
//    {
//        Console.WriteLine($"Sacar {valor.ToString("c")}");
//        if (Saldo < valor)
//            throw new SaldoInsuficienteException(valor, Saldo);

//        Saldo -= valor;
//        return Saldo;

//    }
//    public override string ToString()
//    {
//        return $"{Numero} - {Nome} - Saldo: {Saldo.ToString("c")}";
//    }
//}

//public class SaldoInsuficienteException : Exception
//{
//    public SaldoInsuficienteException() { }

//    public SaldoInsuficienteException(string? message)
//        : base(message)
//    {
//    }

//    public SaldoInsuficienteException(string? message, Exception? innerException)
//        : base(message, innerException)
//    {
//    }

//    //PERSONALIZADO:
//    public SaldoInsuficienteException(decimal valorSaque, decimal valorSaldo)
//        : base($"\nException: Valor do Saque-> {valorSaque.ToString("c")} maior que Saldo-> {valorSaldo.ToString("c")}")
//    { }
//    public override string Message
//    {
//        get
//        {
//            return "Impossível realizar saque";
//        }
//    }
//    public override string? HelpLink
//    {
//        get
//        {
//            return "Info: https://rb.gov/clggby";
//        }
//    }
//}

//-----------------------------EXERCICIO:
//1)
//string? nome = "";
//int idade = 0;
//try
//{
//    Console.WriteLine("Inserir Nome:");
//    nome = Console.ReadLine();
//    if (string.IsNullOrEmpty(nome))
//    {
//        throw new NullReferenceException("Nome não pode ser nulo ou vazio");
//    }
//    Console.WriteLine("Inserir idade:");
//    idade = Convert.ToInt32(Console.ReadLine());
//    if (idade < 0)
//    {
//        throw new Exception("Idade não pode ser negativa");
//    }
//    Console.WriteLine($"\n{nome} de {idade} anos.");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//---------------------------------------------------------------------
//2)
int[] numeros = new int[] { 109, 211, 313, 405, 519, 617, 711, 891, 951, 1001 };

try
{
    Console.WriteLine("Dado o array de números:");
    foreach (int n in numeros)
    {
        Console.Write(n + " ");
    }
    Console.WriteLine("\nIndique o index de um valor:");
    int index = Convert.ToInt32(Console.ReadLine());
    if(index < 0)
    {
        Console.WriteLine("Não pode ser negativo");
    }  
    Console.WriteLine($"Valor: {numeros[index]} no Index: {index}");
}
catch(IndexOutOfRangeException)
{
    Console.WriteLine("Index não existe");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();

