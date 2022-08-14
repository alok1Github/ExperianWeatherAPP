using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Interface
{
    public interface IGet<Request, Response>
        where Request : IRequest
        where Response : IModel
    {
        Task<Response?> Handler(Request request);
    }
}
