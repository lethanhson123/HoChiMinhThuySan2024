using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucAPIController : BaseController<DanhMucAPI, IDanhMucAPIService>
    {
        private readonly IDanhMucAPIService _DanhMucAPIService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DanhMucAPIController(IDanhMucAPIService DanhMucAPIService, IWebHostEnvironment WebHostEnvironment) : base(DanhMucAPIService, WebHostEnvironment)
        {
            _DanhMucAPIService = DanhMucAPIService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        //[AllowAnonymous]
        //[HttpGet]
        //[Route("Geometries")]
        //public async Task<List<DanhMucAPI>> Geometries()
        //{
        //    List<DanhMucAPI> result = new List<DanhMucAPI>();
        //    try
        //    {
        //        //string hexString = "0106000020E6100000010000000103000000010000000B000000FC1CB6FF31BB5A4020208A0937CC244048302A830CBB5A40E011143A0DCC24403022A61E0BBB5A4020CAFAC80BCC24407814BDDF0ABB5A406063CF9912CC2440A89859D70ABB5A40005363E913CC2440D81CF6CE0ABB5A40600D164919CC2440FCB7665317BB5A40404D9A1828CC2440A401D4582BBB5A40E08EE48A3CCC2440987FC6822BBB5A40207E72AC3CCC2440400FCDC031BB5A40E073113A43CC2440FC1CB6FF31BB5A4020208A0937CC2440";
        //        string hexString = "0104000020E6100000010000000101000000A8417CF36AA25A40604CA22EB75F2540";
        //        byte[] byteArray = StringToByteArray(hexString);
        //        WKBReader reader = new WKBReader();
        //        Geometry geometry = reader.Read(byteArray);
        //        var point = geometry.Centroid;
        //        string Name = point.Coordinate.X.ToString();
        //        string Code = point.Coordinate.Y.ToString();
        //        foreach (Coordinate Coordinate in geometry.Coordinates)
        //        {
        //            DanhMucAPI DanhMucAPI = new DanhMucAPI();
        //            DanhMucAPI.Name = Coordinate.X.ToString();
        //            DanhMucAPI.Code = Coordinate.Y.ToString();
        //            result.Add(DanhMucAPI);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = ex.Message;
        //    }
        //    return result;
        //}
        private byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length.");

            return Enumerable.Range(0, hex.Length / 2)
                             .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                             .ToArray();
        }
    }
}

