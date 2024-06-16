//using System;
//using System.Collections.Generic;
//using Newtonsoft.Json;

//// Example usage
//var serializer = new StringCollectionSerializer();

//var stringCollection = new List<string> { "S", "M", "L", "XL" };
//string serializedString = serializer.SerializeStringCollection(stringCollection);
//Console.WriteLine("Serialized: " + serializedString);

//var deserializedCollection = serializer.DeserializeStringCollection(serializedString);
//Console.WriteLine("Deserialized: " + string.Join(", ", deserializedCollection));



//public class StringCollectionSerializer
//{
//    // Method to serialize a collection of strings to a single string
//    public string SerializeStringCollection(List<string> stringCollection)
//    {
//        return JsonConvert.SerializeObject(stringCollection);
//    }

//    // Method to deserialize a single string to a collection of strings
//    public List<string> DeserializeStringCollection(string serializedString)
//    {
//        return JsonConvert.DeserializeObject<List<string>>(serializedString);
//    }
//}

//using ChinaExpress.EntityModels;
//using ChinaExpress.EntityModels.Enums;
//using ChinaExpress.SimpleEntityModels;
//using ChinaExpress.SimpleEntityModels.Enums;
//using Experiments;
//using CustomExtensions = ChinaExpress.Extensions.Extensions;


//var users = new List<User>()
//{
//    new User(1, "Bob", "", "","","", UserRole.Client),
//    new User(2, "Alice", "", "","","", UserRole.Client),
//    new User(3, "John", "", "","","", UserRole.Client),
//};

//var products = new List<Product>()
//{
//    new SingleItem(1, "IPhone", "", "", 0, 0, null, 1, null),
//    new SingleItem(2, "Vaccuum", "", "", 0, 0, null, 2, null),
//    new SingleItem(3, "Watch", "", "", 0, 0, null, 3, null),
//    new SingleItem(4, "Laptop", "", "", 0, 0, null, 4, null),
//    new SingleItem(5, "Cat", "", "", 0, 0, null, 5, null),
//    new SingleItem(6, "Bike", "", "", 0, 0, null, 6, null),
//};

//Console.WriteLine($"All items: " +
//                  $"{string.Join(", ", products.Select(oi => oi.Name))}");

//var orders = new List<Order>()
//{
//    new Order(1,  users[0], null, OrderStatus.Draft, "", new List<OrderItem>()
//    { //BOBs ORDER
//        new OrderItem(1, 1, products[2], 1, null), //Watch 
//        new OrderItem(2, 1, products[3], 1, null), // Laptop
//    }),

//    new Order(2,users[2],null, OrderStatus.Finished, "", new List<OrderItem>()
//    { // JOHNs ORDER
//        new OrderItem(4, 2, products[2], 1, null), //Watch 
//        new OrderItem(5, 2, products[3], 1, new Review(2, "", 2, users[2], 4)), // Laptop
//        new OrderItem(6, 2, products[1], 1, null), //vacuum
//        new OrderItem(29, 2, products[0], 1, null), //IPhone
//    }),

//    new Order(3,users[1], null, OrderStatus.Finished, "", new List<OrderItem>()
//    { // ALICEs ORDER
//        new OrderItem(7, 3, products[4], 1, new Review(3, "", 4, users[1], 7)), //cat 
//        new OrderItem(8, 3, products[1], 1, null), // vacuum
//        new OrderItem(9, 3, products[5], 1, new Review(4, "", 2, users[1], 8)), // bike
//    }),
//};

//Console.WriteLine();
//Console.WriteLine($"Items in current users cart: " +
//                  $"{string.Join(", ", orders[0].GetOrderItems().Select(oi => oi.Product.Name))}");


//var allProductViews = new List<ProductView>()
//{
//    ////John
//    new ProductView(1,1,3, new DateTime(2024, 03, 15)),
//    new ProductView(2,1,3, new DateTime(2024, 03, 16)),

//    new ProductView(3,1,4, new DateTime(2024, 03, 17)),
//    new ProductView(4,1,4, new DateTime(2024, 03, 18)),

//    new ProductView(5,1,6, new DateTime(2024, 03, 17)),
//    new ProductView(6,1,6, new DateTime(2024, 03, 18)),

//    new ProductView(7,1,1, new DateTime(2024, 03, 12)),
//    new ProductView(8,1,1, new DateTime(2024, 03, 13)),
//    new ProductView(9,1,1, new DateTime(2024, 03, 14)),
//    new ProductView(10,1,1, new DateTime(2024, 03, 15)),

//    ////Bob
//    //new ProductView(11222,3,3, new DateTime(2024, 03, 14)),
//    //new ProductView(12,3,3, new DateTime(2024, 03, 15)),
//    //new ProductView(12,3,3, new DateTime(2024, 03, 16)),

//    //new ProductView(13,3,4, new DateTime(2024, 03, 17)),
//    //new ProductView(14,3,4, new DateTime(2024, 03, 18)), 


