using LINQ_Aluno;
using System.Threading.Channels;

int registroPorPagina = 4;
int numeroPagina;

/*FÓRMULA: RESULTADO = DATASOURCE.Skip(NP-1) * NRP).Take(NRP)
 * Onde: NP = Numero de páginas / NRP = Registros por página.*/

//OBS: Simulação limitada por ser um projeto console.



do
{
    Console.WriteLine("\t\t\t \nInforme o número da página:\n");

    if (int.TryParse(Console.ReadLine(), out numeroPagina))
    {
        if (numeroPagina > 0 && numeroPagina < 5)
        {
            var alunos = Aluno.GetAlunos()
                               .Skip((numeroPagina - 1) * registroPorPagina) //FÓRMULA.
                               .Take(registroPorPagina).ToList();

            Console.WriteLine("\n Pág.: " + numeroPagina);

            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Nome: {aluno.Nome} Idade: {aluno.Idade} Curso: {aluno.Cursoo}");
            }
        }
    }
} while (true);



//--------------------------OUTRA FÓRMULA:------------------------
public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }


    public int FirstRowPage
    {
        get { return (CurrentPage - 1) * PageSize + 1; }

    }

    public int LasttRowPage
    {
        get { return Math.Min(CurrentPage * PageSize, RowCount); }

    }
}

