using System.ComponentModel.DataAnnotations.Schema;

namespace Linker.BusinessLogic.Entities;

public class Link
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Id { get; set; }

    public string Redirect { get; set; }
}