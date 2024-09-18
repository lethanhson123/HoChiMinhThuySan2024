namespace Service.Implement
{
    public class ThanhVienService : BaseService<ThanhVien, IThanhVienRepository>
    , IThanhVienService
    {
        private readonly IThanhVienRepository _ThanhVienRepository;

        private readonly IWebHostEnvironment _WebHostEnvironment;

        private readonly IThanhVienTokenService _ThanhVienTokenService;


        private readonly IDanhMucThanhVienService _DanhMucThanhVienService;
        private readonly IDanhMucNgonNguService _DanhMucNgonNguService;

        private readonly IToChucService _ToChucService;

        public ThanhVienService(IThanhVienRepository ThanhVienRepository

            , IWebHostEnvironment WebHostEnvironment

            , IThanhVienTokenService ThanhVienTokenService

            , IDanhMucThanhVienService DanhMucThanhVienService
            , IDanhMucNgonNguService DanhMucNgonNguService

            , IToChucService ToChucService

            ) : base(ThanhVienRepository)
        {
            _ThanhVienRepository = ThanhVienRepository;

            _WebHostEnvironment = WebHostEnvironment;

            _ThanhVienTokenService = ThanhVienTokenService;
            _DanhMucThanhVienService = DanhMucThanhVienService;
            _DanhMucNgonNguService = DanhMucNgonNguService;

            _ToChucService = ToChucService;
        }
        public override void Initialization(ThanhVien model)
        {
            BaseInitialization(model);
            if (string.IsNullOrEmpty(model.TaiKhoan))
            {
                model.TaiKhoan = GlobalHelper.InitializationGUICode;
            }
            if (string.IsNullOrEmpty(model.TaiKhoan))
            {
                model.TaiKhoan = model.Code;
            }
            if (string.IsNullOrEmpty(model.TaiKhoan))
            {
                model.TaiKhoan = model.CCCD;
            }
            if (string.IsNullOrEmpty(model.GUIDCode))
            {
                model.GUIDCode = GlobalHelper.InitializationGUICode;
            }
            if (string.IsNullOrEmpty(model.MatKhau))
            {
                model.MatKhau = GlobalHelper.MatKhauMacDinh;
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                model.Email = model.TaiKhoan;
            }
            if (!string.IsNullOrEmpty(model.DienThoai))
            {
                model.DienThoai = model.DienThoai.Replace(@"'",@"");
            }
            if (!string.IsNullOrEmpty(model.CCCD))
            {
                model.CCCD = model.CCCD.Replace(@"'", @"");
            }
            if (string.IsNullOrEmpty(model.TypeName))
            {
                model.TypeName = GlobalHelper.CMSSite;
            }
            if (model.ParentID == null)
            {
                model.ParentID = GlobalHelper.DanhMucThanhVienID;
            }
            if (model.DanhMucQuocGiaID == null)
            {
                model.DanhMucQuocGiaID = GlobalHelper.DanhMucQuocGiaIDVietNam;
            }
            if (model.DanhMucTinhThanhID == null)
            {
                model.DanhMucTinhThanhID = GlobalHelper.DanhMucTinhThanhID;
            }
            if (model.DanhMucQuanHuyenID == null)
            {
                model.DanhMucQuanHuyenID = GlobalHelper.DanhMucQuanHuyenID;
            }
            if (model.DanhMucUngDungID == null)
            {
                model.DanhMucUngDungID = GlobalHelper.DanhMucUngDungID;
            }
            if (model.DanhMucNgonNguID == null)
            {
                if (!string.IsNullOrEmpty(model.DanhMucNgonNguName))
                {
                    DanhMucNgonNgu DanhMucNgonNgu = _DanhMucNgonNguService.GetByName(model.DanhMucNgonNguName);
                    if (DanhMucNgonNgu.ID == 0)
                    {
                        DanhMucNgonNgu = new DanhMucNgonNgu();
                        DanhMucNgonNgu.Name = model.DanhMucNgonNguName;
                        _DanhMucNgonNguService.Save(DanhMucNgonNgu);
                    }
                    model.DanhMucNgonNguID = DanhMucNgonNgu.ID;
                }
            }

            if (model.ParentID > 0)
            {
                if (string.IsNullOrEmpty(model.ParentName))
                {
                    model.ParentName = _DanhMucThanhVienService.GetByID(model.ParentID.Value).Name;
                }
            }
        }
        public override async Task<ThanhVien> SaveAsync(ThanhVien model)
        {
            int result = await SaveSubAsync(model);
            if (result > 0)
            {
                await Sync(model);
                await SendMailAsync(model);
            }
            return model;
        }
        public virtual async Task<ThanhVien> SaveSyncAsync(ThanhVien model)
        {
            int result = await SaveSubAsync(model);
            return model;
        }
        public virtual async Task<int> Update001Async(ThanhVien model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (model.ID > 0)
            {
                result = await _ThanhVienRepository.UpdateAsync(model);
            }
            return result;
        }
        private async Task<int> Sync(ThanhVien model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (model != null)
            {
                if (model.ID > 0)
                {

                }
            }
            return result;
        }
        private async Task<int> SaveSubAsync(ThanhVien model)
        {
            int result = GlobalHelper.InitializationNumber;
            bool isSave = true;
            Initialization(model);
            if (string.IsNullOrEmpty(model.TaiKhoan))
            {
                isSave = false;
            }
            ThanhVien modelExist = await GetByCondition(item => item.TaiKhoan == model.TaiKhoan).FirstOrDefaultAsync();
            if (modelExist != null)
            {
                if (modelExist.ID != model.ID)
                {
                    isSave = false;
                }
            }
            if (isSave == true)
            {
                if (model.ID > 0)
                {
                    if (model.MatKhau != modelExist.MatKhau)
                    {
                        model.MatKhau = SecurityHelper.Encrypt(model.GUIDCode, model.MatKhau);
                    }
                    if (string.IsNullOrEmpty(model.Note))
                    {
                        model.Note = modelExist.Note;
                    }
                    if (model.Active == null)
                    {
                        model.Active = modelExist.Active;
                    }
                    result = await UpdateAsync(model);
                }
                else
                {
                    model.MatKhau = SecurityHelper.Encrypt(model.GUIDCode, model.MatKhau);
                    result = await AddAsync(model);
                }
                if (result > 0)
                {
                }
            }
            return result;
        }
        private async Task<string> SendMailAsync(ThanhVien model)
        {
            string result = GlobalHelper.InitializationString;
            try
            {
                if (model != null)
                {
                    if (model.ID > 0)
                    {
                        if (model.Active == true)
                        {

                            Helper.Model.Mail mail = new Helper.Model.Mail();
                            mail.MailFrom = GlobalHelper.MasterEmailUser;
                            mail.UserName = GlobalHelper.MasterEmailUser;
                            mail.Password = GlobalHelper.MasterEmailPassword;
                            mail.SMTPPort = GlobalHelper.SMTPPort;
                            mail.SMTPServer = GlobalHelper.SMTPServer;
                            mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                            mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                            mail.Display = GlobalHelper.MasterEmailDisplay;
                            mail.Subject = "Tài khoản [" + model.TaiKhoan + "] thay đổi lúc - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss") + " | " + GlobalHelper.PageTitle;
                            string contentHTML = GlobalHelper.InitializationString;
                            var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "ThanhVien.html");
                            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
                            {
                                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                                {
                                    contentHTML = r.ReadToEnd();
                                }
                            }
                            contentHTML = contentHTML.Replace("[TaiKhoan]", model.TaiKhoan);
                            contentHTML = contentHTML.Replace("[Name]", model.Name);
                            contentHTML = contentHTML.Replace("[DienThoai]", model.DienThoai);
                            contentHTML = contentHTML.Replace("[PageTitle]", GlobalHelper.PageTitle);
                            mail.Content = contentHTML;

                            if (!string.IsNullOrEmpty(model.Email))
                            {
                                mail.Content = contentHTML;
                                mail.MailTo = model.Email;
                                MailHelper.SendMail(mail);
                            }

                            List<ThanhVien> ListThanhVien = await GetByParentIDAndActiveToListAsync(1, true);

                            foreach (ThanhVien ThanhVien in ListThanhVien)
                            {
                                if (!string.IsNullOrEmpty(ThanhVien.Email))
                                {
                                    mail.Content = contentHTML;
                                    mail.MailTo = ThanhVien.Email;
                                    MailHelper.SendMail(mail);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual async Task<ThanhVien> ChangePasswordAsync(ThanhVien model, string password01, string password02, string password03)
        {
            bool isSave = true;
            ThanhVien modelExist = await GetByCondition(item => item.TaiKhoan == model.TaiKhoan).FirstOrDefaultAsync();
            if (modelExist != null)
            {
                if (modelExist.ID != model.ID)
                {
                    isSave = false;
                }
            }
            if (isSave == true)
            {
                if (model.ID > 0)
                {
                    string passwordEncrypt = SecurityHelper.Encrypt(modelExist.GUIDCode, password01);
                    if (passwordEncrypt == modelExist.MatKhau)
                    {
                        if (password02 == password03)
                        {
                            modelExist.MatKhau = SecurityHelper.Encrypt(modelExist.GUIDCode, password02);
                            await UpdateAsync(modelExist);
                        }
                    }
                }
            }
            return model;
        }
        public virtual async Task<ThanhVien> AuthenticationAsync(ThanhVien model)
        {
            ThanhVien result = new ThanhVien();
            if (!string.IsNullOrEmpty(model.TaiKhoan) && !string.IsNullOrEmpty(model.MatKhau))
            {
                result = await GetByCondition(item => item.Active == true && item.TaiKhoan == model.TaiKhoan).FirstOrDefaultAsync();
                bool check = false;
                if (result != null)
                {
                    string passwordDecrypt = SecurityHelper.Decrypt(result.GUIDCode, result.MatKhau);
                    if (passwordDecrypt.Equals(model.MatKhau))
                    {
                        check = true;
                    }
                }
                if (check == true)
                {

                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, GlobalHelper.Subject),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("ID", result.ID.ToString())
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalHelper.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        GlobalHelper.Issuer,
                        GlobalHelper.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddDays(GlobalHelper.TokenThoiGianHieuLuc),
                        signingCredentials: signIn
                    );

                    ThanhVienToken thanhVienToken = new ThanhVienToken();
                    thanhVienToken.Note = model.Note;
                    thanhVienToken.ParentID = result.ID;
                    thanhVienToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    thanhVienToken.BatDau = GlobalHelper.InitializationDateTime;
                    thanhVienToken.KetThuc = thanhVienToken.BatDau.Value.AddDays(GlobalHelper.TokenThoiGianHieuLuc);
                    thanhVienToken.Active = true;
                    await _ThanhVienTokenService.SaveAsync(thanhVienToken);
                    if (thanhVienToken.ID > 0)
                    {
                        result.Note = result.TypeName + "Homepage?" + GlobalHelper.AuthenticationToken + "=" + thanhVienToken.Token;
                        result.HTMLContent = thanhVienToken.Token;
                    }
                }
                else
                {
                    result = new ThanhVien();
                }
            }
            return result;
        }
        public virtual async Task<ThanhVien> AuthenticationMobileAsync(string username, string password)
        {
            ThanhVien result = new ThanhVien();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                result = await GetByCondition(item => item.Active == true && item.TaiKhoan == username).FirstOrDefaultAsync();
                bool check = false;
                if (result != null)
                {
                    string passwordDecrypt = SecurityHelper.Decrypt(result.GUIDCode, result.MatKhau);
                    if (passwordDecrypt.Equals(password))
                    {
                        check = true;
                    }
                }
                if (check == true)
                {

                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, GlobalHelper.Subject),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("ID", result.ID.ToString())
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalHelper.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        GlobalHelper.Issuer,
                        GlobalHelper.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddDays(GlobalHelper.TokenThoiGianHieuLuc),
                        signingCredentials: signIn
                    );

                    ThanhVienToken thanhVienToken = new ThanhVienToken();
                    //thanhVienToken.Note = model.Note;
                    thanhVienToken.ParentID = result.ID;
                    thanhVienToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    thanhVienToken.BatDau = GlobalHelper.InitializationDateTime;
                    thanhVienToken.KetThuc = thanhVienToken.BatDau.Value.AddDays(GlobalHelper.TokenThoiGianHieuLuc);
                    thanhVienToken.Active = true;
                    await _ThanhVienTokenService.SaveAsync(thanhVienToken);
                    if (thanhVienToken.ID > 0)
                    {
                        result.Note = result.TypeName + "Homepage?" + GlobalHelper.AuthenticationToken + "=" + thanhVienToken.Token;
                        result.HTMLContent = thanhVienToken.Token;
                    }
                }
                else
                {
                    result = new ThanhVien();
                }
            }
            return result;
        }
        public virtual async Task<ThanhVien> GetByDienThoaiAsync(string DienThoai)
        {
            ThanhVien result = new ThanhVien();
            if (!string.IsNullOrEmpty(DienThoai))
            {
                result = await GetByCondition(item => item.DienThoai == DienThoai).FirstOrDefaultAsync();
                if (result == null)
                {
                    result = new ThanhVien();
                }
            }
            return result;
        }
        public virtual async Task<ThanhVien> GetByCCCDAsync(string CCCD)
        {
            ThanhVien result = new ThanhVien();
            if (!string.IsNullOrEmpty(CCCD))
            {
                result = await GetByCondition(item => item.CCCD == CCCD).FirstOrDefaultAsync();
                if (result == null)
                {
                    result = new ThanhVien();
                }
            }
            return result;
        }
        public virtual async Task<List<ThanhVien>> GetFromThanhVienThongBaoByDanhMucUngDungIDAndActiveAsync(long DanhMucUngDungID, bool Active)
        {
            List<ThanhVien> result = new List<ThanhVien>();
            if (DanhMucUngDungID > 0)
            {
            }
            if (result == null)
            {
                result = new List<ThanhVien>();
            }
            return result;
        }

        public virtual async Task<int> SyncFromToChucAsync()
        {
            int result = GlobalHelper.InitializationNumber;
            List<ToChuc> ListToChuc = await _ToChucService.GetAllToListAsync();
            foreach (ToChuc ToChuc in ListToChuc)
            {
                ThanhVien ThanhVien = new ThanhVien();
                ThanhVien.ToChucID = ToChuc.ID;
                ThanhVien.ToChucName = ToChuc.Name;
                ThanhVien.TaiKhoan = ToChuc.Code;
                ThanhVien.DienThoai = ToChuc.DienThoai;
                ThanhVien.Email = ToChuc.Email;
                await SaveAsync(ThanhVien);
            }
            return result;
        }


    }
}

