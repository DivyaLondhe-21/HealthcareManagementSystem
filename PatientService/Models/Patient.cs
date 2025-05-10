using System;
using System.Collections.Generic;

namespace PatientService.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Interactions { get; set; } = null!;
}
