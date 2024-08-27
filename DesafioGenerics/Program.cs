//Generic<int> intObj = new Generic<int>();
//intObj.Adicionar(10);
//intObj.Adicionar(20);
//intObj.Adicionar(30);
//intObj.Adicionar(40);
//intObj.Adicionar(50);
//intObj.Adicionar(60);

//Generic<string> intObj2 = new Generic<string>();
//intObj2.Adicionar("Maluco");
//intObj2.Adicionar("Chapado");

//Generic<Aluno> alunos = new Generic<Aluno>();
//Aluno alu1 = new Aluno("Doido", 35);
//Aluno alu2 = new Aluno("Doido", 38);
//Aluno alu3 = new Aluno("Doido", 33);
//Aluno alu4 = new Aluno("Doido", 32);

//alunos.Adicionar(alu1);
//alunos.Adicionar(alu2);
//alunos.Adicionar(alu3);
//alunos.Adicionar(alu4);
//alunos.Adicionar(new Aluno("Canalha", 55));

//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine(intObj[i]);
//}
//Console.WriteLine();
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine(intObj2[i]);
//}
//Console.WriteLine();
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine($"{alunos[i].nome} - {alunos[i].idade} anos");
//}

//Console.ReadKey();

//public class Generic<T>
//{
//    //Array com 5 elementos.
//    T[] obj = new T[5];
//    int contador = 0;

//    //Adicionar elementos.
//    public void Adicionar(T item)
//    {
//        if (contador < 5)
//        {
//            obj[contador] = item;
//        }
//        contador++;
//    }
//    //Indexador para iteração foreach. PRECISA CRIAR INDEXADOR NESSE CASO
//    public T this[int index]
//    {
//        get { return obj[index]; }
//        set { obj[index] = value; }

//    }
//}
//public class Aluno
//{
//    public string? nome;
//    public int idade;

//    public Aluno(string? nome, int idade)
//    {
//        this.nome = nome;
//        this.idade = idade;
//    }
//}
//---------------------------DICTIONARY-------------------------------------------------------------

//var alunos = new Dictionary<int, Aluno>()
//{
//    {1, new Aluno("Maria", 10) },
//    {12345, new Aluno("José", 5) },
//    {35864, new Aluno("Vania", 8) },
//};

//FichaAlunos(alunos);

////Mostrar ficha de alunos:
//static void FichaAlunos(Dictionary<int, Aluno> alunos)
//{
//    foreach (var item in alunos)
//    {
//        Console.WriteLine($"{item.Key} - Aluno:{item.Value.Nome} / Nota:{item.Value.Nota}");
//    }
//}

//Buscar aluno e inserir/modificar nota:
//static void InserirAluno(Dictionary<int, Aluno> alunos)
//{
//    bool cond = true;
//    while (cond == true)
//    {
//        Console.WriteLine("Insira o código do aluno - (Tecle 99 para sair)");
//        int codigo = Convert.ToInt32(Console.ReadLine());

//        if (codigo == 99)
//        {
//            Console.WriteLine("Obrigado pela visita");
//            break;
//        }

//        bool result = alunos.ContainsKey(codigo); //Retorna true se o codigo (TKey) do aluno existe.
//        if (result == true) //Pode ser apenas "if (result)".
//        {
//        repeat:
//            Console.WriteLine($"Aluno: {alunos[codigo].Nome}");
//            Console.WriteLine("Informe a nota (0 a 10)");
//            var nota = Convert.ToInt32(Console.ReadLine());
//            if (nota < 0 || nota > 10)
//            {
//                Console.WriteLine("Nota deve ser de 0 a 10\n");
//                goto repeat;
//            }
//            alunos[codigo].Nota = nota;
//            Console.WriteLine($"Nova nota: {alunos[codigo].Nota}");
//            cond = false;
//        }
//        else
//        {
//            Console.WriteLine("Aluno não localizado");
//            break;
//        }
//    }
//    FichaAlunos(alunos); //Com nova nota.
//}

//Remover aluno:
//static void RemoverAluno(Dictionary<int, Aluno> alunos)
//{
//    Console.WriteLine("Insira o código do aluno para remover");
//    int cod = Convert.ToInt32(Console.ReadLine());
//    if (alunos.ContainsKey(cod))
//    {
//        Console.WriteLine($"Aluno {alunos[cod].Nome} removido");
//        alunos.Remove(cod);
//    }
//    else
//    {
//        Console.WriteLine("Aluno não encontrado");
//    }
//    FichaAlunos(alunos);
//}

//Inserir Aluno:
//InserirAluno(alunos);
//static void InserirAluno(Dictionary<int, Aluno> alunos)
//{
//    Console.WriteLine("Informe o código para o Aluno");
//    int novoCodigo = Convert.ToInt32(Console.ReadLine());

