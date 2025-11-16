using StudentPortalApi.DTOs;

namespace StudentPortalApi.Interfaces
{
    /// <summary>
    /// Repository interface for Address data access operations.
    /// Defines the contract for all address-related database operations.
    /// </summary>
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO?> GetAddressByIdAsync(int id);
        Task<AddressDTO?> GetAddressByStudentIdAsync(int studentId);
        Task<AddressDTO> AddAddressAsync(AddressDTO addressDto);
        Task<AddressDTO?> UpdateAddressAsync(int id, AddressDTO addressDto);
        Task<bool> DeleteAddressAsync(int id);
    }
}

