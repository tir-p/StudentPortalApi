using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPortalApi.DTOs;
using StudentPortalApi.DTOs.Data;
using StudentPortalApi.Interfaces;
using StudentPortalApi.Models;

namespace StudentPortalApi.Repositories
{
    /// <summary>
    /// Repository implementation for Address data access operations.
    /// This layer handles all database interactions using Entity Framework.
    /// Benefits: Separation of data access from business logic, testability, and reusability.
    /// 
    /// Uses async/await for all database operations to:
    /// 1. Prevent thread blocking during I/O operations
    /// 2. Improve scalability by allowing threads to handle other requests
    /// 3. Better resource utilization
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly StudentPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressRepository(StudentPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _dbContext.Addresses
                .Include(a => a.Student)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public async Task<AddressDTO?> GetAddressByIdAsync(int id)
        {
            var address = await _dbContext.Addresses
                .Include(a => a.Student)
                .FirstOrDefaultAsync(a => a.Id == id);

            return address == null ? null : _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO?> GetAddressByStudentIdAsync(int studentId)
        {
            var address = await _dbContext.Addresses
                .Include(a => a.Student)
                .FirstOrDefaultAsync(a => a.StudentId == studentId);

            return address == null ? null : _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO> AddAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO?> UpdateAddressAsync(int id, AddressDTO addressDto)
        {
            var address = await _dbContext.Addresses
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address == null) return null;

            _mapper.Map(addressDto, address);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            if (address == null) return false;

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

