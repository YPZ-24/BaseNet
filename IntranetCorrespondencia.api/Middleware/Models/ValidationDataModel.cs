namespace IntranetCorrespondencia.api.Middleware.Models
{
    public class ValidationDataModel
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationDataModel(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
