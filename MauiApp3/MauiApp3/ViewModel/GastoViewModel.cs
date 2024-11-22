using MauiApp3.Models;

namespace MauiApp3.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class GastoViewModel : INotifyPropertyChanged
{
    private readonly GastoService _gastoService;
    public ObservableCollection<Gasto> Gastos { get; set; } = new();

    private string _mesSelecionado;
    public string MesSelecionado
    {
        get => _mesSelecionado;
        set
        {
            _mesSelecionado = value;
            OnPropertyChanged();
            LoadGastosCommand.Execute(null);
        }
    }

    public Command LoadGastosCommand { get; }
    public Command AddGastoCommand { get; }
    public Command DeleteGastoCommand { get; }

    public GastoViewModel()
    {
        _gastoService = new GastoService();

        LoadGastosCommand = new Command(async () => await LoadGastos());
        AddGastoCommand = new Command<Gasto>(async gasto => await AddGasto(gasto));
        DeleteGastoCommand = new Command<int>(async id => await DeleteGasto(id));
    }

    private async Task LoadGastos()
    {
        if (!string.IsNullOrEmpty(MesSelecionado))
        {
            Gastos.Clear();
            var gastos = await _gastoService.GetGastosAsync(MesSelecionado);
            foreach (var gasto in gastos)
            {
                Gastos.Add(gasto);
            }
        }
    }

    private async Task AddGasto(Gasto gasto)
    {
        await _gastoService.AddGastoAsync(gasto);
        await LoadGastos();
    }

    private async Task DeleteGasto(int id)
    {
        await _gastoService.DeleteGastoAsync(id);
        await LoadGastos();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}