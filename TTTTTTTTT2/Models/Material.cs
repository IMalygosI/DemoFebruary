using System;
using System.Collections.Generic;

namespace TTTTTTTTT2.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly ApprovalDate { get; set; }

    public DateOnly ModificationsDate { get; set; }

    public string Status { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Region { get; set; } = null!;

    public int AuthorId { get; set; }

    public virtual Employee Author { get; set; } = null!;

    public virtual ICollection<MaterialAssociation> MaterialAssociations { get; set; } = new List<MaterialAssociation>();
}
