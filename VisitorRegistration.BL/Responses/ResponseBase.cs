using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
