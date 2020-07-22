namespace DynamoDBFormulaTester
{
    public interface IDynamoDbFormula
    {
        string Name { get; }
        CapaticyUnitType CapaticyUnitType { get; }
        decimal KB { get; }
        int NumberOfObjects { get; }
        decimal Answer();
    }
}