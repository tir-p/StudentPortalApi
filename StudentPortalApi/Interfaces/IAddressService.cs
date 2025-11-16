using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Service interface for Address business logic operations.
    /// This layer abstracts business logic from data access, following the Service-Repository pattern.
    /// </summary>
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO?> GetAddressByIdAsync(int id);
        Task<AddressDTO?> GetAddressByStudentIdAsync(int studentId);
        Task<AddressDTO> CreateAddressAsync(AddressDTO addressDto);
        Task<AddressDTO?> UpdateAddressAsync(int id, AddressDTO addressDto);
        Task<bool> DeleteAddressAsync(int id);
    }
}

