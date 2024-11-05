
namespace TrenRezervasyonAPI.Models
{

    public class ReservationRequest
    {
        public Train Tren { get; set; } = null!;
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }


}