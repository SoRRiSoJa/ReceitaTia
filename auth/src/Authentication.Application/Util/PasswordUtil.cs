using System.Security.Cryptography;
using System.Text;

namespace authentication.Application.Util
{
    public class PasswordUtil
    {
        private HashAlgorithm _hashAlgorithm;
        public PasswordUtil(HashAlgorithm _hashAlgorithm)
        {
            this._hashAlgorithm= _hashAlgorithm ?? throw new ArgumentNullException(nameof(_hashAlgorithm));
        }
        public string GetPasswordHash(string password)
        {
            var encodedValue = Encoding.UTF8.GetBytes(password);
            var encryptedPassword = _hashAlgorithm.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool CheckPassword(string inputPassword, string userPassword,string userSalt)
        {
            if (string.IsNullOrEmpty(userPassword))
                throw new NullReferenceException("No user password informed!");

            var encryptedPassword = GetPasswordHash($"{userPassword}{userSalt}");
            
            return encryptedPassword.Equals(userPassword);
        }
    }
}

