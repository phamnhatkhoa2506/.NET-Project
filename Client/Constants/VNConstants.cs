using System.Collections;

namespace Client.Constants;

public class VNConstants : ILanguageConstants
{
    public string DarkMode => "Tối";

    public string LightMode => "Sáng";

    public string SpecialMode => "Đặc biệt";

    public Hashtable ModeNames => new Hashtable
    {
        {   "light", "Sáng"    },
        {   "dark", "Tối"  },
        {   "special", "Đặc biệt"}
    };

    public Hashtable LangNames => new Hashtable
    {
        {   "en", "Tiếng Anh"     },
        {   "vn", "Tiếng Việt"  },
        {   "jp", "Tiếng Nhật"    }
    };
}