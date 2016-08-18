using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCorpHRportal.Models.Repos
{
    public class PolicyRepository
    {
        private static List<Policy> _policies;

        static PolicyRepository()
        {
            // sample data
            _policies = new List<Policy>
            {
                new Policy {
                    PolicyId = 1,
                    PolicyName = "Policy1",
                    Content = "blahblahblah",
                    Category = new Category
                {
                    CategoryId = 1,
                    CategoryName = "ShockAndAwe"
                    }
                },

                new Policy {
                    PolicyId = 2,
                    PolicyName = "Policy2",
                    Content = "blahblahblah",
                    Category = new Category
                {
                    CategoryId = 2,
                    CategoryName = "SeverancePackages"
                }
                },
                new Policy {
                    PolicyId = 3,
                    PolicyName = "Policy3",
                    Content = "blahblahblah",
                    Category = new Category
                {
                    CategoryId = 3,
                    CategoryName = "Goat"
                },
             },
         };
    }

        public static IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

        public static IEnumerable<Policy> GetbyCat(string categoryName)
        {
            return _policies.Where(p => p.Category.CategoryName == categoryName);
        }

        public static void Add(Policy policy)
        {
            policy.PolicyId = _policies.Max(p => p.PolicyId) + 1;
            _policies.Add(policy);
        }

        public static Policy Get(int policyId)
        {
            return _policies.FirstOrDefault(p => p.PolicyId == policyId);
        }

        public static void Edit(Policy policy)
        {
            var selectedPolicy = _policies.FirstOrDefault(p => p.PolicyId == policy.PolicyId);
            if (selectedPolicy != null)
            {
                selectedPolicy.PolicyName = policy.PolicyName;
            }
        }

        public static void Delete(string policyName, int policyId)
        {
            _policies.RemoveAll(p => p.PolicyName == policyName && p.PolicyId == policyId);
        }

    }
}