namespace SQL_AssetTracker
{
    public class AssetTracking
    {
        public AssetTracking()
        {
        }

        public AssetTracking(int Id,
                                string office,
                                string brand,
                                DateTime purchaseDate,
                                double price,
                                string currency,
                                string laptopModel,
                                string phoneModel,
                                string type,
                                double localPrice)
        {
            ID = Id;
            Office = office;
            Brand = brand;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            LaptopModel = laptopModel;
            PhoneModel = phoneModel;
            Type = type;
            LocalPrice = localPrice;
        }


        public int ID { get; set; }
        public string Office { get; set; }
        public string Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string LaptopModel { get; set; }
        public string PhoneModel { get; set; }
        public string Type { get; set; }
        public double LocalPrice { get; set; }
    }
}
