using MauiApp3.Models;
using MauiApp3.Services;
using Refit;

namespace MauiApp3;

public partial class MainPage : ContentPage
{
    private readonly IApiService _apiService = RestService.For<IApiService>("http://10.0.2.2:5000");

    private async void AdicionarGasto_Clicked(object sender, EventArgs e)
    {
        await AdicionarGastoAsync();
    }

    private async Task ListarGastosAsync(int mesId)
    {
        try
        {
            var gastos = await _apiService.GetGastosPorMesAsync(mesId);
            GastosListView.ItemsSource = gastos; 
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async Task AdicionarGastoAsync()
    {
        try
        {
            var novoGasto = new Gasto
            {
                Descricao = "Compra Teste",
                Preco = 100,
                MesId = 1 
            };

            await _apiService.AddGastoAsync(novoGasto);
            await DisplayAlert("Sucesso", "Gasto adicionado com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
    
}