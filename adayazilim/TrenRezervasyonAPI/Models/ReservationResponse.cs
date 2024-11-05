
namespace TrenRezervasyonAPI.Models
{

    public class ReservationResponse
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; } = new List<YerlesimAyrinti>();
    }

    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; } = null!;
        public int KisiSayisi { get; set; }
    }

 
}