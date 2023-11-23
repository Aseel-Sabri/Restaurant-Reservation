using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IRestaurantRepository restaurantRepository,
        IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateEmployee(ModifyEmployeeDto employeeDto)
    {
        if (!await _restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
            throw new NotFoundException($"No Restaurant with ID {employeeDto.RestaurantId} Exists");

        var employee = _mapper.Map<Employee>(employeeDto);

        var employeeId = await _employeeRepository.CreateEmployee(employee);
        return employeeId;
    }

    public async Task<EmployeeDto> UpdateEmployee(int employeeId, ModifyEmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.FindEmployeeById(employeeId);
        if (employee is null)
            throw new NotFoundException($"No Employee with ID {employeeId} Exists");


        if (!await _restaurantRepository.HasRestaurantById((int)employeeDto.RestaurantId!))
            throw new NotFoundException($"No Restaurant with ID {employeeDto.RestaurantId} Exists");

        _mapper.Map(employeeDto, employee);

        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
        return _mapper.Map<EmployeeDto>(updatedEmployee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        if (!await _employeeRepository.HasEmployeeById(employeeId))
            throw new NotFoundException($"No Employee With ID {employeeId} Exists");

        try
        {
            if (!await _employeeRepository.DeleteEmployee(employeeId))
                throw new ApiException($"Could Not Delete Employee With ID {employeeId}");
        }
        catch (Exception e)
        {
            throw new ApiException($"Could Not Delete Employee With ID {employeeId}, It May Have Related Data", e);
        }
    }

    public async Task<List<EmployeeDto>> GetManagers()
    {
        var managers = await _employeeRepository.GetManagers();
        return _mapper.Map<List<EmployeeDto>>(managers);
    }

    public async Task<List<EmployeeDetails>> GetEmployeesDetails()
    {
        return await _employeeRepository.GetEmployeesDetails();
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        if (!await _employeeRepository.HasEmployeeById(employeeId))
            throw new NotFoundException($"No Employee With ID {employeeId} Exists");

        return await _employeeRepository.CalculateAverageOrderAmount(employeeId);
    }

    public async Task<EmployeeDto> FindEmployeeById(int employeeId)
    {
        var employee = await _employeeRepository.FindEmployeeById(employeeId);

        if (employee is null)
            throw new NotFoundException($"No Employee With ID {employeeId} Exists");

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _employeeRepository.GetAllEmployees();
    }
}