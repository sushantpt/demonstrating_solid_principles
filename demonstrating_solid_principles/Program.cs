// See https://aka.ms/new-console-template for more information

using demonstrating_solid_principles.Classes;
using demonstrating_solid_principles.Classes.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using badExampleCode = demonstrating_solid_principles.Classes.BadExample;
using goodExampleCode = demonstrating_solid_principles.Classes.GoodExample;
using openclosePrinciple = demonstrating_solid_principles.Classes.OpenClosePrinciple;

/*Console.WriteLine("Hello, World!");*/



/* demonstrating bad example */
var user1 = new UserInputs()
{
    UserName = "sushant",
    Email = "sushant@mail.com",
    Password = "password"
};

badExampleCode::Auth badExample = new badExampleCode::Auth(user1);
badExample.VerifyUser();

/* end of demonstrating bad example */



/* demonstrating good example */
var user2 = new UserInputs()
{
    UserName = "jon",
    Email = "bones@mail.com",
    Password = "jonjones11"
};
goodExampleCode::Auth goodExample = new goodExampleCode::Auth(user2);
goodExample.VerifyUser();

/* demonstrating good example */

Console.WriteLine("------------ Open close principle ------------");

/*  demonstrating open close principle */
var user3 = new UserInputs()
{
    UserName = "sushantpant",
    Email = "sushantpant@mail.com",
    Password = "p@ssWo3d"
};

openclosePrinciple::Auth openCloseP = new openclosePrinciple::Auth();
openCloseP.VerifyUser(user3);
if (openCloseP.IsPastUser(user3))
    Console.WriteLine($"Welcome back {user3.UserName}.");

/* end of demonstrating open close principle example */




/* demonstrating Liskov substitution principle*/

Console.WriteLine("------------ Liskov substitution principle ------------");

var user4 = new UserInputs()
{
    UserName = "dawg",
    Email = "dawg@mail.com",
    Password = "handshakeleema"
};

AuthWithDiscount authWithDiscount = new AuthWithDiscount();
if(authWithDiscount.VerifyUser(user4))
    authWithDiscount.SendDiscountCoupon(user4.Email);

/* end of demonstrating Liskov substitution principle*/



/* demonstrating interface segregation principle*/
var user5 = new UserInputs()
{
    UserName = "rambdr",
    Email = "rambdr@mail.com",
    Password = "mteverest8848"
};
AuthForAPAC authForAPAC = new AuthForAPAC();
var verify = authForAPAC.VerifyUserWithEmail(user5.Email, user5.Password); // register with email
if (verify)
    Console.WriteLine($"New account registered with email: {user5.Email}");

/* end of demonstrating interface segregation principle*/


/* demonstrating dependency inversion principle*/
var user6 = new UserInputs()
{
    UserName = "joerogan",
    Email = "joerogan@mail.com",
    Password = "joeroganexperience"
};
var authWithFacebookObj = new AuthWithFacebook();
CallingCode callingCode = new CallingCode(authWithFacebookObj);
var facebookAuth = callingCode.VerifyAuth(user6.UserName, user6.Email, user6.Password);

if (facebookAuth)
    Console.WriteLine($"New account registered with facebook: {user6.UserName}.");

/* end of demonstrating dependency inversion principle*/
