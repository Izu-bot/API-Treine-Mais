using System.Globalization;

namespace TreineMais.Domain.ValueObject;

public class Height
{
    private float Value { get; }

    public Height(float value)
    {
        if (value <= 0)
            throw new InvalidOperationException("Height cannot be negative.");
        if (value > 2.80f)
            throw new InvalidOperationException("Height cannot be greater than 2.80m.");

        Value = value;
    }
    

    public override string ToString()
    {
        // Retorna padrao BR 0,00
        return Value.ToString("N2", new CultureInfo("pt-BR"));
    }
}