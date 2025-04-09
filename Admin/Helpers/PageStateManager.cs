using System.Collections;
using Admin.Models;
using Admin.States;

namespace Admin.Helpers;

/*
    Quản lý gọi APIs cho các trang

    Mỗi trang 1 State
*/

public class PageStateManager
{
    public Hashtable tableState; // Dùng hashtable để quản lý theo key, dễ hơn dùng class

    public PageStateManager(HttpClient http)
    {
        this.tableState = new Hashtable()
        {
            {"country", new BasePageState<Country>(http)},
            {"language", new BasePageState<Language>(http)},
            {"format", new BasePageState<Format>(http)},
            {"limitAge", new BasePageState<LimitAge>(http)},
            {"genre", new BasePageState<Genre>(http)},
            {"concessionType", new BasePageState<ConcessionType>(http)},
            {"area", new BasePageState<Area>(http)},
            {"cinema", new BasePageState<Cinema>(http)},
            {"seatType", new BasePageState<SeatType>(http)},
            {"ticketType", new BasePageState<TicketType>(http)},
            {"ticket", new BasePageState<Ticket>(http)},
            {"concession", new BasePageState<Concession>(http)},
            {"movie", new MoviePageState(http)},
            {"room", new BasePageState<Room>(http)},
            {"showtime", new BasePageState<Showtime>(http)}
        };
    }
}