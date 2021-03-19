using Rock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Rest;
using Rock.Rest.Filters;
using System.Web.Http;

namespace org.abwe.RockMissions.Rest
{
    public class MinAccount
    {
        public int Id;
        public string Name;
        [NonSerialized()]
        public FinancialAccount Parent;
        public int? ParentId;
        public List<MinAccount> Children;
        public bool HasChildren;
        public bool IsActive;

        [NonSerialized()]
        public FinancialAccount FinancialAccount;
    }

    /// <summary>
    /// REST API for ABWE People
    /// </summary>
    public class MissionsOrgAccountsController : ApiController<FinancialAccount>
    {
        public MissionsOrgAccountsController() : base(new FinancialAccountService(new Rock.Data.RockContext())) { }

        List<MinAccount> GetChildren(FinancialAccount account)
        {
            List<MinAccount> children = new List<MinAccount>();

            foreach (var childAccount in account.ChildAccounts) {
                children.Add(new MinAccount
                {
                    Id = childAccount.Id,
                    Name = childAccount.Name,
                    Parent = childAccount.ParentAccount,
                    ParentId = childAccount.ParentAccountId,
                    IsActive = childAccount.IsActive,
                    FinancialAccount = childAccount
                });
                children.AddRange(GetChildren(childAccount));
            }

            return children;
        }

        [Authenticate, Secured]
        [HttpGet]
        [System.Web.Http.Route("api/org_abwe/Missions/Accounts/Search/{term}")]
        public List<MinAccount> Search(string term)
        {
            var personId = GetPerson()?.Id;

            var accountService = new FinancialAccountService(new Rock.Data.RockContext()).Queryable();

            var accounts = accountService.Where(a => a.Name.Contains(term)).Select(a =>
            new MinAccount {
                Id = a.Id,
                Name = a.Name,
                Parent = a.ParentAccount,
                ParentId = a.ParentAccountId,
                IsActive = a.IsActive,
                FinancialAccount = a
            }).ToList();

            List<MinAccount> allAccounts = new List<MinAccount>();

            foreach (var account in accounts)
            {
                
                allAccounts.Add(account);
                if (account.Parent != null)
                {
                    var parent = account.Parent;
                    while (parent != null)
                    {

                        if (!allAccounts.Any(a => a.Id == parent.Id))
                        {
                            allAccounts.Add(new MinAccount
                            {
                                Id = parent.Id,
                                Name = parent.Name,
                                Parent = parent.ParentAccount,
                                ParentId = parent.ParentAccountId,
                                IsActive = parent.IsActive
                            });

                            parent = parent.ParentAccount;
                        }
                        else
                        {
                            parent = null;
                        }
                    }

                    if (account.FinancialAccount.ChildAccounts.Count > 0)
                    {
                        allAccounts.AddRange(GetChildren(account.FinancialAccount).Where(ca => !allAccounts.Any(a => a.Id == ca.Id)));
                    }
                }
            }

            allAccounts.ForEach(account => {
                account.Children = allAccounts.Where(a => a.ParentId == account.Id).ToList();
                if (account.Children.Count > 0) account.HasChildren = true;
            });

            var matchingAccounts = allAccounts.Where(account => account.Parent == null).ToList();

            return matchingAccounts;
        }
    }
}
