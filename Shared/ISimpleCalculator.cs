using System.ServiceModel;

namespace CalculatorTest.Shared;

[ServiceContract]
public interface ISimpleCalculator
{
    // Modified method parameters to work with protobuf-net (gRPC) which may only take a single parameter and need to be async
    // Results should also be a reference type
    [OperationContract] Task<CalculatorResponse> Add(AddRequest request);
    [OperationContract] Task<CalculatorResponse> Subtract(SubtractRequest request);
}