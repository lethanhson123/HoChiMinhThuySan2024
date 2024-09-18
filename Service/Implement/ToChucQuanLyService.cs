
namespace Service.Implement
{
    public class ToChucQuanLyService : BaseService<ToChucQuanLy, IToChucQuanLyRepository>
    , IToChucQuanLyService
    {
        private readonly IToChucQuanLyRepository _ToChucQuanLyRepository;

        private readonly IToChucRepository _ToChucRepository;
        public ToChucQuanLyService(IToChucQuanLyRepository ToChucQuanLyRepository

             , IToChucRepository ToChucRepository

            ) : base(ToChucQuanLyRepository)
        {
            _ToChucQuanLyRepository = ToChucQuanLyRepository;

            _ToChucRepository = ToChucRepository;
        }

        public override void Initialization(ToChucQuanLy model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (string.IsNullOrEmpty(model.ToChucName))
            {
                if (model.ToChucID > 0)
                {
                    ToChuc ToChuc = _ToChucRepository.GetByID(model.ToChucID.Value);
                    model.ToChucName = ToChuc.Name;
                    model.Code = ToChuc.Code;
                }
            }
        }
    }
}

