using System.Runtime.CompilerServices;
using CalculatorTest.Shared;

namespace CalculatorTest.Server.Services;

internal sealed class CalculatorService : ISimpleCalculator
{
    public async Task<CalculatorResponse> Add(AddRequest request) =>
        await Task.FromResult(new CalculatorResponse(request.Start + request.Amount));

    public async Task<CalculatorResponse> Subtract(SubtractRequest request) =>
        await Task.FromResult(new CalculatorResponse(request.Start - request.Amount));
}