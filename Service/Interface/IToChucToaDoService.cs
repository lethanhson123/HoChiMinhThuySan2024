namespace Service.Interface
{
    public interface IToChucToaDoService : IBaseService<ToChucToaDo>
    {
        Task<List<ToChucToaDo>> GetByToChucVungNuoiIDToListAsync(long ToChucVungNuoiID);
        Task<List<ToChucToaDo>> GetByToChucVungNuoiIDAndEmptyToListAsync(long ToChucVungNuoiID);
    }
}

