using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;


namespace PRACTICA_API2
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Form1 programa = new Form1();
            await GetTodoItems();
        }
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync("https://run.mocky.io/v3/1c3ae470-fca5-404e-922d-be70f41b7e67");
            Console.WriteLine(response);
            List<Todo> porhacer = JsonConvert.DeserializeObject<List<Todo>>(response);
            foreach (var item in porhacer)
            {
                string parsedPlaceId = item.PlaceId;
                string parsedPlaceName = item.PlaceName;
                string parsedAddress = item.Address;
                string parsedCategory = Convert.ToString(item.Category);
                string parsedRating = Convert.ToString(item.Rating);
                string parsedIsPetFriendly = Convert.ToString(item.IsPetFriendly);
                string parsedPhoneNumber = Convert.ToString (item.PhoneNumber);
                string parsedSite = Convert.ToString(item.Site);
                string[] row = { parsedPlaceId, parsedPlaceName, parsedAddress, parsedCategory, parsedRating, parsedIsPetFriendly, parsedPhoneNumber, parsedSite };
                var lisViewItems = new ListViewItem(row);
                listView1.Items.Add(lisViewItems);
            }
        }
        class Todo
        {
            public string PlaceId { get; set; }
            public string PlaceName { get; set; }
            public string Address { get; set; }
            public string Category { get; set; }
            public double Rating { get; set; }
            public bool IsPetFriendly { get; set; }
            public string PhoneNumber { get; set; }
            public string Site { get; set; }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
