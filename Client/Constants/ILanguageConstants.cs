using System.Collections;

namespace Client.Constants;

/*
    Interface cho tất cả ngôn ngữ
*/

public interface ILanguageConstants
{
    Hashtable LangNames {get;}

    Hashtable ModeNames {get;}

    string DarkMode {get;}

    string LightMode {get;}

    string SpecialMode {get;}
}