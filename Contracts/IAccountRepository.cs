﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
        //object GetAllAccounts();
        //void CreateAccount(Account accountEntity);

        IEnumerable<Account> GetAllAccounts();
        void CreateAccount(Account account);
    }
}