namespace Service.Interface
{
    public interface IThanhVienTokenService : IBaseService<ThanhVienToken>
    {
        Task<ThanhVienToken> AuthenticationByTokenAsync(string token);
    }
}

