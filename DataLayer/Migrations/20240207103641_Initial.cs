using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bSEEqtyMarketWatches",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    LongName = table.Column<string>(type: "TEXT", nullable: false),
                    expDate = table.Column<string>(type: "TEXT", nullable: false),
                    strikePrice = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    UlaValue = table.Column<string>(type: "TEXT", nullable: false),
                    LastTrdTime = table.Column<string>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    ATP = table.Column<string>(type: "TEXT", nullable: false),
                    PercentChange = table.Column<double>(type: "REAL", nullable: false),
                    ScripName = table.Column<string>(type: "TEXT", nullable: false),
                    BuyQty = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyQty2 = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyQty3 = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyQty4 = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyQty5 = table.Column<int>(type: "INTEGER", nullable: false),
                    SellQty = table.Column<int>(type: "INTEGER", nullable: false),
                    SellQty2 = table.Column<int>(type: "INTEGER", nullable: false),
                    SellQty3 = table.Column<int>(type: "INTEGER", nullable: false),
                    SellQty4 = table.Column<int>(type: "INTEGER", nullable: false),
                    SellQty5 = table.Column<int>(type: "INTEGER", nullable: false),
                    Bids1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Bids2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Bids3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Bids4 = table.Column<int>(type: "INTEGER", nullable: false),
                    Bids5 = table.Column<int>(type: "INTEGER", nullable: false),
                    Ask1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Ask2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Ask3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Ask4 = table.Column<int>(type: "INTEGER", nullable: false),
                    Ask5 = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyPrice = table.Column<double>(type: "REAL", nullable: false),
                    BuyPrice2 = table.Column<double>(type: "REAL", nullable: false),
                    BuyPrice3 = table.Column<double>(type: "REAL", nullable: false),
                    BuyPrice4 = table.Column<double>(type: "REAL", nullable: false),
                    BuyPrice5 = table.Column<double>(type: "REAL", nullable: false),
                    SellPrice = table.Column<double>(type: "REAL", nullable: false),
                    SellPrice2 = table.Column<double>(type: "REAL", nullable: false),
                    SellPrice3 = table.Column<double>(type: "REAL", nullable: false),
                    SellPrice4 = table.Column<double>(type: "REAL", nullable: false),
                    SellPrice5 = table.Column<double>(type: "REAL", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Change = table.Column<double>(type: "REAL", nullable: false),
                    Volume = table.Column<int>(type: "INTEGER", nullable: false),
                    TurnOver = table.Column<double>(type: "REAL", nullable: false),
                    Open = table.Column<double>(type: "REAL", nullable: false),
                    High = table.Column<double>(type: "REAL", nullable: false),
                    Low = table.Column<double>(type: "REAL", nullable: false),
                    PreCloseRate = table.Column<double>(type: "REAL", nullable: false),
                    OI = table.Column<int>(type: "INTEGER", nullable: false),
                    mktTrddttm1 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdPrice1 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdQTy1 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrddttm2 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdPrice2 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdQTy2 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrddttm3 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdPrice3 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdQTy3 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrddttm4 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdPrice4 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdQTy4 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrddttm5 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdPrice5 = table.Column<string>(type: "TEXT", nullable: false),
                    mktTrdQTy5 = table.Column<string>(type: "TEXT", nullable: false),
                    upperCircuit = table.Column<string>(type: "TEXT", nullable: false),
                    lowerCircuit = table.Column<string>(type: "TEXT", nullable: false),
                    Wk52High = table.Column<string>(type: "TEXT", nullable: false),
                    W2AvgQ = table.Column<string>(type: "TEXT", nullable: false),
                    Wk52low = table.Column<string>(type: "TEXT", nullable: false),
                    MCapFF = table.Column<string>(type: "TEXT", nullable: false),
                    MCapFull = table.Column<string>(type: "TEXT", nullable: false),
                    PremTurnover = table.Column<string>(type: "TEXT", nullable: false),
                    Market_Lot = table.Column<string>(type: "TEXT", nullable: false),
                    RBIRefRate = table.Column<string>(type: "TEXT", nullable: false),
                    Rcount = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bSEEqtyMarketWatches", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "bseScrips",
                columns: table => new
                {
                    SCRIP_CD = table.Column<string>(type: "TEXT", nullable: false),
                    Scrip_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    GROUP = table.Column<string>(type: "TEXT", nullable: false),
                    FACE_VALUE = table.Column<string>(type: "TEXT", nullable: false),
                    ISIN_NUMBER = table.Column<string>(type: "TEXT", nullable: false),
                    INDUSTRY = table.Column<string>(type: "TEXT", nullable: false),
                    scrip_id = table.Column<string>(type: "TEXT", nullable: false),
                    Segment = table.Column<string>(type: "TEXT", nullable: false),
                    NSURL = table.Column<string>(type: "TEXT", nullable: false),
                    Issuer_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Mktcap = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bseScrips", x => x.SCRIP_CD);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bSEEqtyMarketWatches");

            migrationBuilder.DropTable(
                name: "bseScrips");
        }
    }
}
