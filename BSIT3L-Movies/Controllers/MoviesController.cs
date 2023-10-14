using System;
using BSIT3L_Movies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSIT3L_Movies.Controllers
{
	public class MoviesController : Controller
    {
        private List<MovieViewModel> _movies;
        public MoviesController()
		{
            // Sample movie data
            _movies = new List<MovieViewModel>
            {
            new MovieViewModel { Id = 1, Name = "20th Century Girl", Rating = "86%", ReleaseYear = 2022, Genre = "Melodrama", Img = "img/M1.jpg", Desc = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", Direct = "Bang Woo-Ri", Link = "https://www.youtube.com/watch?v=8ugaeA-nMTc&pp=ygUQSXJvbiBNYW4gdHJhaWxlcg%3D%3D" },
            new MovieViewModel { Id = 2, Name = "Tune In For Love", Rating = "73%", ReleaseYear = 2019, Genre = "Drama", Img = "img/M2.jpg", Desc = "Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he turns into whenever he loses his temper", Direct = "Jung Ji-woo", Link = "https://www.youtube.com/watch?v=xbqNb2PFKKA&pp=ygUMaHVsayB0cmFpbGVy" },
            new MovieViewModel { Id = 3, Name = "Unlocked", Rating = "67%", ReleaseYear = 2023, Genre = "Drama", Img = "img/M3.jpg", Desc = "With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father's legacy.", Direct = "Michael Apted", Link = "https://www.youtube.com/watch?v=wKtcmiifycU&pp=ygUSSXJvbiBNYW4gMiB0cmFpbGVy" },
            new MovieViewModel { Id = 4, Name = "Time To Hunt", Rating = "77%", ReleaseYear = 2020, Genre = "Action/Adventure", Img = "img/M4.jpg", Desc = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.", Direct = "Yoon Sung-hyun", Link = "https://www.youtube.com/watch?v=JOddp-nlNvQ&pp=ygUMVGhvciB0cmFpbGVy" },
            new MovieViewModel { Id = 5, Name = "Alive", Rating = "90%", ReleaseYear = 2020, Genre = "Action/Adventure", Img = "img/M5.jpg", Desc = "Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a Super-Soldier serum. But being Captain America comes at a price as he attempts to take down a warmonger and a terrorist organization.", Direct = "Cho Il-hyung", Link = "https://www.youtube.com/watch?v=JerVrbLldXw&pp=ygUXY2FwdGFpbiBhbWVyaWNhIHRyYWlsZXI%3D" },
            new MovieViewModel { Id = 6, Name = "Parasite", Rating = "91%", ReleaseYear = 2019, Genre = "Action/Adventure",Img = "img/M6.jpg", Desc = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", Direct = "Bong Joon-ho", Link = "https://www.youtube.com/watch?v=eOrNdBpGMv8&pp=ygUUdGhlIGF2ZW5nZXJzIHRyYWlsZXI%3D" },
            new MovieViewModel { Id = 7, Name = "Psychokinesis", Rating = "80%", ReleaseYear = 2018, Genre = "Action/Adventure", Img = "img/M7.jpg", Desc = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.", Direct = "Yeon Sang-ho", Link = "https://www.youtube.com/watch?v=YLorLVa95Xo&pp=ygUTaXJvbiBtYW4gdHJhaWxlciAzIA%3D%3D" },
            new MovieViewModel { Id = 8, Name = "Nowhere", Rating = "85%", ReleaseYear = 2023, Genre = "Action/Survival", Img = "img/M8.jpg", Desc = "When the Dark Elves attempt to plunge the universe into darkness, Thor must embark on a perilous and personal journey that will reunite him with doctor Jane Foster.", Direct = "Gregg Araki", Link = "https://www.youtube.com/watch?v=npvJ9FTgZbM&pp=ygUbdGhvciB0aGUgZGFyayB3b3JsZCB0cmFpbGVy" },
            new MovieViewModel { Id = 9, Name = "Burial", Rating = "90%", ReleaseYear = 2023, Genre = "Drama/History", Img = "img/M9.jpg", Desc = "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.", Direct = "Ben Parker", Link = "https://www.youtube.com/watch?v=7SlILk2WMTI&pp=ygUrY2FwdGFpbiBhbWVyaWNhIHRoZSB3aW50ZXIgc29sZGllciB0cmFpbGVyIA%3D%3D" },
            new MovieViewModel { Id = 10, Name = "2001 : A Space Odyssey", Rating = "92%", ReleaseYear = 2023, Genre = "Sience Fiction", Img = "img/M10.jpg", Desc = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", Direct = "Stanley Kubrick", Link = "https://www.youtube.com/watch?v=d96cjJhvlMA&pp=ygUNZ290ZyB0cmFpbGVyIA%3D%3D" },
            new MovieViewModel { Id = 11, Name = "Don't Breathe", Rating = "95%", ReleaseYear = 2018, Genre = "Action/Triller", Img = "img/M11.jpg", Desc = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", Direct = " Fede Álvarez", Link = "https://www.youtube.com/watch?v=tmeOjFno6Do&pp=ygUeYXZlbmdlcnMgYWdlIG9mIHVsdHJvbiB0cmFpbGVy" },
            new MovieViewModel { Id = 12, Name = "The God-Father", Rating = "83%", ReleaseYear = 2015, Genre = "Action/Adventure", Img = "img/M12.jpg", Desc = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, pull off a plan that will save the world.", Direct = "Francis Ford Coppola", Link = "https://www.youtube.com/watch?v=pWdKf3MneyI&pp=ygUPQW50LU1hbiB0cmFpbGVy" },
            new MovieViewModel { Id = 13, Name = "Aurora", Rating = "91%", ReleaseYear = 2018, Genre = "Thriller", Img = "img/M13.jpg", Desc = "The second in Roy Andersson’s trilogy of wackily incisive Swedish vignettes comes at you thick and fast – about 50 micro-sketches, sometimes loosely linked – yet sticks like plasticine beneath your fingernails."  , Direct = " Yam Laranas", Link = "https://www.youtube.com/watch?v=dKrVegVI0Us&pp=ygURY2l2aWwgd2FyIHRyYWlsZXI%3D" },
            new MovieViewModel { Id = 14, Name = "Seven Sundays", Rating = "89%", ReleaseYear = 2018, Genre = "Drama", Img = "img/M14.jpg", Desc = "It took Winter’s Bone’s Debra Granik eight years to get this off the ground, but was worth the wait: a brilliantly moving eco drama with Ben Foster and Thomasin McKenzie as a father and daughter living off grid in an Oregon forest, but whose relationship and priorities are changed as the child begins the transition to adulthood.", Direct = "Cathy Garcia-Molina", Link = "https://www.youtube.com/watch?v=HSzx-zryEgM&pp=ygUWZG9jdG9yIHN0cmFuZ2UgdHJhaWxlcg%3D%3D" },
            new MovieViewModel { Id = 15, Name = "Goyo", Rating = "85%", ReleaseYear = 2020, Genre = "Action/Historical", Img = "img/M15.pg", Desc = "British director Andrew Haigh’s quietly devastating drama is a deeply moving portrait of marriage with the shiver of a ghost story. Charlotte Rampling and Tom Courtenay play a Norfolk couple planning their 45th wedding anniversary. A week before the party, a letter lands on their doormat like a hand grenade with news of his early lost love. Rampling is sensational.", Direct = "Jerrold Tarog", Link = "https://www.youtube.com/watch?v=dW1BIid8Osg&pp=ygUhZ3VhcmRpYW5zIG9mIHRoZSBnYWxheHkgMiB0cmFpbGVy" },
            };
        }
        public ActionResult Random()
        {
            var movie = new MovieViewModel() { Name = "Avatar", Rating = "5" };
            return View(movie);
        }
        public ActionResult GetMovie(int id)
        {
            var movie = _movies.Find(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);

        }

    }
}

