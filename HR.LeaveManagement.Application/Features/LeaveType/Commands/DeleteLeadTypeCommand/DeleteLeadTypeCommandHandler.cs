using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeadTypeCommand;
public class DeleteLeadTypeCommandHandler : IRequestHandler<DeleteLeadTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeadTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(DeleteLeadTypeCommand request, CancellationToken cancellationToken)
    {
        var leadTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
        
        if (leadTypeToDelete == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        await _leaveTypeRepository.DeleteAsync(leadTypeToDelete);

        return Unit.Value;
    }
}
