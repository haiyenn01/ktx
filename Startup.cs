using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PlurasightLogin.Startup))]

namespace PlurasightLogin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString =
                 @"data source=DESKTOP-RPK6PAD\SQL2019;initial catalog=abc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            app.CreatePerOwinContext(() => new ExtendedUserBdContext(connectionString));
            app.CreatePerOwinContext<UserStore<ExtendedUser>>(
                (opt, cont) => new UserStore<ExtendedUser>(cont.Get<ExtendedUserBdContext>()));
           
            app.CreatePerOwinContext<UserManager<ExtendedUser>>(
                (opt, cont) =>
                {
                    var userManager = new UserManager<ExtendedUser>(cont.Get<UserStore<ExtendedUser>>());
                    userManager.UserTokenProvider = new DataProtectorTokenProvider<ExtendedUser>(opt.DataProtectionProvider.Create());
                    userManager.EmailService = new EmailService();
                    return userManager;
                    });

            app.CreatePerOwinContext<SignInManager<ExtendedUser, string>>
                ((opt, cont) => new SignInManager<ExtendedUser, string>(cont.Get<UserManager<ExtendedUser>>(),cont.Authentication));
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions{
                AuthenticationType =DefaultAuthenticationTypes.ApplicationCookie
            });

           
        }
    }
}
