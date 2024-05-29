namespace GardaNetGame.Shared.DTOs.Klarna
{
    public class OrderKlarnaDTO
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public int tax_rate { get; set; }
        public double unit_price { get; set; }
        public double total_amount { get; set; }
        //Total amount of the order including tax and any available discounts.
        //The value should be in non-negative minor units.
        //Example: 25 Euros should be 2500.
		public int total_tax_amount { get; set; }
		//Total tax amount of the order.
		//The value should be in non-negative minor units.
		//Example: 25 Euros should be 2500.
	}
}
