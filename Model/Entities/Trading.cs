using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Model.Entities; 

[Table("TRADER_HAS_STOCKS_JT")]
public class Trading {

    [Column("STOCK_ID"), Required]
    public int StockId { get; set; }
    public Stock Stock { get; set; }

    [JsonIgnore]

    [Column("TRADER_ID"), Required]
    public int TraderId { get; set; }
    public Trader Trader { get; set; }

    [Column("TRADED_AT"), DataType(DataType.DateTime)]
    public DateTime TradedAt { get; set; }

    [Column("PRICE")]
    [Precision(10,2),Required]
    public float Price { get; set; }
}