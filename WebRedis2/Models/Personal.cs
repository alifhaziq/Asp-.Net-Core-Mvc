namespace WebRedis2.Models
{
    public class Personal
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Nric { get; set; }
        public int Dob  { get; set; }
        public string Cob { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Martial { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public int Postcode { get; set; }
        public string Town { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        //Spouse
        public string SpouseName { get; set; } = string.Empty;
        public int SpouseNric { get; set; }
        public string Employer { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public int SpousePhoneNumber { get; set; }
        public int ServiceYear { get; set; }
        public string SpouseAddress1 { get; set; } = string.Empty;
        public string SpouseAddress2 { get; set; } = string.Empty;

        // Employment
        public string EmploymentName { get; set; } = string.Empty;
        public string Nature { get; set; } = string.Empty;
        public string EmploymentAddress1 { get; set; } = string.Empty;
        public string EmploymentAddress2 { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int EmploymentServiceYear { get; set; }
        public double MarketValue { get; set; }
        public string AnnualIncome { get; set; } = string.Empty;
        public string Funds { get; set; } = string.Empty;
        public string NetWorth { get; set; } = string.Empty;
        public string SourceWealth { get; set; } = string.Empty;

        // PersonalBank
        public string AccountType { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public int NoAccount { get; set; }
    }

    //public class Spouse
    //{
    //    public string SpouseName { get; set; } = string.Empty;
    //    public int SpouseNric { get; set; }
    //    public string Employer { get; set; } = string.Empty;
    //    public string Occupation { get; set; } = string.Empty;
    //    public int PhoneNumber { get; set; }
    //    public int ServiceYear { get; set; }
    //    public string Address1 { get; set; } = string.Empty;
    //    public string Address2 { get; set; } = string.Empty;
    //    //public Personal Id{ get; set; }
    //}

    //public class Employment
    //{
    //    public string Name { get; set; } = string.Empty;
    //    public string Nature { get; set; } = string.Empty;
    //    public string Address1 { get; set; } = string.Empty;
    //    public string Address2 { get; set; } = string.Empty;
    //    public string Position { get; set; } = string.Empty;
    //    public int ServiceYear { get; set; }
    //    public double MarketValue { get; set; }
    //    public string AnnualIncome { get; set; } = string.Empty;
    //    public string Funds { get; set; } = string.Empty;
    //    public string NetWorth { get; set; } = string.Empty;
    //    public string SourceWealth { get; set; } = string.Empty;
    //}

    //public class PersonalBank
    //{
    //    public string AccountType { get; set; } = string.Empty;
    //    public string Name { get; set; } = string.Empty;            
    //    public int NoAccount { get; set; }
    //}
}
