using System.Collections.Generic;
using EllAid.Entities.Services.Validation;
using EllAid.UseCases.Dashboard.SignIn;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;


namespace EllAid.Details.Main.Error
{
    public class TempDataErrorCollector : IErrorCollector
    {
        readonly ITempDataProvider tempDataProvider;
        readonly IHttpContextAccessor contextAccessor;
        List<ValidationError> errors = new List<ValidationError>();

        public TempDataErrorCollector(ITempDataProvider tempDataProvider, IHttpContextAccessor contextAccessor)
        {
            this.tempDataProvider = tempDataProvider;
            this.contextAccessor = contextAccessor;
        }

        public void AddError(ValidationError error) => errors.Add(error);
        public void AddErrors(IList<ValidationError> errors) => this.errors.AddRange(errors);

        public int Count
        {
            get
            {
                return errors.Count;
            }
        }

        public void Save()
        {
            if (errors.Count > 0)
            {
                AddErrorsToTempData();
            }
        }

        private void AddErrorsToTempData()
        {
            string serializedErrors = JsonConvert.SerializeObject(errors);
            Dictionary<string, object> tempDataDictionary = new Dictionary<string, object>();
            tempDataDictionary.Add(Constants.tempDataErrorDictionaryName, serializedErrors);
            tempDataProvider.SaveTempData(contextAccessor.HttpContext.Request.HttpContext, tempDataDictionary);
        }
    }
}