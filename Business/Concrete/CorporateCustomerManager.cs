using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.CorporateCustomer;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract.Person;
using Entities.Persons;

namespace Business.Concrete;

public class CorporateCustomerManager : ICorporateCustomerService
{
    private readonly ICorporateCustomerDal _corporateCustomerDal;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
    private readonly IMapper _mapper;

    public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IMapper mapper)
    {
        _corporateCustomerDal = corporateCustomerDal;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        _mapper = mapper;
    }

    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
    {

        // fluent validation
        ValidationTool.Validate(new AddCorporateCustomerRequestValidator(), request);


        // business rules
        _corporateCustomerBusinessRules.CheckIfCompanyNameExists(request.CompanyName);

        // mapping
        var corporateCustomerToAdd = _mapper.Map<CorporateCustomers>(request);

        // data operations
        CorporateCustomers addedCorporateCustomer = _corporateCustomerDal.Add(corporateCustomerToAdd);

        // mapping & response
        var response = _mapper.Map<AddCorporateCustomerResponse>(addedCorporateCustomer);
        return response;
    }

    public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
    {
        CorporateCustomers? corporateCustomerToDelete = _corporateCustomerDal.Get(predicate: corporateCustomer => corporateCustomer.Id == request.Id); // 0x123123
        _corporateCustomerBusinessRules.CheckIfCompanyExists(corporateCustomerToDelete); // 0x123123

        CorporateCustomers deletedCorporateCustomer = _corporateCustomerDal.Delete(corporateCustomerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteCorporateCustomerResponse>(
            deletedCorporateCustomer // 0x123123
        );
        return response;
    }

    public GetCorporateCustomerByIdResponse GetById(GetCorporateCustomerByIdRequest request)
    {
        CorporateCustomers? model = _corporateCustomerDal.Get(predicate: CorporateCustomer => CorporateCustomer.Id == request.Id);
        _corporateCustomerBusinessRules.CheckIfCompanyExists(model);

        var response = _mapper.Map<GetCorporateCustomerByIdResponse>(model);
        return response;
    }



    public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request)
    {
        CorporateCustomers? corporateCustomerToUpdate = _corporateCustomerDal.Get(predicate: CorporateCustomer => CorporateCustomer.Id == request.Id);
        _corporateCustomerBusinessRules.CheckIfCompanyExists(corporateCustomerToUpdate);



        corporateCustomerToUpdate = _mapper.Map(request, corporateCustomerToUpdate);
        CorporateCustomers updatedCorporateCustomer = _corporateCustomerDal.Update(corporateCustomerToUpdate!);

        var response = _mapper.Map<UpdateCorporateCustomerResponse>(
            updatedCorporateCustomer
        );
        return response;
    }
}
