using Produk;

namespace Produk
{
    public class Produk<T>
    {
        private List<T> daftarProduk = new List<T>();

        public void tambahProduk(T produk)
        {
            daftarProduk.Add(produk);
        }


        public void hapusProduk(string nama)
        {
            var produk = daftarProduk.Find(p => p.GetType().GetProperty("nama").GetValue(p).ToString() == nama);
            if (produk != null)
            {
                daftarProduk.Remove(produk);
            }
        }
        public void tampilkanSemuaProduk()
        {
            Console.WriteLine("Daftar Produk Tersedia : ");
            foreach (var i in daftarProduk)
            {
                Console.WriteLine(" o\t" + i.ToString());
                Console.WriteLine();
            }
        }
    }

    public class Barang
    {
        public string nama { get; set; }
        public int harga { get; set; }

        public int stok { get; set; }

        public Barang()
        {

        }
        public Barang(string nama, int harga, int stok)
        {
            this.nama = nama;
            this.harga = harga;
            this.stok = stok;
        }

        public override string ToString()
        {
            return $"{nama} \n\tHarga: {harga} \n\tStok: {stok}";
        }
    }



}
public class Program
{
    public static void Main(string[] args)
    {
        Produk<Barang> produk = new Produk<Barang>();
        // Tambah Produk
        produk.tambahProduk(new Barang { nama = "Cimol", harga = 5000, stok = 100 });
        produk.tambahProduk(new Barang { nama = "Cilor", harga = 5000, stok = 100 });
        produk.tambahProduk(new Barang { nama = "Maklor", harga = 3000, stok = 100 });
        produk.tambahProduk(new Barang { nama = "Bacil", harga = 7000, stok = 100 });
        produk.tambahProduk(new Barang { nama = "Cilok", harga = 5000, stok = 100 });
        // tampilkan semua produk
        produk.tampilkanSemuaProduk();

        //hapus produk
        produk.hapusProduk("Cimol");
        produk.tampilkanSemuaProduk();

    }
}