namespace demoApi.Models{

    public struct Product{
        public int id;
        public string name;
        public Current_Price current_price;
    }

    public struct Current_Price{
        public double value;
        public string currency_code;
    }
}