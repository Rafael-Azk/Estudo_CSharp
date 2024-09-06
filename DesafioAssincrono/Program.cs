await ExecutaMetodoAsync();

Console.ReadKey();

static async Task ExecutaMetodoAsync()
{
    var tempo = 10;
    var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

    Console.WriteLine("Iniciando download...");
    Console.WriteLine($"\nCancelando a operação após {tempo} segundos.");

    try
    {
        using var HttpClient = new HttpClient();
        var destino = @"C:\Users\Usuario\Desktop\hehe.txt";

        var response = await HttpClient.GetAsync("https://www.macoratti.net/dados/Poesia.txt",
                                HttpCompletionOption.ResponseHeadersRead, source.Token);

        var totalBytes = response.Content.Headers.ContentLength;
        var readBytes = 0L;

        await using var fileStream = new FileStream(destino, FileMode.Create, FileAccess.Write);
        /* "await" para esperar o processo finalizar;
         * "using" para garantir que fechará automaticamente após finalizar.*/
        await using var contentStream = await response.Content.ReadAsStreamAsync(source.Token);

        var buffer = new byte[81920]; //Reservando 80kb na memória.
        int bytesRead;

        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length,
                                                     source.Token)) > 0)
        {
            await fileStream.WriteAsync(buffer, 0, bytesRead, source.Token);
            readBytes += bytesRead;
            Console.WriteLine($"Progresso: {readBytes}/{totalBytes}");
        }

    }
    catch (OperationCanceledException ex)
    {

        if (source.IsCancellationRequested)
        {
            Console.WriteLine($"\nDownload cancelado por tempo limite... \n{ex.Message}");
        }
        else
        {
            Console.WriteLine("\nTempo limite para download atingido...");
        }

    }
    catch (HttpRequestException ex)
    {

        Console.WriteLine($"\nOcorreu erro de rede... \n{ex.Message}");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro... \n{ex.Message}");
    }
    finally
    {
        Console.WriteLine("\nOperação finalizada...");
    }
}
