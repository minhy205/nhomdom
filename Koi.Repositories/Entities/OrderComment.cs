using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class OrderComment
{
    public int CommentId { get; set; }

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public string CommentText { get; set; } = null!;

    public int? Rating { get; set; }

    public DateTime? CommentDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
