namespace Sat.Recruitment.Api.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string UserType { get; set; }
        decimal Money { get; set; }
    }
}
