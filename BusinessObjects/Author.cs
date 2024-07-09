using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
