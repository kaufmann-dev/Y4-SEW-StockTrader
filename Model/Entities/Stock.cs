using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("STOCKS")]
public class Stock
{
    [Key]
    [Column("STOCK_ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME")]
    [Required, StringLength(50)]
    public string Name { get; set; }
}