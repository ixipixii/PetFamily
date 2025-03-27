using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }
    public async Task<Result<Guid, Error>> HandleAsync(CreateVolunteerRequest request, CancellationToken cancellationToken = default)
    {
        //валидация
        
        //создание доменной модели
        var volunterResult = Volunteer.Create(request.Title, request.Description);

        if (volunterResult.IsFailure)
            return volunterResult.Error;
            
        var volunteer = volunterResult.Value;
        
        //сохранение в БД
        await _volunteersRepository.Add(volunteer, cancellationToken);
        
        return (Guid)volunteer.Id;
    }
}