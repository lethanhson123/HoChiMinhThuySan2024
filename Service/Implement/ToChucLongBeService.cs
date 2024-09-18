namespace Service.Implement
{
    public class ToChucLongBeService : BaseService<ToChucLongBe, IToChucLongBeRepository>
    , IToChucLongBeService
    {
    private readonly IToChucLongBeRepository _ToChucLongBeRepository;
    public ToChucLongBeService(IToChucLongBeRepository ToChucLongBeRepository) : base(ToChucLongBeRepository)
    {
    _ToChucLongBeRepository = ToChucLongBeRepository;
    }
    }
    }

