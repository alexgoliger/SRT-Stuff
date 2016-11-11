using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  public class CourseDTO
  {
    public int CourseId { get; }
    public string Title { get; set; }
    /// <summary>
    /// <para>StartHour represents an hour of the day, expressed in military time.</para>
    /// Therefore, 8 corresponds to 8 AM,
    /// 9 corresponds to 9 AM,
    /// 10 corresponds to 10 AM,
    /// ...,
    /// 18 corresponds to 6 PM.
    /// </summary>
    public int StartHour { get; set; }
    /// <summary>
    /// <para>EndHour represents an hour of the day, expressed in military time.</para>
    /// Therefore, 8 corresponds to 8 AM,
    /// 9 corresponds to 9 AM,
    /// 10 corresponds to 10 AM,
    /// ...,
    /// 18 corresponds to 6 PM.
    /// </summary>
    public int EndHour { get; set; }
    public int Length
    {
      get
      {
        return EndHour - StartHour;
      }
    }

    public CourseDTO(int id, string title, int startHour, int endHour)
    {
      CourseId = id;
      Title = title;
      StartHour = startHour;
      EndHour = endHour;
    }

    public override string ToString()
    {
      return string.Format
      (
        "Course #{0}: {1} from {2} to {3}",
        CourseId,
        Title,
        ConvertHourToTime(StartHour),
        ConvertHourToTime(EndHour)
      );
    }

    public override bool Equals(object obj)
    {
      CourseDTO c = obj as CourseDTO;
      return c != null ?
        CourseId == c.CourseId && Title == c.Title && StartHour == c.StartHour && EndHour == c.EndHour
        : false;
    }

    public override int GetHashCode()
    {
      return CourseId + StartHour + EndHour * Title.GetHashCode();
    }

    private string ConvertHourToTime(int hour)
    {
      if (hour == 12)
      {
        return "12 PM";
      }

      string s = hour < 12 ? " AM" : " PM";
      return hour % 12 + s;
    }
  }
}
