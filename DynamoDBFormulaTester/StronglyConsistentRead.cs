using System;

namespace DynamoDBFormulaTester
{
    public class StronglyConsistentRead : IDynamoDbFormula
    {
        // Formula  4k x 1 object = 1rcu
        public StronglyConsistentRead(decimal kb, int numberOfObjects)
        {
            KB = kb;
            NumberOfObjects = numberOfObjects;
        }

        public decimal KB { get; private set; }

        public int NumberOfObjects { get; private set; }

        public string Name => "strongly consistent read";

        public CapaticyUnitType CapaticyUnitType => CapaticyUnitType.StronglyConsistentRead;

        public decimal Answer()
        {
            int roundedKb = (int)Math.Ceiling(KB/4);
            return roundedKb * NumberOfObjects;
        }
    }
}
