namespace Helper
{
	public class GlobalHelper
	{
		#region Initialization
		public static bool InitializationBool
		{
			get
			{
				return true;
			}
		}
		public static string InitializationString
		{
			get
			{
				return string.Empty;
			}
		}
		public static DateTime InitializationDateTime
		{
			get
			{
				return DateTime.Now;
			}
		}
		public static DateTime DateTimeBegin
		{
			get
			{
				return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
			}
		}
		public static DateTime DateTimeEnd
		{
			get
			{
				return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
			}
		}
        public static string InitializationMaSo
        {
            get
            {
                return "00000000";
            }
        }

        public static string ConstParentName
        {
            get
            {
                return "Nông hộ";
            }
        }

        public static string StatusCodeMessageCreated
        {
            get
            {
                return "Số Lượng Khảo Sát Đồng Bộ Thành Công :";
            }
        }

        public static string StatusCodeMessageCreatedFaile
        {
            get
            {
                return "Số Lượng Khảo Sát Đồng Bộ Không Thành Công :";
            }
        }
        public static string InitializationGUICode
		{
			get
			{
				return Guid.NewGuid().ToString();
			}
		}
		public static string InitializationDateTimeCode
		{
			get
			{
				return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Ticks.ToString();
			}
		}
		public static string InitializationDateTimeCode0001
		{
			get
			{
				return DateTime.Now.ToString("yyyyMMddHHmmss");
			}
		}
		public static int InitializationNumber
		{
			get
			{
				return 0;
			}
		}
		public static int InitializationSortOrder
		{
			get
			{
				return -1;
			}
		}
        #endregion
        #region JWT   	
        public static string Key
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Jwt").GetSection("Key").Value;
            }
        }
        public static string Issuer
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Jwt").GetSection("Issuer").Value;
            }
        }
        public static string Audience
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Jwt").GetSection("Audience").Value;
            }
        }
        public static string Subject
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Jwt").GetSection("Subject").Value;
            }
        }
        #endregion
        #region AppSettings 
        public static string TokenDefault
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TokenDefault").Value;
            }
        }
        public static string TokenAuthentication
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TokenAuthentication").Value;
            }
        }
        public static string TruyXuatNguonGocAPIURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TruyXuatNguonGocAPIURL").Value;
            }
        }
        public static string TruyXuatNguonGocAPIRootURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TruyXuatNguonGocAPIRootURL").Value;
            }
        }
        public static string FTPFull
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("FTPFull").Value;
            }
        }
        public static string TraceabilitySite
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TraceabilitySite").Value;
            }
        }
        public static long DanhMucThanhVienIDQuanTri
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucThanhVienIDQuanTri").Value);
            }
        }
        public static long DanhMucThanhVienID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucThanhVienID").Value);
            }
        }
        public static long DanhMucUngDungID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucUngDungID").Value);
            }
        }
        public static long DanhMucToChucID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucToChucID").Value);
            }
        }
        public static long DanhMucQuocGiaIDVietNam
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucQuocGiaIDVietNam").Value);
            }
        }
        public static long DanhMucTinhThanhID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucTinhThanhID").Value);
            }
        }
        public static long DanhMucQuanHuyenID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return long.Parse(builder.Build().GetSection("AppSettings").GetSection("DanhMucQuanHuyenID").Value);
            }
        }
        public static int NamBatDau
		{
			get
			{
				var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NamBatDau").Value);
			}
		}        
        public static int NamKeThuc
		{
			get
			{
				var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NamKeThuc").Value);
			}
		}
        public static string Image
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Image").Value;
            }
        }
        public static string Download
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Download").Value;
            }
        }
        public static string HTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HTML").Value;
            }
        }
        public static string Upload
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Upload").Value;
            }
        }       
        public static int TokenThoiGianHieuLuc
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("TokenThoiGianHieuLuc").Value);
            }
        }
        public static int RowCount
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("RowCount").Value);
            }
        }
        public static string AuthenticationToken
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AuthenticationToken").Value;
            }
        }
        public static string MatKhauMacDinh
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MatKhauMacDinh").Value;
            }
        }
        public static int NotificationCount
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NotificationCount").Value);
            }
        }
        public static string SMTPServer
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SMTPServer").Value;
            }
        }
        public static int SMTPPort
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("SMTPPort").Value);
            }
        }
        public static int IsMailUsingSSL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("IsMailUsingSSL").Value);
            }
        }
        public static int IsMailBodyHtml
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("IsMailBodyHtml").Value);
            }
        }
        public static string MasterEmailUser
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailUser").Value;
            }
        }
        public static string MasterEmailPassword
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailPassword").Value;
            }
        }
        public static string MasterEmailDisplay
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailDisplay").Value;
            }
        }       
        public static string APISite
		{
			get
			{
				var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				return builder.Build().GetSection("AppSettings").GetSection("APISite").Value;
			}
		}
		public static string CMSSite
		{
			get
			{
				var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				return builder.Build().GetSection("AppSettings").GetSection("CMSSite").Value;
			}
		}		
		public static string SQLServerConectionString
		{
			get
			{
				var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				return builder.Build().GetSection("AppSettings").GetSection("SQLServerConectionString").Value;
			}
		}
        public static string DomainName
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainName").Value;
            }
        }
        public static string DomainURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURL").Value;
            }
        }
        public static string DomainURLSub
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURLSub").Value;
            }
        }
        public static string DomainOnlineURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainOnlineURL").Value;
            }
        }
        public static string DomainOnlineEnglishURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainOnlineEnglishURL").Value;
            }
        }
        public static string APIURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APIURL").Value;
            }
        }
        public static string PageTitle
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageTitle").Value;
            }
        }
        public static string PageDescription
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageDescription").Value;
            }
        }
        public static string PageKeywords
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageKeywords").Value;
            }
        }
        public static string PageTags
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageTags").Value;
            }
        }
        public static string LogoFileName
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LogoFileName").Value;
            }
        }
        public static string LogoIcon
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LogoIcon").Value;
            }
        }
        public static string Facebook
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Facebook").Value;
            }
        }
        public static string Twitter
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Twitter").Value;
            }
        }
        public static string Instagram
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Instagram").Value;
            }
        }
        public static string Youtube
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Youtube").Value;
            }
        }
        public static string Tiktok
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Tiktok").Value;
            }
        }
        public static string Blogs
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Blogs").Value;
            }
        }
        public static string Blog
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Blog").Value;
            }
        }
        public static string Tag
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Tag").Value;
            }
        }
        public static string LogoURL
        {
            get
            {
                return DomainURL + Image + @"/" + LogoFileName;
            }
        }
        public static string LogoIconURL
        {
            get
            {
                return DomainURL + Image + @"/" + LogoIcon;
            }
        }
        #endregion
        #region Functions
        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length.");

            return Enumerable.Range(0, hex.Length / 2)
                             .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                             .ToArray();
        }
        public static string InitializationURLCode(string URLCode)
		{
			URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
			URLCode = URLCode.Split('.')[0];
			URLCode = URLCode.Replace(@".html", @"");
			return URLCode;
		}
		public static string SetName(string fileName)
		{
			string fileNameReturn = fileName;
			if (!string.IsNullOrEmpty(fileNameReturn))
			{
				fileNameReturn = fileNameReturn.ToLower();
				fileNameReturn = fileNameReturn.Replace("’", "-");
				fileNameReturn = fileNameReturn.Replace("“", "-");
				fileNameReturn = fileNameReturn.Replace("--", "-");
				fileNameReturn = fileNameReturn.Replace("+", "-");
				fileNameReturn = fileNameReturn.Replace("/", "-");
				fileNameReturn = fileNameReturn.Replace(@"\", "-");
				fileNameReturn = fileNameReturn.Replace(":", "-");
				fileNameReturn = fileNameReturn.Replace(";", "-");
				fileNameReturn = fileNameReturn.Replace("%", "-");
				fileNameReturn = fileNameReturn.Replace("`", "-");
				fileNameReturn = fileNameReturn.Replace("~", "-");
				fileNameReturn = fileNameReturn.Replace("#", "-");
				fileNameReturn = fileNameReturn.Replace("$", "-");
				fileNameReturn = fileNameReturn.Replace("^", "-");
				fileNameReturn = fileNameReturn.Replace("&", "-");
				fileNameReturn = fileNameReturn.Replace("*", "-");
				fileNameReturn = fileNameReturn.Replace("(", "-");
				fileNameReturn = fileNameReturn.Replace(")", "-");
				fileNameReturn = fileNameReturn.Replace("|", "-");
				fileNameReturn = fileNameReturn.Replace("'", "-");
				fileNameReturn = fileNameReturn.Replace(",", "-");
				fileNameReturn = fileNameReturn.Replace(".", "-");
				fileNameReturn = fileNameReturn.Replace("?", "-");
				fileNameReturn = fileNameReturn.Replace("<", "-");
				fileNameReturn = fileNameReturn.Replace(">", "-");
				fileNameReturn = fileNameReturn.Replace("]", "-");
				fileNameReturn = fileNameReturn.Replace("[", "-");
				fileNameReturn = fileNameReturn.Replace(@"""", "-");
				fileNameReturn = fileNameReturn.Replace(@" ", "-");
				fileNameReturn = fileNameReturn.Replace("á", "a");
				fileNameReturn = fileNameReturn.Replace("à", "a");
				fileNameReturn = fileNameReturn.Replace("ả", "a");
				fileNameReturn = fileNameReturn.Replace("ã", "a");
				fileNameReturn = fileNameReturn.Replace("ạ", "a");
				fileNameReturn = fileNameReturn.Replace("ă", "a");
				fileNameReturn = fileNameReturn.Replace("ắ", "a");
				fileNameReturn = fileNameReturn.Replace("ằ", "a");
				fileNameReturn = fileNameReturn.Replace("ẳ", "a");
				fileNameReturn = fileNameReturn.Replace("ẵ", "a");
				fileNameReturn = fileNameReturn.Replace("ặ", "a");
				fileNameReturn = fileNameReturn.Replace("â", "a");
				fileNameReturn = fileNameReturn.Replace("ấ", "a");
				fileNameReturn = fileNameReturn.Replace("ầ", "a");
				fileNameReturn = fileNameReturn.Replace("ẩ", "a");
				fileNameReturn = fileNameReturn.Replace("ẫ", "a");
				fileNameReturn = fileNameReturn.Replace("ậ", "a");
				fileNameReturn = fileNameReturn.Replace("í", "i");
				fileNameReturn = fileNameReturn.Replace("ì", "i");
				fileNameReturn = fileNameReturn.Replace("ỉ", "i");
				fileNameReturn = fileNameReturn.Replace("ĩ", "i");
				fileNameReturn = fileNameReturn.Replace("ị", "i");
				fileNameReturn = fileNameReturn.Replace("ý", "y");
				fileNameReturn = fileNameReturn.Replace("ỳ", "y");
				fileNameReturn = fileNameReturn.Replace("ỷ", "y");
				fileNameReturn = fileNameReturn.Replace("ỹ", "y");
				fileNameReturn = fileNameReturn.Replace("ỵ", "y");
				fileNameReturn = fileNameReturn.Replace("ó", "o");
				fileNameReturn = fileNameReturn.Replace("ò", "o");
				fileNameReturn = fileNameReturn.Replace("ỏ", "o");
				fileNameReturn = fileNameReturn.Replace("õ", "o");
				fileNameReturn = fileNameReturn.Replace("ọ", "o");
				fileNameReturn = fileNameReturn.Replace("ô", "o");
				fileNameReturn = fileNameReturn.Replace("ố", "o");
				fileNameReturn = fileNameReturn.Replace("ồ", "o");
				fileNameReturn = fileNameReturn.Replace("ổ", "o");
				fileNameReturn = fileNameReturn.Replace("ỗ", "o");
				fileNameReturn = fileNameReturn.Replace("ộ", "o");
				fileNameReturn = fileNameReturn.Replace("ơ", "o");
				fileNameReturn = fileNameReturn.Replace("ớ", "o");
				fileNameReturn = fileNameReturn.Replace("ờ", "o");
				fileNameReturn = fileNameReturn.Replace("ở", "o");
				fileNameReturn = fileNameReturn.Replace("ỡ", "o");
				fileNameReturn = fileNameReturn.Replace("ợ", "o");
				fileNameReturn = fileNameReturn.Replace("ú", "u");
				fileNameReturn = fileNameReturn.Replace("ù", "u");
				fileNameReturn = fileNameReturn.Replace("ủ", "u");
				fileNameReturn = fileNameReturn.Replace("ũ", "u");
				fileNameReturn = fileNameReturn.Replace("ụ", "u");
				fileNameReturn = fileNameReturn.Replace("ư", "u");
				fileNameReturn = fileNameReturn.Replace("ứ", "u");
				fileNameReturn = fileNameReturn.Replace("ừ", "u");
				fileNameReturn = fileNameReturn.Replace("ử", "u");
				fileNameReturn = fileNameReturn.Replace("ữ", "u");
				fileNameReturn = fileNameReturn.Replace("ự", "u");
				fileNameReturn = fileNameReturn.Replace("é", "e");
				fileNameReturn = fileNameReturn.Replace("è", "e");
				fileNameReturn = fileNameReturn.Replace("ẻ", "e");
				fileNameReturn = fileNameReturn.Replace("ẽ", "e");
				fileNameReturn = fileNameReturn.Replace("ẹ", "e");
				fileNameReturn = fileNameReturn.Replace("ê", "e");
				fileNameReturn = fileNameReturn.Replace("ế", "e");
				fileNameReturn = fileNameReturn.Replace("ề", "e");
				fileNameReturn = fileNameReturn.Replace("ể", "e");
				fileNameReturn = fileNameReturn.Replace("ễ", "e");
				fileNameReturn = fileNameReturn.Replace("ệ", "e");
				fileNameReturn = fileNameReturn.Replace("đ", "d");
				fileNameReturn = fileNameReturn.Replace("--", "-");
			}
			return fileNameReturn;
		}
		public static string SetFileName(string content)
		{
			content = content.Replace(@"'", @"""");
			content = content.Replace(@"src=""", "~");
			if (content.Split('~').Length > 1)
			{
				content = content.Split('~')[1];
				content = content.Split('"')[0];
			}
			return content;
		}
		#endregion
	}
}
