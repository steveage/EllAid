using System.Collections.Generic;
using EllAid.Details.Main;
using EllAid.Entities.Services.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace EllAid.Details.UI.Dashboard.Services
{
    public class ModelStateUpdater
    {
        readonly ITempDataProvider dataProvider;
        readonly IHttpContextAccessor accessor;

        public ModelStateUpdater(ITempDataProvider dataProvider, IHttpContextAccessor accessor)
        {
            this.dataProvider = dataProvider;
            this.accessor = accessor;
        }

        internal void AddErrors(ModelStateDictionary modelState)
        {
            
            IDictionary<string, object> tempData = dataProvider.LoadTempData(accessor.HttpContext);
            if(tempData.ContainsKey(Constants.tempDataErrorDictionaryName))
            {
                List<ValidationError> errors = JsonConvert.DeserializeObject<List<ValidationError>>(tempData[Constants.tempDataErrorDictionaryName].ToString());
                errors.ForEach(error =>
                {
                    modelState.AddModelError(error.PropertyName, error.Message);
                });
            }
        }
    }
}