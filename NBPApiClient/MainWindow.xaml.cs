using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBPApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.nbp.pl/api/exchangerates/tables/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("a").Result;
            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsStringAsync().Result;// ReadAsA sync<IEnumerable<Employee>>().Result;
                lbl1.Content = employees;
                tb1.Text = employees;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:60792");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync("/api/student/" + txtID.Text);
            //    response.EnsureSuccessStatusCode(); // Throw on error code. 
            //    var students = await response.Content.ReadAsAsync<Student>();
            //    studentDetailsPanel.Visibility = Visibility.Visible;
            //    studentDetailsPanel.DataContext = students;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Student not Found");
            //}
        }
    }
}
