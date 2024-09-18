namespace Service.Implement
{
    public class ToChucGiongService : BaseService<ToChucGiong, IToChucGiongRepository>
    , IToChucGiongService
    {
        private readonly IToChucGiongRepository _ToChucGiongRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucGiongService _DanhMucGiongService;
        private readonly IDanhMucLoaiGiongService _DanhMucLoaiGiongService;
        public ToChucGiongService(IToChucGiongRepository ToChucGiongRepository

            , IToChucRepository ToChucRepository

            , IDanhMucGiongService DanhMucGiongService
            , IDanhMucLoaiGiongService DanhMucLoaiGiongService

            ) : base(ToChucGiongRepository)
        {
            _ToChucGiongRepository = ToChucGiongRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucGiongService = DanhMucGiongService;
            _DanhMucLoaiGiongService = DanhMucLoaiGiongService;
        }
        public override void Initialization(ToChucGiong model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucGiongName))
            {
                if (model.DanhMucGiongID > 0)
                {
                    model.DanhMucGiongName = _DanhMucGiongService.GetByID(model.DanhMucGiongID.Value).Name;
                }
            }
            else
            {
                DanhMucGiong DanhMucGiong = _DanhMucGiongService.GetByName(model.DanhMucGiongName);
                if (DanhMucGiong.ID == 0)
                {
                    DanhMucGiong = new DanhMucGiong();
                    DanhMucGiong.Name = model.DanhMucGiongName;
                    _DanhMucGiongService.Save(DanhMucGiong);
                }
                model.DanhMucGiongID = DanhMucGiong.ID;
            }
            if (string.IsNullOrEmpty(model.DanhMucLoaiGiongName))
            {
                if (model.DanhMucLoaiGiongID > 0)
                {
                    model.DanhMucLoaiGiongName = _DanhMucLoaiGiongService.GetByID(model.DanhMucLoaiGiongID.Value).Name;
                }
            }
            else
            {
                DanhMucLoaiGiong DanhMucLoaiGiong = _DanhMucLoaiGiongService.GetByName(model.DanhMucLoaiGiongName);
                if (DanhMucLoaiGiong.ID == 0)
                {
                    DanhMucLoaiGiong = new DanhMucLoaiGiong();
                    DanhMucLoaiGiong.Name = model.DanhMucLoaiGiongName;
                    _DanhMucLoaiGiongService.Save(DanhMucLoaiGiong);
                }
                model.DanhMucLoaiGiongID = DanhMucLoaiGiong.ID;
            }
        }
    }
}

