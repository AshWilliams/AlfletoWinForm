using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //sql objects

namespace WindowsFormsAlfleto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbTestDataSet.TablaTest' Puede moverla o quitarla según sea necesario.
            this.tablaTestTableAdapter.Fill(this.dbTestDataSet.TablaTest);

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var myConn = new SqlConnection();
            myConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsAlfleto.Properties.Settings.DbTestConnectionString"].ConnectionString;

            using (myConn)
            {
                myConn.Open();
                var myCommand = new SqlCommand("ProcedureTest", myConn); //Solo el nombre del procedimiento
                myCommand.CommandType = CommandType.StoredProcedure;

                var myReader = await myCommand.ExecuteReaderAsync();

                while (await myReader.ReadAsync())
                {
                    //valor del campo TextoRandom
                    var myTexto = myReader.GetFieldValue<string>(1);
                    MessageBox.Show(myTexto);
                }

            }
                


        }
    }
}
