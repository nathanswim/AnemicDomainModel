using CSharpFunctionalExtensions;
using System;
using System.Text.RegularExpressions;

namespace Logic.Entities
{

    public sealed class Email : ValueObject<Email>
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string emailAddress)
        {
            emailAddress = (emailAddress ?? string.Empty).Trim();

            if (emailAddress.Length == 0)
                return Result.Failure<Email>("Email address should not be empty");

            if (!Regex.IsMatch(emailAddress, @"^(.+)@(.+)$"))
                return Result.Failure<Email>("Email is invalid");

            return Result.Success(new Email(emailAddress));
        }

        protected override bool EqualsCore(Email other) =>
            Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static implicit operator string(Email email) => email.Value;

        public static explicit operator Email(string email) => Create(email).Value;
    }
}
