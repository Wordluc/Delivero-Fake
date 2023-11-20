using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command;
public class AddressCommand
{
    public string? City { get; init; }
    public string? Via { get; init; }
    public int AddressNumber { get; init; }
}
