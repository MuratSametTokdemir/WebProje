namespace WebProgramlamaOdev.Models
{
    public class FilmlerRepository
    {
        private static List<Filmler> _filmler = new List<Filmler>();

        public List<Filmler> GetALL() => _filmler;

        public void Add(Filmler newFilmler) => _filmler.Add(newFilmler);

        

        
    }

}
