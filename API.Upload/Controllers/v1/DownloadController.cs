using DocumentFormat.OpenXml.Wordprocessing;

namespace API.Upload.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController<ToChuc, IToChucService>
    {
        private readonly IToChucService _ToChucService;

        private readonly IWebHostEnvironment _WebHostEnvironment;        

        private readonly IToChucQuanLyService _ToChucQuanLyService;

        private readonly IToChucTieuChuanService _ToChucTieuChuanService;

        private readonly IToChucPhuongTienKhaiThacService _ToChucPhuongTienKhaiThacService;

        private readonly IDanhMucToChucService _DanhMucToChucService;

        private readonly IDanhMucGiongService _DanhMucGiongService;

        public DownloadController(IToChucService ToChucService

            , IWebHostEnvironment WebHostEnvironment           

            , IToChucQuanLyService ToChucQuanLyService

            , IToChucTieuChuanService ToChucTieuChuanService

            , IToChucPhuongTienKhaiThacService ToChucPhuongTienKhaiThacService

            , IDanhMucToChucService DanhMucToChucService

            , IDanhMucGiongService DanhMucGiongService

            ) : base(ToChucService, WebHostEnvironment)
        {
            _ToChucService = ToChucService;
            _WebHostEnvironment = WebHostEnvironment;
            
            _ToChucQuanLyService = ToChucQuanLyService;
            _ToChucTieuChuanService = ToChucTieuChuanService;
            _ToChucPhuongTienKhaiThacService = ToChucPhuongTienKhaiThacService;

            _DanhMucToChucService = DanhMucToChucService;
            _DanhMucGiongService = DanhMucGiongService;

        }

        [HttpPost]
        [Route("NamBatDau")]
        public NamThang NamBatDau()
        {
            NamThang namThang = new NamThang();
            namThang.ID = GlobalHelper.NamBatDau;
            namThang.Name = GlobalHelper.NamBatDau.ToString();
            return namThang;
        }
        [HttpPost]
        [Route("NamKeThuc")]
        public NamThang NamKeThuc()
        {
            NamThang namThang = new NamThang();
            namThang.ID = GlobalHelper.NamBatDau;
            namThang.Name = GlobalHelper.NamBatDau.ToString();
            return namThang;
        }
        [HttpPost]
        [Route("ListNam")]
        public List<NamThang> ListNam()
        {
            List<NamThang> result = new List<NamThang>();
            for (int i = GlobalHelper.NamBatDau; i < GlobalHelper.NamKeThuc; i++)
            {
                NamThang namThang = new NamThang();
                namThang.ID = i;
                namThang.Name = i.ToString();
                result.Add(namThang);
            }
            return result;
        }
        [HttpPost]
        [Route("ListThang")]
        public List<NamThang> ListThang()
        {
            List<NamThang> result = new List<NamThang>();
            for (int i = 0; i < 13; i++)
            {
                NamThang namThang = new NamThang();
                namThang.ID = i;
                namThang.Name = i.ToString();
                result.Add(namThang);
            }
            return result;
        }

        [HttpPost]
        [Route("ExportToChucHoNuoiToExcelAsync")]
        public async Task<JsonResult> ExportToChucHoNuoiToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetByParentIDToListAsync(baseParameter.ParentID.Value);
                DanhMucToChuc DanhMucToChuc = await _DanhMucToChucService.GetByIDAsync(baseParameter.ParentID.Value);
                string fileName = DanhMucToChuc.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucHoNuoiAsync(list, streamExport, DanhMucToChuc.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        [HttpPost]
        [Route("ExportToChucCuaHangToExcelAsync")]
        public async Task<JsonResult> ExportToChucCuaHangToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetByParentIDToListAsync(baseParameter.ParentID.Value);
                DanhMucToChuc DanhMucToChuc = await _DanhMucToChucService.GetByIDAsync(baseParameter.ParentID.Value);
                string fileName = DanhMucToChuc.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucCuaHangAsync(list, streamExport, DanhMucToChuc.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        [HttpPost]
        [Route("ExportToChucTramQuanTracToExcelAsync")]
        public async Task<JsonResult> ExportToChucTramQuanTracToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetByParentIDToListAsync(baseParameter.ParentID.Value);
                DanhMucToChuc DanhMucToChuc = await _DanhMucToChucService.GetByIDAsync(baseParameter.ParentID.Value);
                string fileName = DanhMucToChuc.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucTramQuanTracAsync(list, streamExport, DanhMucToChuc.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        [HttpPost]
        [Route("ExportToChucPhuongTienKhaiThacToExcelAsync")]
        public async Task<JsonResult> ExportToChucPhuongTienKhaiThacToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetByParentIDToListAsync(baseParameter.ParentID.Value);
                DanhMucToChuc DanhMucToChuc = await _DanhMucToChucService.GetByIDAsync(baseParameter.ParentID.Value);
                string fileName = DanhMucToChuc.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucPhuongTienKhaiThacAsync(list, streamExport, DanhMucToChuc.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        [HttpPost]
        [Route("ExportToChucGiongToExcelAsync")]
        public async Task<JsonResult> ExportToChucGiongToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetByParentIDToListAsync(baseParameter.ParentID.Value);
                DanhMucToChuc DanhMucToChuc = await _DanhMucToChucService.GetByIDAsync(baseParameter.ParentID.Value);
                string fileName = DanhMucToChuc.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucGiongAsync(list, streamExport, DanhMucToChuc.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        [HttpPost]
        [Route("ExportToChucDanhMucGiongToExcelAsync")]
        public async Task<JsonResult> ExportToChucDanhMucGiongToExcelAsync()
        {
            string result = GlobalHelper.InitializationString;
            BaseParameter baseParameter = new BaseParameter();
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                List<ToChuc> list = await _ToChucService.GetSQLByDanhMucGiongIDToListAsync(baseParameter.DanhMucGiongID.Value);
                DanhMucGiong DanhMucGiong = await _DanhMucGiongService.GetByIDAsync(baseParameter.DanhMucGiongID.Value);
                string fileName = DanhMucGiong.Name + @"_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
                var streamExport = new MemoryStream();
                await InitializationExcelToChucHoNuoiAsync(list, streamExport, DanhMucGiong.Name);
                var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
                using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
                {
                    streamExport.CopyTo(stream);
                }
                result = GlobalHelper.APISite + "/" + GlobalHelper.Download + "/" + fileName;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
        private async Task<int> InitializationExcelToChucHoNuoiAsync(List<ToChuc> list, MemoryStream streamExport, string DanhMucToChucName)
        {
            int result = GlobalHelper.InitializationNumber;
            using (var package = new ExcelPackage(streamExport))
            {
                var workSheet = package.Workbook.Worksheets.Add(DanhMucToChucName);
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "STT";
                column = column + 1;
                workSheet.Cells[row, column].Value = "ID";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Họ tên";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại thuỷ sản";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ hộ nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Họ tên chủ đất";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ chủ đất";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích đất nuôi trồng thủy sản (ha)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích đang nuôi (ha)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số ao nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Hình thức";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số lượng giống thả (triệu con)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Sản lượng (tấn)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số lượng bệnh (triệu con)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ngày TTB";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Nguồn giống";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ghi chú";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Phường xã";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quận huyện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã hộ nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích thả (ha)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số nhà";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Hiện trạng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quy hoạch";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ khu";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên tổ chức";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Sản lượng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã chứng nhận";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Năm cấp VietGAP";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Vĩ độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Status";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Theo tiêu chuẩn VIETGAP";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích thu (ha)";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích bệnh (ha)";
                column = column + 1;

                for (int i = 1; i < column; i++)
                {
                    workSheet.Cells[row, i].Style.Font.Bold = true;
                    workSheet.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[row, i].Style.Font.Size = 14;
                    workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                row = row + 1;
                int stt = 1;
                List<ToChuc> ListToChuc = await _ToChucService.GetAllToListAsync();
                List<ToChucQuanLy> ListToChucQuanLy = await _ToChucQuanLyService.GetAllToListAsync();
                List<ToChucTieuChuan> ListToChucTieuChuan = await _ToChucTieuChuanService.GetAllToListAsync();
                foreach (ToChuc item in list)
                {
                    try
                    {

                        workSheet.Cells[row, 1].Value = stt;
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 2].Value = item.ID;
                        workSheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        workSheet.Cells[row, 3].Value = item.Name;
                        workSheet.Cells[row, 4].Value = item.DanhMucGiongName;
                        workSheet.Cells[row, 5].Value = item.DanhMucLoaiGiongName;
                        workSheet.Cells[row, 6].Value = item.DiaChi;
                        workSheet.Cells[row, 7].Value = item.ChuDatHoTen;
                        workSheet.Cells[row, 8].Value = item.ChuDatDiaChi;
                        workSheet.Cells[row, 9].Value = item.DienTichNuoiTrongThuySan;
                        workSheet.Cells[row, 10].Value = item.DienTichNuoi;
                        workSheet.Cells[row, 11].Value = item.AoNuoi;
                        workSheet.Cells[row, 12].Value = item.HinhThucNuoi;
                        workSheet.Cells[row, 13].Value = item.SoLuongGiongTha;
                        workSheet.Cells[row, 14].Value = item.SanLuong;
                        workSheet.Cells[row, 15].Value = item.SoLuongBenh;
                        workSheet.Cells[row, 16].Value = item.NgayTTB;
                        workSheet.Cells[row, 17].Value = item.NguonGiong;
                        workSheet.Cells[row, 18].Value = item.Note;
                        workSheet.Cells[row, 19].Value = item.DanhMucXaPhuongName;
                        workSheet.Cells[row, 20].Value = item.DanhMucQuanHuyenName;
                        workSheet.Cells[row, 21].Value = item.Code;
                        workSheet.Cells[row, 22].Value = item.DienTichTha;
                        workSheet.Cells[row, 23].Value = item.SoNha;
                        workSheet.Cells[row, 24].Value = item.DuongPho;
                        workSheet.Cells[row, 25].Value = item.HienTrang;
                        workSheet.Cells[row, 26].Value = item.QuyHoach;
                        workSheet.Cells[row, 27].Value = item.DiaChiKhu;

                        try
                        {
                            ToChucQuanLy ToChucQuanLy = ListToChucQuanLy.Where(obj => obj.ParentID == item.ID).FirstOrDefault();
                            if (ToChucQuanLy == null)
                            {
                                ToChucQuanLy = new ToChucQuanLy();
                            }
                            if (ToChucQuanLy.ToChucID > 0)
                            {
                                ToChuc ToChucHopTacXa = ListToChuc.Where(obj => obj.ID == ToChucQuanLy.ToChucID).FirstOrDefault(); ;
                                workSheet.Cells[row, 28].Value = ToChucHopTacXa.Name;
                                workSheet.Cells[row, 29].Value = ToChucHopTacXa.DienTichNuoiTrongThuySan;
                                workSheet.Cells[row, 30].Value = ToChucHopTacXa.DanhMucGiongName;
                                workSheet.Cells[row, 31].Value = ToChucHopTacXa.SanLuong;
                            }
                        }
                        catch (Exception ex)
                        {
                            string mes = ex.Message;
                        }

                        try
                        {
                            ToChucTieuChuan ToChucTieuChuan = ListToChucTieuChuan.Where(obj => obj.ParentID == item.ID).FirstOrDefault();
                            if (ToChucTieuChuan == null)
                            {
                                ToChucTieuChuan = new ToChucTieuChuan();
                            }
                            workSheet.Cells[row, 32].Value = ToChucTieuChuan.Name;
                            workSheet.Cells[row, 33].Value = ToChucTieuChuan.NamGhiNhan;
                            workSheet.Cells[row, 37].Value = ToChucTieuChuan.Active;
                        }
                        catch (Exception ex)
                        {
                            string mes = ex.Message;
                        }

                        workSheet.Cells[row, 34].Value = item.KinhDo;
                        workSheet.Cells[row, 35].Value = item.ViDo;
                        workSheet.Cells[row, 36].Value = item.Active;

                        workSheet.Cells[row, 38].Value = item.DienTichThuHoach;
                        workSheet.Cells[row, 39].Value = item.DienTichBenh;

                        for (int i = 1; i < column; i++)
                        {
                            workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                            workSheet.Cells[row, i].Style.Font.Size = 14;
                            workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        }
                        stt = stt + 1;
                        row = row + 1;
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }

                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;
            return result;
        }

        private async Task<int> InitializationExcelToChucCuaHangAsync(List<ToChuc> list, MemoryStream streamExport, string DanhMucToChucName)
        {
            int result = GlobalHelper.InitializationNumber;
            using (var package = new ExcelPackage(streamExport))
            {
                var workSheet = package.Workbook.Worksheets.Add(DanhMucToChucName);
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "STT";
                column = column + 1;
                workSheet.Cells[row, column].Value = "ID";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên cơ sở";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên chủ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại cửa hàng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số nhà";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Phường xã";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quận huyện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Điện thoại";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Giống nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Đối tượng nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số hộ nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Hình thức nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã phường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã quận";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại cửa hàng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại hình";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Danh sách sản phẩm kinh doanh";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Người đại diện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Danh mục lưu hành";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Geom";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại cửa hàng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Status";
                column = column + 1;


                for (int i = 1; i < column; i++)
                {
                    workSheet.Cells[row, i].Style.Font.Bold = true;
                    workSheet.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[row, i].Style.Font.Size = 14;
                    workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                row = row + 1;
                int stt = 1;

                foreach (ToChuc item in list)
                {
                    try
                    {

                        workSheet.Cells[row, 1].Value = stt;
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 2].Value = item.ID;
                        workSheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        workSheet.Cells[row, 3].Value = item.Name;
                        workSheet.Cells[row, 4].Value = item.ChuDatHoTen;
                        workSheet.Cells[row, 5].Value = item.DanhMucCuaHangName;
                        workSheet.Cells[row, 6].Value = item.DiaChi;
                        workSheet.Cells[row, 7].Value = item.SoNha;
                        workSheet.Cells[row, 8].Value = item.DuongPho;
                        workSheet.Cells[row, 9].Value = item.DanhMucXaPhuongName;
                        workSheet.Cells[row, 10].Value = item.DanhMucQuanHuyenName;
                        workSheet.Cells[row, 11].Value = item.DienThoai;
                        workSheet.Cells[row, 12].Value = item.DanhMucGiongName;
                        workSheet.Cells[row, 13].Value = item.DanhMucLoaiGiongName;
                        workSheet.Cells[row, 14].Value = item.Note;
                        workSheet.Cells[row, 15].Value = item.HinhThucNuoi;
                        workSheet.Cells[row, 16].Value = item.DienTichNuoiTrongThuySan;
                        workSheet.Cells[row, 17].Value = item.DanhMucXaPhuongID;
                        workSheet.Cells[row, 18].Value = item.DanhMucQuanHuyenID;
                        workSheet.Cells[row, 19].Value = item.DanhMucCuaHangID;
                        workSheet.Cells[row, 20].Value = item.ParentName;
                        workSheet.Cells[row, 21].Value = item.DanhMucNguyenVatLieuName;
                        workSheet.Cells[row, 22].Value = item.ChuDatDiaChi;
                        workSheet.Cells[row, 23].Value = item.Description;
                        workSheet.Cells[row, 24].Value = item.Geom;
                        workSheet.Cells[row, 25].Value = item.KinhDo;
                        workSheet.Cells[row, 26].Value = item.ViDo;
                        workSheet.Cells[row, 27].Value = item.Active;



                        for (int i = 1; i < column; i++)
                        {
                            workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                            workSheet.Cells[row, i].Style.Font.Size = 14;
                            workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        }
                        stt = stt + 1;
                        row = row + 1;
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }

                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;
            return result;
        }
        private async Task<int> InitializationExcelToChucTramQuanTracAsync(List<ToChuc> list, MemoryStream streamExport, string DanhMucToChucName)
        {
            int result = GlobalHelper.InitializationNumber;
            using (var package = new ExcelPackage(streamExport))
            {
                var workSheet = package.Workbook.Worksheets.Add(DanhMucToChucName);
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "STT";
                column = column + 1;
                workSheet.Cells[row, column].Value = "ID";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Geom";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên điểm";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại mẫu";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ký hiệu";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Khối lượng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã phường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã quận";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Phường xã";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quận huyện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Vĩ độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Status";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số nhà";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đường";
                column = column + 1;

                for (int i = 1; i < column; i++)
                {
                    workSheet.Cells[row, i].Style.Font.Bold = true;
                    workSheet.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[row, i].Style.Font.Size = 14;
                    workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                row = row + 1;
                int stt = 1;

                foreach (ToChuc item in list)
                {
                    try
                    {

                        workSheet.Cells[row, 1].Value = stt;
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 2].Value = item.ID;
                        workSheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        workSheet.Cells[row, 3].Value = item.Geom;
                        workSheet.Cells[row, 4].Value = item.Name;
                        workSheet.Cells[row, 5].Value = item.DiaChi;
                        workSheet.Cells[row, 6].Value = item.Description;
                        workSheet.Cells[row, 7].Value = item.Display;
                        workSheet.Cells[row, 8].Value = item.SanLuong;
                        workSheet.Cells[row, 9].Value = item.DanhMucXaPhuongID;
                        workSheet.Cells[row, 10].Value = item.DanhMucQuanHuyenID;
                        workSheet.Cells[row, 11].Value = item.DanhMucXaPhuongName;
                        workSheet.Cells[row, 12].Value = item.DanhMucQuanHuyenName;
                        workSheet.Cells[row, 13].Value = item.KinhDo;
                        workSheet.Cells[row, 14].Value = item.ViDo;
                        workSheet.Cells[row, 15].Value = item.Active;
                        workSheet.Cells[row, 16].Value = item.SoNha;
                        workSheet.Cells[row, 17].Value = item.DuongPho;



                        for (int i = 1; i < column; i++)
                        {
                            workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                            workSheet.Cells[row, i].Style.Font.Size = 14;
                            workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        }
                        stt = stt + 1;
                        row = row + 1;
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }

                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;
            return result;
        }
        private async Task<int> InitializationExcelToChucPhuongTienKhaiThacAsync(List<ToChuc> list, MemoryStream streamExport, string DanhMucToChucName)
        {
            int result = GlobalHelper.InitializationNumber;
            using (var package = new ExcelPackage(streamExport))
            {
                var workSheet = package.Workbook.Worksheets.Add(DanhMucToChucName);
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "STT";
                column = column + 1;
                workSheet.Cells[row, column].Value = "ID";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Họ tên chủ tàu";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số đăng ký";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số nhà";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tổ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Khu phố";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Phường xã";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quận huyện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Chiều cao";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Chiều rộng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Chiều dài";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Dung tích";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Hiệu máy";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Công suất";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Nghề";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số thuyền viên";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ngày đăng ký";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Hạn đăng kiểm";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ghi chú";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Vĩ độ";
                column = column + 1;

                for (int i = 1; i < column; i++)
                {
                    workSheet.Cells[row, i].Style.Font.Bold = true;
                    workSheet.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[row, i].Style.Font.Size = 14;
                    workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                row = row + 1;
                int stt = 1;

                List<ToChucPhuongTienKhaiThac> ListToChucPhuongTienKhaiThac = await _ToChucPhuongTienKhaiThacService.GetAllToListAsync();

                foreach (ToChuc item in list)
                {
                    try
                    {

                        workSheet.Cells[row, 1].Value = stt;
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 2].Value = item.ID;
                        workSheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        workSheet.Cells[row, 3].Value = item.Name;
                        workSheet.Cells[row, 4].Value = item.Code;
                        workSheet.Cells[row, 5].Value = item.SoNha;
                        workSheet.Cells[row, 6].Value = item.DuongPho;
                        workSheet.Cells[row, 7].Value = item.DiaChi;
                        workSheet.Cells[row, 8].Value = item.ApThon;
                        workSheet.Cells[row, 9].Value = item.DanhMucXaPhuongName;
                        workSheet.Cells[row, 10].Value = item.DanhMucQuanHuyenName;
                        ToChucPhuongTienKhaiThac ToChucPhuongTienKhaiThac = ListToChucPhuongTienKhaiThac.Where(x => x.ParentID == item.ID).FirstOrDefault();
                        if (ToChucPhuongTienKhaiThac == null)
                        {
                            ToChucPhuongTienKhaiThac = new ToChucPhuongTienKhaiThac();
                        }
                        workSheet.Cells[row, 11].Value = ToChucPhuongTienKhaiThac.ChieuCao;
                        workSheet.Cells[row, 12].Value = ToChucPhuongTienKhaiThac.ChieuRong;
                        workSheet.Cells[row, 13].Value = ToChucPhuongTienKhaiThac.ChieuDai;
                        workSheet.Cells[row, 14].Value = ToChucPhuongTienKhaiThac.DungTich;
                        workSheet.Cells[row, 15].Value = ToChucPhuongTienKhaiThac.DanhMucHieuMayName;
                        workSheet.Cells[row, 16].Value = ToChucPhuongTienKhaiThac.CongSuat;
                        workSheet.Cells[row, 17].Value = ToChucPhuongTienKhaiThac.DanhMucNganhNgheName;
                        workSheet.Cells[row, 18].Value = ToChucPhuongTienKhaiThac.ThuyenVien;
                        workSheet.Cells[row, 19].Value = ToChucPhuongTienKhaiThac.NgayDangKy;
                        workSheet.Cells[row, 20].Value = ToChucPhuongTienKhaiThac.HanDangKiem;

                        workSheet.Cells[row, 21].Value = item.Note;
                        workSheet.Cells[row, 22].Value = item.KinhDo;
                        workSheet.Cells[row, 23].Value = item.ViDo;




                        for (int i = 1; i < column; i++)
                        {
                            workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                            workSheet.Cells[row, i].Style.Font.Size = 14;
                            workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        }
                        stt = stt + 1;
                        row = row + 1;
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }

                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;
            return result;
        }
        private async Task<int> InitializationExcelToChucGiongAsync(List<ToChuc> list, MemoryStream streamExport, string DanhMucToChucName)
        {
            int result = GlobalHelper.InitializationNumber;
            using (var package = new ExcelPackage(streamExport))
            {
                var workSheet = package.Workbook.Worksheets.Add(DanhMucToChucName);
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "STT";
                column = column + 1;
                workSheet.Cells[row, column].Value = "ID";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã giống";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đơn vị";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Điện thoại";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên giống thuỷ sản";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Diện tích";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Sản lượng";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Ghi chú";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Kinh độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Vĩ độ";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Geom";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Số nhà";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Tên đường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Khu vực nuôi";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại hình cơ sở";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Loại giống";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Đối tượng sản xuất";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã phường";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Mã quận";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Phường xã";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Quận huyện";
                column = column + 1;
                workSheet.Cells[row, column].Value = "Status";
                column = column + 1;

                for (int i = 1; i < column; i++)
                {
                    workSheet.Cells[row, i].Style.Font.Bold = true;
                    workSheet.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[row, i].Style.Font.Size = 14;
                    workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                row = row + 1;
                int stt = 1;                

                foreach (ToChuc item in list)
                {
                    try
                    {

                        workSheet.Cells[row, 1].Value = stt;
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 2].Value = item.ID;
                        workSheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        workSheet.Cells[row, 3].Value = item.Code;
                        workSheet.Cells[row, 4].Value = item.Name;
                        workSheet.Cells[row, 5].Value = item.DiaChi;
                        workSheet.Cells[row, 6].Value = item.DienThoai;
                        workSheet.Cells[row, 7].Value = item.Description;
                        workSheet.Cells[row, 8].Value = item.DienTichNuoiTrongThuySan;
                        workSheet.Cells[row, 9].Value = item.Display;             
                        workSheet.Cells[row, 10].Value = item.Note;
                        workSheet.Cells[row, 11].Value = item.KinhDo;
                        workSheet.Cells[row, 12].Value = item.ViDo;
                        workSheet.Cells[row, 13].Value = item.Geom;
                        workSheet.Cells[row, 14].Value = item.SoNha;
                        workSheet.Cells[row, 15].Value = item.DuongPho;
                        workSheet.Cells[row, 16].Value = item.DiaChiKhu;
                        workSheet.Cells[row, 17].Value = item.DanhMucLoaiHinhName;
                        workSheet.Cells[row, 18].Value = item.DanhMucLoaiGiongName;
                        workSheet.Cells[row, 19].Value = item.DanhMucGiongName;
                        workSheet.Cells[row, 20].Value = item.DanhMucXaPhuongID;
                        workSheet.Cells[row, 21].Value = item.DanhMucQuanHuyenID;
                        workSheet.Cells[row, 22].Value = item.DanhMucXaPhuongName;
                        workSheet.Cells[row, 23].Value = item.DanhMucQuanHuyenName;
                        workSheet.Cells[row, 24].Value = item.Active;

                        for (int i = 1; i < column; i++)
                        {
                            workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                            workSheet.Cells[row, i].Style.Font.Size = 14;
                            workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        }
                        stt = stt + 1;
                        row = row + 1;
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }

                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;
            return result;
        }
    }
}


