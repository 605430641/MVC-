using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Internal;

namespace AgileFrameWork.WebCore
{
    /// <summary>
    /// web核心控制器 替换自己的Demo
    /// </summary>
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly IControllerActivator           _controllerActivator;
        private readonly IControllerPropertyActivator[] _propertyActivators;
        private          object                         Resources;

        public CustomControllerFactory()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DefaultControllerFactory"/>.
        /// </summary>
        /// <param name="controllerActivator">
        /// <see cref="IControllerActivator"/> used to create controller instances.
        /// </param>
        /// <param name="propertyActivators">
        /// A set of <see cref="IControllerPropertyActivator"/> instances used to initialize controller
        /// properties.
        /// </param>
        public CustomControllerFactory(IControllerActivator                      controllerActivator,
                                       IEnumerable<IControllerPropertyActivator> propertyActivators)
        {
            Console.WriteLine("进去核心控制器自定义Demo扩展函数");
            if (controllerActivator == null)
            {
                throw new ArgumentNullException(nameof(controllerActivator));
            }

            if (propertyActivators == null)
            {
                throw new ArgumentNullException(nameof(propertyActivators));
            }

            _controllerActivator = controllerActivator;
            _propertyActivators  = propertyActivators.ToArray();
        }

        /// <inheritdoc />
        public object CreateController(ControllerContext context)
        {
            Console.WriteLine("进去核心控制器自定义Demo扩展函数 CreateController");
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.ActionDescriptor == null)
            {
                throw new ArgumentException("");
            }

            var controller = _controllerActivator.Create(context);

            foreach (var propertyActivator in _propertyActivators)
            {
                propertyActivator.Activate(context,controller);
            }

            return controller;
        }

        /// <inheritdoc />
        public void ReleaseController(ControllerContext context,object controller)
        {
            Console.WriteLine("进去核心控制器自定义Demo扩展函数 ReleaseController");
            
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            _controllerActivator.Release(context,controller);
        }
    }
}