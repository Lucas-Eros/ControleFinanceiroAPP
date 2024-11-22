using MauiApp3.Models;

namespace MauiApp3.Services;
using Refit;

public interface IApiService
{
    [Get("/mes/{id}/gastos")]
    Task<List<Gasto>> GetGastosPorMesAsync(int id);

    [Post("/gasto")]
    Task AddGastoAsync([Body] Gasto gasto);
}