using System.Security.Cryptography.X509Certificates;

string caminhoArquivo = @"C:\Users\User\Desktop\Estudo\exercicio.txt";

Console.WriteLine("Caminho do arquivo que será criado:");
Console.WriteLine(caminhoArquivo);

while (true)
{
    Console.WriteLine("\n Selecione uma opção:");
    Console.WriteLine("1 - Criar arquivo");
    Console.WriteLine("2 - Escrever em arquivo");
    Console.WriteLine("3 - Ler arquivo");
    Console.WriteLine("4 - Procurar texto em arquivo");
    Console.WriteLine("0 - Sair");

    int opcao;

    try
    {
        opcao = Convert.ToInt32(Console.ReadLine());
        switch (opcao)
        {
            case 0:
                Console.WriteLine("\nAté mais...");
                return;
            case 1:
                MetodosArquivo.criarArquivo(caminhoArquivo);
                break;
            case 2:
                MetodosArquivo.escreverArquivo(caminhoArquivo);
                break;
            case 3:
                MetodosArquivo.lerArquivo(caminhoArquivo);
                break;
            case 4:
                MetodosArquivo.procurarArquivo(caminhoArquivo);
                break;
            default:
                Console.WriteLine("Opção inválida...");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("\nNão pode ser letra");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

public class MetodosArquivo
{
    public static void criarArquivo(string caminhoArquivo)
    {
        try
        {
            using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine($"\nO arquivo {caminhoArquivo} foi criado...");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    public static void escreverArquivo(string caminhoArquivo)
    {
        Console.WriteLine("\nDigite o texto:");
        string texto = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo, true)) //"true" indica que não vai substituir texto anterior.
            {
                writer.WriteLine(texto);
            }
            Console.WriteLine("\nTexto gravado com sucesso...");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void lerArquivo(string caminhoArquivo)
    {
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("\nArquivo não encontrado...");

        }
        try
        {
            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void procurarArquivo(string caminhoArquivo)
    {
        Console.WriteLine("\n Digite o texto a ser procurado...");
        string textoProcurado = Console.ReadLine();

        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("\nArquivo não encontrado...");

        }

        try
        {
            bool encontrado = false;
            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                string linha;
                int numLinha = 0;
                while ((linha = reader.ReadLine()) != null)
                {
                    numLinha++;
                    if (linha.ToLower().Contains(textoProcurado))
                    {
                        Console.WriteLine($"Texto encontrado na linha {numLinha} : {linha}");
                        encontrado = true;
                        break;
                    }
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("\n Texto não encontrado...");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

