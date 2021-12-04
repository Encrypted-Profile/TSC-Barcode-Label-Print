using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSC_Print
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string bName = txtBusinessName.Text;
                string pName = txtProductName.Text;
                string pCode = txtProductCode.Text;
                double price = double.Parse(txtProductPrice.Text);

                    TSCLIB_DLL.openport("Printer Name");         //Open specified printer driver
                    TSCLIB_DLL.setup("35", "25", "4", "8", "0", "2.5", "0");    //Setup the media size and sensor type info
                    TSCLIB_DLL.clearbuffer();     //Clear image buffer
                    TSCLIB_DLL.windowsfont(18, 25, 25, 0, 2, 0, "Century Gothic", bName);  //Draw Business Name
                    TSCLIB_DLL.barcode("18", "55", "128", "60", "1", "0", "2", "2", pCode); //Drawing barcode
                    TSCLIB_DLL.windowsfont(18, 135, 30, 0, 2, 0, "Century Gothic", pName);  //Draw Product Name
                    TSCLIB_DLL.windowsfont(18, 165, 30, 0, 2, 0, "Century Gothic", "Retail: Rs." + price);  //Draw Price
                    TSCLIB_DLL.sendcommand("PUTPCX 100,400,\"UL.PCX\"");  //Drawing PCX graphic
                    TSCLIB_DLL.printlabel("1", "1"); //Print labels
                    TSCLIB_DLL.closeport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
