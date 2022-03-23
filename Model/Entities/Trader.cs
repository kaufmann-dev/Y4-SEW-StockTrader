using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("TRADERS")]
public class Trader {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("TRADER_ID")]
    public int TraderId { get; set; }

    [Column("FIRST_NAME")]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Column("LAST_NAME")]
    [StringLength(50)]
    public string LastName { get; set; }

    public List<Trading> Tradings { get; set; } = new List<Trading>();
}