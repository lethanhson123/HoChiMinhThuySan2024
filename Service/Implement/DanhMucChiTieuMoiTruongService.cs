namespace Service.Implement
{
    public class DanhMucChiTieuMoiTruongService : BaseService<DanhMucChiTieuMoiTruong, IDanhMucChiTieuMoiTruongRepository>
    , IDanhMucChiTieuMoiTruongService
    {
        private readonly IDanhMucChiTieuMoiTruongRepository _DanhMucChiTieuMoiTruongRepository;
        public DanhMucChiTieuMoiTruongService(IDanhMucChiTieuMoiTruongRepository DanhMucChiTieuMoiTruongRepository) : base(DanhMucChiTieuMoiTruongRepository)
        {
            _DanhMucChiTieuMoiTruongRepository = DanhMucChiTieuMoiTruongRepository;
        }
    }
}

