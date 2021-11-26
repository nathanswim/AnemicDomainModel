using CSharpFunctionalExtensions;
using System;

namespace Logic.Entities
{
    public sealed class CustomerName : ValueObject<CustomerName>
    {
        public string Value { get; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static Result<CustomerName> Create(string customerName)
        {
            customerName = (customerName ?? string.Empty).Trim();

            if (customerName.Length == 0)
                return Result.Failure<CustomerName>("Customer name should not be empty");

            if (customerName.Length > 100)
                return Result.Failure<CustomerName>("Customer name is too long");

            return Result.Success(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other) =>
            Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static implicit operator string(CustomerName customerName) => customerName.Value;

        public static explicit operator CustomerName(string customerName) => Create(customerName).Value;
    }

}
