using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_Currency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task btnStart_ClickAsync()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5")
            };

            Data[] data = await client.GetFromJsonAsync<Data[]>("");
            // OUTPUT ONLY BTC by USD
            foreach (var item in data)
            {
                lblCCY.Text = item.ccy;
                lblBaseCCY.Text = item.base_ccy;
                lblBuy.Text = item.buy;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _ = btnStart_ClickAsync();
        }
    }
}
