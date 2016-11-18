using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public abstract class Record
  {
    public void Validate()
    {
      var context = new ValidationContext(this);
      var results = new List<ValidationResult>();
      var isValid = Validator.TryValidateObject(this, context, results);
      if (!isValid)
      {
        var messageBuilder = new StringBuilder();
        foreach (var validationResult in results)
        {
          messageBuilder.Append(validationResult.ErrorMessage);
          messageBuilder.AppendLine();
        }

        throw new Exception(messageBuilder.ToString());
      }
    }
  }
}