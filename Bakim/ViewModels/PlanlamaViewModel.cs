namespace Bakim.ViewModels
{
    public class PlannlamaViewModel
    {
       public DateTime BaslangicTarihi { get; set; }
       public DateTime BitisTarihi { get; set; }
       public int BakimTuruId { get; set; }
       public string BakimAdi { get; set; }
       public string BakimAciklamasi { get; set; }
       public int? SectionId { get; set; }
       public int? MachineId { get; set; }
    }


}
