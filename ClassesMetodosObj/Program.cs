//Sintaxe basica:

Pessoa pessoa = new Pessoa(); //Classe instanciada para usar os métodos.

Pessoa p1 = new Pessoa(); //Objeto da classe.
p1.nome = "Maria";
p1.idade = 25; //Atributos e valores do objeto.
p1.sexo = "F";
Pessoa p2 = new(); //Método compacto.
p2.nome = "Azk";
p2.idade = 31;
p2.sexo = "M";

pessoa.Saudacao(); //Instancia da classe chamando um método.

Console.ReadKey();

class Pessoa //Classe
{
    public string? nome; //Atributos
    public int idade;
    public string? sexo;

    public void Saudacao() \\Método.
    {
        Console.WriteLine("Olá!");
        HoraAtual();
}
public void HoraAtual() => //Método compactado quando tem apenas uma linha.
Console.WriteLine(DateTime.Now.ToShortTimeString());

}

//----------------------------------------------------------------------------------------

//Com parametros:

using System.Security.Cryptography.X509Certificates;

Cachorro cachorro = new();

var dog = "Rex";

cachorro.Saudacao("Olá Rex\n");//Valores direto no parametro.

cachorro.Saudacao(dog);//Valores através de variaveis.
cachorro.DataHora();

class Cachorro //Classe

{
    public void Saudacao(string nome)
    {
        Console.WriteLine($"Olá {nome}");
    }

    public void DataHora()
    {
        Console.WriteLine(DateTime.Now.ToShortDateString());
        Console.WriteLine(DateTime.Now.ToShortTimeString());
    }


}

//------------------------------------------------------------------------------------
//Parametros entre classes:

Curso curso = new();
Aluno a1 = new Aluno();
a1.name = "Luiza";
a1.age = 18;
a1.note = 10;
a1.aproved = "s";

curso.Resultado(a1.name, a1.age, a1.note, a1.aproved);


public class Aluno
{
    public string? name;
    public int age;
    public int note;
    public string? aproved;

}
public class Curso
{
    public void Resultado(string nome, int idade, int nota, string aprovado)
    {
        Console.WriteLine($"O aluno {nome} de {idade} anos, tirou nota {nota} e foi...");
        if (aprovado.ToLower() == "s")
        {
            Console.WriteLine("APROVADO!");
        }
        else
        {
            Console.WriteLine("REPROVADO!");
        }
    }

}

//---------------------------------------------------------------------------------------------  
//Classe com construtor:

Aluno aluno = new Aluno("Maria");
Aluno maria = new Aluno("Maria", 22, 10, "s"); //Já constrói com os parametros.
Console.WriteLine(maria.age);
Console.WriteLine(maria.note);
Console.WriteLine(maria.aproved);

public class Aluno
{

    public string? name;
    public int age;
    public int note;
    public string? aproved;

    public Aluno(string nome) => name = nome;

    public Aluno(string nome, int idade, int nota, string aprovado) : this(nome) // Estabele os parametros para o objeto.
    //(:this(x)).... Para evitar duplicação. Adiciona o valor no outro construtor.
    {
        age = idade;
        note = nota;
        aproved = aprovado;
    }

}

//-----------------------------------------------------------------------------------------
// Metodo com retorno:

Calcular calc = new();
//var valor = calc.Somar(10, 20);
//Console.WriteLine(valor);
Console.WriteLine(calc.Somar(10, 20));

class Calcular
{
    public int Somar(int x, int y)
    {
        //var soma = x + y; return soma;
        return x + y;
    }
}

//-------------------------------------------------------------------------------------------
//Metodo com ref:
Carro carro = new Carro();
int potenciaX = 10;

carro.AumentarPotencia(potenciaX);
Console.WriteLine("Valor depois sem ref\n" + potenciaX);

carro.AumentarPotencia(ref potenciaX); // ref modifica o valor da variável original.
Console.WriteLine("Valor depois com ref\n" + potenciaX);

