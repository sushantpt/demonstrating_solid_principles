using demonstrating_solid_principles.Classes.EmailAndOther;
using demonstrating_solid_principles.Classes.OpenClosePrinciple;
using demonstrating_solid_principles.Classes.ViewModels;
using System.Text;

namespace demonstrating_solid_principles.Classes
{
    public class AuthWithDiscount : Auth
    {
        public void SendDiscountCoupon(string email)
        {
            Random rand = new Random();
            int discount = rand.Next(0, 30);

            var arr = new string[] { "A", "B", "C", "Z", "X" };
            var discountCoupon = new StringBuilder();
            for(int i = 0; i < 3; i++)
            {
                discountCoupon.Append(arr[rand.Next(i)]);
                discountCoupon.Append(rand.Next(i+i));
            }

            string subject = "Discount for new user.";
            string body = $"Thanks for joining. To celebrate this, here is a discount of: {discount}%. " +
                $"Discount coupon: {discountCoupon}";
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendEmail(email, subject, body);
        }
    }
}
