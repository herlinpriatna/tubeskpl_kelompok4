using Produk;

namespace Keranjang
{
    public class Keranjang
    {
        
        private List<Class1> _daftarProduk = new List<Class1>();

        public void TambahProduk(Class1 produk)
        {
            _daftarProduk.Add(produk);
            Console.WriteLine($"Produk \"{produk.Nama}\" telah ditambahkan ke keranjang.\n");
        }

        public void TampilkanKeranjang()
        {
            Console.WriteLine($"Isi keranjang ({_daftarProduk.Count} produk):");
            var jumlahProduk = new Dictionary<string, int>();
            foreach (var produk in _daftarProduk)
            {
                if (jumlahProduk.ContainsKey(produk.Nama))
                {
                    jumlahProduk[produk.Nama]++;
                }
                else
                {
                    jumlahProduk.Add(produk.Nama, 1);
                }
            }

            foreach (var item in jumlahProduk)
            {
                var produk = _daftarProduk.Find(p => p.Nama == item.Key);
                Console.WriteLine($"- {produk.Nama}");
                Console.WriteLine($"  Harga: {produk.Harga}");
                Console.WriteLine($"  Jumlah produk: {item.Value}\n");
            }
        }

        public void HapusProduk(string namaProduk)
        {
            var produk = _daftarProduk.Find(p => p.Nama == namaProduk);

            if (produk != null)
            {
                _daftarProduk.Remove(produk);
                Console.WriteLine($"Produk \"{namaProduk}\" telah dihapus dari keranjang.\n");
            }
            else
            {
                Console.WriteLine($"Produk dengan nama \"{namaProduk}\" tidak ditemukan di keranjang.");
            }
        }
    }

    public class Produk
    {
        public List<Class1> DaftarProduk { get; set; }

        public Produk()
        {
            DaftarProduk = new List<Class1>
            {
                new Class1("Nasi Goreng", 15000, 10),
                new Class1("Mie Ayam", 12000, 15),
                new Class1("Sate Ayam", 25000, 5),
                new Class1("Bakso Sapi", 10000, 20)
            };
        }

        public void CariDanTambahProduk(string namaProduk, Keranjang keranjang)
        {
            // mencari produk dengan nama yang sesuai
            var produk = DaftarProduk.Find(p => p.Nama == namaProduk);

            if (produk != null)
            {
                keranjang.TambahProduk(new Class1(namaProduk, produk.Harga, 1));
            }
            else
            {
                Console.WriteLine($"Produk dengan nama \"{namaProduk}\" tidak ditemukan.");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var keranjang = new Keranjang();
            var produk = new Produk();

            produk.CariDanTambahProduk("Nasi Goreng", keranjang);

            produk.CariDanTambahProduk("Nasi Goreng", keranjang);
            produk.CariDanTambahProduk("Nasi Goreng", keranjang);
            keranjang.TampilkanKeranjang();
            keranjang.HapusProduk("Nasi Goreng");
            produk.CariDanTambahProduk("Mie Ayam", keranjang);
            produk.CariDanTambahProduk("Sate Ayam", keranjang);
            produk.CariDanTambahProduk("Sate Ayam", keranjang);
            produk.CariDanTambahProduk("Bakso Sapi", keranjang);

            keranjang.TampilkanKeranjang();

            Console.ReadKey();
        }
    }
}