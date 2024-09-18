namespace Service.Implement
{
    public class DanhMucNguyenVatLieuService : BaseService<DanhMucNguyenVatLieu, IDanhMucNguyenVatLieuRepository>
    , IDanhMucNguyenVatLieuService
    {
    private readonly IDanhMucNguyenVatLieuRepository _DanhMucNguyenVatLieuRepository;
    public DanhMucNguyenVatLieuService(IDanhMucNguyenVatLieuRepository DanhMucNguyenVatLieuRepository) : base(DanhMucNguyenVatLieuRepository)
    {
    _DanhMucNguyenVatLieuRepository = DanhMucNguyenVatLieuRepository;
    }
    }
    }

