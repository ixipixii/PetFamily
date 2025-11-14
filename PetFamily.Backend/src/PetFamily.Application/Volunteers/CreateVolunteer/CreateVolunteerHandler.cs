using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.VO;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.FullName))
            return Errors.General.ValueIsInvalid(nameof(request.FullName));

        var phoneResult = Phone.Create(request.Phone);
        if (phoneResult.IsFailure)
            return phoneResult.Error;

        var searchByPhone = await _volunteersRepository.GetByPhone(phoneResult.Value);
        if (searchByPhone.IsSuccess)
            return Errors.Volunteer.AlreadyExist();

        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        var sociaNetworks = request.SocialNetworksDto
            .Select(s => SocialNetwork.Create(s.Link, s.Title))
            .ToList();

        foreach (var socialNetwork in sociaNetworks)
        {
            if (socialNetwork.IsFailure)
                return socialNetwork.Error;
        }

        var requisites = request.RequisitesDto
            .Select(r => Requisite.Create(r.Title, r.Description))
            .ToList();

        foreach (var requisite in requisites)
        {
            if (requisite.IsFailure)
                return requisite.Error;
        }

        //создание доменной модели
        var volunteer = new Volunteer(VolunteerId.NewVolunteerId(),
            request.FullName,
            emailResult.Value,
            phoneResult.Value,
            sociaNetworks.Select(s => s.Value).ToList(),
            requisites.Select(r => r.Value).ToList()
        );

        //сохранение в БД
        await _volunteersRepository.Add(volunteer, cancellationToken);

        return (Guid)volunteer.Id;
    }
}