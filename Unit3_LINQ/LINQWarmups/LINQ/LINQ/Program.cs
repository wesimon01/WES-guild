using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {

            // region 1, 10 linq exercises           
            #region  
            //PrintOutOfStock();

            //InStockAndMoreThan3dollars();

            //WAcustomersOrders();

            //getProductNames();

            //ProductsPlus25Percent();

            //ProductNamesUpperCase();

            //FirstThreeFromA();

            //ReverseNumbersC();

            //ProductsAlphabet();

            //ProductsByCat();

            #endregion

            // region 2, 10 linq exercises
            #region

            //LessThanPosition();

            //FirstMod3();

            //UnitsInStockDesc();

            //BCpairs();

            //evenStock();

            //skip3numA();

            //takeUntil6();

            //LINQex8();

            //LINQex10();

            //First3WA();

            #endregion

            //region 3, 10 linq exercises
            #region

            //CatPriceSort();

            //CommonAB();

            //UniqueAB();

            //inAnotB();

            //ID12();

            //OddNumbersA();

            //AllbutfirsttwoWA();

            //ID789();

            //custIDorderCount();

            //CatProductCount();

            #endregion

            //region 4, 10 linq exercises
            #region

            //TotalUnitsPerCat();

            //MinPricePerCat();

            //HiPricePerCat();

            //AvgPriceInCat();

            NumbersCMod5();

            //UniqueProductCats();

            //GroupsWithAllinStock();

            //OnlyLessThan9();

            //AtleastOneOutofStock();

            //ByYearByMonth();

            #endregion
            Console.ReadLine();
        }
       
        //LINQ exercise #1
        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.UnitsInStock == 0);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        //LINQ exercise #2
        private static void InStockAndMoreThan3dollars()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        //LINQ exercise #3
        private static void WAcustomersOrders()
        {
            var customers = DataLoader.LoadCustomers();
            var results = customers.Where(c => c.Region == "WA");

            foreach (var customer in results)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        //LINQ exercise #4
        private static void getProductNames()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.ProductName != null);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        //LINQ exercise #5
        private static void ProductsPlus25Percent()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.ProductName != null);

            foreach (var product in results)
            {
                Console.WriteLine("{0},  {1:N3}", product.ProductName, product.UnitPrice * 1.2500m);
            }
        }

        //LINQ exercise #6
        private static void ProductNamesUpperCase()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.ProductName != null);

            foreach (var product in results)

                Console.WriteLine(product.ProductName.ToUpper());
        }

        //LINQ #7
        private static void evenStock()
        {
            var products = DataLoader.LoadProducts();
            var results = products.Where(p => p.UnitsInStock % 2 == 0).OrderByDescending(p => p.UnitsInStock);

            foreach (var i in results)
            {
                Console.WriteLine("{0}, {1}", i.ProductName, i.UnitsInStock);
            }
        }
        
        //LINQ #8
        private static void LINQex8()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                          select new { p.ProductName, p.Category, Price = p.UnitPrice };

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #9
        private static void BCpairs()
        {
            var B = DataLoader.NumbersB;
            var C = DataLoader.NumbersC;

            var pairs = from b in B
                        from c in C
                        where b < c
                        select new { b, c };

            foreach (var i in pairs)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ #10
        private static void LINQex10()
        {
            var customers = DataLoader.LoadCustomers();
            var results = customers.SelectMany(c => c.Orders, (c, o)
                           => new { c.CustomerID, o.OrderID, o.Total })
                           .Where(o => o.Total < 500).OrderByDescending(o => o.Total);

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ exercise #11
        private static void FirstThreeFromA()
        {

            int[] numbers = DataLoader.NumbersA;
            var results = numbers.Take(3);

            foreach (var number in results)

                Console.WriteLine(number);
        }

        //LINQ #12
        private static void First3WA()
        {
            var customers = DataLoader.LoadCustomers();
            var results = from cust in customers
                          from order in cust.Orders
                          where cust.Region == "WA"
                          select new { cust.CustomerID, order.OrderID, order.OrderDate, cust.Region };
            var first3Wa = results.Take(3);

            foreach (var i in first3Wa)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ #13
        private static void skip3numA()
        {
            var A = DataLoader.NumbersA;
            var result = A.Skip(3);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #14 
        private static void AllbutfirsttwoWA()
        {
            var customers = DataLoader.LoadCustomers();
            var waOrders = from c in customers
                           from o in c.Orders
                           where c.Region == "WA"
                           select new { c.CustomerID, o.OrderID, o.OrderDate };

            var allButFirst2Orders = waOrders.Skip(2);

            foreach (var i in allButFirst2Orders)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #15
        private static void takeUntil6()
        {
            var C = DataLoader.NumbersC;
            var result = C.TakeWhile(x => x < 6);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #16
        private static void LessThanPosition()
        {
            var numbers = DataLoader.NumbersC;
            var lessPos = numbers.TakeWhile((n, index) => n >= index);

            foreach (var i in lessPos)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #17
        private static void FirstMod3()
        {

            var numbers = DataLoader.NumbersC;
            var result = numbers.SkipWhile(n => n % 3 != 0);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ exercise #18 
        private static void ProductsAlphabet()
        {
            var products = DataLoader.LoadProducts();
            var sortedAlpha = products.OrderBy(p => p.ProductName);

            foreach (var i in sortedAlpha)
            {
                Console.WriteLine(i.ProductName);
            }
        }
        
        // LINQ #19
        private static void UnitsInStockDesc()
        {
            var products = DataLoader.LoadProducts();
            var result = products.OrderByDescending(p => p.UnitsInStock);

            foreach (var i in result)
            {
                Console.WriteLine("{0}, {1}", i.UnitsInStock, i.ProductName);
            }
        }
        
        //LINQ #20
        private static void CatPriceSort()
        {
            var products = DataLoader.LoadProducts();
            var sortedProducts = from p in products
                                 orderby p.Category, p.UnitPrice descending
                                 select p;

            foreach (var i in sortedProducts)
            {
                Console.WriteLine("{0}, {1}, {2}", i.ProductName, i.Category, i.UnitPrice);
            }
        }

        //LINQ exercise #21
        private static void ReverseNumbersC()
        {
            int[] numbers = DataLoader.NumbersC;
            var results = numbers.Reverse();

            foreach (var number in results)

                Console.WriteLine(number);
        }
       
        // #22 method syntax
        private static void NumbersCMod5()
        {
            var C = DataLoader.NumbersC;
            var numberGroups = C.GroupBy(n => n % 5).Select(g => new { remainder = g.Key, Numbers = g });
                
                

            foreach (var i in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", i.remainder);
                foreach (var n in i.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }

        ////LINQ #22
        //private static void NumbersCMod5()
        //{
        //    var C = DataLoader.NumbersC;
        //    var numberGroups = from n in C
        //                       group n by n % 5 into G
        //                       select new { Remainder = G.Key, Numbers = G };

        //    foreach (var G in numberGroups)
        //    {
        //        Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", G.Remainder);
        //        foreach (var n in G.Numbers)
        //        {
        //            Console.WriteLine(n);
        //        }
        //    }
        //}

        // LINQ exercise #23 
        private static void ProductsByCat()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                          orderby p.Category
                          select p;

            foreach (var i in results)
            {
                Console.WriteLine("{0}, {1}", i.ProductName, i.Category);
            }
        }

        //LINQ #24
        private static void ByYearByMonth()
        {
            var customers = DataLoader.LoadCustomers();
            var results = customers.Select(c => new { customer = c, OrderbyYear = c.Orders.GroupBy(o => o.OrderDate.Year) });

            foreach (var i in results)
            {
                Console.Write(i.customer.CustomerID);

                foreach (var o in i.OrderbyYear)
                {
                    Console.Write(o.Key);

                    foreach (var y in o.GroupBy(y => y.OrderDate.Month))
                    {
                        Console.Write(y.Key);

                        foreach (var z in y)
                        {
                            Console.WriteLine(z.OrderID);

                        }
                    }
                }
            }
        }
        
        //LINQ #25
        private static void UniqueProductCats()
        {
            var products = DataLoader.LoadProducts();
            var results = (products.Select(p => p.Category)).Distinct();

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ #26
        private static void UniqueAB()
        {
            var A = DataLoader.NumbersA;
            var B = DataLoader.NumbersB;

            var uniqueValues = A.Union(B);

            foreach (var i in uniqueValues)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #27
        private static void CommonAB()
        {
            var A = DataLoader.NumbersA;
            var B = DataLoader.NumbersB;

            var commonValues = A.Intersect(B);

            foreach (var i in commonValues)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #28
        private static void inAnotB()
        {
            var A = DataLoader.NumbersA;
            var B = DataLoader.NumbersB;

            var values = A.Except(B);

            foreach (var i in values)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #29 
        private static void ID12()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                          where p.ProductID == 12
                          select new { p.ProductName, p.ProductID };

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }
        
        //LINQ #30
        private static void ID789()
        {
            var products = DataLoader.LoadProducts();
            var result = products.Any(p => p.ProductID == 789);

            Console.WriteLine(result); //result is a bool not a list
        }
        
        //LINQ #31
        private static void AtleastOneOutofStock()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                     .Where(pGroup => pGroup.Any(p => p.UnitsInStock == 0))
                     .Select(pGroup => new { Category = pGroup.Key, Products = pGroup });

            foreach (var i in results)
            {
                Console.WriteLine(i.Category);
            }
        }
        
        //LINQ #32
        private static void OnlyLessThan9()
        {
            var B = DataLoader.NumbersB;
            var result = B.Any(p => p < 9);

            Console.WriteLine(result);
        }
        
        //LINQ #33
        private static void GroupsWithAllinStock()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Where(pGroup => pGroup.All(p => p.UnitsInStock > 0))
                          .Select(pGroup => new { Category = pGroup.Key, Products = pGroup });

            foreach (var i in results)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i.Category);
                Console.ResetColor();

                foreach (var j in i.Products)
                {
                    Console.WriteLine("{0}, {1}", j.ProductName, j.UnitsInStock);
                }
            }
        }


        //LINQ #34
        private static void OddNumbersA()
        {
            var A = DataLoader.NumbersA;
            var result = from n in A
                         where n % 2 != 0 // where n % 2 == 1
                         select n;

            int[] answer = result.ToArray();
            int len = answer.Length;
            Console.WriteLine(len);
        }

        //LINQ #35   
        private static void custIDorderCount()
        {
            var customers = DataLoader.LoadCustomers();
            var results = customers.Select(c => new { c.CustomerID, Ordercount = c.Orders.Count() });
            var answer = results.OrderByDescending(c => c.Ordercount);

            foreach (var i in answer)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #36
        private static void CatProductCount()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Select(prodGroup => new { Category = prodGroup.Key, ProductCount = prodGroup.Count() })
                          .OrderByDescending(p => p.ProductCount);

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #37
        private static void TotalUnitsPerCat()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Select(prodGroup => new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock) });
            var answer = results.OrderByDescending(p => p.TotalUnitsInStock);

            foreach (var i in answer)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #38
        private static void MinPricePerCat()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Select(pGroup => new { Category = pGroup.Key, MinPriceInGroup = pGroup.Min(p => p.UnitPrice) });

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #39
        private static void HiPricePerCat()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Select((pGroup) => new { Category = pGroup.Key, HiPriceInGroup = pGroup.Max(p => p.UnitPrice) });

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        //LINQ #40
        private static void AvgPriceInCat()
        {
            var products = DataLoader.LoadProducts();
            var results = products.GroupBy(p => p.Category)
                          .Select(pGroup => new { Category = pGroup.Key, AverageGrpPrice = pGroup.Average(p => p.UnitPrice) });

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }
 
        
                
    }
}




    

