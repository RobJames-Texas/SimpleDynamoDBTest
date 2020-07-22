using System;

namespace DynamoDBFormulaTester
{
    public class EventuallyConsistentRead : IDynamoDbFormula
    {
        // Formula  4k x 2 object = 1rcu
        public EventuallyConsistentRead(decimal kb, int numberOfObjects)
        {
            KB = kb;
            NumberOfObjects = numberOfObjects;
        }

        public decimal KB { get; private set; }

        public int NumberOfObjects { get; private set; }

        public string Name => "eventually consistent read";

        public CapaticyUnitType CapaticyUnitType => CapaticyUnitType.EventuallyConsistentRead;

        public decimal Answer()
        {
            int roundedKb = (int)Math.Ceiling(KB / 4);
            return roundedKb * (Math.Ceiling((decimal)NumberOfObjects / (decimal)2));
        }
    }
}
