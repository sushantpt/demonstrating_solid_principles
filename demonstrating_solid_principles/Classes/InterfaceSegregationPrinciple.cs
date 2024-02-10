namespace demonstrating_solid_principles.Classes
{
    public interface IEmailAuth
    {
        public bool VerifyUserWithEmail(string email, string password);
        public bool IsEmailConfirmed(string email);
    }

    public interface IMobileAuth
    {
        public bool VerifyUserWithMobile(string mobileNo, string password);
        public bool IsMobileConfirmed(string mobileNo);
    }

    public interface ISocialMediaAuth
    {
        public bool VerifyUserWithSocialMedia(int socialMediaId, string userName, string password);
        public bool IsSocialMediaConfirmed(string userName);
    }

    public class AuthForAPAC : IEmailAuth, ISocialMediaAuth
    {
        public bool IsEmailConfirmed(string email)
        {
            if (email is not null && email.Contains('@'))
            {
                Console.WriteLine("Email is verified.");
                return true;
            }
            return false;
        }

        public bool IsSocialMediaConfirmed(string userName)
        {
            var listOfSocialMediaUsername = new string[] { "jon", "dawg", "sushant" };
            if (userName is not null && listOfSocialMediaUsername.Contains(userName))
            {
                Console.WriteLine("Social media is verified.");
                return true;
            }
            return false;
        }

        public bool VerifyUserWithEmail(string email, string password)
        {
            if (email.Contains('@') && email.Contains('.') && password.Length > 8)
                return true;

            return false;
        }

        public bool VerifyUserWithSocialMedia(int socialMediaId, string userName, string password)
        {
            var listOfSocialMediaUsername = new string[] { "jon", "dawg", "sushant" };
            if (socialMediaId > 1 && userName is not null && listOfSocialMediaUsername.Contains(userName) && password.Length > 8)
                return true;

            return false;
        }
    }

    public class AuthForAmerica : IEmailAuth, ISocialMediaAuth, IMobileAuth
    {
        public bool IsEmailConfirmed(string email)
        {
            if(email is not null && email.Contains('@'))
            {
                Console.WriteLine("Email is verified.");
                return true;
            }
            return false;
        }

        public bool IsMobileConfirmed(string mobileNo)
        {
            if (mobileNo is not null && mobileNo.Contains("+123") && mobileNo.Length is 10)
            {
                Console.WriteLine("Mobile is verified.");
                return true;
            }
            return false;
        }

        public bool IsSocialMediaConfirmed(string userName)
        {
            var listOfSocialMediaUsername = new string[] { "jon", "dawg", "sushant" };
            if (userName is not null && listOfSocialMediaUsername.Contains(userName))
            {
                Console.WriteLine("Social media is verified.");
                return true;
            }
            return false;
        }

        public bool VerifyUserWithEmail(string email, string password)
        {
            if(email.Contains('@') && email.Contains('.') && password.Length > 8)
                return true;

            return false;
        }

        public bool VerifyUserWithMobile(string mobileNo, string password)
        {
            if (mobileNo is not null && mobileNo.Contains("+123") && mobileNo.Length is 10 && password.Length > 8)
                return true;

            return false;
        }

        public bool VerifyUserWithSocialMedia(int socialMediaId, string userName, string password)
        {
            var listOfSocialMediaUsername = new string[] { "jon", "dawg", "sushant" };
            if (socialMediaId > 1 && userName is not null && listOfSocialMediaUsername.Contains(userName) && password.Length > 8)
                return true;

            return false;
        }
    }
}
