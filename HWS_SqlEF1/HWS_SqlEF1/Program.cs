using HWS_SqlEF1.Models;
NorthwindContext db = new NorthwindContext();



//Exc.1

var exc1 = from item in db.Products
           select new { item.ProductName, item.QuantityPerUnit };

//Exc.2

var exc2 = from item in db.Products
           where item.Discontinued == false
           select new { item.ProductId, item.ProductName };

//Exc.3

var exc3 = from item in db.Products
           where item.Discontinued == true
           select new { item.ProductId, item.ProductName };

//Exc.4

var exc4 = (from item in db.Products
            join prd in db.Products
            on item.ProductId equals prd.ProductId
            orderby item.UnitPrice descending
            select new
            {
                prd.ProductName,
                item.UnitPrice,
            }).ToList();

//Exc.5

var exc5 = from item in db.Products
           where item.UnitPrice < 20
           select new { item.ProductId, item.ProductName, item.UnitPrice };

//Exc.6

var exc6 = from item in db.Products
           where item.UnitPrice > 15 && item.UnitPrice < 25
           select new { item.ProductId, item.ProductName, item.UnitPrice };

//Exc.7

var exc7 = from item in db.Products
           where item.UnitPrice > db.Products.Average(x => x.UnitPrice)
           select new { item.ProductName, item.UnitPrice };

//Exc.8

var exc8 = db.Products.Join(db.Products,
   x => x.ProductId,
   x => x.ProductId,
   (pUnitPrice, pName) => new
   {
       pName.ProductName,
       pUnitPrice.UnitPrice
   }
   ).OrderByDescending(x => x.UnitPrice).Take(10).ToList();

//Exc.9

var exc9 = (from item in db.Products
            where item.Discontinued == false
            select item.ProductName).Count();

var exc9p2 = (from item in db.Products
              where item.Discontinued == true
              select item.ProductName).Count();


//Exc.10

var query = from item in db.Products
            where item.Discontinued == false && item.UnitsInStock < item.UnitsOnOrder
            select new { item.ProductId, item.UnitsOnOrder, item.UnitsInStock };
