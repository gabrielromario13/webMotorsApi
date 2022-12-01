namespace WebMotors.Application.Services
{
    public interface IService<TRequestModel, TResponseModel>
    {
        Task<TResponseModel> Create(TRequestModel request);
        Task<TResponseModel> GetById(int id);
        Task<IEnumerable<TResponseModel>> GetAll();
        Task<bool> Update(int id, TRequestModel request);
        Task<bool> Delete(int id);
    }
}
