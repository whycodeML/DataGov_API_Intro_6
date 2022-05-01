using DataGov_API_Intro_6.Models;
using Microsoft.AspNetCore.Mvc;
using DataGov_API_Intro_6.DataAccess;
using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataGov_API_Intro_6.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient;

        static string BASE_URL = "https://ott-details.p.rapidapi.com";
        static string API_KEY = "fcb94842d2msh7238fb0fdf3f53cp16acebjsna44816fbf14c"; //Add your API key here inside ""

        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.
        // https://www.nps.gov/subjects/developer/get-started.htm

        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Rent()
        {



            Genre g1 = new Genre();
            //g1.id = 1;
            g1.name = "Action";

            Genre g2 = new Genre();
            //g2.id = 2;
            g2.name = "Adventure";
            Genre g3 = new Genre();
            //g3.id = 3;
            g3.name = "Comedy";
            Genre g4 = new Genre();
            //g4.id = 4;
            g4.name = "Crime";
            Genre g5 = new Genre();
            //g5.id = 5;
            g5.name = "Documentry";
            Genre g6 = new Genre();
            //g6.id = 6;
            g6.name = "Drama";
            Genre g7 = new Genre();
            //g7.id = 7;
            g7.name = "Fantasy";
            Genre g8 = new Genre();
            //g8.id = 8;
            g8.name = "Horror";
            Genre g9 = new Genre();
            //g9.id = 9;
            g9.name = "Mistery";
            Genre g10 = new Genre();
           // g10.id = 10;
            g10.name = "Romance";
            Genre g11 = new Genre();
            //g11.id = 11;
            g11.name = "War";

            //HashMap<int,Genre>
            Dictionary<int, Genre> map = new Dictionary<int, Genre>(); ;
            map.Add(1, g1);
            map.Add(2, g2);
            map.Add(3, g3);
            map.Add(4, g4);
            map.Add(5, g5);
            map.Add(6, g6);
            map.Add(7, g7);
            map.Add(8, g8);
            map.Add(9, g9);
            map.Add(10, g10);
            map.Add(11, g11);


            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            //Add these to DB;
            dbContext.Genre.Add(g1);
            dbContext.Genre.Add(g2);
            dbContext.Genre.Add(g3); 
            dbContext.Genre.Add(g4); 
            dbContext.Genre.Add(g5);
            dbContext.Genre.Add(g6);
            dbContext.Genre.Add(g7);
            dbContext.Genre.Add(g8);
            dbContext.Genre.Add(g9);
            dbContext.Genre.Add(g10);
            dbContext.Genre.Add(g11);


            var client = new HttpClient();


            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://ott-details.p.rapidapi.com/advancedsearch?start_year=1970&end_year=2020&min_imdb=6&max_imdb=7.8&genre=action&language=english&type=movie&sort=latest&page=1"),
                Headers =
{
{ "X-RapidAPI-Host", "ott-details.p.rapidapi.com" },
{ "X-RapidAPI-Key", "1bacf7826dmsh617aefdc9ca940ap122776jsnfad2dbb63d73" },
},
            };


            string genreData = "";
            Rootobject movies = null;




            try
            {



                using (var response = await client.SendAsync(request1))
                {

                    genreData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();



                }



                if (!genreData.Equals(""))
                {
                    Console.WriteLine(genreData);

                    movies = JsonConvert.DeserializeObject<Rootobject>(genreData);


                }
                /*{
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string NATIONAL_PARK_API_PATH = BASE_URL + "/advancedsearch?start_year=1970&end_year=2020&min_imdb=6&max_imdb=7.8&genre=action&language=english&type=movie&sort=latest&page=1";
                    string parksData = "";

                    Parks parks = null;

                    //httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);
                    httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

                    try
                    {
                        //HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
                        //                                        .GetAwaiter().GetResult();
                        HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
                                                                .GetAwaiter().GetResult();



                        if (response.IsSuccessStatusCode)
                        {
                            parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        }

                        if (!parksData.Equals(""))
                        {
                            // JsonConvert is part of the NewtonSoft.Json Nuget package
                            parks = JsonConvert.DeserializeObject<Parks>(parksData);
                        }*/

                ViewBag.data = movies;
                Rootobject obj = new Rootobject();
                obj.Id=movies.Id;
                dbContext.Rootobject.Add(obj);
                Random rnd = new Random();

                foreach (var item in movies.results)
                {
                    Result res = new Result();
                    res.id = item.id;
                    int n = numbers[rnd.Next(numbers.Count)];
                    res.genres = map.GetValueOrDefault(n);
                    res.title = item.title;
                    res.root = obj;
                    res.released = item.released;
                    res.title = item.title;
                    res.imdbid = item.imdbid;
                    res.imdbrating = item.imdbrating;
                    res.synopsis = item.synopsis;
                    res.type = item.type;
                    

                    //res.root = obj;

                    dbContext.Result.Add(res);


                    Result res1 = new Result();
                    res1.id = item.id;
                    int n2 = numbers[rnd.Next(numbers.Count)];
                    res1.genres = map.GetValueOrDefault(n2);
                    res1.title = item.title;
                    res1.root = obj;
                    res1.released = item.released;
                    res1.title = item.title;
                    res1.imdbid = item.imdbid;
                    res1.imdbrating = item.imdbrating;
                    res1.synopsis = item.synopsis;
                    res1.type = item.type;
                    dbContext.Result.Add(res1);
                }

               // dbContext.Rootobject.Add(movies);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(movies);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult addMovie()
        {
            return View();
        }

        public IActionResult EditMovie()
        {
            return View();
        }

        public IActionResult DeleteMovie()
        {
            return View();
        }
        public IActionResult EditMovieB()
        {
            return View();
        }
    }
}













