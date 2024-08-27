//Corrente c1 = new Corrente();
//c1.ID = "Rafael";
//c1.Nmro = 1993;
//Poupança c2 = new Poupança();
//c2.ID = "Dai";
//c2.Nmro = 2001;
//Investimento c3 = new Investimento();
//c3.ID = "Azk";
//c3.Nmro = 0000;

//c1.Depositar(1000);
//c2.Depositar(1000);
//c3.Depositar(1000);
//Console.WriteLine();
//c1.Sacar(100);
//c2.Sacar(100);
//c3.Sacar(100);
//Console.WriteLine();
//c1.Sacar(2000);
//c2.Sacar(2000);
//c3.Sacar(2000);
//Console.WriteLine();
//c1.ExibirSaldo();
//c2.ExibirSaldo();
//c3.ExibirSaldo();
//Console.WriteLine();
//c3.Sacar((decimal)907.991000); //Sald. insuf. por causa do juros.


//class Cliente
//{
//    public string? ID { get; set; }
//    public int Nmro { get; set; }

//}
//abstract class Conta : Cliente
//{
//    public decimal saldo;

//    public void ExibirSaldo()
//    {
//        Console.WriteLine($"{ID} da conta {Nmro}. Seu saldo é {saldo.ToString("c")}");
//    }
//    public virtual decimal Depositar(decimal d)
//    {
//        saldo = saldo + d;
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }
//    public virtual decimal Sacar(decimal s)
//    {
//        saldo = saldo - s;
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }

//}
//class Corrente : Conta
//{

//}
//class Poupança : Conta
//{
//    const double jurosP = 1.005;
//    public override decimal Depositar(decimal d)
//    {
//        saldo = saldo + d * (decimal)jurosP;
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }
//    public override decimal Sacar(decimal s)
//    {
//        if (saldo < s)
//        {
//            Console.WriteLine("Saldo Insuficiete");
//            return saldo;
//        }

//        saldo = saldo - s;
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }

//}
//class Investimento : Conta
//{
//    const double jurosI = 1.009;
//    const double jurosSaque = 0.001;
//    public override decimal Depositar(decimal d)
//    {
//        saldo = saldo + d * (decimal)jurosI;
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }
//    public override decimal Sacar(decimal s)
//    {
//        if (saldo < s + (saldo * (decimal)jurosSaque))
//        {
//            Console.WriteLine("Saldo Insuficiete");
//            return saldo;
//        }
//        saldo = saldo - s - (saldo * (decimal)jurosSaque);
//        Console.WriteLine(saldo.ToString("c"));
//        return saldo;
//    }

//}
//------------------------------------------------------------------------------------
//SalvarXml salvarXml = new SalvarXml();
//salvarXml.Nome();
//salvarXml.Salvar();
//SalvarJason salvarJason = new SalvarJason();
//salvarJason.Nome();
//salvarJason.Salvar();

//ISalvar acesso = new SalvarJason(); //Acessar metodo da interface que contem implementação.
//acesso.Compactar();



//interface ISalvar
//{
//    public abstract void Salvar();

//    public void Compactar()
//    {
//        Console.WriteLine("Compactando");
//    }
//}
//public abstract class arquivoBase
//{
//    public virtual void Nome()
//    {
//        Console.WriteLine("Definir Nome do arquivo");
//    }
//}
//public class SalvarXml : arquivoBase, ISalvar
//{
//    public void Salvar()
//    {
//        Console.WriteLine("Salvar arquivo em XML");
//    }
//    public override void Nome()
//    {
//        Console.WriteLine("Definir nome XML");
//    }
//}
//public class SalvarJason : arquivoBase, ISalvar
//{
//    public void Salvar()
//    {
//        Console.WriteLine("Salvar arquivo em JSON");
//    }
//    public override void Nome()
//    {
//        Console.WriteLine("Definir nome JSON");
//    }
//}
//-----------------------------------------------------------------------------

//Carro c1 = new Carro("Ford Ka", 20);
//c1.Ficha();
//c1.Dirigir();
//c1.Abastecer(20);

//Carro c2 = new Carro("Ferrari", 0);
//c2.Ficha();
//c2.Dirigir();
//c2.Abastecer(30);
//c2.Dirigir();




//interface IVeiculo
//{
//    void Dirigir();
//    public bool Abastecer(int x);
//}
//class Carro : IVeiculo
//{
//    string? nome {  get; set; }
//    int gasolina { get; set; }
//    public Carro(string? nome, int gasolina)
//    {
//        this.nome = nome;
//        this.gasolina = gasolina;
//    }
//    public void Ficha()
//    {
//        Console.WriteLine($"\nCarro {nome} com {gasolina} de gasolina");
//    }

//    public bool Abastecer(int x)
//    {
//        gasolina += x;
//        Console.WriteLine($"Abasteceu {gasolina}lts");
//        return true;
//    }

//    public void Dirigir()
//    {
//        if (gasolina > 0)
//        {
//            Console.WriteLine("\nDirigindo");
//        }
//        else
//        {
//            Console.WriteLine("\nSem Gasolina");
//        }

//    }
//}
//--------------------------------------------------------------------------------
SalaAula B1 = new SalaAula("B1");
Pessoas p1 = new Pessoas("Maria", "Professora");
Pessoas p2 = new Pessoas("Nat", "Aluna");
Pessoas p3 = new Pessoas("Keila", "Professora");

B1.Incluir(p1);
B1.Incluir(p2);
B1.Incluir(p3);

B1.Lista();
class SalaAula
{
    string? sala { get; set; }
    private List<Pessoas>? pessoas { get; set; }
    public SalaAula(string? sala)
    {
        this.sala = sala;
        pessoas = new List<Pessoas>();
    }
    public void Incluir(Pessoas pess)
    {
        pessoas?.Add(pess);
    }
    public void Lista()
    {
        Console.WriteLine($"Sala {sala}\n");

        foreach (var pess in pessoas)
        {
            Console.WriteLine($"{pess.nome} - {pess.tipo}");
        }
    }

}
public class Pessoas
{
    public string? nome;
    public string? tipo;

    public Pessoas(string? nome, string? tipo)
    {
        this.nome = nome;
        this.tipo = tipo;
    }
}
//-------------------------------------------------------------------------------

//int total = 3;
//Pessoa[] pessoas = new Pessoa[total];
//Console.WriteLine(("Informe o nome de 3 pessoas"));
//for (int i = 0; i < total; i++)
//{
//    pessoas[i] = new Pessoa()
//    {
//        Nome = Console.ReadLine()
//    };
//}
//Console.WriteLine("\nAcessando os dados... \n");
//for (int i = 0; i < total; i++)
//{
//    Console.WriteLine(pessoas[i].ToString());
//}
//Console.ReadLine();


//public class Pessoa
//{
//    public string? Nome { get; set; }
//    public override string ToString()
//    {
//        return "Ola ! Meu nome é " + Nome;
//    }
//}




