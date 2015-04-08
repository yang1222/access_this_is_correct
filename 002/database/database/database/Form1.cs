using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string data = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=data.mdb";

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(data);

            conn.Open();

            string searchNID = "Select * From data";

            OleDbCommand cmd = new OleDbCommand(searchNID, conn);
            
            cmd.ExecuteNonQuery();
            
            OleDbDataReader dr;

            dr = cmd.ExecuteReader();

            int count;

            count = dr.FieldCount;

            while (dr.Read()) 
            {
                int n;

                for (n = 0 ; n < count; n++) 
                {

                    
                    label1.Text += dr[n].ToString()+" ";
                    
                }
            }

            dr.Close();

            cmd.Dispose();

            conn.Close();

        }
    }
}
