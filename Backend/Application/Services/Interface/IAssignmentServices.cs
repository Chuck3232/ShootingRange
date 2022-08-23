using Application.Commands.Assignment;
using Application.Dto;
using Domain.Models;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IAssignmentServices : IService
    {
        Task AddAssignmentWeapon(AddAssigmentWeapon command);
        Task AcceptationAssignment(GetAssignmentById command);
        Task AddAssignmentAmmunition(AddAssignmentAmmo command);
        Task AddAssignmentInstructor(AddAssignmentInstructor command);
        List<AssignmentDto> GetMyAssignments(GetMyAssignments command);
        Task DeclineAssignment(GetAssignmentById command);
    }
}
