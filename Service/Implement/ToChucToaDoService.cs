using Service.Interface;

namespace Service.Implement
{
    public class ToChucToaDoService : BaseService<ToChucToaDo, IToChucToaDoRepository>
    , IToChucToaDoService
    {
        private readonly IToChucToaDoRepository _ToChucToaDoRepository;

        private readonly IToChucVungNuoiRepository _ToChucVungNuoiRepository;

        private readonly IToChucRepository _ToChucRepository;

        public ToChucToaDoService(IToChucToaDoRepository ToChucToaDoRepository

            , IToChucVungNuoiRepository ToChucVungNuoiRepository
            , IToChucRepository ToChucRepository

            ) : base(ToChucToaDoRepository)
        {
            _ToChucToaDoRepository = ToChucToaDoRepository;

            _ToChucVungNuoiRepository = ToChucVungNuoiRepository;
            _ToChucRepository = ToChucRepository;
        }
        public override void Initialization(ToChucToaDo model)
        {
            BaseInitialization(model);
            ToChucVungNuoi ToChucVungNuoi = _ToChucVungNuoiRepository.GetByID(model.ToChucVungNuoiID.Value);
            if (model.ParentID == null)
            {
                model.ParentID = ToChucVungNuoi.ParentID;
            }
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucVungNuoiRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (string.IsNullOrEmpty(model.ToChucVungNuoiName))
            {
                if (model.ToChucVungNuoiID > 0)
                {
                    model.ToChucVungNuoiName = ToChucVungNuoi.Name;
                }
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                if (model.ToChucVungNuoiID > 0)
                {
                    model.Code = ToChucVungNuoi.Code;
                }
            }
        }
        public virtual async Task<List<ToChucToaDo>> GetByToChucVungNuoiIDToListAsync(long ToChucVungNuoiID)
        {
            List<ToChucToaDo> result = new List<ToChucToaDo>();
            if (ToChucVungNuoiID > 0)
            {
                result = await GetByCondition(item => item.ToChucVungNuoiID == ToChucVungNuoiID).ToListAsync();
            }
            if (result == null)
            {
                result = new List<ToChucToaDo>();
            }
            return result;
        }
        public virtual async Task<List<ToChucToaDo>> GetByToChucVungNuoiIDAndEmptyToListAsync(long ToChucVungNuoiID)
        {
            List<ToChucToaDo> result = new List<ToChucToaDo>();
            ToChucToaDo empty = new ToChucToaDo();
            result.Add(empty);
            if (ToChucVungNuoiID > 0)
            {
                result.AddRange(await GetByCondition(item => item.ToChucVungNuoiID == ToChucVungNuoiID).ToListAsync());
            }
            if (result == null)
            {
                result = new List<ToChucToaDo>();
            }
            return result;
        }
    }
}

