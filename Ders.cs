public class Ders
{
    public int Id { get; set; }
    public string DersAdi { get; set; }
    public string Gun { get; set; }
    public string Saat { get; set; }

    public Ders() { }
    public Ders(string adi, string gun, string saat)
    {
        DersAdi = adi;
        Gun = gun;
        Saat = saat;
    }

    public virtual string BilgiVer()
    {
        return $"{DersAdi} - {Gun} - {Saat}";
    }

    public override string ToString() => BilgiVer();
}