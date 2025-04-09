using System.Collections;

namespace Admin.Constants;

public class ModePathConstants
{
    public static Hashtable Paths = new Hashtable
    {
        {   "light", URLConstants.LightModePath   },
        {   "dark", URLConstants.DarkModePath  },
        {   "special", URLConstants.SpecialModePath    }
    };    
}