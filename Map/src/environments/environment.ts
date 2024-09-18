export const environment = {
  production: false,
  DomainURL: "",
  DomainDestination: "",
  APIURL: "https://api.bandothuysan.tphcm.vungtrong.vn/api/v1/",
  APIRootURL: "https://api.bandothuysan.tphcm.vungtrong.vn/",
  APIUploadURL: "https://api.upload.bandothuysan.tphcm.vungtrong.vn/api/v1/",
  APIUploadRootURL: "https://api.upload.bandothuysan.tphcm.vungtrong.vn/",
  APIReportURL: "https://api.report.bandothuysan.tphcm.vungtrong.vn/api/v1/",
  APIReportRootURL: "https://api.report.bandothuysan.tphcm.vungtrong.vn/",
  APIMapURL: "https://api.map.bandothuysan.tphcm.vungtrong.vn/api/v1/",
  APIMapRootURL: "https://api.map.bandothuysan.tphcm.vungtrong.vn/",
  MapURL: "https://map.bandothuysan.tphcm.vungtrong.vn/#/",
  IPRegistry: "https://ipv4.myexternalip.com/json",
  IPRegistryURL: "https://api.ipregistry.co/?key=tryout",
  LoadingFile: "loading.gif",
  DialogConfigWidth: "80%",
  DialogConfigWidth60: "60%",
  InitializationString: "",
  InitializationNumber: 0,
  DanhMucQuocGiaIDVietNam: 237,
  DanhMucUngDungID: 1,
  DanhMucThanhVienID: 2,
  DanhMucTinhThanhID: 3776,
  DanhMucQuanHuyenID: 144479,
  DanhMucToChucIDTramQuanTrac: 7,
  DanhMucToChucIDHopTacXa: 8,
  DanhMucToChucIDHoNuoi: 1,
  DanhMucToChucIDPhuongTienKhaiThac: 9,
  DanhMucToChucIDGiong: 10,
  DanhMucToChucIDVungTrong: 11,
  DanhMucToChucIDCuaHang: 12,
  MapZoom: 16,
  Latitude: 10.410817,
  Longitude: 106.9468827,
  PageSize: 10,
  LineWidth: 3,
  MapPopupWidth: "600px",
  MapIconWidth: "30px",
  MapIcon: "30assets/image/logo_30_2024.pngpx",
  MaptilerAPIKey: "6iFTqps4QVACLERa26MA",
  TokenDefault: "d85df3cb-5688-4b1d-b120-50479b23d2a0",
  Token: "Token",
  TokenFCM: "TokenFCM",
  Download: "Download",
  MaSo: "00000000",
  Homepage: "Homepage",
  Login: "Login",
  Bearer: "Bearer null",
  ThanhVienToChucID: "ThanhVienToChucID",
  ThanhVienParentID: "ThanhVienParentID",
  ThanhVienID: "ThanhVienID",
  ThanhVienHoTen: "ThanhVienHoTen",
  ThanhVienTaiKhoan: "ThanhVienTaiKhoan",
  ThanhVienFileName: "ThanhVienFileName",
  UploadSuccess: "Upload thành công.",
  UploadNotSuccess: "Upload không thành công.",
  SaveSuccess: "Lưu thành công.",
  SaveNotSuccess: "Lưu không thành công.",
  DeleteConfirm: "Bạn muốn xóa dữ liệu này?",
  DeleteSuccess: "Xóa thành công.",
  DeleteNotSuccess: "Xóa không thành công.",
  LoginNotSuccess: "Đăng nhập không thành công.",
  UserNameNotExists: "Tài khoản chưa tồn tại.",
  UserNameExists: "Tài khoản đã tồn tại.",
  UserNameRequired: "UserName là bắt buộc.",
  ToChucExists: "Tổ chức đã tồn tại.",
  ToChucToaDoSaveThongBao: "Dữ liệu tọa độ chưa chọn.",
  PageTitle: "Chi cục Thủy sản Thành phố Hồ Chí Minh",
  PageTitleShort: "Chi cục Thủy sản",
  PageDescription: "Hệ thống Bản đồ số hóa các vùng nuôi và khai thác trên địa bàn Thành phố Hồ Chí Minh",

  IPRegistryIP: "IPRegistryIP",
  IPRegistryDevice: "IPRegistryDevice",
  IPRegistryLongitude: "IPRegistryLongitude",
  IPRegistryLatitude: "IPRegistryIPLatitude",
  IPRegistryCountryName: "IPRegistryCountryName",
  IPRegistryRegionName: "IPRegistryRegionName",
  IPRegistryCityName: "IPRegistryCityName",

  Polygon: "Polygon",

};

import * as MapboxDraw from '@mapbox/mapbox-gl-draw';

export const draw: MapboxDraw = new MapboxDraw({
  displayControlsDefault: false,
  controls: {
    polygon: true,
    trash: true
  }
});
