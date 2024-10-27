namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }

        public string DiscountTitle { get; set; }

        public string Amount { get; set; }

        public string DiscountDescription { get; set; }

        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