//    ////Alice
//    //new ProductView(18,2,5, new DateTime(2024, 03, 12)),
//    //new ProductView(19, 2,5, new DateTime(2024, 03, 13)),
//    //new ProductView(20 ,2,5, new DateTime(2024, 03, 14)),

//    //new ProductView(21, 2,2, new DateTime(2024, 03, 12)),
//    //new ProductView(22 ,2,2, new DateTime(2024, 03, 13)),

//    //new ProductView(23 ,2,6, new DateTime(2024, 03, 13)),
//};


//var currentUserId = 1; //BOB

//var currentUserCart = CustomExtensions.FirstOrDefault(orders,
//    o => o.User.Id == currentUserId && o.OrderStatus == OrderStatus.Draft);

//var productsInCartIds = currentUserCart.GetOrderItems().Select(oi => oi.Product.ProductId).ToList();

//var foreignOrders = CustomExtensions.Where(orders, o => o.User.Id != currentUserId);
//var recommendedFromSimilar = GetRecommendedItemsFromSimilarOrders(foreignOrders, productsInCartIds);

//var primaryProjection =
//    GetRecommendationProjection(recommendedFromSimilar, allProductViews, currentUserId, 1);

//var primaryProjectinProductItemIds = primaryProjection.Select(p => p.Product.ProductId).ToArray();
//var foreignOrderItems = foreignOrders.SelectMany(o => o.GetOrderItems()).DistinctBy(o => o.Id).ToArray();

//var rawSecondaryProjection = GetRecommendationProjection(foreignOrderItems, allProductViews, currentUserId, 2).ToArray();

//var secondaryProjection =
//    CustomExtensions.Where(rawSecondaryProjection, rp =>
//        !primaryProjectinProductItemIds.Contains(rp.Product.ProductId)
//        && !productsInCartIds.Contains(rp.Product.ProductId));

//var finishedReccomendations = primaryProjection.Concat(secondaryProjection)
//    .OrderBy(p => p.Priority) //Place the items from similar first, the from other orders
//    .ThenByDescending(p => p.Views.Count()) //sort by views from the current user
//    .ThenBy(p => p.DayWeight) // Sort by recently viewed
//    .ThenByDescending(p => p.Rating) //sort by review stars
//    .Select(p => p.Product)
//    .DistinctBy(d => d.ProductId)
//    .ToList();

//Console.WriteLine();
//Console.WriteLine($"Recommended items: " +
//                  $"{string.Join(", ", finishedReccomendations.Select(oi => oi.Name))}");

//List<OrderItem> GetRecommendedItemsFromSimilarOrders(List<Order> foreignOrders, List<int> productsInCarIds)
//{
//    var similarOrders = new List<Order>();
//    foreach (var foreignOrder in foreignOrders)
//    {
//        var orderProductItemIds = foreignOrder.GetOrderItems().Select(oi => oi.Product.ProductId);

//        if (orderProductItemIds.Intersect(productsInCarIds).Count() > 2)
//        {
//            Console.WriteLine();
//            Console.WriteLine($"Found similar order with items: " +
//                              $"{string.Join(", ", foreignOrder.GetOrderItems().Select(oi => oi.Product.Name))}");
//            similarOrders.Add(foreignOrder);
//        }
//    }

//    var recommendedItems = new List<OrderItem>();
//    foreach (var similarOrder in similarOrders)
//    {

//        var notAddedItems = CustomExtensions
//            .Where(similarOrder.GetOrderItems(), oi =>
//                !productsInCartIds.Contains(oi.Product.ProductId))
//            .Select(oi => oi)
//            .ToList();

//        recommendedItems.AddRange(notAddedItems);
//    }

//    return recommendedItems;
//}

//ICollection<RecommendationProjection> GetRecommendationProjection(ICollection<OrderItem> orderItems,
//    ICollection<ProductView> productViews, int userId, int priority)
//{
//    return orderItems
//        .GroupBy(p => p.Product)
//        .Select(x => new
//        {
//            Priority = priority,
//            Product = x.First().Product,
//            Views = productViews.Where(pv => pv.ProductId == x.First().Product.ProductId
//                                             && pv.UserId == userId),
//            Rating = 0 //x.Average(r => r.Review?.Stars) ?? 0,
//        }).Select(x => new RecommendationProjection()
//        {
//            Priority = x.Priority,
//            Views = x.Views,
//            Product = x.Product,
//            Rating = x.Rating,
//            DayWeight = 0 // x.Views.Sum(v => (DateTime.Now - v.ViewDateTime).Hours)
//        })
//        .ToList();
//}

//namespace Experiments
//{
//    public class RecommendationProjection
//    {
//        public int Priority { get; set; }
//        public Product Product { get; set; }
//        public IEnumerable<ProductView> Views { get; set; }
//        public double Rating { get; set; }
//        public double DayWeight { get; set; }
//    }
//}