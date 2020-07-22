using System;

namespace DynamoDBFormulaTester
{
    public class Write : IDynamoDbFormula
    {
        // Formula  1k x 1 object = 1wcu

        public Write(decimal kb, int numberOfObjects)
        {
            KB = kb;
            NumberOfObjects = numberOfObjects;
        }

        public decimal KB { get; private set; }

        public int NumberOfObjects { get; private set; }

        public string Name => "write";

        public CapaticyUnitType CapaticyUnitType => CapaticyUnitType.Write;

        public decimal Answer()
        {
            int roundedKb = (int)Math.Ceiling(KB);
            return roundedKb * NumberOfObjects;
        }
    }
}