class Carro
{
    public void AumentarPotencia(int y)
    {
        y += 3;
    }
    public void AumentarPotencia(ref int y)
    {
        y += 5;
    }

}

//---------------------------------------------------------------------------------------
//Metodo com out:
Circulo circulo = new Circulo();
double raio = 5;

double perimetro = circulo.CalculaAreaPerimetro(raio, out double area);

Console.WriteLine("Perimetro: " + perimetro);
Console.WriteLine("Area: " + area);

public class Circulo
{
    public double CalculaAreaPerimetro(double raio, out double area)// out, a variavel recebe seu valor no parametro.
    {
        area = Math.PI * Math.Pow(raio, 2);
        double perimetro = 2 * Math.PI * raio;
        return perimetro;
    }
}

//---------------------------------------------------------------------------------------------
//Argumento nomeado:

Destinatario destinatario = new Destinatario();

var destino = "www.w";
string assunto = null;
string titulo = null;

destinatario.Destino(destino: "www.com.br", titulo: "urgente", assunto: "my eggs");
//Usando o nome no parametro com ":", pode não precisa seguir a ordem sem dar erro.

destinatario.Destino2(destino: "www.com.br");
destinatario.Destino2(destino, assunto: "hehe");
//Usa o argumento padrão caso não seja ditado um.

class Destinatario
{
    public void Destino(string destino, string assunto, string titulo)
    {
        Console.WriteLine($"\n Destino {destino}. Assunto: {assunto}. Titulo: {titulo}");
    }
    public void Destino2(string destino, string assunto = "Assunto padrão", string titulo = "Titulo padrao")
    {
        Console.WriteLine($"\n Destino {destino}. Assunto: {assunto}. Titulo: {titulo}");
    }
}

//-------------------------------------------------------------------------------------------
//Metodo STATIC:

Calculo.Soma(50, 60);
//Não precisa instanciar objeto para usar. Apenas a classe.



public class Calculo
{
    public static void Soma(int n1 = 0, int n2 = 0)
    {
        Console.WriteLine(n1 + n2);
    }
}
//---------------------------------------------------------------------------------
//GET/SET
Produto p1 = new Produto();
p1.Nome = "Caderno Espiral";
p1.Valor = 4.50;
p1.EstoqueMin = 10;

p1.Exibir();

public class Produto
{
    private string? nome;
    public string? Nome
    {
        get { return nome.ToUpper(); }
        set { nome = value; }
    }
    private double valor;
    public double Valor
    {
        get { return valor; }
        set
        {
            if (value < 5.00)
            {
                valor = 5.00;
            }
            else
            {
                valor = value;
            }
        }
    }
    private double desconto = 0.05;// Valor direto no apoio.
    public double Desconto
    {
        get { return desconto; }
    }
    public double PrecoFinal //Apenas get se valor no apoio. Então não precisa do apoio.
    {
        get { return Valor - (Valor * Desconto); }

    }
    private int min; //Só pode ser acessado através do apoio (private).
    public int EstoqueMin
    {
        set { min = value; }
    }
    public void Exibir()
    {
        Console.WriteLine($"\n{Nome}\nPreço:{Valor.ToString("c")}\nDesconto:{Desconto}\nValor Final:{PrecoFinal.ToString("c")}\nEstoque minimo:{min}");
    }
}
//-----------------------------------------------------------------------------------------------
//ENUM:

Console.WriteLine($"{Lista.Segunda} e {(int)Lista.Domingo}");

public enum Lista
{
    Segunda,
    terca,
    Sabado,
    Domingo
};

//-------------------------------------------------------------------------------------
//TIPOS ANONIMOS:

var pessoa = new
{
    Nome = "Maria",
    Idade = 25,
    endereco = new { cidade = "Santos", pais = "Brasil" }
};

Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
Console.WriteLine(pessoa.endereco.cidade + " " + pessoa.endereco.pais);
//------------------------------------------------------------------------------------------







