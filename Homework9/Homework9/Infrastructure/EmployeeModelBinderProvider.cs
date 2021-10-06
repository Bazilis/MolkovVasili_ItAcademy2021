using Homework9.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Homework9.Infrastructure
{
    public class EmployeeModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _binder = new EmployeeModelBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(EmployeeItem) ? _binder : null;
        }
    }
}
