using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
