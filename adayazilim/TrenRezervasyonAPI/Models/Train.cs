
namespace TrenRezervasyonAPI.Models
{
    public class Train
    {
        public string Ad { get; set; } = null!;
        public List<Vagon> Vagonlar { get; set; } = null!;
    }

}


