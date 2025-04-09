using System.Collections;
using Admin.Constants;

namespace Admin.Services;

public class LanguageConstantsService
{
    private readonly LanguageService _languageService; // service kiểm tra ngôn ngữ

    private readonly Hashtable table;

    public LanguageConstantsService(LanguageService languageService)
    {
        _languageService = languageService;
        this.table = new Hashtable();
        this.table.Add("en", new GenericENConstants());
        this.table.Add("vn", new GenericVNConstants());
        // this.table.Add("jp", new GenericJPConstants());
    }

    // Tạo constants động thay đổi dựa trên service
    public ILanguageConstants Constants =>
            this.table[this._languageService.currentLanguage] as ILanguageConstants 
            ?? new GenericENConstants();  // Giá trị mặc định nếu null

}
