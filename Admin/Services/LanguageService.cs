namespace Admin.Services;

public class LanguageService
{
    public string currentLanguage = "en";

    public event Action? OnLanguageChanged;

    public void ChangeLanguage(string lang)
    {
        this.currentLanguage = lang;
        OnLanguageChanged?.Invoke();
    }
}
