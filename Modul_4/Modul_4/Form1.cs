using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://dummy-user-tan.vercel.app/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newUser = new User
            {
                Id = 1,
                Name = "John Doe",
                Hutang = 100000,
                Saldo = 10000000,
            };

            var json = JsonConvert.SerializeObject(newUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var postResponse = client.PostAsync("user", data).Result;

            if (postResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Data Berhasil Ditambahkan");
            }
            else
            {
                MessageBox.Show("Error Code" + postResponse.StatusCode + " : Message - " + postResponse.ReasonPhrase);
            }

            HttpResponseMessage response = client.GetAsync("user").Result;
            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<IEnumerable<User>>(users);
                dataGridView1.DataSource = user;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
