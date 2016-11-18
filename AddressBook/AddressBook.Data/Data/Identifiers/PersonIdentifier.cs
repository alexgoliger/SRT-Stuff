using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data.Common.Util;

namespace AddressBook.Data.Identifiers
{
  public class PersonIdentifier : Identifier
  {
    private const string PREPENDED_STRING = "PER";
    public int PersistableID { get; }
    public string DisplayableIdentifier { get; }

    public PersonIdentifier(int id)
    {
      var checksumCalculator = new ChecksumCalculator(id);
      PersistableID = id;
      DisplayableIdentifier = string.Format("{0}{1}", PREPENDED_STRING, checksumCalculator.CalculateChecksum());
    }

    public PersonIdentifier(string displayableId)
    {
      var checksumString = displayableId.Replace(PREPENDED_STRING, string.Empty);
      var checksumValue = int.Parse(checksumString);
      var checksumCalculator = new ChecksumCalculator(checksumValue);
      PersistableID = checksumCalculator.ReverseChecksum();
      DisplayableIdentifier = displayableId;
    }
  }
}
