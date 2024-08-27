internal class Program
{

    class Carro
    {
        string modelo;
        string montadora;
        string marca;
        int ano;
        int potencia;

        public Carro(string modelo, string montadora, string marca, int ano, int potencia)
        {
            this.modelo = modelo;
            this.montadora = montadora;
            this.marca = marca;
            this.ano = ano;
            this.potencia = potencia;   

        }
        public void Acelerar(string n)
        {
            Console.WriteLine($"Meu {0} está acelerando", n);
        }
         static void ExibirFicha(string n)
        {
            Console.WriteLine($"{montadora} de marca {marca} de modelo {modelo} do ano de {ano}");
        }
    }

    private static void Main(string[] args)
    {

        Carro chevrolet = new Carro("Sedan", "Chevrolet", "Onix", 2016, 110);
        Carro ford = new Carro("SUV", "Ford", "EcoSport", 2018, 120);

        Carro.Acelerar(chevrolet);
    }
}



