﻿using Autofac;
using Likegram.Business.Abstract;
using Likegram.Business.Concrete;
using Likegram.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Likegram.Core.Utilities.Interceptors;
using Likegram.DataAccess.Concrete.EntityFramework;
using Likegram.DataAccess.Abstract;

namespace Likegram.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            #region DataAccess Registers
            builder.RegisterType<EfCommentAnswerDal>().As<ICommentAnswerDal>().SingleInstance();
            //builder.RegisterType<EfCommentLikeDal>().As<ICommentLikeDal>().SingleInstance();
            builder.RegisterType<EfPostCommentDal>().As<IPostCommentDal>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>().SingleInstance();
            //builder.RegisterType<EfPostLikeDal>().As<IPostLikeDal>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>().SingleInstance();
            #endregion
            #region Business Registers
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<PostCommentManager>().As<IPostCommentService>().SingleInstance();

            #endregion

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });

        }
    }
}
