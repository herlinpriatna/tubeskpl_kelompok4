using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

using System;
using System.Collections.Generic;

public enum MetodePembayaran
{
    Bank,
    Ewallet,
    COD
}

public class Produk
{
    public string Nama { get; set; }
    public int Harga { get; set; }
    public int Stok { get; set; }
}

public class PesanProduk
{
    private List<Produk> produkTersedia;

    public PesanProduk()
    {
        produkTersedia = new List<Produk>
        {
            new Produk { Nama = "Cimol", Harga = 10000, Stok = 5 },
            new Produk { Nama = "Cilok", Harga = 20000, Stok = 3 },
            new Produk { Nama = "Cilor", Harga = 30000, Stok = 2 }
        };
    }

    public void Pesan(string namaProduk, int jumlah, MetodePembayaran metodePembayaran)
    {
        var produk = produkTersedia.Find(p => p.Nama == namaProduk);
        if (produk == null)
        {
            Console.WriteLine($"Produk {namaProduk} tidak tersedia");
            return;
        }

        if (produk.Stok < jumlah)
        {
            Console.WriteLine($"Stok {namaProduk} tidak mencukupi");
            return;
        }

        switch (metodePembayaran)
        {
            case MetodePembayaran.Bank:
                Console.WriteLine("Silakan transfer ke rekening Kelompok 4 132346783");
                break;
            case MetodePembayaran.Ewallet:
                Console.WriteLine("Kode pembayaran: 53629728");
                break;
            case MetodePembayaran.COD:
                Console.WriteLine("Barang akan segera dikirimkan");
                break;
            default:
                Console.WriteLine("Metode pembayaran tidak valid");
                return;
        }

        produk.Stok -= jumlah;
        Console.WriteLine($"Pembelian {jumlah} {namaProduk} berhasil");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PesanProduk pesanProduk = new PesanProduk();

        // Pesan produk dengan metode pembayaran bank
        pesanProduk.Pesan("Cimol", 2, MetodePembayaran.Bank);
        Console.WriteLine();

        // Pesan produk dengan metode pembayaran ewallet
        pesanProduk.Pesan("Cilok", 1, MetodePembayaran.Ewallet);
        Console.WriteLine();


        // Pesan produk dengan metode pembayaran COD
        pesanProduk.Pesan("Cilor", 1, MetodePembayaran.COD);
        Console.WriteLine();


    }
}