namespace Service.Implement
{
    public class ThongBaoThanhVienService : BaseService<ThongBaoThanhVien, IThongBaoThanhVienRepository>
    , IThongBaoThanhVienService
    {
    private readonly IThongBaoThanhVienRepository _ThongBaoThanhVienRepository;
    public ThongBaoThanhVienService(IThongBaoThanhVienRepository ThongBaoThanhVienRepository) : base(ThongBaoThanhVienRepository)
    {
    _ThongBaoThanhVienRepository = ThongBaoThanhVienRepository;
    }
    }
    }

