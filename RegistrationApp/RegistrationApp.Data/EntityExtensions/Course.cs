using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Data
{
  public partial class Course
  {
    public override string ToString()
    {
      return string.Format
      (
        "Course #{0}: {1} from {2} to {3}",
        CourseId,
        Title,
        ConvertTimeToHour(StartHour),
        ConvertTimeToHour(EndHour)
      );
    }

    private string ConvertTimeToHour(TimeSpan time)
    {
      if (time.Hours == 12)
      {
        return "12 PM";
      }

      string s = time.Hours < 12 ? " AM" : " PM";
      return time.Hours % 12 + s;
    }
  }
}
