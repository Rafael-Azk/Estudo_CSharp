//var i = 1;
//Console.WriteLine("Para sair digite 999: \n");
//Console.WriteLine("Insira um número: \n");
//int tab = Convert.ToInt32(Console.ReadLine());

////if (tab > 0)
////{
////    while (i <= 20)
////    {
////        if (tab == 999)
////        {
////            break;
////        }

////        Console.WriteLine($"{tab} x {i} = {tab * i}");
////        i++;
////    }
////}
////else
////{
////    Console.WriteLine("Valor inválido");
////}
//----------------------------------------------------------------

//int[] num = [1, 202, 350, 45, 50];
//Array.Sort(num);

//for (int i = 0; i <= num.Length; i++)
//{
//    Console.WriteLine(num[i]);

//}

////------------------------------------------------------------------
//int x = 0;
//while (x <= 5)
//{
//    int y = 0;
//    while (y <= 5)
//    {
//        Console.Write($"({x},{y}) ");
//        y++;
//    }
//    x++;
//    Console.WriteLine();
//}


//-------------------------------------------------------------------

for (int i = 0; i <= 10; i++)
{
    for (int j = 0; j <= 10; j++)
    {
        if (i == 5)
        {
            i++;
            j--;
            continue;
        }
        Console.Write($"({i},{j})");
    }
    Console.WriteLine();
}