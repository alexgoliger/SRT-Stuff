using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.ServiceCommands
{
  public abstract class ServiceCommand<TRequest, TResponse>
    where TRequest : IRequest
    where TResponse : IResponse, new()
  {
    protected abstract void Validate(TRequest request);
    protected abstract bool OnExecute(TResponse response);

    public TResponse Execute(TRequest request)
    {
      var response = new TResponse();
      response.Status = new Status
      {
        IsSuccessful = false,
        ErrorMessage = null
      };
      try
      {
        // TODO: log beginning of validation
        Validate(request);
        // TODO: log successful ending of validation
        // TODO: log beginning of execution
        if (!OnExecute(response))
        {
          // TODO: log failing execution
          response.Status.IsSuccessful = false;
        }
        else
        {
          // TODO: log successful ending of execution
          response.Status.IsSuccessful = true;
        }
        return response;
      }
      catch (Exception e)
      {
        // TODO: log exception here
        response.Status.IsSuccessful = false;
        response.Status.ErrorMessage = e.Message;
        return response;
      }
    }
  }
}
