using System.Collections;
using Client.Constants;
using Client.Services;

namespace Client.Services;

public class LanguageConstantsService
{
    private readonly LanguageService _languageService; // service kiểm tra ngôn ngữ

    private readonly Hashtable table;

    public LanguageConstantsService(LanguageService languageService)
    {
        _languageService = languageService;
        this.table = new Hashtable();
        this.table.Add("en", new ENConstants());
        this.table.Add("vn", new VNConstants());
        // this.table.Add("jp", new GenericJPConstants());
    }

    // Tạo constants động thay đổi dựa trên service
    public ILanguageConstants Constants =>
            this.table[this._languageService.currentLanguage] as ILanguageConstants 
            ?? new ENConstants();  // Giá trị mặc định nếu null

}
