namespace Produk;

public class Class1
{
    public string Nama { get; set; }
    public int Harga { get; set; }
    public int Stok { get; set; }
    public int Jumlah { get; set; }

    public Class1(string nama, int harga, int stok)
    {
        Nama = nama;
        Harga = harga;
        Stok = stok;
        Jumlah = 1;
    }
}