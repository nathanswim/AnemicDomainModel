using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Entities
{
    public class Customer : Entity
    {
        public virtual CustomerName Name
        {
            get => (CustomerName)_name;
            set => _name = value;
        }
        private string _name;


        public virtual Email Email
        {
            get => (Email)_email;
            protected set => _email = value;
        }
        private string _email;

        public virtual CustomerStatus Status { get; protected set; }

        public virtual Dollars MoneySpent
        {
            get => Dollars.Of(_moneySpent);
            protected set => _moneySpent = value;
        }
        private decimal _moneySpent;

        public virtual IReadOnlyList<PurchasedMovie> PurchasedMovies => _purchasedMovies.ToList();

        private readonly IList<PurchasedMovie> _purchasedMovies;

        protected Customer()
        {
            _purchasedMovies = new List<PurchasedMovie>();
        }

        public Customer(CustomerName name, Email email)
            : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            MoneySpent = Dollars.Of(0);
            Status = CustomerStatus.Regular;
        }

        public virtual void PurchaseMovie(Movie movie)
        {
            ExpirationDate expirationDate = movie.GetExpirationDate();
            Dollars price = movie.CalculatePrice(Status);

            var purchasedMovie = new PurchasedMovie(movie, this, price, expirationDate);
            _purchasedMovies.Add(purchasedMovie);
            MoneySpent += price;
        }

        public virtual bool Promote()
        {
            // at least 2 active movies during the last 30 days
            if (PurchasedMovies.Count(x =>
                x.ExpirationDate == ExpirationDate.Infinite ||
                x.ExpirationDate.Date >= DateTime.UtcNow.AddDays(-30)) < 2)
                return false;

            // at least 100 dollars spent during the last year
            if (PurchasedMovies.Where(x => x.PurchaseDate > DateTime.UtcNow.AddYears(-1)).Sum(x => x.Price) < 100m)
                return false;

            Status = Status.Promote();

            return true;
        }

    }
}
