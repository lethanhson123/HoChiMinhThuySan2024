namespace Service.Implement
{
    public class ToChucNuoiNhuyenTheService : BaseService<ToChucNuoiNhuyenThe, IToChucNuoiNhuyenTheRepository>
    , IToChucNuoiNhuyenTheService
    {
    private readonly IToChucNuoiNhuyenTheRepository _ToChucNuoiNhuyenTheRepository;
    public ToChucNuoiNhuyenTheService(IToChucNuoiNhuyenTheRepository ToChucNuoiNhuyenTheRepository) : base(ToChucNuoiNhuyenTheRepository)
    {
    _ToChucNuoiNhuyenTheRepository = ToChucNuoiNhuyenTheRepository;
    }
    }
    }

