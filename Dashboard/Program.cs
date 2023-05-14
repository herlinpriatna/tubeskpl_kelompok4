using System;

public class Dashboard
{
    public enum State
    {
        Start, Login, Registrasi, TampilkanSemuaProduk, PesanProduk, KeranjangProduk, ChatBot, CariProduk, Logout
    }

    private State currentState;

    public Dashboard()
    {
        currentState = State.Start;
    }

    public void Start()
    {
        Console.WriteLine("Selamat datang di Dashboard!");
        currentState = State.Login;
        ShowMenu();
    }

    public void Login()
    {
        Console.WriteLine("Anda berhasil login!");
        currentState = State.TampilkanSemuaProduk;
        ShowMenu();
    }

    public void Registrasi()
    {
        Console.WriteLine("Anda berhasil melakukan registrasi!");
        currentState = State.Login;
        ShowMenu();
    }

    public void TampilkanSemuaProduk()
    {
        Console.WriteLine("Berikut adalah daftar semua produk:");
        // logic untuk menampilkan semua produk
        currentState = State.PesanProduk;
        ShowMenu();
    }

    public void PesanProduk()
    {
        Console.WriteLine("Silakan pilih produk yang ingin Anda pesan:");
        // logic untuk memilih produk
        currentState = State.KeranjangProduk;
        ShowMenu();
    }

    public void KeranjangProduk()
    {
        Console.WriteLine("Ini adalah keranjang belanja Anda:");
        // logic untuk menampilkan keranjang belanja
        currentState = State.ChatBot;
        ShowMenu();
    }

    public void ChatBot()
    {
        Console.WriteLine("Anda sedang berbicara dengan ChatBot:");
        // logic untuk berinteraksi dengan ChatBot
        currentState = State.CariProduk;
        ShowMenu();
    }

    public void CariProduk()
    {
        Console.WriteLine("Silakan cari produk yang Anda inginkan:");
        // logic untuk mencari produk
        currentState = State.PesanProduk;
        ShowMenu();
    }

    public void Logout()
    {
        Console.WriteLine("Anda berhasil logout!");
        currentState = State.Start;
        ShowMenu();
    }

    public void ShowMenu()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Menu:");
        switch (currentState)
        {
            case State.Start:
                Console.WriteLine("1. Mulai");
                break;
            case State.Login:
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registrasi");
                break;
            case State.TampilkanSemuaProduk:
                Console.WriteLine("1. Tampilkan Semua Produk");
                Console.WriteLine("2. Cari Produk");
                Console.WriteLine("3. Logout");
                break;
            case State.PesanProduk:
                Console.WriteLine("1. Pilih Produk");
                Console.WriteLine("2. Kembali ke Daftar Produk");
                Console.WriteLine("3. Checkout");
                break;
            case State.KeranjangProduk:
                Console.WriteLine("1. Hapus Produk");
                Console.WriteLine("2. Lanjutkan Belanja");
                Console.WriteLine("3. Checkout");
                break;
            case State.ChatBot:
                Console.WriteLine("1. Tanya ChatBot");
                Console.WriteLine("2. Kembali ke Daftar Produk");
                Console.WriteLine("3. Checkout");
                break;
            case State.CariProduk:
                Console.WriteLine("1. Cari Produk");
                Console.WriteLine("2. Kembali ke Daftar Produk");
                Console.WriteLine("3. Checkout");
                break;
            case State.Logout:
                Console.WriteLine("1. Logout");
                break;
        }
        Console.WriteLine("----------------------------------");
    }
    public void HandleInput(string input)
    {
        switch (currentState)
        {
            case State.Start:
                if (input == "1")
                {
                    Start();
                }
                break;
            case State.Login:
                if (input == "1")
                {
                    Login();
                }
                else if (input == "2")
                {
                    currentState = State.Registrasi;
                    ShowMenu();
                }
                break;
            case State.Registrasi:
                if (input == "1")
                {
                    Registrasi();
                }
                break;
            case State.TampilkanSemuaProduk:
                if (input == "1")
                {
                    TampilkanSemuaProduk();
                }
                else if (input == "2")
                {
                    currentState = State.CariProduk;
                    ShowMenu();
                }
                else if (input == "3")
                {
                    Logout();
                }
                break;
            case State.PesanProduk:
                if (input == "1")
                {
                    PesanProduk();
                }
                else if (input == "2")
                {
                    currentState = State.TampilkanSemuaProduk;
                    ShowMenu();
                }
                else if (input == "3")
                {
                    currentState = State.KeranjangProduk;
                    ShowMenu();
                }
                break;
            case State.KeranjangProduk:
                if (input == "1")
                {
                    // logic untuk menghapus produk dari keranjang belanja
                    ShowMenu();
                }
                else if (input == "2")
                {
                    currentState = State.TampilkanSemuaProduk;
                    ShowMenu();
                }
                else if (input == "3")
                {
                    // logic untuk checkout
                    Logout();
                }
                break;
            case State.ChatBot:
                if (input == "1")
                {
                    // logic untuk berinteraksi dengan ChatBot
                    ShowMenu();
                }
                else if (input == "2")
                {
                    currentState = State.TampilkanSemuaProduk;
                    ShowMenu();
                }
                else if (input == "3")
                {
                    // logic untuk checkout
                    Logout();
                }
                break;
            case State.CariProduk:
                if (input == "1")
                {
                    // logic untuk mencari produk
                    currentState = State.PesanProduk;
                    ShowMenu();
                }
                else if (input == "2")
                {
                    currentState = State.TampilkanSemuaProduk;
                    ShowMenu();
                }
                else if (input == "3")
                {
                    // logic untuk checkout
                    Logout();
                }
                break;
            case State.Logout:
                if (input == "1")
                {
                    Logout();
                }
                break;
        }
    }

}

public class Program
{
    static void Main(string[] args)
    {
        Dashboard dashboard = new Dashboard();
        dashboard.Start();

        while (true)
        {
            string input = Console.ReadLine();
            dashboard.HandleInput(input);
        }
    }
}
