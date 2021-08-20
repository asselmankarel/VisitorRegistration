using System.Collections.Generic;

namespace VisitorRegistration.BL.Responses
{
    public abstract class ResponseBase
    {
        public bool Successful => ErrorMessages.Count == 0;
        public List<string> ErrorMessages { get; } = new List<string>();

        public void AddErrorMessage(string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                ErrorMessages.Add((errorMessage));
            }
        }

    }
}
