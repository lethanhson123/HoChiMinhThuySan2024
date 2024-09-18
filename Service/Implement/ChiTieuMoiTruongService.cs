

using Service.Interface;

namespace Service.Implement
{
    public class ChiTieuMoiTruongService : BaseService<ChiTieuMoiTruong, IChiTieuMoiTruongRepository>
    , IChiTieuMoiTruongService
    {
        private readonly IChiTieuMoiTruongRepository _ChiTieuMoiTruongRepository;

        private readonly IToChucRepository _ToChucRepository;

        private readonly IDanhMucChiTieuMoiTruongService _DanhMucChiTieuMoiTruongService;

        public ChiTieuMoiTruongService(IChiTieuMoiTruongRepository ChiTieuMoiTruongRepository

            , IToChucRepository ToChucRepository

            , IDanhMucChiTieuMoiTruongService DanhMucChiTieuMoiTruongService

            ) : base(ChiTieuMoiTruongRepository)
        {
            _ChiTieuMoiTruongRepository = ChiTieuMoiTruongRepository;

            _ToChucRepository = ToChucRepository;

            _DanhMucChiTieuMoiTruongService = DanhMucChiTieuMoiTruongService;
        }
        public override void Initialization(ChiTieuMoiTruong model)
        {
            BaseInitialization(model);
            if (model.NgayGhiNhan == null)
            {
                model.NgayGhiNhan = GlobalHelper.InitializationDateTime;
            }
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
            if (string.IsNullOrEmpty(model.DanhMucChiTieuMoiTruongName))
            {
                if (model.DanhMucChiTieuMoiTruongID > 0)
                {
                    model.DanhMucChiTieuMoiTruongName = _DanhMucChiTieuMoiTruongService.GetByID(model.DanhMucChiTieuMoiTruongID.Value).Name;
                }
            }
            else
            {
                DanhMucChiTieuMoiTruong DanhMucChiTieuMoiTruong = _DanhMucChiTieuMoiTruongService.GetByName(model.DanhMucChiTieuMoiTruongName);
                if (DanhMucChiTieuMoiTruong.ID == 0)
                {
                    DanhMucChiTieuMoiTruong = new DanhMucChiTieuMoiTruong();
                    DanhMucChiTieuMoiTruong.Name = model.DanhMucChiTieuMoiTruongName;
                    _DanhMucChiTieuMoiTruongService.Save(DanhMucChiTieuMoiTruong);
                }
                model.DanhMucChiTieuMoiTruongID = DanhMucChiTieuMoiTruong.ID;
            }
        }

        public virtual async Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucToListAsync(DateTime BatDau, DateTime KetThuc)
        {
            List<ChiTieuMoiTruong> result = new List<ChiTieuMoiTruong>();
            try
            {
                BatDau = new DateTime(BatDau.Year, BatDau.Month, BatDau.Day, 0, 0, 0);
                KetThuc = new DateTime(KetThuc.Year, KetThuc.Month, KetThuc.Day, 23, 59, 59);
                result = await GetByCondition(item => item.NgayGhiNhan >= BatDau && item.NgayGhiNhan <= KetThuc).ToListAsync();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<ChiTieuMoiTruong>> GetByBatDau_KetThucAndEmptyToListAsync(DateTime BatDau, DateTime KetThuc)
        {
            List<ChiTieuMoiTruong> result = new List<ChiTieuMoiTruong>();
            ChiTieuMoiTruong Empty = new ChiTieuMoiTruong();
            result.Add(Empty);
            try
            {
                BatDau = new DateTime(BatDau.Year, BatDau.Month, BatDau.Day, 0, 0, 0);
                KetThuc = new DateTime(KetThuc.Year, KetThuc.Month, KetThuc.Day, 23, 59, 59);
                result.AddRange(await GetByCondition(item => item.NgayGhiNhan >= BatDau && item.NgayGhiNhan <= KetThuc).ToListAsync());
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}

