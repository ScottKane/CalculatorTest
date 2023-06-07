using ProtoBuf;

namespace CalculatorTest.Shared;

[ProtoContract]
public class AddRequest
{
    public AddRequest() { }
    public AddRequest(int start, int amount) => (Start, Amount) = (start, amount);
    
    [ProtoMember(1)] public int Start { get; }
    [ProtoMember(2)] public int Amount { get; }
}