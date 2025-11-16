using StudentPortalApi.DTOs;
using StudentPortalApi.Interfaces;

namespace StudentPortalApi.Services
{
    /// <summary>
    /// Service implementation for Address business logic.
    /// This layer handles business rules, validation, and orchestrates repository calls.
    /// Benefits: Separation of concerns, testability, and centralized business logic.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            return await _addressRepository.GetAllAddressesAsync();
        }

        public async Task<AddressDTO?> GetAddressByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _addressRepository.GetAddressByIdAsync(id);
        }

        public async Task<AddressDTO?> GetAddressByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
                return null;

            return await _addressRepository.GetAddressByStudentIdAsync(studentId);
        }

        public async Task<AddressDTO> CreateAddressAsync(AddressDTO addressDto)
        {
            // Business logic validation can be added here
            // For example: Check if student exists, validate address format, etc.
            
            return await _addressRepository.AddAddressAsync(addressDto);
        }

        public async Task<AddressDTO?> UpdateAddressAsync(int id, AddressDTO addressDto)
        {
            if (id <= 0)
                return null;

            // Business logic validation can be added here
            return await _addressRepository.UpdateAddressAsync(id, addressDto);
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _addressRepository.DeleteAddressAsync(id);
        }
    }
}

