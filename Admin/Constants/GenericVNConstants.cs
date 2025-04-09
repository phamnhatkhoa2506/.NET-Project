using System.Collections;

namespace Admin.Constants;

/*
    Constants cho ngôn ngữ tiếng việt
*/

public class GenericVNConstants : ILanguageConstants
{
     public string CountryNameNavMenu => "Nước";

    public string LanguageNameNavMenu => "Ngôn ngữ";

    public string FormatNameNavMenu => "Hình thức xem phim";

    public string LimitAgeNameNavMenu => "Giới hạn độ tuổi";

    public string GenreNameNavMenu => "Thể loại";

    public string MovieNameNavMenu => "Phim";

    public string CountryPageTitle => "Country";

    public string CountryH1 => "Country";

    public string CountryP => "Quản lý dữ liệu cho các nước";
    
    public string LanguagePageTitle => "Language";

    public string LanguageH1 => "Language";

    public string LanguageP => "Quản lý dữ liệu cho ngôn ngữ";

    public string FormatPageTitle => "Format";

    public string FormatH1 => "Format";

    public string FormatP => "Quản lý hình thức xem phim";

    public string LimitAgePageTitle => "Limit Age";

    public string LimitAgeH1 => "Limit Age";

    public string LimitAgeP => "Quản lý giới hạn độ tuổi xem phim";

    public string GenrePageTitle => "Genre";

    public string GenreH1 => "Genre";

    public string GenreP => "Quản lý thể loại xem phim";

    public string MoviePageTitle => "Movie";

    public string MovieH1 => "Movie";

    public string MovieP => "Muốn xem phim gì nào?";

    public string ShowtimePageTitle => "Showtime";

    public string ShowtimeH1 => "Showtime";

    public string ShowtimeP => "Quản lý lịch chiếu";

    public string AreaPageTitle => "Area";

    public string AreaH1 => "Area";

    public string AreaP => "Quản lý khu vực rạp phim";

    public string CinemaPageTitle => "Cinema";

    public string CinemaH1 => "Cinema";

    public string CinemaP => "Quản lý rạp phim";

    public string RoomPageTitle => "Room";

    public string RoomH1 => "Room";

    public string RoomP => "Quản lý phòng phim";

    public string ConcessionTypePageTitle => "Concession Type";

    public string ConcessionTypeH1 => "Concession Type";

    public string ConcessionTypeP => "Quản lý loại thức ăn đồ uống";

    public string ConcessionPageTitle => "Concession";

    public string ConcessionH1 => "Concession";

    public string ConcessionP => "Quản lý thức ăn đồ uống";

    public string SeatTypePageTitle => "Seat Type";

    public string SeatTypeH1 => "Seat Type";

    public string SeatTypeP => "Quản lý loại ghế ngồi";

    public string SeatPageTitle => "Seat";

    public string SeatH1 => "Seat";

    public string SeatP => "Quản lý ghế ngồi";

    public string BookedSeatsPageTitle => "Booked Seats";

    public string BookedSeatsH1 => "Booked Seats";

    public string BookedSeatsP => "Quản lý ghế đã được đặt";

    public string TicketTypePageTitle => "Ticket Type";

    public string TicketTypeH1 => "Ticket Type";

    public string TicketTypeP => "Quản lý loại vé";

    public string TicketPageTitle => "Ticket";

    public string TicketH1 => "Ticket";

    public string TicketP => "Quản lý vé";

    public string BookedTicketsPageTitle => "Booked Tickets";

    public string BookedTicketsH1 => "Booked Tickets";

    public string BookedTicketsP => "Quản lý vé đã đặt";

    public string UserPageTitle => "User";

    public string UserH1 => "User";

    public string UserP => "Quản lý người dùng";

    public string MembershipPageTitle => "Membership";

    public string MembershipH1 => "Membership";

    public string MembershipP => "Quản lý hội viên";

    public string TransactionPageTitle => "Transaction";

    public string TransactionH1 => "Transaction";

    public string TransactionP => "Quản lý giao dịch";

    public string BillPageTitle => "Bill";

    public string BillH1 => "Bill";

    public string BillP => "Quản lý hoá đơn";
    
