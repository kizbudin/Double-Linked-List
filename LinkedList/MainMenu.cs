using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MainMenu
    {
        DoublyLinkedList<int> _doublyLinkedList = new DoublyLinkedList<int>();
        public void Menu()
        {
            
            while (true)
            {
                if (_doublyLinkedList.Count > 0)
                {
                    LihatData();
                }
                Console.WriteLine("==============================================");
                Console.WriteLine("                Linked List ");
                Console.WriteLine("1. Lihat Data");
                Console.WriteLine("2. Tambah data di awal");
                Console.WriteLine("3. Tambah data di akhir");
                Console.WriteLine("4. Hapus data");
                Console.WriteLine("5. Hapus data awal");
                Console.WriteLine("6. Hapus data akhir");
                Console.WriteLine("7. Hapus semua data");
                Console.WriteLine("8. Keluar");
                Console.WriteLine("==============================================\n");
                byte input = 0;
                Console.Write("Pilih menu [1-8]> ");
                if (byte.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            {
                                Console.Clear();
                                LihatData();
                                Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                TambahDiAwal();
                                break;
                            }
                        case 3:
                            {
                                TambahDiAkhir();
                                break;
                            }
                        case 4:
                            {
                                HapusData();
                                break;
                            }
                        case 5:
                            {
                                HapusDiAwal();
                                break;
                            }
                        case 6:
                            {
                                HapusDiAkhir();
                                break;
                            }
                        case 7:
                            {
                                HapusSemuaData();
                                break;
                            }
                        case 8:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.WriteLine("Input tak dikenal, program keluar");
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                }
            }

        }
        private void LihatData()
        {
            Console.WriteLine("*******************************");
            if (_doublyLinkedList.Count > 0)
            {

                Console.WriteLine("Nilai Head/Start: {0}", _doublyLinkedList.Head.Value);
                Console.WriteLine("Nilai Tail/End: {0}\n", _doublyLinkedList.Tail.Value);
                DoublyLinkedListNode<int> counter = _doublyLinkedList.Head;
                while (counter != null)
                {
                    string prev = counter.Previous == null ? "NULL" : counter.Previous.Value.ToString();
                    string current = counter.Value.ToString();
                    string next = counter.Next == null ? "NULL" : counter.Next.Value.ToString();
                    Console.WriteLine("  |Prev-Link: {0} | (Nilai: {1}) | Next-Link: {2} |", prev, current, next);
                    counter = counter.Next;
                }
            }
            else
            {
                Console.WriteLine("Tidak ada data di linked list");
            }
            Console.WriteLine("\n*******************************\n");
            

        }
        private void TambahDiAwal()
        {
            Console.Write("\nMasukkan nilai integer> ");
            int value = 0;
            if(int.TryParse(Console.ReadLine(),out value))
            {
                _doublyLinkedList.AddFirst(value);
                Console.WriteLine("Data berhasil diinputkan!"); 
            }
            else
            {
                Console.WriteLine("#Error: Harus input nilai integer!");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
        private void TambahDiAkhir()
        {

            Console.Write("\nMasukkan nilai integer> ");
            int value = 0;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                _doublyLinkedList.AddLast(value);
                Console.WriteLine("Data berhasil diinputkan!");
            }
            else
            {
                Console.WriteLine("#Error: Harus input nilai integer!");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
        private void HapusData()
        {
            LihatData();
            Console.Write("\nMasukkan nilai yang akan dihapus> ");
            int value = 0;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                if (_doublyLinkedList.Remove(value))
                {
                    Console.WriteLine("Data berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Data gagal dihapus, nilai tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("#Error: Harus input nilai integer!");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
        private void HapusDiAwal()
        {
            
            if (_doublyLinkedList.Count > 0)
            {
                Console.WriteLine("Tekan [Enter] untuk menghapus data di awal");
                Console.ReadLine();
                _doublyLinkedList.RemoveFirst();
                Console.WriteLine("Data berhasil dihapus");
            }
            else
            {
                Console.WriteLine("Tidak ada item di linked list");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
        private void HapusDiAkhir()
        {

            if (_doublyLinkedList.Count > 0)
            {
                Console.WriteLine("Tekan [Enter] untuk menghapus data di akhir");
                Console.ReadLine();
                _doublyLinkedList.RemoveLast();
                Console.WriteLine("Data berhasil dihapus");
            }
            else
            {
                Console.WriteLine("Tidak ada item di linked list");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
        private void HapusSemuaData()
        {

            if (_doublyLinkedList.Count > 0)
            {
                Console.WriteLine("Tekan [Enter] untuk menghapus semua data");
                Console.ReadLine();
                _doublyLinkedList.Clear();
                Console.WriteLine("Data berhasil dihapus");
            }
            else
            {
                Console.WriteLine("Tidak ada item di linked list");
            }
            Console.WriteLine("Tekan [Enter] untuk melanjutkan.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
