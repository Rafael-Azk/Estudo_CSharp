//DELEGATE:
/* Uma mesma variável pode invocar vários metodos em separado, ou ao mesmo tempo.*/

float result;

DelegateCalculadora calc = Calculadora.Somar;
result = calc(10, 50);
Console.WriteLine($"Soma: {result}");

calc = Calculadora.Subtrair;
result = calc(10, 50);
Console.WriteLine($"Subtração: {result}");

calc = Calculadora.Multiplicar;
result = calc.Invoke(10, 50); //Invoke é um metodo de invocar. Não necessario usar.
Console.WriteLine($"Multiplicação: {result}");

Console.ReadKey();

public class Calculadora
{
    public static float Somar(float x, float y)
    {
        return x + y;
    }
    public static float Subtrair(float x, float y)
    {
        return x - y;
    }
    public static float Multiplicar(float x, float y)
    {
        return x * y;
    }
}
public delegate float DelegateCalculadora(float x, float y);

/*Obs: Os parametros e tipos de valores precisam ser iguais para serem usados com o mesmo Delegate*/

//---------------------------------------------------------------------------
//DELEGATE MULTICAST:
/*Para acionar vários métodos ao mesmo tempo*/

DelegateMulticast multicast = Calculadora.Somar;

Console.WriteLine("Adicionando métodos:");
multicast += Calculadora.Subtrair;
multicast += Calculadora.Multiplicar; //Adiciona método para acionar ao mesmo tempo.
multicast(100, 50);

Console.WriteLine("\nRetirando métodos:");
multicast -= Calculadora.Subtrair; //Retirou um método.
multicast(100, 50);


Console.ReadKey();


public class Calculadora
{
    public static float Somar(float x, float y)
    {
        Console.WriteLine($"Soma: {x + y}");
        return x + y;
    }
    public static float Subtrair(float x, float y)
    {
        Console.WriteLine($"Subtração: {x - y}");
        return x - y;
    }
    public static float Multiplicar(float x, float y)
    {
        Console.WriteLine($"Multiplicação: {x * y}");
        return x * y;
    }
}
public delegate float DelegateMulticast(float x, float y);
//---------------------------------------------------------------------------
//METODOS ANÔNIMOS:

Imprimir imprimir = delegate (int valor)
{
    Console.WriteLine($"Método anonimo: {valor}");
};
imprimir(100);
imprimir(200);

Console.ReadKey();

public delegate void Imprimir(int valor);

//--------------Ex. Sem e com metodo anonimo:

List<string> nomes = new List<string>()
{
    "Ana", "Maria", "Paulo", "Fabio", "Clara"
};

string resultado = nomes.Find(VerificaNome);//Find comum (predicado), sem método anonimo.
Console.WriteLine(resultado);
//----------
string? result = nomes.Find(delegate (string nome) //Metodo anonimo.
{
    return nome.Equals("Ana");
});
Console.WriteLine(result);
////------------
Console.WriteLine(nomes.Find(nome => nome.ToLower().Contains("maria")));//Metodo anonimo com Lambda.(Serve Equals/Contais).
Console.ReadKey();

static bool VerificaNome(string nome)
{
    return nome.Equals("Clara");
}

//-------------------------DELEGATES PRÉ-DEFINIDOS----------------------------
//DELEGATE PREDICATE:
/*Retorna true/false e realiza operações de acordo com um critério*/

int num = 6;

Predicate<int> delegatePar = x => x % 2 == 0;

if (delegatePar(num))
{
    Console.WriteLine($"O número {num} é par");
}
else
{
    Console.WriteLine($"O número {num} é ímpar");
}
//---------------------------------------------------------------------
//DELEGATE ACTION:
//Action Recebe até 16 parametros. Ação void.

int num = 8;

Action<int> dobra = delegate (int x) //Metodo anonimo comum.
{
    Console.WriteLine(x * 2);
};

Action<int> dobrar = x => Console.WriteLine(x * 2);//Metodo com Lambda.

dobra(num);
dobrar(num);

//---------------------------------------------------------------------
//DELEGATE FUNC:
//Recebe até 16 parametros, mais um retorno. EX <int, int> (Param e retorno).

double num = 10;
double num2 = 20;

Func<double, double> Raiz = delegate (double x)//Metodo anonimo comum.
{
    return Math.Sqrt(x);
};
double res = Raiz(num2);
Console.WriteLine($"Raiz é {res}");


Func<double, double> RaizQ = x => Math.Sqrt(x); //Metodo anonimo com Lambda.
double result = RaizQ(num);
Console.WriteLine($"\nRaiz Q de {num} é {result}");

