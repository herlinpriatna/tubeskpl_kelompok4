using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Account.AccountSystem;

namespace Account
{
    internal class AccountSystem
    {
        public enum State
        {
            Start, Login, Registrasi,
            PembeliRegistrasi, PembeliLogin, PembeliScreen,
            PenjualRegistrasi, PenjualLogin, PenjualScreen,
            End
        };

        public enum Trigger { pembeliSelect, penjualSelect, RegistrasiBtn, LoginBtn, Submit, Cancel };

        class transisi
        {
            public State prevState;
            public State nextState;
            public Trigger trigger;

            public transisi(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        transisi[] transisiArr =
        {
            //start
            new transisi(State.Start, State.Registrasi, Trigger.RegistrasiBtn),
            new transisi(State.Start, State.Login, Trigger.LoginBtn),
            new transisi(State.Start, State.End, Trigger.Cancel),

            //registrasi
            new transisi(State.Registrasi, State.PembeliRegistrasi, Trigger.pembeliSelect),
            new transisi(State.Registrasi, State.PenjualRegistrasi, Trigger.penjualSelect),
            new transisi(State.Registrasi, State.End, Trigger.Cancel),

            new transisi(State.PembeliRegistrasi, State.Start, Trigger.Submit),
            new transisi(State.PembeliRegistrasi, State.Registrasi, Trigger.Cancel),

            new transisi(State.PembeliRegistrasi, State.Start, Trigger.Submit),
            new transisi(State.PembeliRegistrasi, State.Registrasi, Trigger.Cancel),

            //login
            new transisi(State.Login, State.PembeliLogin, Trigger.pembeliSelect),
            new transisi(State.Login, State.PenjualLogin, Trigger.penjualSelect),
            new transisi(State.Login, State.End, Trigger.Cancel),

            new transisi(State.PembeliLogin, State.PembeliScreen, Trigger.Submit),
            new transisi(State.PembeliLogin, State.Login, Trigger.Cancel),

            new transisi(State.PenjualLogin, State.PenjualScreen, Trigger.Submit),
            new transisi(State.PenjualLogin, State.Login, Trigger.Cancel),

            // Bagian MainScreen
            new transisi(State.PembeliScreen, State.Start, Trigger.Cancel),
            new transisi(State.PenjualScreen, State.Start, Trigger.Cancel)
        };

        public State currentState;

        public State getNextState(State prevState, Trigger trigger)
        {
            State nextState = prevState;
            for (int i = 0; i < transisiArr.Length; i++)
            {
                if (transisiArr[i].prevState == prevState && transisiArr[i].trigger == trigger)
                {
                    nextState = transisiArr[i].nextState;
                }
            }
            return nextState;
        }
        public void activeTrigger(Trigger trigger)
        {
            State nextState = getNextState(currentState, trigger);
            currentState = nextState;
        }

        public void Register()
        {
            //Preconditions
            Debug.Assert(currentState == AccountSystem.State.PembeliRegistrasi ||
                currentState == AccountSystem.State.PenjualRegistrasi, "Invalid state");

            if (currentState == AccountSystem.State.PembeliRegistrasi)
            {
                Console.WriteLine("--Registrasi Pembeli--");
            }
            else if (currentState == AccountSystem.State.PenjualRegistrasi)
            {
                Console.WriteLine("--Registrasi Penjual--");
            }

            Console.WriteLine("Name (maks: 20 huruf, tidak ada spasi)");
            Console.Write("Input: ");
            string Name = Console.ReadLine();
            // Cek panjang username dan apakah terdapat spasi pada username
            if (Name.Length > 20 || Name.Contains(" "))
            {
                Console.WriteLine("Name tidak valid");
                return;
            }

            Console.WriteLine("Password (maks: 16 karakter, tidak ada spasi)");
            Console.Write("Input: ");
            string password = Console.ReadLine();

            // Cek panjang password dan apakah terdapat spasi pada password
            if (password.Length > 16 || password.Contains(" "))
            {
                Console.WriteLine("Password tidak valid");
                return;
            }

            // Memasukkan data ke dengan teknik Runtime Config
            string tipe_akun = "";
            if (currentState == State.PembeliRegistrasi)
            {
                tipe_akun = "Pembeli";
            }
            else if (currentState == State.PenjualRegistrasi)
            {
                tipe_akun = "Penjual";
            }

            Config config = new Config(tipe_akun, Name, password);
            Account acc = new Account();
            acc.config = config;
            acc.WriteNewConfigFile();

            Console.WriteLine("\nRegistrasi berhasil!");
            Console.WriteLine("Kembali ke halaman Registrasi/Login");
        }

        public void Login()
        {
            //Preconditions
            //Debug.Assert(currentState == AccountSystem.State.PembeliLogin ||
              //  currentState == AccountSystem.State.PenjualLogin, "Invalid state");

            String tipe_akun = "";
            if (currentState == AccountSystem.State.PembeliLogin)
            {
                Console.WriteLine("--Login Pembeli--");
                tipe_akun = "Pembeli";
            }
            else if (currentState == AccountSystem.State.PenjualLogin)
            {
                Console.WriteLine("--Login Penjual--");
                tipe_akun = "Penjual";
            }

            Console.Write("Name: ");
            string Name = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Pengecekan tipe akun, username, password
            Account acc = new Account();
            Config config = acc.ReadConfigFile();

            if (tipe_akun == config.tipe_akun && Name == config.Name && password == config.Password)
            {
                Console.WriteLine("Login berhasil!");
            }
            else
            {
                Console.WriteLine("Login gagal, Name atau password salah");
            }
        }

        public void MainScreen()
        {
            //Preconditions
            //Debug.Assert(currentState == AccountSystem.State.PembeliScreen ||
              //  currentState == AccountSystem.State.PenjualScreen, "Invalid state");

            Account acc = new Account();
            Config config = acc.ReadConfigFile();

            if (currentState == AccountSystem.State.PembeliScreen)
            {
                Console.WriteLine("Selamat datang, pembeli " + config.Name + "!");
            }
            else if (currentState == AccountSystem.State.PenjualScreen)
            {
                Console.WriteLine("Selamat datang, Penjual " + config.Name + "!");
            }

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Logout");
            string menuMain = Console.ReadLine();

            if (menuMain == "1")
            {
                Console.WriteLine("Logout. Kembali ke halaman Registrasi/Login");
                activeTrigger(Trigger.Cancel);
            }
        }
    }
}
