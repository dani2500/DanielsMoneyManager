namespace DanielsMoneyManagerApi.Dtos
{
    public class LoginResponseDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Jwt { get; set; }
        //public int UserId { get; set; }
        public int JwtLifeTimeMs {  get; set; }
    }
}
