using Service.Interface;

namespace Service.Implement
{
    public class ToChucNguyenVatLieuService : BaseService<ToChucNguyenVatLieu, IToChucNguyenVatLieuRepository>
    , IToChucNguyenVatLieuService
    {
        private readonly IToChucNguyenVatLieuRepository _ToChucNguyenVatLieuRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucNguyenVatLieuService _DanhMucNguyenVatLieuService;
        public ToChucNguyenVatLieuService(IToChucNguyenVatLieuRepository ToChucNguyenVatLieuRepository

             , IToChucRepository ToChucRepository

             , IDanhMucNguyenVatLieuService DanhMucNguyenVatLieuService

            ) : base(ToChucNguyenVatLieuRepository)
        {
            _ToChucNguyenVatLieuRepository = ToChucNguyenVatLieuRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucNguyenVatLieuService = DanhMucNguyenVatLieuService;
        }
        public override void Initialization(ToChucNguyenVatLieu model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _ToChucRepository.GetByID(model.ParentID.Value).Name;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucNguyenVatLieuName))
            {
                if (model.DanhMucNguyenVatLieuID > 0)
                {
                    model.DanhMucNguyenVatLieuName = _DanhMucNguyenVatLieuService.GetByID(model.DanhMucNguyenVatLieuID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucNguyenVatLieuID == null)
                {
                    DanhMucNguyenVatLieu DanhMucNguyenVatLieu = _DanhMucNguyenVatLieuService.GetByName(model.DanhMucNguyenVatLieuName);
                    if (DanhMucNguyenVatLieu.ID == 0)
                    {
                        DanhMucNguyenVatLieu = new DanhMucNguyenVatLieu();
                        DanhMucNguyenVatLieu.Name = model.DanhMucNguyenVatLieuName;
                        _DanhMucNguyenVatLieuService.Save(DanhMucNguyenVatLieu);
                    }
                    model.DanhMucNguyenVatLieuID = DanhMucNguyenVatLieu.ID;
                }
            }
        }
    }
}

