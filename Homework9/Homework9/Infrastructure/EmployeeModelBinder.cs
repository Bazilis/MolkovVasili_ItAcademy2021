using Homework9.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Homework9.Infrastructure
{
    public class EmployeeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var idPartValues = bindingContext.ValueProvider.GetValue("Id");
            var namePartValues = bindingContext.ValueProvider.GetValue("Name");
            var salaryPartValues = bindingContext.ValueProvider.GetValue("Salary");

            var rnd = new Random();

            if (!int.TryParse(idPartValues.FirstValue, out int id))
            {
                id = rnd.Next();
            }
            string name = namePartValues.FirstValue;

            if (!int.TryParse(salaryPartValues.FirstValue, out int salary))
            {
                salary = rnd.Next();
            }

            if (string.IsNullOrEmpty(name)) name = "Name is Null Or Empty";

            bindingContext.Result = ModelBindingResult.Success(new EmployeeItem() { Id = id, Name = name, Salary = salary});
            
            return Task.CompletedTask;
        }
    }
}
