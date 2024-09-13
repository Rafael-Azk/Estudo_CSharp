//HERANÇA:
Funcionario func = new Funcionario();
func.nome = "Mister";
func.email = "www";
func.empresa = "M&M";
func.salario = 26345;
func.Verificar();
Console.WriteLine(func.empresa);
Console.WriteLine(func.salario);
Console.WriteLine();
Aluno alu = new Aluno();
alu.nome = "jack";
alu.email = "hehehe.";
alu.curso = "T.I";
alu.nota = 10;
alu.Verificar();
Console.WriteLine(alu.curso);
Console.WriteLine(alu.nota);

Console.ReadKey();
public class Pessoa
{
    public string? nome { get; set; }
    public string? email { get; set; }

    public void Verificar()
    {
        Console.WriteLine($"Nome: {nome}\nEmail: {email}");
    }
}
public class Funcionario : Pessoa
{
    public string? empresa { get; set; }
    public decimal salario { get; set; }
}
public class Aluno : Pessoa
{
    public string? curso { get; set; }
    public int nota { get; set; }
}
//--------------------------------------------------------------------------------
//HERANÇA CONSTRUTOR:

Aluno a1 = new Aluno("Rafa");

class Pessoa
{
    public Pessoa()
    {
        Console.WriteLine("Construtor S/P");
    }
    public Pessoa(string nome)
    {
        Console.WriteLine("Construtor C/P");
    }

}
class Aluno : Pessoa
{
    public Aluno() : base()
    {
        Console.WriteLine("Derivado S/P");
    }
    public Aluno(string nome) : base(nome)
    //"base()" invoca um construtor especifico da classe base. O construtor sem parametro é invocado por padrão.
    {
        Console.WriteLine("Derivado C/P");
    }
}
//------------------------------------------------------------------------------
//HERANÇA - VIRTUAL E OVERRIDE:

Aluno a1 = new();
a1.nome = "Azk";
a1.curso = "Programação";
a1.Saudacao();

class Pessoa
{
    public string? nome { get; set; }
    public virtual void Saudacao() // Virtual indica que pode ser substituido.
    {
        Console.WriteLine($"Eu sou {nome}");
    }
}
class Aluno : Pessoa
{
    public string? curso { get; set; }
    public override void Saudacao() //Override substitui o virtual.
    {
        Console.WriteLine($"Sou {nome} do curso {curso}");
    }
}
//----------------------------------------------------------------------
//HERANÇA - SEALED:
sealed class Animal //Sealed impede que a classe seja herdada. Ou um Override seja sobrescrito.
{

}
//--------------------------------------------------------------------------------------
//CLASS E METODO ABSTRACT:

Quadrado q = new();
q.cor = "Vermelho";
Console.WriteLine("Medida de lado do quadrado vermelho:");
q.lado = Convert.ToInt32(Console.ReadLine());

q.CalcularArea();
q.CalcularPerimetro();
q.Ficha();
Console.ReadKey();
abstract class Forma
{
    public string? cor { get; set; }
    public double area { get; set; }
    public double perimetro { get; set; }

    public abstract void CalcularArea();
    public abstract void CalcularPerimetro();
    public abstract void Ficha();
}
class Quadrado : Forma
{
    public double lado { get; set; }
    public override void CalcularArea()
    {
        this.area = lado * lado;

    }
    public override void CalcularPerimetro()
    {
        this.perimetro = 4 * lado;

    }

    public override void Ficha()
    {
        Console.WriteLine($"O quadrado da cor {cor} tem area de {area} e perimetro de {perimetro}");
    }
}
//-----------------------------------------------------------------------
// INTERFACE:
Demo d = new Demo();
IControle c = new Demo(); //Acessar metodo dentro da interface.

d.nome = "Pincel";
d.Desenhar();
d.Pintar();

c.Exibir();


interface IControle
{
    string? nome { get; set; }
    void Desenhar();
    public void Exibir()
    {
        Console.WriteLine("Teste...");
    }
}
interface IGrafico
{
    void Pintar();
}
class Demo : IControle, IGrafico
{
    public string? nome { get; set; } = string.Empty;
    public void Desenhar()
    {
        Console.WriteLine("Desenhando");
    }

    public void Pintar()
    {
        Console.WriteLine("Pintando");
    }
}
//------------------------------------------------------------------------
//COMPOSIÇÃO:
public class Casa
{
    private readonly Telhado? _telhado;
    private readonly Vigas? _vigas;

