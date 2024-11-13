using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Application.Features.Products.Dtos
{
  // Data Tranfer Object => Data Structure görevi gören Immutable Types
  public record CreateProductRequest([Required] string Name,decimal Price, int Stock) : IRequest;
  
}
