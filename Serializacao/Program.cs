

//SERIALIZAÇÃO:

//------------------------BINÁRIA (OBSOLETA)-----------------------------

using System.Runtime.Serialization.Formatters.Binary;

var alu1 = new Aluno("Maria", "kkk@hotmail.com", 18);
var caminhoArquivo = @"C:\Users\Usuario\Desktop\AlunoSerial.bin";
using (FileStream fs = new FileStream(caminhoArquivo, FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
var bf = new BinaryFormatter(); //Obsoleto. Não vai compilar.
bf.Serialize(fs, alu1);

Console.WriteLine("\nTecle algo para desserializar...");
Console.ReadKey();
fs.Seek(0, SeekOrigin.Begin);
var alunoDesserializado = (Aluno)bf.Deserialize(fs);
Console.WriteLine(alunoDesserializado.Nome);
}
Console.WriteLine("Serializado com sucesso...");


[Serializable]
public class Aluno
{
    public string Nome { get; set; }
    public string Email { get; set; }
    [NonSerialized]
    public int Idade;

    public Aluno(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}

//-----------------------------------XML----------------------
using System.Xml.Serialization;

var alu1 = new Aluno("Maria", "kkk@hotmail.com", 18);
var caminhoArquivo = @"C:\Users\Usuario\Desktop\AlunoSerial.bin";

XmlSerializer serializar = new XmlSerializer(typeof(Aluno));

using (StreamWriter writer = new StreamWriter(caminhoArquivo))
{
    serializar.Serialize(writer, alu1);
}
Console.WriteLine("Serializado para XML com sucesso....");
Console.WriteLine("\n Tecle para desserializar....");
Console.ReadKey();

using (StreamReader reader = new StreamReader(caminhoArquivo))
{
    var aluno = (Aluno)serializar.Deserialize(reader);

    Console.WriteLine($"Aluno desserializado: Nome: {aluno.Nome} - Idade: {aluno.Idade} - " +
        $"Email: {aluno.Email}");
}
Console.ReadKey();



public class Aluno
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade;

    public Aluno() { } /*Construtor padrão necessário para serializar XML.
                        * Não necessário em caso de classe sem construtor adicional.*/

    public Aluno(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}

//-------------------------------------JASON-----------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

var alu1 = new Aluno("Maria", "kkk@hotmail.com", 18);
var caminhoArquivo = @"C:\Users\Usuario\Desktop\AlunoSerial.json";

using FileStream stream = new FileStream(caminhoArquivo,
                                         FileMode.OpenOrCreate, FileAccess.ReadWrite);
{
    JsonSerializer.Serialize(stream, alu1);
}

Console.WriteLine("Serializado Json com sucesso...");
Console.ReadKey();
/*OBS: Precisa desserializar sem a serialização em uso. Separar por projetos Class*/
string conteudoJson = File.ReadAllText(caminhoArquivo);
var aluno = JsonSerializer.Deserialize<Aluno>(conteudoJson);
Console.WriteLine($"\nAluno desserializado: Nome: {aluno.Nome} - Idade: {aluno.Idade} - " +
                                                $"Email: {aluno.Email}");


public class Aluno
{
    public string Nome { get; set; }
    public string Email { get; set; }
    //public int Idade; /*Não será serializada pois naõ tem 
    //                   * propriedade "Get/Set". Também existe outra forma, "JsonIgnore".

    [JsonIgnore] // Não vai serializar idade.
    public int Idade { get; set; }

    public Aluno() { } /*Construtor padrão necessário para serializar XML.
                        * Não necessário em caso de classe sem construtor adicional.*/

    public Aluno(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}



