using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical_25.Database;
using Practical_25.Model;

namespace Practical25_Mediator.Mediator
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHanlder : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly ApplicationDbContext _context;
            public GetAllEmployeesQueryHanlder(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.ToListAsync();
                return employees;
            }
        }
    }
}
