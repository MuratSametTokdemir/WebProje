using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProjesi.Models;

namespace WebProgramlamaProjesi.Controllers
{
   

    public class FilmlerController : Controller
    {
        private AppDbContext _context;

        private readonly FilmlerRepository _filmlerRepository;

        public FilmlerController(AppDbContext constext)
        {
            _filmlerRepository = new FilmlerRepository();

            _context = constext;

            if (!_context.Filmler.Any())
            {
                _context.Filmler.Add(new Filmler() { Name = "Yüzüklerin Efendisi", Year = 2001, DirectorName = "Peter Jackson", Kategori = "Fantastik" });
                _context.Filmler.Add(new Filmler() { Name = "Demir Adam", Year = 2008, DirectorName = "Jon Favreau", Kategori = "Bilim Kurgu" });
                _context.Filmler.Add(new Filmler() { Name = "İnception", Year = 2010, DirectorName = "Christopher Nolan", Kategori = "Bilim Kurgu" });
                _context.Filmler.Add(new Filmler() { Name = "Avengers", Year = 2012, DirectorName = "Anthony Russo", Kategori = "Bilim Kurgu" });
                _context.Filmler.Add(new Filmler() { Name = "Prestige", Year = 2006, DirectorName = "Christopher Nolan", Kategori = "Gizem" });
                _context.Filmler.Add(new Filmler() { Name = "İnterstellar", Year = 2014, DirectorName = "Christopher Nolan", Kategori = "Bilim Kurgu" });
                _context.Filmler.Add(new Filmler() { Name = "Dunkirk", Year = 2017, DirectorName = "Christopher Nolan", Kategori = "Savaş" });
                _context.Filmler.Add(new Filmler() { Name = "Sherlock Holmes", Year = 2009, DirectorName = "Guy Ritchie", Kategori = "Polisiye" });
                _context.Filmler.Add(new Filmler() { Name = "Fight Club", Year = 1999, DirectorName = "David Fincher", Kategori = "Aksiyon" });
                _context.Filmler.Add(new Filmler() { Name = "Kara Şövalye", Year = 2008, DirectorName = "Christopher Nolan", Kategori = "Aksiyon" });
                _context.Filmler.Add(new Filmler() { Yorum = "Prestige harika bir film tavsiye ederim.", Puan = 4 });
                _context.Filmler.Add(new Filmler() { Yorum = "nception tam bir başyapıt", Puan = 5 });


                _context.SaveChanges();
            }




        }


        public IActionResult Index()
        {
            var filmler = _context.Filmler.ToList();
            return View(filmler);
        }
    }
}
