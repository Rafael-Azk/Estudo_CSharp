try
{
    Console.WriteLine("Acessar arquivo poesia.txt em https://macoratti.net/dados\n");
    Console.WriteLine("Nome do arquivo: Informar");
    string? arquivo = Console.ReadLine(); //Busca arquivo.
    Console.WriteLine("URL do site: Informar");
    string? url = Console.ReadLine(); //Busca URL.
    Console.WriteLine("\nAguarde...\n");

    HttpClient client = new HttpClient();
    HttpResponseMessage response = client.GetAsync(url + "/" + arquivo).Result;//Obtém na variável o resultado da Busca/Resposta do servidor.

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Acesso realizado com sucesso!");
        Console.WriteLine("Cód de status: " + response.StatusCode);
    }
    else
    {
        throw new HttpRequestException("Erro: " + (int)response.StatusCode);//Cód convertido para int (Ex: 404).  
    }
}
catch (HttpRequestException ex) when (ex.Message.Contains("404"))
{
    Console.WriteLine("Página não encontrada");
}
catch (HttpRequestException ex) when (ex.Message.Contains("401"))
{
    Console.WriteLine("Acesso não autorizado");
}
catch (HttpRequestException ex) when (ex.Message.Contains("400"))
{
    Console.WriteLine("Requisição inválida");
}
catch (HttpRequestException ex) when (ex.Message.Contains("500"))
{
    Console.WriteLine("Erro interno do servidor");
}
catch (Exception ex) //Sempre usar exceção ex genérica.
{
    Console.WriteLine("Erro: " + ex.Message);
}
finally
{
    Console.WriteLine("\nProcessamento concluído");
}