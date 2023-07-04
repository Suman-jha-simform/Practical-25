using MediatR;
using Practical_25.Database;
using Practical_25.Model;

namespace Practical25_Mediator.Mediator
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public DateTime JoinDate { get; set; }
        public Department DepartmentId { get; set; }
        public bool DeleteStatus { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly ApplicationDbContext _context;
            public UpdateEmployeeCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
                if (employee is not null)
                {
                    employee.Name = request.Name;
                    employee.Salary = request.Salary;
                    employee.Email = request.Email;
                    employee.JoinDate = request.JoinDate;
                    employee.DepartmentId = request.DepartmentId;
                    employee.DeleteStatus = request.DeleteStatus;
                    await _context.SaveChangesAsync();
                    return employee.Id;
                }
                return default;
            }
        }
    }
}
