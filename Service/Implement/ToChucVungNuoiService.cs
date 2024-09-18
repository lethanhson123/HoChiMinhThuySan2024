using Service.Interface;

namespace Service.Implement
{
    public class ToChucVungNuoiService : BaseService<ToChucVungNuoi, IToChucVungNuoiRepository>
    , IToChucVungNuoiService
    {
        private readonly IToChucVungNuoiRepository _ToChucVungNuoiRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucGiongService _DanhMucGiongService;
        private readonly IDanhMucLoaiGiongService _DanhMucLoaiGiongService;
        public ToChucVungNuoiService(IToChucVungNuoiRepository ToChucVungNuoiRepository

            , IToChucRepository ToChucRepository

            , IDanhMucGiongService DanhMucGiongService
            , IDanhMucLoaiGiongService DanhMucLoaiGiongService

            ) : base(ToChucVungNuoiRepository)
        {
            _ToChucVungNuoiRepository = ToChucVungNuoiRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucGiongService = DanhMucGiongService;
            _DanhMucLoaiGiongService = DanhMucLoaiGiongService;
        }
        public override void Initialization(ToChucVungNuoi model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                if (model.ToChucID == null)
                {
                    ToChuc ToChuc = _ToChucRepository.GetByCode(model.Code);
                    model.ToChucID = ToChuc.ID;
                    model.ToChucName = ToChuc.Name;
                    model.Code = ToChuc.Code;
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

