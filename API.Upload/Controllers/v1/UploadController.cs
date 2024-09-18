


using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace API.Upload.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UploadController : BaseController<ToChuc, IToChucService>
    {
        private readonly IToChucService _ToChucService;

        private readonly IWebHostEnvironment _WebHostEnvironment;

        private readonly IToChucTieuChuanService _ToChucTieuChuanService;
        private readonly IToChucQuanLyService _ToChucQuanLyService;
        private readonly IToChucPhuongTienKhaiThacService _ToChucPhuongTienKhaiThacService;
        private readonly IToChucVungNuoiService _ToChucVungNuoiService;

        public UploadController(IToChucService ToChucService
            , IWebHostEnvironment WebHostEnvironment

            , IToChucTieuChuanService ToChucTieuChuanService
            , IToChucQuanLyService ToChucQuanLyService
            , IToChucPhuongTienKhaiThacService ToChucPhuongTienKhaiThacService
            , IToChucVungNuoiService ToChucVungNuoiService

            ) : base(ToChucService, WebHostEnvironment)
        {
            _ToChucService = ToChucService;
            _WebHostEnvironment = WebHostEnvironment;


            _ToChucTieuChuanService = ToChucTieuChuanService;
            _ToChucQuanLyService = ToChucQuanLyService;
            _ToChucPhuongTienKhaiThacService = ToChucPhuongTienKhaiThacService;
            _ToChucVungNuoiService = ToChucVungNuoiService;
        }
        [HttpPost]
        [Route("PostToChucTramQuanTracByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucTramQuanTracByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucTramQuanTrac_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 7;
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.HTMLContent = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.Description = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.Display = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SanLuong = decimal.Parse(workSheet.Cells[i, 8].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 11].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 12].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 17].Value != null)
                                                {
                                                    ToChuc.KinhDo = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 18].Value != null)
                                                {
                                                    ToChuc.ViDo = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 20].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 21].Value != null)
                                                {
                                                    ToChuc.DuongPho = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                }
                                                ToChuc.ParentID = 7;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucHoNuoiByExcelFile")]
        public virtual List<ToChuc> PostToChucHoNuoiByExcelFile()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucHoNuoi_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                if (workSheet.Cells[i, 21].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                }
                                                ToChuc = _ToChucService.GetByCode(ToChuc.Code);

                                                if (workSheet.Cells[i, 21].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.DanhMucGiongName = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DanhMucLoaiGiongName = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.ChuDatHoTen = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.ChuDatDiaChi = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 9].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichNuoiTrongThuySan = decimal.Parse(workSheet.Cells[i, 9].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 10].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichNuoi = decimal.Parse(workSheet.Cells[i, 10].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 11].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.AoNuoi = int.Parse(workSheet.Cells[i, 11].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 12].Value != null)
                                                {
                                                    ToChuc.HinhThucNuoi = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 13].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SoLuongGiongTha = decimal.Parse(workSheet.Cells[i, 13].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 14].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SanLuong = decimal.Parse(workSheet.Cells[i, 14].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 15].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SoLuongBenh = decimal.Parse(workSheet.Cells[i, 15].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 16].Value != null)
                                                {
                                                    ToChuc.NgayTTB = workSheet.Cells[i, 16].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 17].Value != null)
                                                {
                                                    ToChuc.NguonGiong = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 18].Value != null)
                                                {
                                                    ToChuc.Note = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 19].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 20].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 22].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichTha = decimal.Parse(workSheet.Cells[i, 22].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 23].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 24].Value != null)
                                                {
                                                    ToChuc.DuongPho = workSheet.Cells[i, 24].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 25].Value != null)
                                                {
                                                    ToChuc.HienTrang = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 26].Value != null)
                                                {
                                                    ToChuc.QuyHoach = workSheet.Cells[i, 26].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 27].Value != null)
                                                {
                                                    ToChuc.DiaChiKhu = workSheet.Cells[i, 27].Value.ToString().Trim();
                                                }

                                                ToChuc ToChucHopTacXa = new ToChuc();
                                                if (workSheet.Cells[i, 28].Value != null)
                                                {
                                                    ToChucHopTacXa.Name = workSheet.Cells[i, 28].Value.ToString().Trim();
                                                }
                                                ToChucHopTacXa = _ToChucService.GetByName(ToChucHopTacXa.Name);
                                                if (workSheet.Cells[i, 28].Value != null)
                                                {
                                                    ToChucHopTacXa.Name = workSheet.Cells[i, 28].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 29].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChucHopTacXa.DienTichNuoiTrongThuySan = decimal.Parse(workSheet.Cells[i, 29].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 30].Value != null)
                                                {
                                                    ToChucHopTacXa.DanhMucGiongName = workSheet.Cells[i, 30].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 31].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChucHopTacXa.SanLuong = decimal.Parse(workSheet.Cells[i, 31].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }

                                                ToChucTieuChuan ToChucTieuChuan = new ToChucTieuChuan();
                                                if (workSheet.Cells[i, 32].Value != null)
                                                {
                                                    ToChucTieuChuan.Name = workSheet.Cells[i, 32].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 33].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChucTieuChuan.NamGhiNhan = int.Parse(workSheet.Cells[i, 33].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 37].Value != null)
                                                {
                                                    string Active = workSheet.Cells[i, 37].Value.ToString().Trim();
                                                    if (!string.IsNullOrEmpty(Active))
                                                    {
                                                        ToChucTieuChuan.Active = true;
                                                    }
                                                }

                                                if (workSheet.Cells[i, 34].Value != null)
                                                {
                                                    ToChuc.KinhDo = workSheet.Cells[i, 34].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 35].Value != null)
                                                {
                                                    ToChuc.ViDo = workSheet.Cells[i, 35].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 38].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichThuHoach = decimal.Parse(workSheet.Cells[i, 38].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 39].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichBenh = decimal.Parse(workSheet.Cells[i, 39].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }

                                                if (string.IsNullOrEmpty(ToChucHopTacXa.DanhMucLoaiGiongName))
                                                {
                                                    ToChucHopTacXa.DanhMucLoaiGiongName = ToChuc.DanhMucLoaiGiongName;
                                                }
                                                if (string.IsNullOrEmpty(ToChuc.DanhMucGiongName))
                                                {
                                                    ToChuc.DanhMucGiongName = ToChucHopTacXa.DanhMucGiongName;
                                                }


                                                ToChucHopTacXa.ParentID = 8;
                                                ToChucHopTacXa.Active = true;
                                                _ToChucService.Save(ToChucHopTacXa);

                                                ToChuc.ParentID = 1;
                                                ToChuc.Active = true;
                                                _ToChucService.Save(ToChuc);
                                                result.Add(ToChuc);

                                                if (ToChuc.ID > 0)
                                                {
                                                    if (ToChucTieuChuan.Active == true)
                                                    {
                                                        ToChucTieuChuan ToChucTieuChuanSave = _ToChucTieuChuanService.GetByCondition(item => item.ParentID == ToChuc.ID && item.Name == ToChucTieuChuan.Name).FirstOrDefault();
                                                        if (ToChucTieuChuanSave == null)
                                                        {
                                                            ToChucTieuChuanSave = new ToChucTieuChuan();
                                                            ToChucTieuChuanSave.Name = ToChucTieuChuan.Name;
                                                            ToChucTieuChuanSave.NamGhiNhan = ToChucTieuChuan.NamGhiNhan;
                                                            ToChucTieuChuanSave.ParentID = ToChuc.ID;
                                                            ToChucTieuChuanSave.ParentName = ToChuc.Name;
                                                            ToChucTieuChuanSave.DanhMucTieuChuanID = 1;
                                                            _ToChucTieuChuanService.Save(ToChucTieuChuanSave);
                                                        }
                                                    }


                                                    if (ToChucHopTacXa.ID > 0)
                                                    {
                                                        ToChucQuanLy ToChucQuanLy = _ToChucQuanLyService.GetByCondition(item => item.ParentID == ToChuc.ID && item.ToChucID == ToChucHopTacXa.ID).FirstOrDefault();
                                                        if (ToChucQuanLy == null)
                                                        {
                                                            ToChucQuanLy = new ToChucQuanLy();
                                                            ToChucQuanLy.ParentID = ToChuc.ID;
                                                            ToChucQuanLy.ParentName = ToChuc.Name;
                                                            ToChucQuanLy.ToChucID = ToChucHopTacXa.ID;
                                                            ToChucQuanLy.ToChucName = ToChucHopTacXa.Name;
                                                            ToChucQuanLy.Code = ToChucHopTacXa.Code;
                                                            _ToChucQuanLyService.Save(ToChucQuanLy);
                                                        }
                                                    }
                                                }
                                                if (ToChucHopTacXa.ID > 0)
                                                {
                                                    if (ToChucTieuChuan.Active == true)
                                                    {
                                                        ToChucTieuChuan ToChucTieuChuanSave = _ToChucTieuChuanService.GetByCondition(item => item.ParentID == ToChucHopTacXa.ID && item.Name == ToChucTieuChuan.Name).FirstOrDefault();
                                                        if (ToChucTieuChuanSave == null)
                                                        {
                                                            ToChucTieuChuanSave = new ToChucTieuChuan();
                                                            ToChucTieuChuanSave.Name = ToChucTieuChuan.Name;
                                                            ToChucTieuChuanSave.NamGhiNhan = ToChucTieuChuan.NamGhiNhan;
                                                            ToChucTieuChuanSave.ParentID = ToChucHopTacXa.ID;
                                                            ToChucTieuChuanSave.ParentName = ToChucHopTacXa.Name;
                                                            ToChucTieuChuanSave.DanhMucTieuChuanID = 1;
                                                            _ToChucTieuChuanService.Save(ToChucTieuChuanSave);
                                                        }
                                                    }

                                                    if (ToChuc.ID > 0)
                                                    {
                                                        ToChucQuanLy ToChucQuanLy = _ToChucQuanLyService.GetByCondition(item => item.ParentID == ToChucHopTacXa.ID && item.ToChucID == ToChuc.ID).FirstOrDefault();
                                                        if (ToChucQuanLy == null)
                                                        {
                                                            ToChucQuanLy = new ToChucQuanLy();
                                                            ToChucQuanLy.ParentID = ToChucHopTacXa.ID;
                                                            ToChucQuanLy.ParentName = ToChucHopTacXa.Name;
                                                            ToChucQuanLy.ToChucID = ToChuc.ID;
                                                            ToChucQuanLy.ToChucName = ToChuc.Name;
                                                            ToChucQuanLy.Code = ToChuc.Code;
                                                            _ToChucQuanLyService.Save(ToChucQuanLy);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucPhuongTienKhaiThacByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucPhuongTienKhaiThacByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucPhuongTienKhaiThac_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCodeAsync(ToChuc.Code);

                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DuongPho = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.ApThon = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 9].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 10].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 21].Value != null)
                                                {
                                                    ToChuc.Note = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 22].Value != null)
                                                {
                                                    ToChuc.KinhDo = workSheet.Cells[i, 22].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 23].Value != null)
                                                {
                                                    ToChuc.ViDo = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                }

                                                ToChuc.ParentID = 9;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                                if (ToChuc.ID > 0)
                                                {
                                                    ToChucPhuongTienKhaiThac ToChucPhuongTienKhaiThac = await _ToChucPhuongTienKhaiThacService.GetByCondition(item => item.ParentID == ToChuc.ID && item.Code == ToChuc.Code).FirstOrDefaultAsync();
                                                    if (ToChucPhuongTienKhaiThac == null)
                                                    {
                                                        ToChucPhuongTienKhaiThac = new ToChucPhuongTienKhaiThac();
                                                        ToChucPhuongTienKhaiThac.ParentID = ToChuc.ID;
                                                        ToChucPhuongTienKhaiThac.ParentName = ToChuc.Name;
                                                        ToChucPhuongTienKhaiThac.Code = ToChuc.Code;
                                                        ToChucPhuongTienKhaiThac.Note = ToChuc.Note;
                                                        ToChucPhuongTienKhaiThac.KinhDo = ToChuc.KinhDo;
                                                        ToChucPhuongTienKhaiThac.ViDo = ToChuc.ViDo;
                                                        ToChucPhuongTienKhaiThac.DanhMucQuanHuyenID = ToChuc.DanhMucQuanHuyenID;
                                                        ToChucPhuongTienKhaiThac.DanhMucQuanHuyenName = ToChuc.DanhMucQuanHuyenName;
                                                        ToChucPhuongTienKhaiThac.DanhMucXaPhuongID = ToChuc.DanhMucXaPhuongID;
                                                        ToChucPhuongTienKhaiThac.DanhMucXaPhuongName = ToChuc.DanhMucXaPhuongName;


                                                        if (workSheet.Cells[i, 11].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.ChieuCao = decimal.Parse(workSheet.Cells[i, 11].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 12].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.ChieuRong = decimal.Parse(workSheet.Cells[i, 12].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 13].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.ChieuDai = decimal.Parse(workSheet.Cells[i, 13].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 14].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.DungTich = decimal.Parse(workSheet.Cells[i, 14].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 15].Value != null)
                                                        {
                                                            ToChucPhuongTienKhaiThac.DanhMucHieuMayName = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 16].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.CongSuat = decimal.Parse(workSheet.Cells[i, 16].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 17].Value != null)
                                                        {
                                                            ToChucPhuongTienKhaiThac.DanhMucNganhNgheName = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 18].Value != null)
                                                        {
                                                            try
                                                            {
                                                                ToChucPhuongTienKhaiThac.ThuyenVien = int.Parse(workSheet.Cells[i, 18].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string message = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 19].Value != null)
                                                        {
                                                            try
                                                            {
                                                                string NgayDangKy = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                                string Nam = NgayDangKy.Substring(0, 4);
                                                                string Thang = NgayDangKy.Substring(5, 2);
                                                                string Ngay = NgayDangKy.Substring(8, 2);
                                                                ToChucPhuongTienKhaiThac.NgayDangKy = new DateTime(int.Parse(Nam), int.Parse(Thang), int.Parse(Ngay));
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                string message = e.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 20].Value != null)
                                                        {
                                                            try
                                                            {
                                                                string HanDangKiem = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                                string Nam = HanDangKiem.Substring(0, 4);
                                                                string Thang = HanDangKiem.Substring(5, 2);
                                                                string Ngay = HanDangKiem.Substring(8, 2);
                                                                ToChucPhuongTienKhaiThac.HanDangKiem = new DateTime(int.Parse(Nam), int.Parse(Thang), int.Parse(Ngay));
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                string message = e.Message;
                                                            }
                                                        }
                                                        await _ToChucPhuongTienKhaiThacService.SaveAsync(ToChucPhuongTienKhaiThac);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucGiongByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucGiongByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucGiong_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 10;
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 13].Value != null)
                                                {
                                                    ToChuc.HTMLContent = workSheet.Cells[i, 13].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DienThoai = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.Description = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichNuoiTrongThuySan = decimal.Parse(workSheet.Cells[i, 8].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 9].Value != null)
                                                {
                                                    ToChuc.Display = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 10].Value != null)
                                                {
                                                    ToChuc.Note = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 11].Value != null)
                                                {
                                                    ToChuc.KinhDo = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 12].Value != null)
                                                {
                                                    ToChuc.ViDo = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 14].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 15].Value != null)
                                                {
                                                    ToChuc.DuongPho = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 16].Value != null)
                                                {
                                                    ToChuc.DiaChiKhu = workSheet.Cells[i, 16].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 17].Value != null)
                                                {
                                                    ToChuc.DanhMucLoaiHinhName = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 18].Value != null)
                                                {
                                                    ToChuc.DanhMucLoaiGiongName = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 19].Value != null)
                                                {
                                                    ToChuc.DanhMucGiongName = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 22].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 22].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 23].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                }

                                                ToChuc.ParentID = 10;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucVungTrongByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucVungTrongByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucVungTrong_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 1;
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCodeAsync(ToChuc.Code);

                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.HTMLContent = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.Code = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }

                                                ToChuc.ParentID = 1;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucCuaHangByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucCuaHangByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucCuaHang_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 12;
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.ChuDatHoTen = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (string.IsNullOrEmpty(ToChuc.Name))
                                                {
                                                    ToChuc.Name = ToChuc.ChuDatHoTen;
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.ChuDatHoTen = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (string.IsNullOrEmpty(ToChuc.Name))
                                                {
                                                    ToChuc.Name = ToChuc.ChuDatHoTen;
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DanhMucCuaHangName = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.DuongPho = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 9].Value != null)
                                                {
                                                    ToChuc.DanhMucXaPhuongName = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 10].Value != null)
                                                {
                                                    ToChuc.DanhMucQuanHuyenName = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 21].Value != null)
                                                {
                                                    ToChuc.DanhMucNguyenVatLieuName = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 22].Value != null)
                                                {
                                                    ToChuc.Note = workSheet.Cells[i, 22].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 23].Value != null)
                                                {
                                                    ToChuc.ChuDatDiaChi = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 24].Value != null)
                                                {
                                                    ToChuc.Description = workSheet.Cells[i, 24].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 25].Value != null)
                                                {
                                                    ToChuc.HTMLContent = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 30].Value != null)
                                                {
                                                    ToChuc.KinhDo = workSheet.Cells[i, 30].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 31].Value != null)
                                                {
                                                    ToChuc.ViDo = workSheet.Cells[i, 31].Value.ToString().Trim();
                                                }

                                                ToChuc.ParentID = 12;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucLongBeByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucLongBeByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucLongBe_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 3; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 13;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name && item.DanhMucQuanHuyenID == ToChuc.DanhMucQuanHuyenID && item.DanhMucXaPhuongID == ToChuc.DanhMucXaPhuongID).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.DienTichNuoiTrongThuySan = decimal.Parse(workSheet.Cells[i, 4].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    ToChuc.DiaChiKhu = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.SoLuongGiongTha = decimal.Parse(workSheet.Cells[i, 6].Value.ToString().Trim());
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    ToChuc.DanhMucGiongName = "Hàu";
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.DanhMucGiongName = "Cá bớp";
                                                }

                                                ToChuc.ParentID = 13;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucNuoiNhuyenThe001ByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucNuoiNhuyenThe001ByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucNuoiNhuyenThe001_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 3; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 14;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name && item.DanhMucQuanHuyenID == ToChuc.DanhMucQuanHuyenID && item.DanhMucXaPhuongID == ToChuc.DanhMucXaPhuongID).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {
                                                    int NamSinh = GlobalHelper.InitializationDateTime.Year;
                                                    try
                                                    {
                                                        NamSinh = int.Parse(workSheet.Cells[i, 5].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                    ToChuc.NgaySinh = new DateTime(NamSinh, 1, 1);
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.CCCD = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 10].Value != null)
                                                {
                                                    ToChuc.DienThoai = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 12].Value != null)
                                                {
                                                    ToChuc.SoNha = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 13].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SoLuongGiongTha = decimal.Parse(workSheet.Cells[i, 13].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }                                               
                                                if (workSheet.Cells[i, 14].Value != null)
                                                {
                                                    ToChuc.Description = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 15].Value != null)
                                                {
                                                    ToChuc.Note = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 16].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.SanLuong = decimal.Parse(workSheet.Cells[i, 16].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }

                                                ToChuc.ParentID = 14;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("PostToChucNuoiNhuyenThe002ByExcelFileAsync")]
        public virtual async Task<List<ToChuc>> PostToChucNuoiNhuyenThe002ByExcelFileAsync()
        {
            List<ToChuc> result = new List<ToChuc>();
            try
            {
                BaseParameter baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = "ToChucNuoiNhuyenThe002_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {

                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                ToChuc ToChuc = new ToChuc();
                                                ToChuc.ParentID = 14;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                ToChuc = await _ToChucService.GetByCondition(item => item.ParentID == ToChuc.ParentID && item.Name == ToChuc.Name && item.DanhMucQuanHuyenID == ToChuc.DanhMucQuanHuyenID && item.DanhMucXaPhuongID == ToChuc.DanhMucXaPhuongID).FirstOrDefaultAsync();
                                                if (ToChuc == null)
                                                {
                                                    ToChuc = new ToChuc();
                                                }
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    ToChuc.Name = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 3].Value != null)
                                                {
                                                    int NamSinh = GlobalHelper.InitializationDateTime.Year;
                                                    try
                                                    {
                                                        NamSinh = int.Parse(workSheet.Cells[i, 3].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                    ToChuc.NgaySinh = new DateTime(NamSinh, 1, 1);
                                                }
                                                if (workSheet.Cells[i, 4].Value != null)
                                                {
                                                    ToChuc.DiaChi = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 5].Value != null)
                                                {                                                   
                                                    try
                                                    {
                                                        ToChuc.DienTichNuoiTrongThuySan = decimal.Parse(workSheet.Cells[i, 5].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }                                                   
                                                }
                                                if (workSheet.Cells[i, 6].Value != null)
                                                {
                                                    ToChuc.DiaChiKhu = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 7].Value != null)
                                                {
                                                    try
                                                    {
                                                        ToChuc.NamGhiNhan = int.Parse(workSheet.Cells[i, 7].Value.ToString().Trim());
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        string message = ex.Message;
                                                    }
                                                }
                                                if (workSheet.Cells[i, 8].Value != null)
                                                {
                                                    ToChuc.DanhMucGiongName = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                }
                                               

                                                ToChuc.ParentID = 14;
                                                ToChuc.DanhMucQuanHuyenID = baseParameter.DanhMucQuanHuyenID;
                                                ToChuc.DanhMucXaPhuongID = baseParameter.DanhMucXaPhuongID;
                                                ToChuc.Active = true;
                                                await _ToChucService.SaveAsync(ToChuc);
                                                result.Add(ToChuc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
    }
}

