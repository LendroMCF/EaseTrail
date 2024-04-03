using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EaseTrail.WebApp.Models;

public partial class Account : Notifiable<Notification>
{
    public Account()
    {
    }

    public Account(string email, string password, string phone)
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(email, "Email", "Email format is incorrect")
                .IsLowerThan(password, 9, "Password", "Password can't be lower than 9")
                .IsEmpty(phone, "Phone", "Phone cannot be empty")
        );

        Email = email;
        Password = password;
        Phone = phone;
    }

    public string Id { get; set; } = null!;

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Code { get; set; }

    public string Token { get; set; }

    public int Status { get; set; }

    public virtual ICollection<AccountDetail> AccountDetails { get; set; } = new List<AccountDetail>();

    public virtual ICollection<AccountPlan> AccountPlans { get; set; } = new List<AccountPlan>();

    public virtual ICollection<Collaborator> Collaborators { get; set; } = new List<Collaborator>();

    public virtual ICollection<OriginStatus> OriginStatuses { get; set; } = new List<OriginStatus>();

    public virtual ICollection<SystemTransaction> SystemTransactions { get; set; } = new List<SystemTransaction>();

    public virtual ICollection<TeamAccount> TeamAccounts { get; set; } = new List<TeamAccount>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Transaction> TransactionReceivers { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionSenders { get; set; } = new List<Transaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
