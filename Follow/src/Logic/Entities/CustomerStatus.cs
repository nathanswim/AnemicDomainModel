﻿using CSharpFunctionalExtensions;
using System;

namespace Logic.Entities
{
    public class CustomerStatus : ValueObject<CustomerStatus>
    {
        public static readonly CustomerStatus Regular = new CustomerStatus(CustomerStatusType.Regular, null);

        public CustomerStatusType Type { get; }

        public ExpirationDate ExpirationDate => (ExpirationDate)_expirationDate;
        private readonly DateTime? _expirationDate;

        public bool IsAdvanced => Type == CustomerStatusType.Advanced && !ExpirationDate.IsExpired;

        private CustomerStatus() { }

        private CustomerStatus(CustomerStatusType type, ExpirationDate expirationDate)
            : this()
        {
            Type = type;
            _expirationDate = expirationDate ?? throw new ArgumentNullException(nameof(expirationDate));
        }

        public CustomerStatus Promote()
        {
            return new CustomerStatus(
                CustomerStatusType.Advanced,
                (ExpirationDate)DateTime.UtcNow.AddYears(1));
        }

        public decimal GetDiscount() => IsAdvanced ? 0.25m : 0.00m;

        protected override bool EqualsCore(CustomerStatus other) =>
            Type == other.Type && ExpirationDate == other.ExpirationDate;

        protected override int GetHashCodeCore() =>
            Type.GetHashCode() ^ ExpirationDate.GetHashCode();
    }

    public enum CustomerStatusType
    {
        Regular = 1,
        Advanced = 2
    }
}
