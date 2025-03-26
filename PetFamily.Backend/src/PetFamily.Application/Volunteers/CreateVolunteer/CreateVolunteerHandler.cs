using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    public async Task<Result<Guid>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken = default)
    {
        //валидация
        
        //создание доменной модели
        var volunterResult = Volunteer.Create(request.Title, request.Description);

        
        
        //сохранение в БД
        
    }
}