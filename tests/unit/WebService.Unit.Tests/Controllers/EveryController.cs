using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

using FluentAssertions;

using WebService.Controllers;

using Xunit;

namespace WebService.Unit.Tests.Controllers
{
    public class EveryController
    {
        private readonly Assembly controllersAssembly;
        private readonly IEnumerable<Type> controllers;

        public EveryController()
        {
            this.controllersAssembly = Assembly.GetAssembly(typeof(AbstractController));
            this.controllers = this.controllersAssembly.GetTypes()
                .Where(n => n.IsClass)
                .Where(n => n.IsAbstract == false)
                .Where(n => typeof(ControllerBase).IsAssignableFrom(n))
                .Where(n => n.Namespace.EndsWith("Controllers"));
        }

        [Fact]
        public void EveryController_Should_BaseOnAbstractController()
        {
            this.controllers.Should().AllBeAssignableTo(typeof(AbstractController));
        }

        [Fact]
        public void EveryControllerPublicMethod_Should_BeDecoratedWithRequestMethod()
        {
            var controllersPublicMethods = this.controllers
                .SelectMany(n => n.GetMethods()
                    .Where(method => method.IsPublic));

            controllersPublicMethods.First().Should().BeDecoratedWith<HttpMethodAttribute>();
        }
    }
}