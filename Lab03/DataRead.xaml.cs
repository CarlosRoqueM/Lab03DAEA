using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab03
{
    /// <summary>
    /// Lógica de interacción para DataRead.xaml
    /// </summary>
    public partial class DataRead : Window
    {
        public DataRead()
        {
            InitializeComponent();
            CargaDatos();
        }

        private void CargaDatos()
        {
            string ConnectionString = "Data Source= LAB1504-04\\SQLEXPRESS; Initial Catalog=lab03;" + "User Id = CarlosR; Password=123456";

            List<Student> students = new List<Student>();

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId = reader.GetInt32("StudentId");
                    string FirstName = reader.GetString("FirstName");
                    string LastName = reader.GetString("LastName");

                    students.Add(new Student { StudentId = StudentId, FirstName = FirstName, LastName = LastName });
                }
                connection.Close();
                Number02.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }
        }
    }
