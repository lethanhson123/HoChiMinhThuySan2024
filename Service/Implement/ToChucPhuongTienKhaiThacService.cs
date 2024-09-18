using Service.Interface;

namespace Service.Implement
{
    public class ToChucPhuongTienKhaiThacService : BaseService<ToChucPhuongTienKhaiThac, IToChucPhuongTienKhaiThacRepository>
    , IToChucPhuongTienKhaiThacService
    {
        private readonly IToChucPhuongTienKhaiThacRepository _ToChucPhuongTienKhaiThacRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucHieuMayService _DanhMucHieuMayService;
        private readonly IDanhMucNganhNgheService _DanhMucNganhNgheService;

        public ToChucPhuongTienKhaiThacService(IToChucPhuongTienKhaiThacRepository ToChucPhuongTienKhaiThacRepository

            , IToChucRepository ToChucRepository

            , IDanhMucHieuMayService DanhMucHieuMayService

            , IDanhMucNganhNgheService DanhMucNganhNgheService

            ) : base(ToChucPhuongTienKhaiThacRepository)
        {
            _ToChucPhuongTienKhaiThacRepository = ToChucPhuongTienKhaiThacRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucHieuMayService = DanhMucHieuMayService;
            _DanhMucNganhNgheService = DanhMucNganhNgheService;
        }
        public override void Initialization(ToChucPhuongTienKhaiThac model)
        {
            BaseInitialization(model);
            ToChuc ToChuc = _ToChucRepository.GetByID(model.ParentID.Value);
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = ToChuc.Name;
                }
            }
            if (model.DanhMucQuanHuyenID == null)
            {
                if (model.ParentID > 0)
                {
                    model.DanhMucQuanHuyenID = ToChuc.DanhMucQuanHuyenID;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucQuanHuyenName))
            {
                if (model.ParentID > 0)
                {
                    model.DanhMucQuanHuyenName = ToChuc.DanhMucQuanHuyenName;
                }
            }
            if (model.DanhMucXaPhuongID == null)
            {
                if (model.ParentID > 0)
                {
                    model.DanhMucXaPhuongID = ToChuc.DanhMucXaPhuongID;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucXaPhuongName))
            {
                if (model.ParentID > 0)
                {
                    model.DanhMucXaPhuongName = ToChuc.DanhMucXaPhuongName;
                }
            }
            if (string.IsNullOrEmpty(model.KinhDo))
            {
                if (model.ParentID > 0)
                {
                    model.KinhDo = ToChuc.KinhDo;
                }
            }
            if (string.IsNullOrEmpty(model.ViDo))
            {
                if (model.ParentID > 0)
                {
                    model.ViDo = ToChuc.ViDo;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucHieuMayName))
            {
                if (model.DanhMucHieuMayID > 0)
                {
                    model.DanhMucHieuMayName = _DanhMucHieuMayService.GetByID(model.DanhMucHieuMayID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucHieuMayID == null)
                {
                    DanhMucHieuMay DanhMucHieuMay = _DanhMucHieuMayService.GetByName(model.DanhMucHieuMayName);
                    if (DanhMucHieuMay.ID == 0)
                    {
                        DanhMucHieuMay.Name = model.DanhMucHieuMayName;
                        _DanhMucHieuMayService.Save(DanhMucHieuMay);
                    }
                    model.DanhMucHieuMayID = DanhMucHieuMay.ID;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucNganhNgheName))
            {
                if (model.DanhMucNganhNgheID > 0)
                {
                    model.DanhMucNganhNgheName = _DanhMucNganhNgheService.GetByID(model.DanhMucNganhNgheID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucNganhNgheID == null)
                {
                    DanhMucNganhNghe DanhMucNganhNghe = _DanhMucNganhNgheService.GetByName(model.DanhMucNganhNgheName);
                    if (DanhMucNganhNghe.ID == 0)
                    {
                        DanhMucNganhNghe.Name = model.DanhMucNganhNgheName;
                        _DanhMucNganhNgheService.Save(DanhMucNganhNghe);
                    }
                    model.DanhMucNganhNgheID = DanhMucNganhNghe.ID;
                }
            }
        }
    }
}

