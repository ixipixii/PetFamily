using PetFamily.Application.Volunteers.DTO;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(string FullName, 
                                     string Email, 
                                     string Phone,
                                     IEnumerable<RequisitesDTO> RequisitesDto,
                                     IEnumerable<SocialNetworksDTO> SocialNetworksDto);