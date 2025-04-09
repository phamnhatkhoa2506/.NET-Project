using System.Collections;

namespace Admin.Constants;

/*
    Constants cho ngôn ngữ tiếng anh
*/

public class GenericENConstants : ILanguageConstants
{
    public string CountryNameNavMenu => "Country";

    public string LanguageNameNavMenu => "Language";

    public string FormatNameNavMenu => "Format";

    public string LimitAgeNameNavMenu => "Limit Age";

    public string GenreNameNavMenu => "Genre";

    public string MovieNameNavMenu => "Movie";

    public string CountryPageTitle => "Country";

    public string CountryH1 => "Country";

    public string CountryP => "Manage countries' data for Movies";

    public string LanguagePageTitle => "Language";

    public string LanguageH1 => "Language";

    public string LanguageP => "Manage languages' data";

    public string FormatPageTitle => "Format";

    public string FormatH1 => "Format";

    public string FormatP => "Manage formats' data";

    public string LimitAgePageTitle => "Limit Age";

    public string LimitAgeH1 => "Limit Age";

    public string LimitAgeP => "Manage limit ages' data for Movies";

    public string GenrePageTitle => "Genre";

    public string GenreH1 => "Genre";

    public string GenreP => "Manage genres' data for Movies";

    public string MoviePageTitle => "Movie";

    public string MovieH1 => "Movie";

    public string MovieP => "All you need is MOVIE";

    public string ShowtimePageTitle => "Showtime";

    public string ShowtimeH1 => "Showtime";

    public string ShowtimeP => "Manage showtimes";

    public string AreaPageTitle => "Area";

    public string AreaH1 => "Area";

    public string AreaP => "Manage areas' data";

    public string CinemaPageTitle => "Cinema";

    public string CinemaH1 => "Cinema";

    public string CinemaP => "Manage cinemas";

    public string RoomPageTitle => "Room";

    public string RoomH1 => "Room";

    public string RoomP => "Manage rooms";

    public string ConcessionTypePageTitle => "Concession Type";

    public string ConcessionTypeH1 => "Concession Type";

    public string ConcessionTypeP => "Manage concessions' type ";

    public string ConcessionPageTitle => "Concession";

    public string ConcessionH1 => "Concession";

    public string ConcessionP => "Manage concessions";

    public string SeatTypePageTitle => "Seat Type";

    public string SeatTypeH1 => "Seat Type";

    public string SeatTypeP => "Manage seats' type";

    public string SeatPageTitle => "Seat";

    public string SeatH1 => "Seat";

    public string SeatP => "Manage seats";

    public string BookedSeatsPageTitle => "Booked Seats";

    public string BookedSeatsH1 => "Booked Seats";

    public string BookedSeatsP => "Manage booked seats";

    public string TicketTypePageTitle => "Ticket Type";

    public string TicketTypeH1 => "Ticket Type";

    public string TicketTypeP => "Manage tickets' type";

    public string TicketPageTitle => "Ticket";

    public string TicketH1 => "Ticket";

    public string TicketP => "Manage tickets";

    public string BookedTicketsPageTitle => "Booked Tickets";

    public string BookedTicketsH1 => "Booked Tickets";

    public string BookedTicketsP => "Manage booked tickets";

    public string UserPageTitle => "User";

    public string UserH1 => "User";

    public string UserP => "Manage users";

    public string MembershipPageTitle => "Membership";

    public string MembershipH1 => "Membership";

    public string MembershipP => "Manage memberships";

    public string TransactionPageTitle => "Transaction";

    public string TransactionH1 => "Transaction";

    public string TransactionP => "Manage transactions";

    public string BillPageTitle => "Bill";

    public string BillH1 => "Bill";

    public string BillP => "Manage bills";

    public string FindingButtonPlaceholder =>  "Search";

    public string EnterNameVNInputPlaceholder => "Enter Vietnamese Name";

    public string EnterNameENInputPlaceholder => "Enter English Name";

    public string EnterNamePriceInputPlaceholder => "Enter the price";

    public string EnterNameQuantityInputPlaceholder => "Enter quantity";

    public string EnterNameSeatQuantityInputPlaceholder => "Enter number of seats";

    public string EnterNameRoomQuantityInputPlaceholder => "Enter number of rooms";

    public string EnterNameImgUrlInputPlaceholder => "Enter image link";

    public string EnterNameAddressInputPlaceholder => "Enter address";

    public string AddingButtonText => "Add";

    public string AddingMovieButtonText => "Add a Movie";

    public string VietnameseName => "Vietnamese Name";

    public string EnglishName => "English Name";

    public string TypeName => "Type";

    public string QuantityContext => "Quantity";

    public string RoomTypeContext => "Room type";

    public string NumSeatsContext => "Number of seats";

    public string CinemaNameContext => "Cinema";

    public string DirectorContext => "Director";

    public string DurationContext => "Duration";

    public string ActorContext => "Actor";

    public string GenreNameVNContext => "Genre (VN)";

    public string GenreNameENContext => "Genre (EN)";

    public string ReleasedDateContext => "Released date";

    public string EndDateContext => "End date";

    public string CountryNameVNContext => "Country (VN)";
 
    public string CountryNameENContext => "Country (EN)";

    public string LimitAgeVNContext => "Limit age (VN)";
 
    public string LimitAgeENContext => "Limit age (EN)";
 
    public string FormatVNContext => "Format (VN)";

    public string FormatENContext => "Format (EN)";
 
    public string LanguageVNContext => "Language (VN)";
 
    public string LanguageENContext => "Language (EN)";
 
    public string BriefVNContext => "Brief (VN)";
 
    public string BriefENContext => "Brief (EN)";
 
    public string ImgUrlContext => "Image URL";
 
    public string PosterUrlContext => "Poster URL";

    public string TrailerUrlContext => "Trailer URL";

    public string TicketTypeContext => "Ticket type";

    public string TicketPriceContext => "Price";

    public string DateShowContext => "Date show";

    public string StartTimeContext => "Start time";

    public string MovieNameContext => "Movie name";

    public string RoomNameContext => "Room";

    public string AddressContext => "Address";

    public string MovieAllText => "All";

    public string MovieShowingText => "Showing";

    public string MovieUpcomingText => "Upcoming";

    public string Notion => "Note";

    public string NameError => "The inputs cannot be empty";

    public string SuccessAddingNotification => "Successfully added a country";

    public string FailedAddingNotification => "Error happened, try again";

    public string InvalidPriceNotification => "Price must be a number";

    public string InvalidQuantityNotification => "Quantity must be a natural number";

    public string ConflictNotification => "Already exist";

    public string DarkMode => "Dark";

    public string LightMode => "Light";

    public string SpecialMode => "Special";

    public Hashtable LangNames => new Hashtable
    {
        {   "en", "English"     },
        {   "vn", "VietNamese"  },
        {   "jp", "Japanese"    }
    };

    public Hashtable ModeNames => new Hashtable
    {
        {   "light", "Light"    },
        {   "dark", "Dark"  },
        {   "special", "Special"}
    };

    public string ErrorTitle => "Server Error";

    public string ErrorMassage => "Server failed, please check the problem and retry.";

    public string RetryButton => "Retry";
}