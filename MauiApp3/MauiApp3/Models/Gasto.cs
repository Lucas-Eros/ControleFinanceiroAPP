namespace MauiApp3.Models;

public class Gasto
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int MesId { get; set; }
}