    public Casa(Telhado? telhado)
    {
        _telhado = telhado;
        _vigas = new Vigas();
    }
}
public class Telhado
{

}
public class Vigas
{

}


//----------------------------------------------------------------------
//AGREGAÇÃO + GENERIC:

Professor pfr1 = new Professor("Rafael", "Quimica", 60456);
Professor pfr2 = new Professor("Azk", "Ingles", 1002777);
Professor pfr3 = new Professor("Dai", "Matematica", 765165);
Professor pfr4 = new Professor("Nat", "Literatura", 752665);

Departamento dp1 = new Departamento("Exatas");
dp1.incluiProfessor(pfr1);
dp1.incluiProfessor(pfr3);
dp1.listaProfessor();

Departamento dp2 = new Departamento("Humanas");
dp2.incluiProfessor(pfr2);
dp2.incluiProfessor(pfr4);
dp2.listaProfessor();

class Departamento
{
    public string? nome { get; set; }
    private List<Professor>? professores { get; set; }
    public Departamento(string? nome)
    {
        this.nome = nome;
        professores = new List<Professor>();
    }
    public void incluiProfessor(Professor prf)
    {
        professores?.Add(prf);
    }
    public void listaProfessor()
    {
        Console.WriteLine($"\nDepartamento: {nome}\n");

        foreach (var prof in professores)
        {
            Console.WriteLine($"{prof.nome} -> {prof.disciplina} -> {prof.ID}");

        }
    }
}
class Professor
{
    public string? nome;
    public string? disciplina;
    public int? ID;

    public Professor(string? nome, string? disciplina, int? ID)
    {
        this.nome = nome;
        this.disciplina = disciplina;
        this.ID = ID;
    }
}

//-------------- AGREGAÇÃO SIMPLES----

Cliente c1 = new("Rafael", 35846652);
CartaoCredito cdc = new();

cdc.numero = 654464;
cdc.validade = "02/2050";
cdc.cliente = c1;

Console.WriteLine($"{cdc.cliente.nome}\nCelular - {cdc.cliente.tel}\ncartão nmr {cdc.numero} e validade {cdc.validade}");


public class Cliente
{
    public string? nome;
    public int tel;
    public Cliente(string? nome, int tel)
    {
        this.nome = nome;
        this.tel = tel;
    }
}
public class CartaoCredito
{
    public int numero { get; set; }
    public string? validade { get; set; }
    public Cliente? cliente { get; set; } //Agregação
}

//-----------------------------------------------------------------------------------
//HERANÇA + COMPOSIÇÃO:

Macaco a1 = new Macaco("Rex", 25);
a1.Ficha();
a1.locomocao();

class Animal
{
    public string? nome { get; set; }
    public int idade { get; set; }

    public Animal(string? nome, int idade)
    {
        this.nome = nome;
        this.idade = idade;
    }
    public virtual void Ficha()
    {

    }
}
class Macaco : Animal
{
    private readonly Andar? _andar;

    public Macaco(string? nome, int idade) : base(nome, idade)
    {
        _andar = new Andar();
    }

    public void locomocao()
    {
        _andar?.Andando();
    }
    public override void Ficha()
    {
        Console.WriteLine($"Macaco {nome} de {idade} anos.");
    }
}
class Andar
{
    public void Andando()
    {
        Console.WriteLine("Status: Andando");
    }
}
//------------------------------------------------------------------------------------

//POLIMORFISMO EM TEMPO DE EXECUÇÃO:

/*Figura figura1 = new Circulo();
Figura figura2 = new Quadrado(); -> Individual.*/

var figuras = new List<Figura>
{
    new Circulo(),
    new Quadrado()
};
foreach (var figura in figuras)
{
    figura.Desenhar();
}

class Figura
{
    public virtual void Desenhar()
    {

    }
}
class Circulo : Figura
{
    public override void Desenhar()
    {
        Console.WriteLine("Desenhando Circulo");
    }
}
class Quadrado : Figura
{
    public override void Desenhar()
    {
        Console.WriteLine("Desenhando Quadrado");
    }
}

//POLIMORFISMO EM TEMPO DE COMPILAÇÃO:

Console.WriteLine(Calcular.Somar(10, 50));
Console.WriteLine(Calcular.Somar(10, 50, 80));
class Calcular
{
    public static int Somar(int x, int y)
    {
        return x + y;
    }
    public static int Somar(int x, int y, int z)
    {
        return (x + y + z);
    }
}