    public string FindingButtonPlaceholder => "Tìm";

    public string EnterNameVNInputPlaceholder => "Nhập tên tiếng Việt";

    public string EnterNameENInputPlaceholder => "Nhập tên tiếng Anh";

    public string EnterNamePriceInputPlaceholder => "Nhập giá";

    public string EnterNameQuantityInputPlaceholder => "Nhập số lượng";

    public string EnterNameSeatQuantityInputPlaceholder => "Nhập số lượng ghế";

    public string EnterNameRoomQuantityInputPlaceholder => "Nhập số lượng phòng";

    public string EnterNameImgUrlInputPlaceholder => "Nhập link ảnh";

    public string EnterNameAddressInputPlaceholder => "Nhập địa chỉ";

    public string AddingButtonText => "Thêm";

    public string AddingMovieButtonText => "Thêm phim";

    public string VietnameseName => "Tên Việt Nam";

    public string EnglishName => "Tên Tiếng Anh";

    public string TypeName => "Loại";

    public string QuantityContext => "Số lượng";

    public string RoomTypeContext => "Loại phòng";

    public string NumSeatsContext => "Số lượng ghế";

    public string CinemaNameContext => "Rạp";

    public string DirectorContext => "Đạo diễn";

    public string DurationContext => "Thời lượng";

    public string ActorContext => "Diễn viên";

    public string GenreNameVNContext => "Thể loại (VN)";

    public string GenreNameENContext => "Thể loại (EN)";

    public string ReleasedDateContext => "Ngày khởi chiếu";

    public string EndDateContext => "Ngày dừng chiếu";

    public string CountryNameVNContext => "Nước (VN)";
 
    public string CountryNameENContext => "Nước (EN)";

    public string LimitAgeVNContext => "Giới hạn độ tuổi (VN)";
 
    public string LimitAgeENContext => "Giới hạn độ tuổi (EN)";
 
    public string FormatVNContext => "Hình thức chiếu (VN)";

    public string FormatENContext => "Hình thức chiếu (EN)";
 
    public string LanguageVNContext => "Ngôn ngữ (VN)";
 
    public string LanguageENContext => "Ngôn ngữ (EN)";
 
    public string BriefVNContext => "Nội dung (VN)";
 
    public string BriefENContext => "Nội dung (EN)";
 
    public string ImgUrlContext => "Đường dẫn ảnh";
 
    public string PosterUrlContext => "Đường dẫn poster";

    public string TrailerUrlContext => "Đường dẫn trailer";

    public string TicketTypeContext => "Loại vé";

    public string TicketPriceContext => "Giá";

    public string DateShowContext => "Ngày chiếu";

    public string StartTimeContext => "Giờ chiếu";

    public string MovieNameContext => "Tên phim";

    public string RoomNameContext => "Phòng chiếu";

    public string AddressContext => "Nơi chiếu";

    public string MovieAllText => "Tất cả";

    public string MovieShowingText => "Đang chiếu";

    public string MovieUpcomingText => "Sắp chiếu";

    public string Notion => "Ghi chú";

    public string NameError => "Không thể để trống thông tin";

    public string SuccessAddingNotification => "Thêm thành công";

    public string FailedAddingNotification => "Lỗi, hãy thử lại";

    public string InvalidPriceNotification => "Giá phải là một số";

    public string InvalidQuantityNotification => "Số lượng phải là một số tự nhiên";

    public string ConflictNotification => "Đã tồn tại";

    public string DarkMode => "Tối";

    public string LightMode => "Sáng";

    public string SpecialMode => "Đặc biệt";

    public Hashtable LangNames => new Hashtable
    {
        {   "en", "Tiếng Anh"     },
        {   "vn", "Tiếng Việt"  },
        {   "jp", "Tiếng Nhật"    }
    };

    public Hashtable ModeNames => new Hashtable
    {
        {   "light", "Sáng"    },
        {   "dark", "Tối"  },
        {   "special", "Đặc biệt"}
    };

    public string ErrorTitle => "Lỗi Server";

    public string ErrorMassage => "Hệ thống gặp sự cố, vui lòng kiểm tra cổng server và thử lại.";

    public string RetryButton => "Thử lại";
}