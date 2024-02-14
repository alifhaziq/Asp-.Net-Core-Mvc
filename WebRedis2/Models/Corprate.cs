namespace WebRedis2.Models
{
    public class Corprate
    {
        public string Name { get; set; } = string.Empty;
        public int RegisterationNo { get; set; }
        public string CountryOrigin { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int NoPhone { get; set; }
        public int NoFax { get; set; }
        public int ContactPerson { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public int PostCode { get; set; }
        public string Town { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string TypeOrganisation { get; set; } = string.Empty;
        public string Nature { get; set; } = string.Empty;
        public double PaidCapital { get; set; }
        public DateTime DateCapital { get; set; }
        public string ShareHolder { get; set; } = string.Empty;
        public DateTime DateShareHodlder { get; set; }
        public double ProfitLoss { get; set; }
        public DateTime DateProfitLoss { get; set; } 
        public string AccountType { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public int NoAccount { get; set; }
    }
}