//--------------------------------------EXERCICIO------------------------

var listaPessoas = new List<Pessoa>()
{
    new Pessoa("Ana", 21),
    new Pessoa("Paula", 31),
    new Pessoa("Lorena", 18),
    new Pessoa("Bia", 17),
    new Pessoa("Kétlin", 20)
};

Console.WriteLine("Lista:");
Action<Pessoa> imprimePessoa = p => Console.WriteLine($"Nome: {p.nome} - Idade: {p.idade}");
listaPessoas.ForEach(imprimePessoa);
//---------------------
Console.WriteLine("\nMaiores de 18:");
Predicate<Pessoa> deMaior = p => p.idade > 18;
var maiores18 = listaPessoas.FindAll(deMaior);
maiores18.ForEach(imprimePessoa);
//---------------------
Console.WriteLine("\n O mais velho:");
Func<Pessoa, int> maisVelho = p => p.idade;
var pessoaMaisVelha = listaPessoas.MaxBy(maisVelho);//Melhor metodo.
Console.WriteLine($"Mais velho: {pessoaMaisVelha.nome} - {pessoaMaisVelha.idade} anos");

int idadeMax = listaPessoas.Max(maisVelho); //Metodo tradicional.
var pessoaIdadeMax = listaPessoas.Find(p => p.idade == idadeMax);
Console.WriteLine($"Mais velho: {pessoaIdadeMax.nome} - {pessoaIdadeMax.idade} anos");


public class Pessoa
{
    public Pessoa(string? nome, int idade)
    {
        this.nome = nome;
        this.idade = idade;
    }

    public string? nome { get; set; }
    public int idade { get; set; }
}

//----------------------------------------------------------------------------
//EVENTOS:

var pedido = new Pedido();

//Inscrevendo os assinantes do evento:
pedido.OnCriarPedido += Email.Send;
pedido.OnCriarPedido += SMS.Send;

//Acionando metodo e os eventos:
pedido.CriarPedido();

class Pedido
{
    public event PedidoEvent? OnCriarPedido;
    public void CriarPedido()
    {
        Console.WriteLine("Pedido criado");
        if (OnCriarPedido != null)
            OnCriarPedido();
    }
}

class Email
{
    public static void Send()
    {
        Console.WriteLine("Enviando Email");
    }
}

class SMS
{
    public static void Send()
    {
        Console.WriteLine("Enviando SMS");
    }
}

delegate void PedidoEvent();

//--------------------EVENTHANDLER---------------------

var pedido = new Pedido();

//Inscrevendo os assinantes do evento:
pedido.OnCriarPedido += Email.Send;
pedido.OnCriarPedido += SMS.Send;

//Acionando metodo e os eventos:
pedido.CriarPedido();

class Pedido
{
    public event EventHandler? OnCriarPedido;
    public void CriarPedido()
    {
        Console.WriteLine("Pedido criado");
        if (OnCriarPedido != null)
            OnCriarPedido(this, EventArgs.Empty);
    }
}

class Email
{
    public static void Send(object? sender, EventArgs e)
    {
        Console.WriteLine("Enviando Email");
    }
}

class SMS
{
    public static void Send(object? sender, EventArgs e)
    {
        Console.WriteLine("Enviando SMS");
    }
}

//------------EVENTHANDLER COM ARGS (EVENTHANDLER<TARGS>

var pedido = new Pedido();

//Inscrevendo os assinantes do evento:
pedido.OnCriarPedido += Email.Send;
pedido.OnCriarPedido += SMS.Send;

//Acionando metodo e os eventos:
pedido.CriarPedido("blablabla@hotmail.com", 13955668874);




class PedidoEvento : EventArgs
{
    public string? email { get; set; }
    public long telefone { get; set; }
}
class Pedido
{
    public event EventHandler<PedidoEvento>? OnCriarPedido;
    public void CriarPedido(string email, long fone)
    {
        Console.WriteLine("Pedido criado");
        if (OnCriarPedido != null)
            OnCriarPedido(this, new PedidoEvento { email = email, telefone = fone });
    }
}

class Email
{
    public static void Send(object? sender, PedidoEvento e)
    {
        Console.WriteLine($"Enviando Email para - {e.email}");
    }
}

class SMS
{
    public static void Send(object? sender, PedidoEvento e)
    {
        Console.WriteLine($"Enviando SMS para: {e.telefone}");
    }
}

//-------------------------------------------------------------------------
//METODO DE EXTENSÃO:

string texto = "Rafael de Almeida";
string textoInvertido = texto.InverteString();

Console.WriteLine(textoInvertido);


public static class StringExtensions
{
    public static string InverteString(this string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}