//    if (!alunos.ContainsKey(novoCodigo))
//    {
//        Console.WriteLine("Informe o Nome:");
//        string? novoNome = Console.ReadLine();
//        Console.WriteLine("Informa a nota inicial:");
//        int novaNota = Convert.ToInt32(Console.ReadLine());
//        alunos.Add(novoCodigo, new Aluno(novoNome, novaNota));
//    }
//    else
//    {
//        Console.WriteLine("Código já existente: " + alunos[novoCodigo].Nome);
//    }
//    FichaAlunos(alunos);
//}

//Ordernar Alunos:
//OrdernarAlunos(alunos);
//static void OrdernarAlunos(Dictionary<int, Aluno> alunos)
//{
//    var alunosOrdenados = alunos.OrderBy(x => x.Value.Nome);
//    foreach (var item in alunosOrdenados)
//    {
//        Console.WriteLine($"{item.Value.Nome} Nota:{item.Value.Nota} - Chave:{item.Key}");
//    }
//}

//Remover todos da lista:
//alunos.Clear();
//FichaAlunos(alunos);
//Console.WriteLine("Tudo limpo");

//public class Aluno
//{
//    public Aluno(string? nome, int nota)
//    {
//        Nome = nome;
//        Nota = nota;
//    }

//    public string? Nome { get; set; }
//    public int Nota { get; set; }
//}

//---------------------------------------------------------------------------------------------
//var editor = new EditorTexto();
//Console.WriteLine("Digitando...");
//editor.DigitarChar('s');
//editor.DigitarChar('t');
//editor.DigitarChar('a');
//editor.DigitarChar('q');
//editor.DigitarChar('u');

//Console.WriteLine("\nUndo:");
//editor.UndoChar();
//editor.UndoChar();

//Console.WriteLine("\nRedigitando...");
//editor.DigitarChar('c');
//editor.DigitarChar('k');

//public class EditorTexto
//{
//    private Stack<char> PilhaChar = new Stack<char>();
//    private string Texto = "";

//    public void DigitarChar(char c)
//    {
//        Texto += c;
//        PilhaChar.Push(c);
//        Console.WriteLine($"Texto: {Texto}");
//    }
//    public void UndoChar()
//    {
//        PilhaChar.Pop();
//        Texto = Texto.Substring(0, Texto.Length - 1);
//        Console.WriteLine($"Texto: {Texto}");
//    }
//}

//-----------------------------------------------------------------------

//Add pedidos na fila:
//Queue<Pedido> fila = new Queue<Pedido>();
//fila.Enqueue(new Pedido(101, (decimal)3.50));
//fila.Enqueue(new Pedido(122, (decimal)55.40));
//fila.Enqueue(new Pedido(150, (decimal)89.10));

//Console.WriteLine("\nLocalizando pedido Cod: 122");
//decimal codPedido = 122;
//Pedido? localizaPedido = fila.FirstOrDefault(p => p.produto == codPedido);
//if (localizaPedido != null)
//{
//    Console.WriteLine($"Pedido localizado...\nValor: {localizaPedido.valor.ToString("c")} \n");
//}
//else
//{
//    Console.WriteLine("Pedido não localizado...\n");
//}

////Numero total de pedidos:
//Console.WriteLine($"\nTotal de pedidos {fila.Count}\n");

////Processando pedidos na fila:
//while (fila.Count() > 0)
//{
//    //Retira o próximo da fila:
//    Pedido primeiroDaFila = fila.Dequeue();

//    Console.WriteLine($"\nProcessando pedido. Produto Cód:{primeiroDaFila.produto} - Valor: {primeiroDaFila.valor.ToString("c")}");
//}




//class Pedido
//{
//    public Pedido(int produto, decimal valor)
//    {
//        this.produto = produto;
//        this.valor = valor;
//    }

//    public int produto { get; set; }
//    public decimal valor { get; set; }
//}
//---------------------------------------------------------------------------

//-------------------------------PROBLEMA:

//Generic<int> gen = new Generic<int>();
//gen.TesteSub();

//public class Generic<T>
//{
//    public T Campo;
//    public void TesteSub()
//    {
//        T i = Campo + 1;
//    }
//}
//-----------------------------MINHA SOLUÇÃO:

Generic<int> gen = new Generic<int>();
gen.TesteSub();


public class Generic<T> where T : struct
{
    public T Campo;
    public void TesteSub()
    {
        int i = Convert.ToInt32(Campo) + 1;
        Console.WriteLine(i);
    }
}

//------------------------SOLUÇÃO COPILOT

//Generic<int> gen = new Generic<int>();
//gen.Campo = 5;
//gen.TesteSub();

//public class Generic<T> where T : struct, IComparable, IFormattable, IConvertible
//{
//    public T Campo;
//    public void TesteSub()
//    {
//        if (Campo is int)
//        {
//            int i = Convert.ToInt32(Campo) + 1;
//            Console.WriteLine(i);
//        }
//    }
//}










