/* Classes para tratamento de arquivos e diretórios:
 * File - FileInfo - Directory - DirectoryInfo - Path - FileStream - StreamReader - StreamWriter*/
//----------------------------------------------------------

//FILE:
/*METODOS DE MANIPULAÇÃO:
 * Create - Delete - Copy - Move - (Nomes auto explicativos)
 * Exists - Verifica se o arquivo existe.
 * METODO LEITURA E ESCRITA:
 * ReadAllText - Abre, lê, retorna uma string e fecha.
 * ReadAllBytes - Lê arquivo binário e retorna array de bytes.
 * WriteAllText - Cria arquivo, grava uma string em arq de texto e fecha.
 * WriteAllBytes - Grava array de bytes em arq binario.
 * AppendAllText - Abre arquivo, anexa string e fecha (cria arquivo se não existir um).
 * OUTROS METODOS:
 * ReadAllLines - Lê as linhas do arquivo
 * GetLastwriteTime - Data/Hora última modificação.
 * GetLastAccesTime - Data/Hora último acesso.
 * 
 * CRIAR ARQUIVOS - CAMINHO E NOME:
 * EX: string caminho = @"C:\MeusArquivos\arquivo.txt"; ("@" permite uso normal do "\").
 * EX2: string caminho = "C:\\MeusArquivos\\arquivo.txt"; (Sem "@").*/

//--------------------------------Exemplo------------------------------------------------------


//string caminhoOrigem = @"C:\Users\Usuario\Desktop\teste.txt";
//string mover = @"C:\Users\Usuario\Desktop\txt\teste.txt";

//if (!File.Exists(mover))
//{
//    try
//    {


//        /*File.Create(caminhoOrigem);*/ // O "WriteAllText" já cria com o texto.
//        File.WriteAllText(caminhoOrigem, "Azk \r\n"); // "\r\n" = nova linha.
//        string novoTexto = "O poeta bla bla bla \r\n" +
//                            "bla bla bla lorem\r\n" +
//                            "haha haha haha haha\r\n";

//        File.AppendAllText(caminhoOrigem, novoTexto); //Junta dois textos.
//        string conteudo = File.ReadAllText(caminhoOrigem); //Lê tudo e guarda na variavel.
//        Console.WriteLine(conteudo); //Exibe.

//        Console.WriteLine($"Ultima modificação: {File.GetLastWriteTime(caminhoOrigem)}");
//        Console.WriteLine($"Ultimo acesso: {File.GetLastAccessTime(caminhoOrigem)}");

//        string[] linhas = File.ReadAllLines(caminhoOrigem);
//        foreach (var line in linhas)
//        {
//            Console.WriteLine(line);
//        }

//        var copia = @"C:\Users\Usuario\Downloads\copiaTexto.txt";
//        Console.WriteLine($"Copiando de {caminhoOrigem} para {copia}");
//        File.Copy(caminhoOrigem, copia);

//        Console.WriteLine($"Movendo de {caminhoOrigem} para {mover}");
//        File.Move(caminhoOrigem, mover);

//        File.Delete(caminhoOrigem);
//        File.Delete(copia);
//        //File.Delete(mover);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}
//Console.WriteLine("\nConcluido!");
//--------------------------------------------------------------------------------

//FILEINFO:

//try
//{
//    string infoOrigem = @"C:\Users\Usuario\Desktop\teste.txt";
//    string mover = @"C:\Users\Usuario\Desktop\Movertxt\teste.txt";
//    string copia = @"C:\Users\Usuario\Desktop\Copiatxt\teste_1.txt";

//    FileInfo arquivoOrigem = new FileInfo(infoOrigem);
//    Console.WriteLine($"Nome do arquivo: {arquivoOrigem.Name}");
//    Console.WriteLine($"Nome completo do arquivo: {arquivoOrigem.FullName}");
//    Console.WriteLine($"Somente leitura?: {arquivoOrigem.IsReadOnly}");

//    var diretorioPai = arquivoOrigem.Directory;
//    Console.WriteLine($"Diretório pai: {diretorioPai?.Name}");

//    Console.WriteLine($"Tamanho do arquivo: {arquivoOrigem.Length}bytes");
//    Console.WriteLine($"Ultima gravação {arquivoOrigem.LastWriteTime}");



