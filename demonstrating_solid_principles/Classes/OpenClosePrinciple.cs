using demonstrating_solid_principles.Classes.EmailAndOther;
using demonstrating_solid_principles.Classes.GoodExample;
using demonstrating_solid_principles.Classes.ViewModels;

namespace demonstrating_solid_principles.Classes.OpenClosePrinciple
{
    public abstract class Authenticate
    {
        private string[] Users = ["ram", "sam", "john", "tom", "hari"];
        private string[] Emails = ["ram@mail.com", "sam@mail.com", "john@mail.com", "tom@mail.com", "hari@mail.com"];

        public bool VerifyUser(UserInputs _inputs)
        {
            /* when everthing goes fine */
            if (ValidateUser(_inputs) && RegisterUser(_inputs))
            {
                string toEmail = _inputs.Email;
                string subject = "New email from Auth Module";
                string body = $"Account has been created successfully. \n" +
                                $"Username: {_inputs.UserName} \n" +
                                $"Email: {_inputs.Email} \n" +
                                $"Password: {_inputs.Password} \n";
                
                EmailHelper email = new EmailHelper();
                email.SendEmail(toEmail, subject, body);
                return true;
            }

            /* when something goes wrong */
            return false;
        }

        /// <summary>
        /// Function to validate user inputs.
        /// </summary>
        /// <param name="_inputs"></param>
        /// <returns></returns>
        private bool ValidateUser(UserInputs _inputs)
        {
            if (string.IsNullOrWhiteSpace(_inputs.UserName) || string.IsNullOrWhiteSpace(_inputs.Email) || string.IsNullOrWhiteSpace(_inputs.Password))
            {
                Console.WriteLine("Username, Email and Password are required field.");
                return false;
            }

            if (Emails.Contains(_inputs.Email))
            {
                Console.WriteLine("Email already exists. Please sign in.");
                return false;
            }

            if (Users.Contains(_inputs.UserName))
            {
                Console.WriteLine("User name already exists.");
                return false;
            }

            if (_inputs.Password.Length < 8)
            {
                Console.WriteLine("Password length must be atleast 8 characters.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Function to register user.
        /// </summary>
        /// <param name="_inputs"></param>
        /// <returns></returns>
        private bool RegisterUser(UserInputs _inputs)
        {
            Console.WriteLine($"New user {_inputs.UserName} has been created.");
            return true;
        }
    }

    public class Auth : Authenticate
    {
        /// <summary>
        /// For this auth module, i will add a function to check if the user was a past user.
        /// </summary>
        /// <returns></returns>
        public bool IsPastUser(UserInputs _inputs)
        {
            var pastUserList = new List<string>()
            {
                "volk@mail.com", "chael@mail.com", "topuria@mail.com", "islam@mail.com", "sushantpant@mail.com"
            };

            if (pastUserList.Contains(_inputs.Email))
                return true;

            return false;
        }
    }
}
