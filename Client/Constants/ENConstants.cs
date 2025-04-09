using System.Collections;

namespace Client.Constants;

public class ENConstants : ILanguageConstants
{
    public string DarkMode => "Dark";

    public string LightMode => "Light";

    public string SpecialMode => "Special";

    public Hashtable ModeNames => new Hashtable
    {
        {   "light", "Light"    },
        {   "dark", "Dark"  },
        {   "special", "Special"}
    };

    public Hashtable LangNames => new Hashtable
    {
        {   "en", "Tiếng Anh"     },
        {   "vn", "Tiếng Việt"  },
        {   "jp", "Tiếng Nhật"    }
    };
}