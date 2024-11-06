using Business.Abstract;
using Business.Requests.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.UnitOfWork;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUnitOfWork unitOfWork, ITokenHelper tokenHelper)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
        }

        public AccessToken Login(LoginRequest request)
        {
            User? user = _unitOfWork.UserDal.Get(i => i.Email == request.Email);
            UserRole? userRole = _unitOfWork.UserRoleDal.Get(i => i.Id == request.UserRoleId);
            bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordCorrect)
            {
                throw new Exception("Şifre Yanlış");
            }
            return _tokenHelper.CreateToken(user, userRole);
        }

        public void Register(RegisterRequest request)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

           

            User user = new User();
            user.Email = request.Email;
            user.Approved = false;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _unitOfWork.UserDal.Add(user);
            _unitOfWork.Save();
        }
    }
}
