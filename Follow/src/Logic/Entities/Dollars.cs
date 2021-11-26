using CSharpFunctionalExtensions;

namespace Logic.Entities
{
    public sealed class Dollars : ValueObject<Dollars>
    {
        private const decimal MaxDollarAmount = 1_000_000;

        public Dollars(decimal value) => Value = value;

        public decimal Value { get; }

        public static Result<Dollars> Create(decimal dollarAmount)
        {
            if (dollarAmount < 0)
                return Result.Failure<Dollars>("Dollar amount cannot be negative");

            if (dollarAmount > MaxDollarAmount)
                return Result.Failure<Dollars>($"Dollar amount cannot be greater than {MaxDollarAmount:C}");

            if (dollarAmount % 0.01m > 0)
                return Result.Failure<Dollars>($"Dollar amount cannot contain fractions of pennies");

            return Result.Success(new Dollars(dollarAmount));
        }

        public static Dollars Of(decimal value) => Create(value).Value;


        protected override bool EqualsCore(Dollars other) => Value == other.Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static implicit operator decimal(Dollars value) => value.Value;

        public static Dollars operator +(Dollars a, Dollars b) => new Dollars(a.Value * b.Value);
        public static Dollars operator *(Dollars dollars, decimal multiplier) => new Dollars(dollars.Value * multiplier);

    }
}
