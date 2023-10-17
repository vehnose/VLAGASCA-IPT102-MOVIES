using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BSIT3L_Movies.Models;
using System.Collections.Generic;

namespace BSIT3L_Movies.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly List<MovieViewModel> _movies;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _movies = new List<MovieViewModel>
        {
           new MovieViewModel { Id = 1, Name = "20th Century Girl", Rating = "86%", ReleaseYear = 2022, Genre = "Melodrama", Img = "img/M1.jpg", Desc = "On the brink of a new century, a high schooler finds love by accident. " +
            "The premise of 20th Century Girl is this: Na Bo-ra is seventeen and loyal to her best friend, Yeon-du. However, Yeon-du is leaving for the United States soon, as she needs a specific kind of surgery for her heart.", Direct = "Bang Woo-Ri", Link = "https://www.youtube.com/watch?v=KFS4_qevE7M" },
            new MovieViewModel { Id = 2, Name = "Tune In For Love", Rating = "73%", ReleaseYear = 2019, Genre = "Drama", Img = "img/M2.jpg", Desc = "In 1994 during the IMF crisis, two people meet while exchanging stories on a radio program. They fall in love, but can't quite seem to get the timing right.", Direct = "Jung Ji-woo", Link = "https://www.youtube.com/watch?v=O2x8gaL5Omw" },
            new MovieViewModel { Id = 3, Name = "Unlocked", Rating = "67%", ReleaseYear = 2023, Genre = "Drama", Img = "img/M3.jpg", Desc = "A woman's life is turned upside-down when a dangerous man gets hold of her lost cell phone and uses it to track her every move. A woman's life is turned upside-down when a dangerous man gets hold of her lost cell phone and uses it to track her every move.", Direct = "Michael Apted", Link = "https://www.youtube.com/watch?v=k8qGElYoAoU" },
            new MovieViewModel { Id = 4, Name = "Time To Hunt", Rating = "77%", ReleaseYear = 2020, Genre = "Action/Adventure", Img = "img/M4.jpg", Desc = "Set in a dystopian South Korea, the film follows a group of friends who plot a heist and find themselves hunted down by a mysterious assassin after accomplishing the mission.", Direct = "Yoon Sung-hyun", Link = "https://www.youtube.com/watch?v=1qFSdKY2wvk" },
            new MovieViewModel { Id = 5, Name = "Alive", Rating = "90%", ReleaseYear = 2020, Genre = "Action/Adventure", Img = "img/M5.jpg", Desc = "SThe rapid spread of an unknown infection has left an entire city in ungovernable chaos, but one survivor remains alive in total isolation.", Direct = "Cho Il-hyung", Link = "https://www.imdb.com/title/tt10620868/" },
            new MovieViewModel { Id = 6, Name = "Parasite", Rating = "91%", ReleaseYear = 2019, Genre = "Action/Adventure",Img = "img/M6.jpg", Desc = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", Direct = "Bong Joon-ho", Link = "https://www.youtube.com/watch?v=isOGD_7hNIY" },
            new MovieViewModel { Id = 7, Name = "Psychokinesis", Rating = "80%", ReleaseYear = 2018, Genre = "Action/Adventure", Img = "img/M7.jpg", Desc = "A father with newly acquired superpowers sets out to help his estranged daughter before she loses everything.", Direct = "Yeon Sang-ho", Link = "https://www.youtube.com/watch?v=1EkIWVjBBc0" },
            new MovieViewModel { Id = 8, Name = "Nowhere", Rating = "85%", ReleaseYear = 2023, Genre = "Action/Survival", Img = "img/M8.jpg", Desc = "The plot follows a pregnant woman separated from her husband while trying to flee the country to Ireland. She then finds herself trying to survive inside a shipping container in the heart of the sea.", Direct = "Gregg Araki", Link = "https://www.youtube.com/watch?v=6epG_oJEX8Y" },
            new MovieViewModel { Id = 9, Name = "Burial", Rating = "90%", ReleaseYear = 2023, Genre = "Drama/History", Img = "img/M9.jpg", Desc = "Inspired by true events, a lawyer helps a funeral home owner save his family business from a corporate behemoth, exposing a complex web of race, power, and injustice.", Direct = "Ben Parker", Link = "https://www.youtube.com/watch?v=ZOhIdaufd3Q" },
            new MovieViewModel { Id = 10, Name = "2001 : A Space Odyssey", Rating = "92%", ReleaseYear = 2023, Genre = "Sience Fiction", Img = "img/M10.jpg", Desc = "An imposing black structure provides a connection between the past and the future in this enigmatic adaptation of a short story by revered sci-fi author Arthur C. Clarke. When Dr. Dave Bowman (Keir Dullea) and other astronauts are sent on a mysterious mission, their ship's computer system, HAL, begins to display increasingly strange behavior, leading up to a tense showdown between man and machine that results in a mind-bending trek through space and time.",
                Direct = "Stanley Kubrick", Link = "https://www.youtube.com/watch?v=U5uk1-CMEeE" },
            new MovieViewModel { Id = 11, Name = "Don't Breathe", Rating = "95%", ReleaseYear = 2018, Genre = "Action/Triller", Img = "img/M11.jpg", Desc = "Three Detroit thieves look to rob a blind man's house with a major cash settlement so the main character, Rocky, can move to California forever. Little do they know of the blind man's capabilities and hidden secret within the home, as they must find a way out of the house alive, in the dark.", Direct = " Fede Álvarez", Link = "https://www.youtube.com/watch?v=76yBTNDB6vU" },
            new MovieViewModel { Id = 12, Name = "The God-Father", Rating = "83%", ReleaseYear = 2015, Genre = "Action/Adventure", Img = "img/M12.jpg", Desc = "Widely regarded as one of the greatest films of all time, this mob drama, based on Mario Puzo's novel of the same name, focuses on the powerful Italian-American crime family of Don Vito Corleone (Marlon Brando). When the don's youngest son, Michael (Al Pacino), reluctantly joins the Mafia, he becomes involved in the inevitable cycle of violence and betrayal. Although Michael tries to maintain a normal relationship with his wife, Kay (Diane Keaton), he is drawn deeper into the family business.", Link = "https://www.imdb.com/title/tt0068646/" },
            new MovieViewModel { Id = 13, Name = "Aurora", Rating = "91%", ReleaseYear = 2018, Genre = "Thriller", Img = "img/M13.jpg", Desc = "A fatal shipwreck spurs an islander innkeeper and her sister to recover the missing victims' bodies -- until the dead come seeking shelter themselves. "  , Direct = " Yam Laranas", Link = "https://www.youtube.com/watch?v=dKrVegVI0Us&pp=ygURY2l2aWwgd2FyIHRyYWlsZXI%3D" },
            new MovieViewModel { Id = 14, Name = "Seven Sundays", Rating = "89%", ReleaseYear = 2018, Genre = "Family/Drama", Img = "img/M14.jpg", Desc = "Siblings reunite when their father is diagnosed with cancer, and must settle old issues as they spend time together.", Direct = "Cathy Garcia-Molina", Link = "https://www.youtube.com/watch?v=jmt8s6IUT6k" },
            new MovieViewModel { Id = 15, Name = "Goyo: Ang Batang Heneral", Rating = "85%", ReleaseYear = 2020, Genre = "Action/Historical", Img = "img/M15.pg", Desc = "Brash ladies' man Gregorio `Goyo' del Pilar, one of the youngest generals during the Philippine-American War, faces his greatest challenge as he leads a large caravan of soldiers and civilians in a perilous escape attempt north.", Direct = "Jerrold Tarog", Link = "https://www.youtube.com/watch?v=LvmlxCuAens" },
            };
    }

    public IActionResult Index()
    {
        return View(_movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

