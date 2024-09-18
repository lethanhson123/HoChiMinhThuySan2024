using Data.Model;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using System;

namespace Service.Implement
{
    public class ToChucService : BaseService<ToChuc, IToChucRepository>
    , IToChucService
    {
        private readonly IToChucRepository _ToChucRepository;

        private readonly IToChucGiongService _ToChucGiongService;
        private readonly IToChucToaDoService _ToChucToaDoService;
        private readonly IToChucNguyenVatLieuService _ToChucNguyenVatLieuService;

        private readonly IDanhMucToChucService _DanhMucToChucService;
        private readonly IDanhMucTinhThanhService _DanhMucTinhThanhService;
        private readonly IDanhMucQuanHuyenService _DanhMucQuanHuyenService;
        private readonly IDanhMucXaPhuongService _DanhMucXaPhuongService;
        private readonly IDanhMucGiongService _DanhMucGiongService;
        private readonly IDanhMucLoaiGiongService _DanhMucLoaiGiongService;
        private readonly IDanhMucLoaiHinhService _DanhMucLoaiHinhService;
        private readonly IDanhMucCuaHangService _DanhMucCuaHangService;
        private readonly IDanhMucNguyenVatLieuService _DanhMucNguyenVatLieuService;
        public ToChucService(IToChucRepository ToChucRepository

            , IToChucGiongService ToChucGiongService
            , IToChucToaDoService ToChucToaDoService
            , IToChucNguyenVatLieuService ToChucNguyenVatLieuService

            , IDanhMucToChucService DanhMucToChucService
            , IDanhMucTinhThanhService DanhMucTinhThanhService
            , IDanhMucQuanHuyenService DanhMucQuanHuyenService
            , IDanhMucXaPhuongService DanhMucXaPhuongService
            , IDanhMucGiongService DanhMucGiongService
            , IDanhMucLoaiGiongService DanhMucLoaiGiongService
            , IDanhMucLoaiHinhService DanhMucLoaiHinhService
            , IDanhMucCuaHangService DanhMucCuaHangService
            , IDanhMucNguyenVatLieuService DanhMucNguyenVatLieuService

            ) : base(ToChucRepository)
        {
            _ToChucRepository = ToChucRepository;

            _ToChucGiongService = ToChucGiongService;
            _ToChucToaDoService = ToChucToaDoService;
            _ToChucNguyenVatLieuService = ToChucNguyenVatLieuService;

            _DanhMucToChucService = DanhMucToChucService;
            _DanhMucTinhThanhService = DanhMucTinhThanhService;
            _DanhMucQuanHuyenService = DanhMucQuanHuyenService;
            _DanhMucXaPhuongService = DanhMucXaPhuongService;
            _DanhMucGiongService = DanhMucGiongService;
            _DanhMucLoaiGiongService = DanhMucLoaiGiongService;
            _DanhMucLoaiHinhService = DanhMucLoaiHinhService;
            _DanhMucCuaHangService = DanhMucCuaHangService;
            _DanhMucNguyenVatLieuService = DanhMucNguyenVatLieuService;
        }
        public override void Initialization(ToChuc model)
        {
            BaseInitialization(model);
            if (!string.IsNullOrEmpty(model.DienThoai))
            {
                model.DienThoai = model.DienThoai.Replace(@"'", @"");
            }
            if (!string.IsNullOrEmpty(model.CCCD))
            {
                model.CCCD = model.CCCD.Replace(@"'", @"");
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = model.DienThoai;
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = model.CCCD;
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = GlobalHelper.InitializationGUICode;
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = GlobalHelper.InitializationGUICode;
            }
            if (model.ParentID == null)
            {
                model.ParentID = GlobalHelper.DanhMucToChucID;
            }
            if (string.IsNullOrEmpty(model.ParentName))
            {
                if (model.ParentID > 0)
                {
                    model.ParentName = _DanhMucToChucService.GetByID(model.ParentID.Value).Name;
                }
            }
            if (model.DanhMucTinhThanhID == null)
            {
                model.DanhMucTinhThanhID = GlobalHelper.DanhMucTinhThanhID;
            }
            if (string.IsNullOrEmpty(model.DanhMucTinhThanhName))
            {
                if (model.DanhMucTinhThanhID > 0)
                {
                    model.DanhMucTinhThanhName = _DanhMucTinhThanhService.GetByID(model.DanhMucTinhThanhID.Value).Name;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucQuanHuyenName))
            {
                if (model.DanhMucQuanHuyenID > 0)
                {
                    model.DanhMucQuanHuyenName = _DanhMucQuanHuyenService.GetByID(model.DanhMucQuanHuyenID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucQuanHuyenID == null)
                {
                    if (model.DanhMucTinhThanhID > 0)
                    {
                        List<DanhMucQuanHuyen> ListDanhMucQuanHuyen = _DanhMucQuanHuyenService.GetByParentIDToList(model.DanhMucTinhThanhID.Value);
                        DanhMucQuanHuyen DanhMucQuanHuyen = ListDanhMucQuanHuyen.Where(item => model.DanhMucQuanHuyenName.Contains(item.Name)).FirstOrDefault();
                        if (DanhMucQuanHuyen == null)
                        {
                            DanhMucQuanHuyen = new DanhMucQuanHuyen();
                            DanhMucQuanHuyen.ParentID = model.DanhMucTinhThanhID;
                            DanhMucQuanHuyen.Name = model.DanhMucQuanHuyenName;
                            _DanhMucQuanHuyenService.Add(DanhMucQuanHuyen);
                        }
                        model.DanhMucQuanHuyenID = DanhMucQuanHuyen.ID;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucXaPhuongName))
            {
                if (model.DanhMucXaPhuongID > 0)
                {
                    model.DanhMucXaPhuongName = _DanhMucXaPhuongService.GetByID(model.DanhMucXaPhuongID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucXaPhuongID == null)
                {
                    if (model.DanhMucQuanHuyenID > 0)
                    {
                        List<DanhMucXaPhuong> ListDanhMucXaPhuong = _DanhMucXaPhuongService.GetByParentIDToList(model.DanhMucQuanHuyenID.Value);
                        DanhMucXaPhuong DanhMucXaPhuong = ListDanhMucXaPhuong.Where(item => model.DanhMucXaPhuongName.Contains(item.Name)).FirstOrDefault();
                        if (DanhMucXaPhuong == null)
                        {
                            DanhMucXaPhuong = new DanhMucXaPhuong();
                            DanhMucXaPhuong.ParentID = model.DanhMucQuanHuyenID;
                            DanhMucXaPhuong.Name = model.DanhMucXaPhuongName;
                            _DanhMucXaPhuongService.Add(DanhMucXaPhuong);
                        }
                        model.DanhMucXaPhuongID = DanhMucXaPhuong.ID;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucLoaiHinhName))
            {
                if (model.DanhMucLoaiHinhID > 0)
                {
                    model.DanhMucLoaiHinhName = _DanhMucLoaiHinhService.GetByID(model.DanhMucLoaiHinhID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucLoaiHinhID == null)
                {
                    DanhMucLoaiHinh DanhMucLoaiHinh = _DanhMucLoaiHinhService.GetByName(model.DanhMucLoaiHinhName);
                    if (DanhMucLoaiHinh.ID == 0)
                    {
                        DanhMucLoaiHinh = new DanhMucLoaiHinh();
                        DanhMucLoaiHinh.Name = model.DanhMucLoaiHinhName;
                        _DanhMucLoaiHinhService.Save(DanhMucLoaiHinh);
                    }
                    model.DanhMucLoaiHinhID = DanhMucLoaiHinh.ID;
                }
            }
            if (string.IsNullOrEmpty(model.DanhMucCuaHangName))
            {
                if (model.DanhMucCuaHangID > 0)
                {
                    model.DanhMucCuaHangName = _DanhMucCuaHangService.GetByID(model.DanhMucCuaHangID.Value).Name;
                }
            }
            else
            {
                if (model.DanhMucCuaHangID == null)
                {
                    DanhMucCuaHang DanhMucCuaHang = _DanhMucCuaHangService.GetByName(model.DanhMucCuaHangName);
                    if (DanhMucCuaHang.ID == 0)
                    {
                        DanhMucCuaHang = new DanhMucCuaHang();
                        DanhMucCuaHang.Name = model.DanhMucCuaHangName;
                        _DanhMucCuaHangService.Save(DanhMucCuaHang);
                    }
                    model.DanhMucCuaHangID = DanhMucCuaHang.ID;
                }
            }
            if (!string.IsNullOrEmpty(model.DanhMucGiongName))
            {
                model.DanhMucGiongName = model.DanhMucGiongName.Trim();
            }
            if (!string.IsNullOrEmpty(model.DanhMucLoaiGiongName))
            {
                model.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName.Trim();
            }
        }
        public override ToChuc Save(ToChuc model)
        {
            int result = GlobalHelper.InitializationNumber;
            bool isSave = true;
            switch (model.ParentID)
            {
                case 1:
                    if (string.IsNullOrEmpty(model.Code))
                    {
                        isSave = false;
                    }
                    break;
                default:
                    if (string.IsNullOrEmpty(model.Name))
                    {
                        isSave = false;
                    }
                    break;
            }
            if (isSave == true)
            {
                if (model.ID > 0)
                {
                    result = Update(model);
                }
                else
                {
                    result = Add(model);
                }
            }
            if (result > 0)
            {
                Sync(model);
            }
            return model;
        }
        public override async Task<ToChuc> SaveAsync(ToChuc model)
        {
            int result = GlobalHelper.InitializationNumber;
            bool isSave = true;
            switch (model.ParentID)
            {
                case 1:
                    if (string.IsNullOrEmpty(model.Code))
                    {
                        isSave = false;
                    }
                    break;
                default:
                    if (string.IsNullOrEmpty(model.Name))
                    {
                        isSave = false;
                    }
                    break;
            }
            if (isSave == true)
            {
                if (model.ID > 0)
                {
                    result = await UpdateAsync(model);
                }
                else
                {
                    result = await AddAsync(model);
                }
            }
            if (result > 0)
            {
                await SyncAsync(model);
            }
            return model;
        }
        private async Task<int> SyncAsync(ToChuc model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (model != null)
            {
                if (model.ID > 0)
                {
                    if (!string.IsNullOrEmpty(model.DanhMucNguyenVatLieuName))
                    {
                        foreach (string Name in model.DanhMucNguyenVatLieuName.Split(','))
                        {
                            string DanhMucNguyenVatLieuName = Name.Trim();
                            if (!string.IsNullOrEmpty(DanhMucNguyenVatLieuName))
                            {
                                DanhMucNguyenVatLieu DanhMucNguyenVatLieu = await _DanhMucNguyenVatLieuService.GetByNameAsync(DanhMucNguyenVatLieuName);
                                if (DanhMucNguyenVatLieu.ID == 0)
                                {
                                    DanhMucNguyenVatLieu.Name = model.DanhMucNguyenVatLieuName;
                                    await _DanhMucNguyenVatLieuService.SaveAsync(DanhMucNguyenVatLieu);
                                }
                                ToChucNguyenVatLieu ToChucNguyenVatLieu = await _ToChucNguyenVatLieuService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucNguyenVatLieuID == DanhMucNguyenVatLieu.ID).FirstOrDefaultAsync();
                                if (ToChucNguyenVatLieu == null)
                                {
                                    ToChucNguyenVatLieu = new ToChucNguyenVatLieu();
                                    ToChucNguyenVatLieu.ParentID = model.ID;
                                    ToChucNguyenVatLieu.ParentName = model.Name;
                                    ToChucNguyenVatLieu.DanhMucNguyenVatLieuID = DanhMucNguyenVatLieu.ID;
                                    ToChucNguyenVatLieu.DanhMucNguyenVatLieuName = DanhMucNguyenVatLieu.Name;
                                    await _ToChucNguyenVatLieuService.SaveAsync(ToChucNguyenVatLieu);
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(model.DanhMucGiongName))
                    {
                        if (model.DanhMucGiongName.Split('(').Length > 1)
                        {
                            model.DanhMucGiongName = model.DanhMucGiongName.Split('(')[1];
                            model.DanhMucGiongName = model.DanhMucGiongName.Replace(@")", @"");
                            model.DanhMucGiongName = model.DanhMucGiongName.Trim();
                        }
                        foreach (string Name in model.DanhMucGiongName.Split(','))
                        {
                            if (!string.IsNullOrEmpty(Name))
                            {
                                DanhMucLoaiGiong DanhMucLoaiGiong = new DanhMucLoaiGiong();
                                if (!string.IsNullOrEmpty(model.DanhMucLoaiGiongName))
                                {
                                    DanhMucLoaiGiong = await _DanhMucLoaiGiongService.GetByNameAsync(model.DanhMucLoaiGiongName);
                                    if (DanhMucLoaiGiong.ID == 0)
                                    {
                                        DanhMucLoaiGiong.Name = model.DanhMucLoaiGiongName;
                                        await _DanhMucLoaiGiongService.SaveAsync(DanhMucLoaiGiong);
                                    }
                                }
                                string DanhMucGiongName = Name.Trim();
                                DanhMucGiong DanhMucGiong = await _DanhMucGiongService.GetByNameAsync(DanhMucGiongName);
                                if (DanhMucGiong.ID == 0)
                                {
                                    DanhMucGiong.Name = DanhMucGiongName;
                                    await _DanhMucGiongService.SaveAsync(DanhMucGiong);
                                }
                                ToChucGiong ToChucGiong = await _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID && item.DanhMucLoaiGiongID == DanhMucLoaiGiong.ID).FirstOrDefaultAsync();
                                if (ToChucGiong == null)
                                {
                                    ToChucGiong = new ToChucGiong();
                                    ToChucGiong.ParentID = model.ID;
                                    ToChucGiong.ParentName = model.Name;
                                    ToChucGiong.DanhMucLoaiGiongID = DanhMucLoaiGiong.ID;
                                    ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                    ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                    ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                    await _ToChucGiongService.SaveAsync(ToChucGiong);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (model.ParentID == 14)
                        {
                            DanhMucGiong DanhMucGiong = await _DanhMucGiongService.GetByIDAsync(1091);
                            ToChucGiong ToChucGiong = await _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefaultAsync();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;                                
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                await _ToChucGiongService.SaveAsync(ToChucGiong);
                            }

                            DanhMucGiong = await _DanhMucGiongService.GetByIDAsync(1169);
                            ToChucGiong = await _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefaultAsync();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                await _ToChucGiongService.SaveAsync(ToChucGiong);
                            }

                            DanhMucGiong = await _DanhMucGiongService.GetByIDAsync(1170);
                            ToChucGiong = await _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefaultAsync();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                await _ToChucGiongService.SaveAsync(ToChucGiong);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(model.HTMLContent))
                    {
                        try
                        {
                            byte[] byteArray = GlobalHelper.StringToByteArray(model.HTMLContent);
                            WKBReader reader = new WKBReader();
                            Geometry geometry = reader.Read(byteArray);
                            Point point = geometry.Centroid;
                            foreach (Coordinate Coordinate in geometry.Coordinates)
                            {
                                ToChucToaDo ToChucToaDo = new ToChucToaDo();
                                ToChucToaDo.ParentID = model.ID;
                                ToChucToaDo.ParentName = model.Name;
                                ToChucToaDo.Code = model.Code;
                                ToChucToaDo.KinhDo = Coordinate.X.ToString();
                                ToChucToaDo.ViDo = Coordinate.Y.ToString();
                                ToChucToaDo = await _ToChucToaDoService.GetByCondition(item => item.ParentID == ToChucToaDo.ParentID && item.KinhDo == ToChucToaDo.KinhDo && item.ViDo == ToChucToaDo.ViDo).FirstOrDefaultAsync();
                                if (ToChucToaDo == null)
                                {
                                    ToChucToaDo = new ToChucToaDo();
                                    ToChucToaDo.ParentID = model.ID;
                                    ToChucToaDo.ParentName = model.Name;
                                    ToChucToaDo.Code = model.Code;
                                    ToChucToaDo.KinhDo = Coordinate.X.ToString();
                                    ToChucToaDo.ViDo = Coordinate.Y.ToString();
                                    if (Coordinate.X == point.X)
                                    {
                                        if (Coordinate.Y == point.Y)
                                        {
                                            ToChucToaDo.Active = true;
                                        }
                                    }
                                    await _ToChucToaDoService.SaveAsync(ToChucToaDo);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }
                    if (!string.IsNullOrEmpty(model.KinhDo))
                    {
                        if (!string.IsNullOrEmpty(model.ViDo))
                        {
                            ToChucToaDo ToChucToaDo = new ToChucToaDo();
                            ToChucToaDo.ParentID = model.ID;
                            ToChucToaDo.ParentName = model.Name;
                            ToChucToaDo.Code = model.Code;
                            ToChucToaDo.KinhDo = model.KinhDo;
                            ToChucToaDo.ViDo = model.ViDo;
                            ToChucToaDo = await _ToChucToaDoService.GetByCondition(item => item.ParentID == ToChucToaDo.ParentID && item.Active == true).FirstOrDefaultAsync();
                            if (ToChucToaDo == null)
                            {
                                ToChucToaDo = new ToChucToaDo();
                                ToChucToaDo.ParentID = model.ID;
                                ToChucToaDo.ParentName = model.Name;
                                ToChucToaDo.Code = model.Code;
                                ToChucToaDo.KinhDo = model.KinhDo;
                                ToChucToaDo.ViDo = model.ViDo;
                                ToChucToaDo.Active = true;
                                await _ToChucToaDoService.SaveAsync(ToChucToaDo);
                            }
                        }
                    }
                }
            }
            return result;
        }
        private int Sync(ToChuc model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (model != null)
            {
                if (model.ID > 0)
                {
                    if (!string.IsNullOrEmpty(model.DanhMucNguyenVatLieuName))
                    {
                        foreach (string Name in model.DanhMucNguyenVatLieuName.Split(','))
                        {
                            if (!string.IsNullOrEmpty(Name))
                            {
                                string DanhMucNguyenVatLieuName = Name.Trim();
                                DanhMucNguyenVatLieu DanhMucNguyenVatLieu = _DanhMucNguyenVatLieuService.GetByName(DanhMucNguyenVatLieuName);
                                if (DanhMucNguyenVatLieu.ID == 0)
                                {
                                    DanhMucNguyenVatLieu.Name = model.DanhMucNguyenVatLieuName;
                                    _DanhMucNguyenVatLieuService.Save(DanhMucNguyenVatLieu);
                                }
                                ToChucNguyenVatLieu ToChucNguyenVatLieu = _ToChucNguyenVatLieuService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucNguyenVatLieuID == DanhMucNguyenVatLieu.ID).FirstOrDefault();
                                if (ToChucNguyenVatLieu == null)
                                {
                                    ToChucNguyenVatLieu = new ToChucNguyenVatLieu();
                                    ToChucNguyenVatLieu.ParentID = model.ID;
                                    ToChucNguyenVatLieu.ParentName = model.Name;
                                    ToChucNguyenVatLieu.DanhMucNguyenVatLieuID = DanhMucNguyenVatLieu.ID;
                                    ToChucNguyenVatLieu.DanhMucNguyenVatLieuName = DanhMucNguyenVatLieu.Name;
                                    _ToChucNguyenVatLieuService.Save(ToChucNguyenVatLieu);
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(model.DanhMucGiongName))
                    {
                        foreach (string Name in model.DanhMucGiongName.Split(','))
                        {
                            if (!string.IsNullOrEmpty(Name))
                            {
                                DanhMucLoaiGiong DanhMucLoaiGiong = new DanhMucLoaiGiong();
                                if (!string.IsNullOrEmpty(model.DanhMucLoaiGiongName))
                                {
                                    DanhMucLoaiGiong = _DanhMucLoaiGiongService.GetByName(model.DanhMucLoaiGiongName);
                                    if (DanhMucLoaiGiong.ID == 0)
                                    {
                                        DanhMucLoaiGiong.Name = model.DanhMucLoaiGiongName;
                                        _DanhMucLoaiGiongService.Save(DanhMucLoaiGiong);
                                    }
                                }

                                string DanhMucGiongName = Name.Trim();
                                DanhMucGiong DanhMucGiong = _DanhMucGiongService.GetByName(DanhMucGiongName);
                                if (DanhMucGiong.ID == 0)
                                {
                                    DanhMucGiong.Name = DanhMucGiongName;
                                    _DanhMucGiongService.Save(DanhMucGiong);
                                }
                                ToChucGiong ToChucGiong = _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID && item.DanhMucLoaiGiongID == DanhMucLoaiGiong.ID).FirstOrDefault();
                                if (ToChucGiong == null)
                                {
                                    ToChucGiong = new ToChucGiong();
                                    ToChucGiong.ParentID = model.ID;
                                    ToChucGiong.ParentName = model.Name;
                                    ToChucGiong.DanhMucLoaiGiongID = DanhMucLoaiGiong.ID;
                                    ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                    ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                    ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                    _ToChucGiongService.Save(ToChucGiong);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (model.ParentID == 14)
                        {
                            DanhMucGiong DanhMucGiong = _DanhMucGiongService.GetByID(1091);
                            ToChucGiong ToChucGiong = _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefault();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                _ToChucGiongService.Save(ToChucGiong);
                            }

                            DanhMucGiong = _DanhMucGiongService.GetByID(1169);
                            ToChucGiong = _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefault();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                _ToChucGiongService.Save(ToChucGiong);
                            }

                            DanhMucGiong = _DanhMucGiongService.GetByID(1170);
                            ToChucGiong = _ToChucGiongService.GetByCondition(item => item.ParentID == model.ID && item.DanhMucGiongID == DanhMucGiong.ID).FirstOrDefault();
                            if (ToChucGiong == null)
                            {
                                ToChucGiong = new ToChucGiong();
                                ToChucGiong.ParentID = model.ID;
                                ToChucGiong.ParentName = model.Name;
                                ToChucGiong.DanhMucLoaiGiongName = model.DanhMucLoaiGiongName;
                                ToChucGiong.DanhMucGiongID = DanhMucGiong.ID;
                                ToChucGiong.DanhMucGiongName = DanhMucGiong.Name;
                                _ToChucGiongService.Save(ToChucGiong);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(model.HTMLContent))
                    {
                        try
                        {
                            byte[] byteArray = GlobalHelper.StringToByteArray(model.HTMLContent);
                            WKBReader reader = new WKBReader();
                            Geometry geometry = reader.Read(byteArray);
                            Point point = geometry.Centroid;
                            foreach (Coordinate Coordinate in geometry.Coordinates)
                            {
                                ToChucToaDo ToChucToaDo = new ToChucToaDo();
                                ToChucToaDo.ParentID = model.ID;
                                ToChucToaDo.ParentName = model.Name;
                                ToChucToaDo.Code = model.Code;
                                ToChucToaDo.KinhDo = Coordinate.X.ToString();
                                ToChucToaDo.ViDo = Coordinate.Y.ToString();
                                ToChucToaDo = _ToChucToaDoService.GetByCondition(item => item.ParentID == ToChucToaDo.ParentID && item.KinhDo == ToChucToaDo.KinhDo && item.ViDo == ToChucToaDo.ViDo).FirstOrDefault();
                                if (ToChucToaDo == null)
                                {
                                    ToChucToaDo = new ToChucToaDo();
                                    ToChucToaDo.ParentID = model.ID;
                                    ToChucToaDo.ParentName = model.Name;
                                    ToChucToaDo.Code = model.Code;
                                    ToChucToaDo.KinhDo = Coordinate.X.ToString();
                                    ToChucToaDo.ViDo = Coordinate.Y.ToString();
                                    if (Coordinate.X == point.X)
                                    {
                                        if (Coordinate.Y == point.Y)
                                        {
                                            ToChucToaDo.Active = true;
                                        }
                                    }
                                    _ToChucToaDoService.Save(ToChucToaDo);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }
                    if (!string.IsNullOrEmpty(model.KinhDo))
                    {
                        if (!string.IsNullOrEmpty(model.ViDo))
                        {
                            ToChucToaDo ToChucToaDo = new ToChucToaDo();
                            ToChucToaDo.ParentID = model.ID;
                            ToChucToaDo.ParentName = model.Name;
                            ToChucToaDo.Code = model.Code;
                            ToChucToaDo.KinhDo = model.KinhDo;
                            ToChucToaDo.ViDo = model.ViDo;
                            ToChucToaDo = _ToChucToaDoService.GetByCondition(item => item.ParentID == ToChucToaDo.ParentID && item.KinhDo == ToChucToaDo.KinhDo && item.ViDo == ToChucToaDo.ViDo).FirstOrDefault();
                            if (ToChucToaDo == null)
                            {
                                ToChucToaDo = new ToChucToaDo();
                                ToChucToaDo.ParentID = model.ID;
                                ToChucToaDo.ParentName = model.Name;
                                ToChucToaDo.Code = model.Code;
                                ToChucToaDo.KinhDo = model.KinhDo;
                                ToChucToaDo.ViDo = model.ViDo;
                                _ToChucToaDoService.Save(ToChucToaDo);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public virtual async Task<List<ToChuc>> GetByParentIDAndSearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDAsync(long ParentID, string SearchString, long DanhMucQuanHuyenID, long DanhMucXaPhuongID)
        {
            List<ToChuc> result = new List<ToChuc>();
            result = await GetByCondition(item => item.ParentID == ParentID).ToListAsync();
            if (!string.IsNullOrEmpty(SearchString))
            {
                result = result.Where(item => item.Code.Contains(SearchString) || item.Name.Contains(SearchString) || item.DienThoai.Contains(SearchString) || item.CCCD.Contains(SearchString) || item.Email.Contains(SearchString)).ToList();
            }
            else
            {
                if (DanhMucQuanHuyenID > 0)
                {
                    if (DanhMucXaPhuongID > 0)
                    {
                        result = result.Where(item => item.DanhMucQuanHuyenID == DanhMucQuanHuyenID && item.DanhMucXaPhuongID == DanhMucXaPhuongID).ToList();
                    }
                    else
                    {
                        result = result.Where(item => item.DanhMucQuanHuyenID == DanhMucQuanHuyenID).ToList();
                    }
                }
            }
            if (result == null)
            {
                result = new List<ToChuc>();
            }
            return result;
        }

        public virtual async Task<List<ToChuc>> GetSQLByParentID_ActiveToListAsync(long ParentID, bool Active)
        {
            List<ToChuc> result = new List<ToChuc>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ParentID",ParentID),
                    new SqlParameter("@Active",Active),
                };
                result = await GetByStoredProcedureToListAsync("sp_ToChucTransferByParentID_Active", parameters);
            }
            return result;
        }
        public virtual async Task<List<ToChuc>> GetSQLByParentID_Active_SearchStringToListAsync(long ParentID, bool Active, string SearchString)
        {
            List<ToChuc> result = new List<ToChuc>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ParentID",ParentID),
                    new SqlParameter("@Active",Active),
                    new SqlParameter("@SearchString",SearchString),
                };
                result = await GetByStoredProcedureToListAsync("sp_ToChucTransferByParentID_Active_SearchString", parameters);
            }
            return result;
        }
        public virtual async Task<List<ToChuc>> GetSQLByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongIDToListAsync(long ParentID, bool Active, string SearchString, long DanhMucQuanHuyenID, long DanhMucXaPhuongID)
        {
            List<ToChuc> result = new List<ToChuc>();
            if (ParentID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ParentID",ParentID),
                    new SqlParameter("@Active",Active),
                    new SqlParameter("@SearchString",SearchString),
                    new SqlParameter("@DanhMucQuanHuyenID",DanhMucQuanHuyenID),
                    new SqlParameter("@DanhMucXaPhuongID",DanhMucXaPhuongID),
                };
                result = await GetByStoredProcedureToListAsync("sp_ToChucTransferByParentID_Active_SearchString_DanhMucQuanHuyenID_DanhMucXaPhuongID", parameters);
            }
            return result;
        }
        public virtual async Task<List<ToChuc>> GetSQLByDanhMucGiongIDToListAsync(long DanhMucGiongID)
        {
            List<ToChuc> result = new List<ToChuc>();
            if (DanhMucGiongID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DanhMucGiongID",DanhMucGiongID),
                };
                result = await GetByStoredProcedureToListAsync("sp_ToChucByDanhMucGiongID", parameters);
            }
            return result;
        }
        public virtual async Task<List<ToChuc>> GetSQLByDanhMucGiongID_ActiveToListAsync(long DanhMucGiongID, bool Active)
        {
            List<ToChuc> result = new List<ToChuc>();
            if (DanhMucGiongID > 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DanhMucGiongID",DanhMucGiongID),
                    new SqlParameter("@Active",Active),
                };
                result = await GetByStoredProcedureToListAsync("sp_ToChucByDanhMucGiongID_Active", parameters);
            }
            return result;
        }
    }
}

