using ClientApp.Models;

namespace ClientApp.Services
{
    public class UserInfoService
    {
        private User? _user;

        public bool IsLoggedIn() => _user != null;

        public User? GetUserInfo()
        {
            if (_user is null)
            {
                Console.WriteLine("User has not logged in yet");
            }
            return _user;
        }

        public void SetUserInfo(User? user)
        {
            if (user != null)
            { 
                _user = user;
            }
        }
    }
}
