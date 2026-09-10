using System;
public class Program
{
    public static void Main()
    {
        const string DIVISOR = "====================";
        List<string> shoppingList = new List<string>();

        while (true)
        {
            // MENU
            Console.Clear();
            Console.WriteLine($"{DIVISOR}\nLISTAGEM DE COMPRAS\n{DIVISOR}\n");
            Console.WriteLine("[1] Ver lista");
            Console.WriteLine("[2] Adicionar item");
            Console.WriteLine("[3] Excluir item\n");

            int op = Convert.ToInt32(Console.ReadLine());

            // OPERAÇÃO
            switch (op)
            {
                case 1:
                    // Ver lista
                    Console.Clear();
                    if (shoppingList.Count > 0)
                    {
                        Console.WriteLine("LISTA");
                        foreach (string item in shoppingList)
                        {
                            Console.WriteLine("- " + item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lista vazia!");
                    }

                    Console.Write("\nClique para continuar... ");
                    Console.ReadKey();
                    break;

                case 2:
                    // Adicionar item
                    Console.Clear();
                    Console.Write("Qual item deseja adicionar? ");
                    string addItem = Console.ReadLine()!;

                    if (!string.IsNullOrEmpty(addItem))
                    {
                        addItem = addItem.Trim();
                        addItem = $"{char.ToUpper(addItem[0])}{addItem.Substring(1).ToLower()}"; // Capitalização

                        // Item já existe
                        if (shoppingList.Contains(addItem))
                        {
                            Console.Write($"\nO item '{addItem}' já está na lista!");
                            Console.Write("\nClique para continuar... ");
                            Console.ReadKey();
                        }
                        else
                        {
                            // Item não existe
                            shoppingList.Add(addItem);
                            Console.Write($"\n{addItem} agora está na lista!\nClique para continuar... ");
                            Console.ReadKey();
                        }
                        break;                        
                    }

                    else
                    {
                        Console.Write("\nDigite um texto válido!");
                        Console.Write("\nClique para continuar... ");
                        Console.ReadKey();
                        break;
                    }

                case 3:
                    // Excluir item
                    break;

                default:
                    break;
            }
        }
    }
}