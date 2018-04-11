using System;
using System.Collections.Generic;
using System.Text;


  public  class Hacker
    {
    public string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";
   // public static string Hello = "jhkjhj";
    public string Password
    {
        get => this.password;
        set => this.password = value;
    }

    private int Id { get; set; }

   // private string Muk { get; }
    public double BankAccountBalance { get; private set; }

    public void DownloadAllBankAccountsInTheWorld()
    {
    }
}

