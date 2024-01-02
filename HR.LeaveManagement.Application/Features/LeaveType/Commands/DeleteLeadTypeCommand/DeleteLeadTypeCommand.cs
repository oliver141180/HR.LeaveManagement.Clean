using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeadTypeCommand;
public class DeleteLeadTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
