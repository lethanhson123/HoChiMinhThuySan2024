namespace Service.Implement
{
    public class ThanhVienTokenService : BaseService<ThanhVienToken, IThanhVienTokenRepository>
    , IThanhVienTokenService
    {
        private readonly IThanhVienTokenRepository _ThanhVienTokenRepository;
        public ThanhVienTokenService(IThanhVienTokenRepository ThanhVienTokenRepository) : base(ThanhVienTokenRepository)
        {
            _ThanhVienTokenRepository = ThanhVienTokenRepository;
        }
        public override int Add(ThanhVienToken model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            result = _ThanhVienTokenRepository.Add(model);
            if (result > 0)
            {
                //Sync(model);
            }
            return result;
        }
        public override async Task<int> AddAsync(ThanhVienToken model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            result = await _ThanhVienTokenRepository.AddAsync(model);
            if (result > 0)
            {
                //Sync(model);
            }
            return result;
        }
        private int Sync(ThanhVienToken model)
        {
            int result = GlobalHelper.InitializationNumber;
            List<ThanhVienToken> listThanhVienToken = GetByParentIDAndActiveToList(model.ParentID.Value, true);
            foreach (ThanhVienToken itemThanhVienToken in listThanhVienToken)
            {
                if (itemThanhVienToken.ID != model.ID)
                {
                    itemThanhVienToken.Active = false;
                    Update(itemThanhVienToken);
                }
            }
            return result;
        }
        public async Task<ThanhVienToken> AuthenticationByTokenAsync(string token)
        {
            ThanhVienToken result = new ThanhVienToken();
            if (!string.IsNullOrEmpty(token))
            {
                result = await _ThanhVienTokenRepository.GetByCondition(item => item.Token == token && item.Active == true).FirstOrDefaultAsync();
                if (result != null)
                {
                    if (DateTime.Compare(result.KetThuc.Value, GlobalHelper.InitializationDateTime) > 0)
                    {
                        result.Active = true;
                    }
                    else
                    {
                        result.Active = false;
                    }
                    await _ThanhVienTokenRepository.UpdateAsync(result);
                }
            }
            return result;
        }
    }
}

