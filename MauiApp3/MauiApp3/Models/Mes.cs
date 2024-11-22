namespace MauiApp3.Models;

public class Mes
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Gasto> Gastos { get; set; } = new();
}