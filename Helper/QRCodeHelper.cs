namespace Helper
{
	public class QRCodeHelper
	{
		public static QRCodeModel CreateQRCode(string code, string path)
		{			
			bool isFolderExists = System.IO.Directory.Exists(path);
			if (!isFolderExists)
			{
				System.IO.Directory.CreateDirectory(path);
			}
			QRCodeModel model = new QRCodeModel();
			using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
			using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.H))
			using (QRCoder.QRCode qrCode = new QRCode(qrCodeData))
			{
				Bitmap qrCodeImage = qrCode.GetGraphic(20);
				string fileName = code + ".png";
				path = Path.Combine(path, fileName);
				qrCodeImage.Save(path, ImageFormat.Png);
				model.Code = code;
				model.FileName = path;
			}
			return model;
		}
		public static QRCodeModel CreateQRCodeURL(string code, string url, string path)
		{
			bool isFolderExists = System.IO.Directory.Exists(path);
			if (!isFolderExists)
			{
				System.IO.Directory.CreateDirectory(path);
			}
			QRCodeModel model = new QRCodeModel();
			using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
			using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.H))
			using (QRCoder.QRCode qrCode = new QRCode(qrCodeData))
			{
				Bitmap qrCodeImage = qrCode.GetGraphic(20);
				string fileName = code + ".png";
				path = Path.Combine(path, fileName);
				qrCodeImage.Save(path, ImageFormat.Png);
				model.Code = code;
				model.FileName = fileName;
			}
			return model;
		}
	}
}
