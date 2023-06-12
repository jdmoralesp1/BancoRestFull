using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<List<ClienteDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
