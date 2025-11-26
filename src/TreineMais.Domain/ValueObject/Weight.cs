using System.Globalization;

namespace TreineMais.Domain.ValueObject;

public class Weight
{
    public float Value { get; }

    public Weight(float value)
    {
        if (value <= 0)
            throw new InvalidOperationException("Weight must be positive");
        if (value > 500.0f)
            throw new InvalidOperationException("Weight must be less than 500.00");
        
        Value = value;
    }
    

    public override string ToString()
    {
        return Value.ToString("N2", new CultureInfo("pt-BR"));
    }
}