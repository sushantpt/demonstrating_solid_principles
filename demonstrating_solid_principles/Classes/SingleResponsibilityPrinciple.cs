using demonstrating_solid_principles.Classes.EmailAndOther;
using demonstrating_solid_principles.Classes.ViewModels;


namespace demonstrating_solid_principles.Classes.BadExample
{
    public class Auth(UserInputs inputs)
    {
        private UserInputs _inputs = inputs;
        private string[] Users = ["ram", "sam", "john", "tom", "hari"];
        private string[] Emails = ["ram@mail.com", "sam@mail.com", "john@mail.com", "tom@mail.com", "hari@mail.com"];

        public bool VerifyUser()
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

            Console.WriteLine($"New user {_inputs.UserName} has been created.");

            // user's inputs seems fine, now send them email confirming their identity.
            Console.WriteLine("--- New email from Auth Module ---");
            Console.WriteLine($"Account has been created successfully. \n" +
                $"Username: {_inputs.UserName} \n" +
                $"Email: {_inputs.Email} \n" +
                $"Password: {_inputs.Password} \n");
            return true;
        }
    }
}

namespace demonstrating_solid_principles.Classes.GoodExample
{
    public class Auth(UserInputs inputs)
    {
        private UserInputs _inputs = inputs;
        private string[] Users = ["ram", "sam", "john", "tom", "hari"];
        private string[] Emails = ["ram@mail.com", "sam@mail.com", "john@mail.com", "tom@mail.com", "hari@mail.com"];
    
        public bool VerifyUser()
        {
            /* when everthing goes fine */
            if (ValidateUser() && RegisterUser())
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
        /// <returns></returns>
        public bool ValidateUser()
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
        /// <returns></returns>
        public bool RegisterUser()
        {
            Console.WriteLine($"New user {_inputs.UserName} has been created.");
            return true;
        }
    }

}

namespace demonstrating_solid_principles.Classes.EmailAndOther
{
    public class EmailHelper
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Email to: {to}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
        }
    }
}

namespace demonstrating_solid_principles.Classes.ViewModels
{
    public class UserInputs
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
