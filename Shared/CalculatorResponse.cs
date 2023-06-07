using ProtoBuf;

namespace CalculatorTest.Shared;

[ProtoContract]
public class CalculatorResponse
{
    public CalculatorResponse() { }
    public CalculatorResponse(int value) => Value = value;
    
    [ProtoMember(1)] public int Value { get; set; }
}