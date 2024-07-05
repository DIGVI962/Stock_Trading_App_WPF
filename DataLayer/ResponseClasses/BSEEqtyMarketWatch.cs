using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ResponseClasses
{
    public class BSEEqtyMarketWatch
    {
        public string LongName { get; set; }
        public string expDate { get; set; }
        public string strikePrice { get; set; }
        public string Unit { get; set; }
        public string UlaValue { get; set; }
        public string LastTrdTime { get; set; }
        public string URL { get; set; }
        public string ATP { get; set; }
        public double PercentChange { get; set; }
        [Key]
        public string Symbol { get; set; }
        public string ScripName { get; set; }
        public int BuyQty { get; set; }
        public int BuyQty2 { get; set; }
        public int BuyQty3 { get; set; }
        public int BuyQty4 { get; set; }
        public int BuyQty5 { get; set; }
        public int SellQty { get; set; }
        public int SellQty2 { get; set; }
        public int SellQty3 { get; set; }
        public int SellQty4 { get; set; }
        public int SellQty5 { get; set; }
        public int Bids1 { get; set; }
        public int Bids2 { get; set; }
        public int Bids3 { get; set; }
        public int Bids4 { get; set; }
        public int Bids5 { get; set; }
        public int Ask1 { get; set; }
        public int Ask2 { get; set; }
        public int Ask3 { get; set; }
        public int Ask4 { get; set; }
        public int Ask5 { get; set; }
        public double BuyPrice { get; set; }
        public double BuyPrice2 { get; set; }
        public double BuyPrice3 { get; set; }
        public double BuyPrice4 { get; set; }
        public double BuyPrice5 { get; set; }
        public double SellPrice { get; set; }
        public double SellPrice2 { get; set; }
        public double SellPrice3 { get; set; }
        public double SellPrice4 { get; set; }
        public double SellPrice5 { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public int Volume { get; set; }
        public double TurnOver { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double PreCloseRate { get; set; }
        public int OI { get; set; }
        public string mktTrddttm1 { get; set; }
        public string mktTrdPrice1 { get; set; }
        public string mktTrdQTy1 { get; set; }
        public string mktTrddttm2 { get; set; }
        public string mktTrdPrice2 { get; set; }
        public string mktTrdQTy2 { get; set; }
        public string mktTrddttm3 { get; set; }
        public string mktTrdPrice3 { get; set; }
        public string mktTrdQTy3 { get; set; }
        public string mktTrddttm4 { get; set; }
        public string mktTrdPrice4 { get; set; }
        public string mktTrdQTy4 { get; set; }
        public string mktTrddttm5 { get; set; }
        public string mktTrdPrice5 { get; set; }
        public string mktTrdQTy5 { get; set; }
        public string upperCircuit { get; set; }
        public string lowerCircuit { get; set; }
        public string Wk52High { get; set; }
        public string W2AvgQ { get; set; }
        public string Wk52low { get; set; }
        public string MCapFF { get; set; }
        public string MCapFull { get; set; }
        public string PremTurnover { get; set; }
        public string Market_Lot { get; set; }
        public string RBIRefRate { get; set; }
        public string Rcount { get; set; }
    }
}
