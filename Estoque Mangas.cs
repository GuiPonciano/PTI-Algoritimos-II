using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Estoque
{
    Manga[]   mangas = new Manga[0];
    Manga item = new Manga();
    

    
    public void Adicionar(Manga manga)
    {
        Console.WriteLine("Digite o nome do mangá: ");
        item.Nome = Console.ReadLine();

        Console.WriteLine("Digite o nome do Autor: ");
        item.Autor = Console.ReadLine();

        Console.WriteLine("Digite Preço: ");
        item.Preço = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o Ano de lançamento: ");
        item.AnoLançamento =Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o Gênero: ");
        item.Gênero =Console.ReadLine();

        Console.WriteLine("Digite a Quantidade: ");
        item.Quantidade = Convert.ToInt32(Console.ReadLine());

        Manga novoManga = new Manga(item.Nome, item.Autor, item.Preço, item.AnoLançamento, item.Gênero, item.Quantidade);   
        Manga[] novo = new Manga[mangas.Length + 1];

        for(int cont = 0; cont < mangas.Length; cont ++){
            novo[cont] = mangas[cont];
        }

        novo[mangas.Length] = novoManga;
        mangas = novo;
        Console.WriteLine("Mangá Adicionado com suceesso!!!!");

    }
    public void Lista(Manga manga)
    {
         if (mangas.Length == 0)
            {
                Console.WriteLine("Estoque vazio.");
                return;
            }
        foreach(Manga lista in mangas)
        {
         Console.WriteLine($"{lista.Nome} - Autor: {lista.Autor} - R$ {lista.Preço} - Lançamento: {lista.AnoLançamento} - Gênero: {lista.Gênero} - (Estoque: {lista.Quantidade})");
        }
    }
    public void Remover(Manga manga)
    {
      if (mangas.Length == 0)
    {
        Console.WriteLine("Estoque vazio. Não há mangás para remover.");
        return;
    }
    Console.WriteLine("Digite o nome do mangá que deseja remover:");
    item.Nome = Console.ReadLine();
    int count = 0;
     for (int i = 0; i < mangas.Length; i++)
    {
        if (!mangas[i].Nome.Equals(item.Nome, StringComparison.OrdinalIgnoreCase))
        {
            count++;
        }
    }
     if (count == mangas.Length)
    {
        Console.WriteLine($"Mangá '{item.Nome}' não encontrado no estoque.");
        return;
    }
    Manga[] novoArray = new Manga[count];
     int index = 0;
    for (int i = 0; i < mangas.Length; i++)
    {
        if (!mangas[i].Nome.Equals(item.Nome, StringComparison.OrdinalIgnoreCase))
        {
            novoArray[index] = mangas[i];
            index++;
        }
    }
     mangas = novoArray;

    Console.WriteLine($"Mangá '{item.Nome}' removido com sucesso!");
    }
    public void  EntradaEstoque(Manga manga)
    {
        if (mangas.Length == 0)
        {
        Console.WriteLine("Estoque vazio. Não há mangás para entrada de estoque.");
        return;
        }

        Console.WriteLine("Digite o nome do mangá para entrada de estoque:");
        item.Nome = Console.ReadLine();
 
        Manga? mangaEncontrado = null;

        for (int i = 0; i < mangas.Length; i++)
        {
        if (mangas[i].Nome.Equals(item.Nome, StringComparison.OrdinalIgnoreCase))
        {
            mangaEncontrado = mangas[i];
            break;
        }
        }

        if (mangaEncontrado == null)
        {
        Console.WriteLine($"Mangá '{item.Nome}' não encontrado no estoque.");
        return;
        }

        Console.WriteLine("Digite a quantidade para entrada de estoque:");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
        Console.WriteLine("Quantidade inválida. A quantidade deve ser um número positivo.");
        return;
        }

        mangaEncontrado.Quantidade += quantidade;
        Console.WriteLine($"Entrada de estoque: {quantidade} unidades do mangá '{mangaEncontrado.Nome}' adicionadas.");
        Console.WriteLine($"Quantidade atualizada: {mangaEncontrado.Quantidade}");
    }
    public void SaidaEstoque(Manga manga)
    {
        if (mangas.Length == 0)
        {
        Console.WriteLine("Estoque vazio. Não há mangás para saída de estoque.");
        return;
        }
        
        Console.WriteLine("Digite o nome do mangá para saída de estoque:");
        item.Nome = Console.ReadLine();
        
        Manga? mangaEncontrado = null;
        for (int i = 0; i < mangas.Length; i++)
        {
        if (mangas[i].Nome.Equals(item.Nome, StringComparison.OrdinalIgnoreCase))
        {
            mangaEncontrado = mangas[i];
            break;
        }
        }
        
        if (mangaEncontrado == null)
        {
        Console.WriteLine($"Mangá '{item.Nome}' não encontrado no estoque.");
        return;
        }

        Console.WriteLine("Digite a quantidade para saída de estoque:");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
        Console.WriteLine("Quantidade inválida. A quantidade deve ser um número positivo.");
        return;
        }
          if (mangaEncontrado.Quantidade < quantidade)
        {
        Console.WriteLine($"Quantidade insuficiente no estoque. Estoque atual de '{mangaEncontrado.Nome}': {mangaEncontrado.Quantidade}");
        return;
        }

        mangaEncontrado.Quantidade -= quantidade;
        Console.WriteLine($"Saída de estoque: {quantidade} unidades do mangá '{mangaEncontrado.Nome}' removidas.");
        Console.WriteLine($"Quantidade atualizada: {mangaEncontrado.Quantidade}");
    }
}
        








