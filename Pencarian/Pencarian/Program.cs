namespace Produk
{
    public class ProdukList
    {
        private List<Class1> daftarProduk;

        public ProdukList()
        {
            daftarProduk = new List<Class1>();
        }

        public void TambahProduk(Class1 produk)
        {
            daftarProduk.Add(produk);
        }

        public Class1 CariProduk(string nama)
        {
            return daftarProduk.Find(p => p.Nama == nama);
        }
    }

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
}