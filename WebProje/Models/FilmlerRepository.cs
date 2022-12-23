namespace WebProje.Models
{
    public class FilmlerRepository
    {
        private static List<Filmler> _filmler = new List<Filmler>();

        public List<Filmler> GetALL() => _filmler;

        public void Add(Filmler newFilmler) => _filmler.Add(newFilmler);

        public void Remove(int id)
        {
            var hasFilmler = _filmler.FirstOrDefault(x => x.Id == id);

            if (hasFilmler == null)
            {
                throw new Exception($"Bu ,id{id}'ye sahip film bulunmamaktadır.");
            }
            _filmler.Remove(hasFilmler);
        }

        public void Update(Filmler updateFilmler)
        {
            var hasFilmler = _filmler.FirstOrDefault(x => x.Id == updateFilmler.Id);

            if (hasFilmler == null)
            {
                throw new Exception($"Bu ,id{updateFilmler.Id}'ye sahip film bulunmamaktadır.");
            }

            hasFilmler.Name = updateFilmler.Name;
            hasFilmler.Year = updateFilmler.Year;
            hasFilmler.DirectorName=updateFilmler.DirectorName;

            var index = _filmler.FindIndex(x => x.Id == updateFilmler.Id);
            _filmler[index] = hasFilmler;


        }







    }
}
