using System;
using Produk;

namespace Pencarian
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdukList produkList = new ProdukList();

            produkList.TambahProduk(new Class1("Nasi Goreng", 15000, 10));
            produkList.TambahProduk(new Class1("Mie Ayam", 12000, 5));
            produkList.TambahProduk(new Class1("Sate Ayam", 25000, 8));
            produkList.TambahProduk(new Class1("Bakso Sapi", 10000, 12));

            string input;
            do
            {
                Console.Write("Masukkan nama makanan yang ingin dicari: ");
                input = Console.ReadLine();

                Class1 makanan = produkList.CariProduk(input);

                if (makanan != null)
                {
                    Console.WriteLine($"  {makanan.Nama}");
                    Console.WriteLine($"  Harga: {makanan.Harga}");
                    Console.WriteLine($"  Jumlah produk: {makanan.Stok}");
                }
                else
                {
                    Console.WriteLine($"\nMakanan yang Anda cari tidak ditemukan.");
                }

                Console.Write("\nApakah Anda ingin mencari makanan lain? (y/n) ");
                input = Console.ReadLine().ToLower();
                Console.WriteLine("");
            } while (input == "y");
        }
    }
}
