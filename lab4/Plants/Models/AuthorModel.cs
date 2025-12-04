using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Plants.REST.Models
{
public class Author
n {
[Key]
public Guid Id { get; set; } = Guid.NewGuid();
[Required]
public string Name { get; set; }


// Navigation
public ICollection<Plant> Plants { get; set; }
}
}
