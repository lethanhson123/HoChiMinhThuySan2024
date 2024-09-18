using Service.Interface;

namespace Service.Implement
{
    public class ToChucTieuChuanService : BaseService<ToChucTieuChuan, IToChucTieuChuanRepository>
    , IToChucTieuChuanService
    {
        private readonly IToChucTieuChuanRepository _ToChucTieuChuanRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucTieuChuanService _DanhMucTieuChuanService;
        public ToChucTieuChuanService(IToChucTieuChuanRepository ToChucTieuChuanRepository

            , IToChucRepository ToChucRepository

            , IDanhMucTieuChuanService DanhMucTieuChuanService

            ) : base(ToChucTieuChuanRepository)
        {
            _ToChucTieuChuanRepository = ToChucTieuChuanRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucTieuChuanService = DanhMucTieuChuanService;
        }
        public override void Initialization(ToChucTieuChuan model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (model.DanhMucTieuChuanID == null)
            {
                model.DanhMucTieuChuanID = 1;
            }
            if (string.IsNullOrEmpty(model.DanhMucTieuChuanName))
            {
                if (model.DanhMucTieuChuanID > 0)
                {
                    model.DanhMucTieuChuanName = _DanhMucTieuChuanService.GetByID(model.DanhMucTieuChuanID.Value).Name;
                }
            }
            else
            {
                DanhMucTieuChuan DanhMucTieuChuan = _DanhMucTieuChuanService.GetByName(model.DanhMucTieuChuanName);
                if (DanhMucTieuChuan.ID == 0)
                {
                    DanhMucTieuChuan = new DanhMucTieuChuan();
                    DanhMucTieuChuan.Name = model.DanhMucTieuChuanName;
                    _DanhMucTieuChuanService.Save(DanhMucTieuChuan);
                }
                model.DanhMucTieuChuanID = DanhMucTieuChuan.ID;
            }
        }
    }
}

