namespace Service.Interface
{
    public interface IChiTieuMoiTruongService : IBaseService<ChiTieuMoiTruong>
    {
        Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucToListAsync(DateTime BatDau, DateTime KetThuc);
        Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucAndEmptyToListAsync(DateTime BatDau, DateTime KetThuc);
    }
}

