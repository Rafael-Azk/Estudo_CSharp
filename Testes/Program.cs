Console.WriteLine("Cliente especial? S/N");
var resposta = Console.ReadLine();
if (resposta == "S")
{
    Console.WriteLine("Desconto 10%");
}
else if (resposta == "N")
{
    Console.WriteLine("Não cotado");
}
else
{
    Console.WriteLine("Valor inválido");
}

//------------------

Console.WriteLine("Cliente especial? S/N");
var resposta_ = Console.ReadLine().ToLower();

switch (resposta_)
{
    case "s":
        Console.WriteLine("Desconto 10%");
        break;
    case "n":
        Console.WriteLine("Não elegível");
        break;
    default:
        Console.WriteLine("Valor inválido");
        break;
}

Console.ReadKey();

//-------------------------

int cargo = 0;
int funcao = 0;
Console.WriteLine("Gerente(1) ou Programador(2)");
cargo = Convert.ToInt32(Console.ReadLine());



switch (cargo)
{
    case 1:
        Console.WriteLine("Bem-Vindo Gerente");
        break;
    case 2:
        Console.WriteLine("Junio(1) ou Senior(2)");
        funcao = Convert.ToInt32(Console.ReadLine());

        switch (funcao)
        {
            case 1:
                Console.WriteLine("Bem Vindo Junior");
                break;
            case 2:
                Console.WriteLine("Bem vindo Senior");
                break;
        }
        break;
    default:
        Console.WriteLine("Que porra é essa?");
        break;
}

Console.ReadKey();




