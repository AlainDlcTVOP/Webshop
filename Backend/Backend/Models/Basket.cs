using SkiShop.Models;

namespace Backend.Models
{
    public class Basket
    {
        public int Id { get; set; } = 1;
        public string CustomerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public double TotalCost()
        {
            double sum = 0;
            foreach (var item in Items)
            {
                sum += item.Product.Price * item.Quantity;
            }

            return sum;

        }

        public void UpdateQuantity(Product product, int quantity)
        {
            var item = Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (quantity == 0)
                Items.Remove(item);
            else
                item.Quantity = quantity;

        }


        public void AddItem(Product product, int quantity)
        {
            if (Items.All(x => x.Product.Id != product.Id))
            {
                Items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                var existingItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingItem != null)
                    existingItem.Quantity += 1;
            }


        }

        public void RemoveItem(Product product)
        {
            var item = Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item == null) return;
            Items.Remove(item);
        }
    }
}
