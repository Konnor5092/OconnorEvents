using Microsoft.AspNetCore.Mvc.ModelBinding;
using OconnorEvents.Mediatr.CollectionQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Binders
{
    public class SortColumnModelBinder : IModelBinder, IModelBinderProvider
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (bindingContext.ModelType == typeof(IEnumerable<SortColumn>))
            {
                if (!string.IsNullOrEmpty(valueProviderResult.FirstValue))
                {
                    var bindedResult = valueProviderResult.FirstValue
                        .Split(',')
                        .Select(o => new SortColumn
                        {
                            Direction = o.StartsWith('-') ? SortColumn.Directions.Descending : SortColumn.Directions.Ascending,
                            Name = o.StartsWith('-') ? o.TrimStart('-') : o
                        });

                    bindingContext.Result = ModelBindingResult.Success(bindedResult);
                }
            }

            return Task.CompletedTask;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(IEnumerable<SortColumn>))
            {
                return this;
            }

            return null;
        }
    }
}
