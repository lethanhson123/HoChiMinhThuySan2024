namespace Service.Implement
{
    public class ThanhVienThongBaoService : BaseService<ThanhVienThongBao, IThanhVienThongBaoRepository>
    , IThanhVienThongBaoService
    {
    private readonly IThanhVienThongBaoRepository _ThanhVienThongBaoRepository;
    public ThanhVienThongBaoService(IThanhVienThongBaoRepository ThanhVienThongBaoRepository) : base(ThanhVienThongBaoRepository)
    {
    _ThanhVienThongBaoRepository = ThanhVienThongBaoRepository;
    }
    }
    }

