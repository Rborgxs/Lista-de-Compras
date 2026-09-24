using System;
public class Program()
{
    public static void Main()
    {
        const string DIVISOR = "====================";
        List<string> shoppingList = new List<string>();
        int op = 0;


        while (true)
        {
            // MENU
            try
            {
                Console.Clear();
                Console.WriteLine($"{DIVISOR}\nLISTAGEM DE COMPRAS\n{DIVISOR}\n");
                Console.WriteLine("[1] Ver lista");
                Console.WriteLine("[2] Adicionar item");
                Console.WriteLine("[3] Excluir item\n");

                op = Convert.ToInt32(Console.ReadLine());
            } catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nDigite uma opção válida! " + e.Message);
                Console.Write("\nClique em qualquer tecla para voltar... ");
                Console.ReadKey();
                continue;
            }

            // OPERAÇÃO
            switch (op)
            {
                // Ver lista
                case 1:
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

                // Adicionar item
                case 2:
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
                            Console.Write($"\n{addItem} agora está na lista!\nClique em qualquer tecla para continuar... ");
                            Console.ReadKey();
                        }
                        break;                        
                    }

                    else
                    {
                        Console.Write("\nDigite um texto válido!");
                        Console.Write("\nClique em qualquer tecla para voltar... ");
                        Console.ReadKey();
                        break;
                    }

                // Excluir item
                case 3:
                    if (shoppingList.Count > 0)
                    {
                        // Mostra lista
                        int index = 0;
                        Console.Clear();
                        Console.WriteLine("LISTA");
                        
                        int i = 1;
                        foreach (string item in shoppingList)
                        {
                            Console.WriteLine($"[{i}] {item}");
                            i++;
                        }

                        // Tratamentos de erro para o índice
                        try
                        {
                            Console.WriteLine("\nQual item deseja excluir? ");
                            index = Convert.ToInt32(Console.ReadLine()!) - 1;

                            //if (index < 0 || index >= shoppingList.Count)
                            //    throw new IndexOutOfRangeException("Índice inválido!");
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("\nDigite um número válido!");
                            Console.Write("\nClique em qualquer tecla para voltar... ");
                            Console.ReadKey();
                            break;
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.Clear();
                            Console.WriteLine($"\n{ex.Message}");
                            Console.Write("\nClique em qualquer tecla para voltar... ");
                            Console.ReadKey();
                            break;
                        }

                        if (index >= 0 && index < shoppingList.Count)
                        {
                            shoppingList.RemoveAt(index);
                            Console.WriteLine($"\n'{shoppingList[index]}' excluído da lista com sucesso!");
                            Console.Write("\nClique em qualquer tecla para continuar... ");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sua lista está vazia!");
                        Console.Write("\nClique em qualuqer tecla para voltar... ");
                        Console.ReadKey();
                    }
                    break;


                default:
                    Console.Clear();
                    Console.Write("\nDigite uma opção válida!");
                    Console.Write("\nClique em qualquer tecla para voltar... ");
                    Console.ReadKey();
                    break;
            }
        }
    }
}