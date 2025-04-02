using System.Reflection.PortableExecutable;

public class Manga
{  
    public Manga()
    {}

    public string Nome { get; set; } = string.Empty;
    public string Autor{ get; set; } = string.Empty;
    public decimal Preço{ get; set; }
    public int AnoLançamento{ get; set; }
    public string Gênero{ get; set; } = string.Empty;
    public int Quantidade{ get; set; }
    
   
    public Manga(string? nome,string? autor,decimal preço,int anoLançamento,string? gênero,int quantidade)
    {
        Nome = nome;
        Autor = autor;
        Preço = preço;
        AnoLançamento = anoLançamento;
        Gênero = gênero;
        Quantidade = quantidade;
    }



}


