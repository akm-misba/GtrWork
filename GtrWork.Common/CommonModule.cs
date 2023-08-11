using Autofac;
using GtrWork.Common.Utilities;
using System;

namespace GtrWork.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>();
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<EmailService>().As<IEmailService>()
            //  .WithParameter("host", "smtp.gmail.com")
            //  .WithParameter("port", 465)
            //  .WithParameter("username", "imisbahul53@gmail.com")
            //  .WithParameter("password", "30583603")
            //  .WithParameter("useSSL", true)
            //  .WithParameter("from", "imisbahul53@gmail.com")
            //  .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
