using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateCustomer(ModifyCustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        var customerId = await _customerRepository.CreateCustomer(customer);
        return customerId;
    }

    public async Task<CustomerDto> UpdateCustomer(int customerId, ModifyCustomerDto customerDto)
    {
        var customer = await _customerRepository.FindCustomerById(customerId);
        if (customer is null)
            throw new NotFoundException($"No Customer with ID {customerId} Exists");

        _mapper.Map(customerDto, customer);

        var updatedCustomer = await _customerRepository.UpdateCustomer(customer);
        return _mapper.Map<CustomerDto>(updatedCustomer);
    }

    public async Task DeleteCustomer(int customerId)
    {
        if (!await _customerRepository.HasCustomerById(customerId))
            throw new NotFoundException($"No Customer With ID {customerId} Exists");

        try
        {
            if (!await _customerRepository.DeleteCustomer(customerId))
                throw new DeleteException($"Could Not Delete Customer With ID {customerId}");
        }
        catch (Exception e)
        {
            throw new DeleteException(
                $"Could Not Delete Customer With ID {customerId}, It May Have Related Data", e);
        }
    }

    public async Task<IEnumerable<CustomerDto>> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customers = await _customerRepository.FindCustomersWithPartySizeGreaterThan(partySize);
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllCustomers();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> FindCustomerById(int customerId)
    {
        var customer = await _customerRepository.FindCustomerById(customerId);
        if (customer is null)
            throw new NotFoundException($"No Customer with ID {customerId} Exists");

        return _mapper.Map<CustomerDto>(customer);
    }
}