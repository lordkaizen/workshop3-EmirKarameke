using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.IndividualCustomer;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Business.Responses.Model;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Person;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class IndividualCustomerManager : IIndividualCustomerService
{
    private readonly IIndividualCustomerDal _individualCustomerDal;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
    private readonly IMapper _mapper;
    public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal, IndividualCustomerBusinessRules individualCustomerBusinessRules, IMapper mapper)
    {
        _individualCustomerDal = individualCustomerDal;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
        _mapper = mapper;
    }
    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
    {
        ValidationTool.Validate(new AddIndividualCustomerRequestValidator(), request);
        // business rules
        _individualCustomerBusinessRules.CheckIfIndividualCustomerFirstNameExists(request.FirstName);

        // mapping
        var individualCustomerToAdd = _mapper.Map<IndividualCustomers>(request);

        // data operations
        IndividualCustomers addedModel = _individualCustomerDal.Add(individualCustomerToAdd);

        // mapping & response
        var response = _mapper.Map<AddIndividualCustomerResponse>(addedModel);
        return response;
    }

    public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request)
    {
        IndividualCustomers? individualCustomerToDelete = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id); // 0x123123
        _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToDelete); // 0x123123

        IndividualCustomers deletedİndividualCustomer = _individualCustomerDal.Delete(individualCustomerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteIndividualCustomerResponse>(
            deletedİndividualCustomer // 0x123123
        );
        return response;
    }

    public GetIndividualCustomerByIdResponse GetById(GetIndividualCustomerByIdRequest request)
    {
        IndividualCustomers? individualCustomer = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id);
        _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomer);

        var response = _mapper.Map<GetIndividualCustomerByIdResponse>(individualCustomer);
        return response;
    }

    public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request)
    {
        IndividualCustomers? individualCustomerToUpdate = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id); // 0x123123
        _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToUpdate);


        //modelToUpdate = _mapper.Map<Model>(request); // 0x333123
        /* Bunu kullanmayacağız çünkü bizim için yeni bir nesne (referans) oluşturuyor.
        Ve ayrıca entity sınıfında olup da request sınıfında olmayan alanlar (örn. CreatedAt vb.) varsayılan değerler alacak,
        böylece yanlış bir veri güncellemesi yapmış oluruz. */
        individualCustomerToUpdate = _mapper.Map(request, individualCustomerToUpdate); // 0x123123
        IndividualCustomers updatedModel = _individualCustomerDal.Update(individualCustomerToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateIndividualCustomerResponse>(
            updatedModel // 0x123123
        );
        return response;
    }
}
