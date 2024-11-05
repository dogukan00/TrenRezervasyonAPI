using Microsoft.AspNetCore.Mvc;
using TrenRezervasyonAPI.Models;


namespace TrenRezervasyonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpPost]
        public IActionResult CheckReservation([FromBody] ReservationRequest request)
        {
            var response = new ReservationResponse();
            int toplamIstenenKoltukSayisi = request.RezervasyonYapilacakKisiSayisi;

            if (!request.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                foreach (var vagon in request.Tren.Vagonlar)
                {
                    int musaitKoltukSayisi = (int)(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;
                    if (musaitKoltukSayisi >= toplamIstenenKoltukSayisi)
                    {
                        response.RezervasyonYapilabilir = true;
                        response.YerlesimAyrinti.Add(new YerlesimAyrinti
                        {
                            VagonAdi = vagon.Ad,
                            KisiSayisi = toplamIstenenKoltukSayisi
                        });
                        return Ok(response);
                    }
                }
            }
            else
            {
                foreach (var vagon in request.Tren.Vagonlar)
                {
                    int musaitKoltukSayisi = (int)(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;
                    int atanacakKoltukSayisi = musaitKoltukSayisi > toplamIstenenKoltukSayisi ? toplamIstenenKoltukSayisi : musaitKoltukSayisi;

                    if (atanacakKoltukSayisi > 0)
                    {
                        response.YerlesimAyrinti.Add(new YerlesimAyrinti
                        {
                            VagonAdi = vagon.Ad,
                            KisiSayisi = atanacakKoltukSayisi
                        });

                        toplamIstenenKoltukSayisi -= atanacakKoltukSayisi;
                    }

                    if (toplamIstenenKoltukSayisi == 0)
                        break;
                }

                response.RezervasyonYapilabilir = toplamIstenenKoltukSayisi == 0;
            }

            return Ok(response);
        }
    }
}
