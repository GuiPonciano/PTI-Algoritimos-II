using System.Reflection;
using System.Runtime.CompilerServices;

public class OperaçõesMenu
 {
  Estoque estoques = new Estoque();
  Manga mangas = new Manga();
public void ExecutaMenu()
    {
      int opção;
       do
     {
      opção = Menu();
      ProcessarOpção(opção);
     } while (opção!=0);
    } 
public  int Menu()
    {
        Console.WriteLine (@"
        O que você deseja fazer:
        [1]Novo
        [2]Lista de Produtos
        [3]Remover produto
        [4]Entrada de estoque
        [5]Saida de estoque
        [0]Sair");

        int opção = Convert.ToInt32(Console.ReadLine());
        return opção;
   }
public  void ProcessarOpção(int opção)
     
      {
       switch (opção)
       {
         case 1:
         estoques.Adicionar(mangas);
         break;
         case 2:
         estoques.Lista(mangas);
         break;
         case 3:
         estoques.Remover(mangas);
         break;
         case 4:
         estoques.EntradaEstoque(mangas);
         break;
         case 5:
         estoques.SaidaEstoque(mangas);
         break;
         case 0:
         Console.WriteLine("saindo...");
         break;
         default:
         Console.WriteLine("Opção Invalida! Tente Novamente.");
         break;
       }
      }
 } 