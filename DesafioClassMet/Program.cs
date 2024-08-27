//Carro chevrolet = new Carro("Sedan", "Chevrolet", "Onix", 2016, 110);
//Carro ford = new Carro("SUV", "Ford", "EcoSport", 2018, 120);
//Carro car = new();

//chevrolet.ExibirFicha();
//chevrolet.Acelerar();

//ford.ExibirFicha();
//ford.Acelerar();

//class Carro
//{
//    string? modelo;
//    string? montadora;
//    string? marca;
//    int ano;
//    int potencia;

//    public Carro(string modelo, string montadora, string marca, int ano, int potencia)
//    {
//        this.modelo = modelo;
//        this.montadora = montadora;
//        this.marca = marca;
//        this.ano = ano;
//        this.potencia = potencia;

//    }
//    public Carro()
//    {

//    }
//    public void Acelerar()
//    {
//        Console.WriteLine($"Meu {marca} está acelerando");
//    }
//    public void ExibirFicha()
//    {
//        Console.WriteLine($"\n{montadora} da marca {marca} de modelo {modelo} do ano de {ano} e {potencia} cavalos");
//    }
//}

//---------------------------------------------------------------------------------------

//Carro ford = new("Ka", "Ford");

//ford.VeloMax(120);

//class Carro
//{
//    string? Modelo;
//    String? Montadora;

//    public Carro(string mod, string mont)
//    {
//        Modelo = mod;
//        Montadora = mont;   
//    }
//    public int VeloMax(int potencia)
//    {
//        Console.WriteLine($"A potencia total do seu {Modelo} é {potencia}\n");
//        return (int)(double)(potencia * 1.75);

//    }
//}
//---------------------------------------------------------------------------------
//Potencia potencia = new();
//int pot = 10;
//potencia.AumentarPotencia(pot, out double velocidade);

//Console.WriteLine("Nova Velocidade: " + velocidade);


//class Potencia
//{
//    public int AumentarPotencia(int pot, out double velocidade)
//    {
//        int Novapot = pot + 7;
//        velocidade = Novapot * 1.75;
//        return (int)(double)velocidade;    

//    }
//}
//-----------------------------------------------------------------------------------------------

Loja car1 = new Loja();
Loja.ipva = 530;
Loja.ValorIpva();

car1.nome = "Fiat";

Console.WriteLine($"O {car1.nome} paga {Loja.ipva} de juros");

public class Loja
{
    public string? nome;
    public static int ipva;

    public static void ValorIpva()
    {
        ipva += 600;
    }
}