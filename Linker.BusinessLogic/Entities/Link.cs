using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linker.BusinessLogic.Entities;

public class Link
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(7)]
    public string Id { get; set; }

    [StringLength(4096)] public string Redirect { get; set; }
}