using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Plants.REST.Models
{
public class Plant
{
[Key]
public Guid Id { get; set; } = Guid.NewGuid();
[Required]
public string Title { get; set; }
public string ISBN { get; set; }
public int Year { get; set; }


// Foreign key
public Guid AuthorId { get; set; }
[ForeignKey("AuthorId")]
public Author Author { get; set; }
}
}
