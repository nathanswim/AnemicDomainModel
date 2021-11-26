using CSharpFunctionalExtensions;
using System;

namespace Logic.Entities
{
    public class ExpirationDate : ValueObject<ExpirationDate>
    {
        public static readonly ExpirationDate Infinite = new ExpirationDate(null);

        public ExpirationDate(DateTime? date) => Date = date;

        public DateTime? Date { get; }

        public bool IsExpired => this != Infinite && Date <= DateTime.UtcNow;


        public static Result<ExpirationDate> Create(DateTime date)
        {
            return Result.Success(new ExpirationDate(date));
        }

        protected override bool EqualsCore(ExpirationDate other) => Date == other.Date;
        protected override int GetHashCodeCore() => Date.GetHashCode();

        public static implicit operator DateTime?(ExpirationDate value) => value.Date;

        public static explicit operator ExpirationDate(DateTime? date)
        {
            if (date.HasValue)
                return Create(date.Value).Value;
            return Infinite;
        }
    }
}
