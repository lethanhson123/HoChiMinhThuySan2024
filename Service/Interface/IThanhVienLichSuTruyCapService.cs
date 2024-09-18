namespace Service.Interface
{
    public interface IThanhVienLichSuTruyCapService : IBaseService<ThanhVienLichSuTruyCap>
    {
        Task<List<ThanhVienLichSuTruyCap>> GetByBatDau_KetThucToListAsync(DateTime batDau, DateTime ketThuc);
        Task<List<ThanhVienLichSuTruyCap>> GetBySearchString_BatDau_KetThucToListAsync(string searchString, DateTime batDau, DateTime ketThuc);
    }
}