//    if (arquivoOrigem.Exists)
//    {
//        Console.WriteLine("Copiando e movendo...");
//        arquivoOrigem.CopyTo(copia);
//        arquivoOrigem.MoveTo(mover);
//    }
//}
//catch (FileNotFoundException ex)
//{
//    Console.WriteLine("Arquivo não encontrado...");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//-------------------------------------------------------------------------------
//DIRECTORY

//var diretorio = @"C:\Users\Usuario\Desktop\PastaTeste\teste"; //Diretorio + Subdiretorio.
//var diretorio2 = @"C:\Users\Usuario\Desktop\x";
//var raiz = @"C:\";

//try
//{
//    if (!Directory.Exists(diretorio))
//    {
//        Directory.CreateDirectory(diretorio);
//        Console.WriteLine("Diretorio criado...\n"); //Pasta + Subpasta.
//    }
//    else
//    {
//        Console.WriteLine("Arquivo já existe....");
//    }

//    if (Directory.Exists(diretorio))
//    {
//        Directory.Delete(diretorio); //Deleta Subpasta.
//        Console.WriteLine("Deletando SubPasta...\n");
//    }
//    else
//    {
//        Console.WriteLine("Pasta não existe....");
//    }

//    string[] pastaRaiz = Directory.GetDirectories(raiz, "a*"); //Pesquisa pastas que começam com a letra "A".
//    foreach (var pasta in pastaRaiz)
//    {
//        Console.WriteLine(pasta);
//    }

//    string[] dir2 = Directory.GetFiles(diretorio2); //Pesquisa files do diretorio.
//    foreach (var arq in dir2)
//    {
//        Console.WriteLine(arq);
//    }

//    Console.ReadKey();

//    Directory.Move(diretorio2, diretorio); //Move pasta para dentro de outra pasta.

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//---------------------------------------------------------------------------------------
//DIRECTORYINFO:

//var dir = @"C:\Users\Usuario\Desktop\x";

//var dirOrigem = new DirectoryInfo(dir);

//Console.WriteLine($"Nome: {dirOrigem.Name}");
//Console.WriteLine($"Caminho completo: {dirOrigem.FullName}");
//Console.WriteLine($"Data criação: {dirOrigem.CreationTime}");
//Console.WriteLine($"Ultimo acesso: {dirOrigem.LastAccessTime}");
//Console.WriteLine($"Ultima modificação: {dirOrigem.LastWriteTime}");
//Console.WriteLine($"Atributos: {dirOrigem.Attributes}");

//var novoDir = new DirectoryInfo(@"C:\Users\Usuario\Desktop\NovaPasta");   
//novoDir.Create();
//novoDir.Delete();   

//foreach(var arq in dirOrigem.GetDirectories())
//{
//    Console.WriteLine(arq.Name);
//}
//foreach (var arq in dirOrigem.GetFiles())
//{
//    Console.WriteLine(arq.Name);
//}

//dirOrigem.CreateSubdirectory("Pastinha2");

//------------------------------------------------------------------------
//PATH:

//string caminho = "C:\\Users\\Usuario\\Desktop\\x\\xt.txt";

//char dirSeparador = Path.DirectorySeparatorChar;
//Console.WriteLine($"Separador de diretorio padrão: {dirSeparador}");

//string[] diretorios = caminho.Split(dirSeparador);
//Console.WriteLine("Diretorios e arquivos no caminho:");
//foreach (var dir in diretorios)
//{
//    Console.WriteLine(dir);
//}

//string path = "C:\\Users\\Usuario\\Desktop";
//string path2 = "C:\\Users\\Usuario\\Desktop\\x\\xt.txt";
//string pathCombinado = Path.Combine(path, path2);
//Console.WriteLine("\nPath combinado:");
//Console.WriteLine(pathCombinado);

//Console.WriteLine(Path.GetDirectoryName(pathCombinado));
//Console.WriteLine(Path.GetExtension(pathCombinado));
//Console.WriteLine(Path.GetFileName(pathCombinado));
//Console.WriteLine(Path.GetFileNameWithoutExtension(pathCombinado));
//Console.WriteLine(Path.HasExtension(pathCombinado));
//Console.WriteLine(Path.IsPathRooted(pathCombinado));
//Console.WriteLine(Path.ChangeExtension(pathCombinado, ".docx"));
//Console.WriteLine(Path.GetPathRoot(pathCombinado));

//char[] caracterInvalidos = Path.GetInvalidFileNameChars();
//Console.WriteLine(new string (caracterInvalidos));

//---------------------------------------------------------

//FILESTREAM:

string file;
