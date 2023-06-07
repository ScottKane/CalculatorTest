using ProtoBuf;

namespace CalculatorTest.Shared;

[ProtoContract]
public class SubtractRequest
{
    public SubtractRequest() { }
    public SubtractRequest(int start, int amount) => (Start, Amount) = (start, amount);
    
    [ProtoMember(1)] public int Start { get; }
    [ProtoMember(2)] public int Amount { get; }
}