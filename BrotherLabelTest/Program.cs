using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bpac;

namespace BrotherLabelTest
{
    class Program
    {
        //http://www.brother.com/product/dev/label/bpac/download/index.htm
        //Installer 32bit (64bit virker ikke)
        static void Main(string[] args)
        {
            string strFilePath = "TRR-MAT-LABEL.lbx";

            Document doc = new Document();

            // Open template
            doc.Open(strFilePath);
            //Console.WriteLine(doc.GetPrinterName());

            doc.GetObject("ComputerName").Text = "Computernavn";
            doc.GetObject("Barcode").Text = "Stregkode";
            doc.GetObject("BottomText").Text = "TIL TJENESTEBRUG";
            
            // Print setting start
            doc.StartPrint("", PrintOptionConstants.bpoDefault);

            // Adds a print job (1 job is printed)
            doc.PrintOut(1, PrintOptionConstants.bpoDefault);

            // Print setting end (=Print start)
            doc.EndPrint();

            // Close template
            doc.Close();
        }

        private void CheckIfOnline()
        {
            Document doc = new Document();

            // Acquire the printer list
            object[] printers = (object[])doc.Printer.GetInstalledPrinters();

            // Acquire the printer name
            // string printerName = doc.GetPrinterName();
            string printerName = printers[0].ToString();

            // Check that the printer is online
            if (doc.Printer.IsPrinterOnline(printerName))
                Console.WriteLine($"{printerName} er online");
            else
                Console.WriteLine($"{printerName} er offline");

            Console.ReadKey();
        }
    }
}
