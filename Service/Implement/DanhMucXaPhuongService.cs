namespace Service.Implement
{
    public class DanhMucXaPhuongService : BaseService<DanhMucXaPhuong, IDanhMucXaPhuongRepository>
    , IDanhMucXaPhuongService
    {
        private readonly IDanhMucXaPhuongRepository _DanhMucXaPhuongRepository;
        public DanhMucXaPhuongService(IDanhMucXaPhuongRepository DanhMucXaPhuongRepository) : base(DanhMucXaPhuongRepository)
        {
            _DanhMucXaPhuongRepository = DanhMucXaPhuongRepository;
        }
    }
}

