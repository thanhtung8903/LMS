using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public int Year { get; set; }

    public int Page { get; set; }

    public int CategoryId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
