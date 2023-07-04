using MediatR;
using Practical_25.Database;
using Practical_25.Model;

namespace Practical25_Mediator.Mediator
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public DateTime JoinDate { get; set; }
        public Department DepartmentId { get; set; }


        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly ApplicationDbContext _context;
            public CreateEmployeeCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = new Employee { Name = request.Name,Salary = request.Salary, Email= request.Email, JoinDate = request.JoinDate, DepartmentId = request.DepartmentId};
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee.Id;
            }
        }
    }
}
