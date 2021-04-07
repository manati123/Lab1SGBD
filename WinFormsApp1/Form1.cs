using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly string PARENT_TABLE = "Certification";
        private readonly string CHILD_TABLE = "Freelancer";
        private readonly string FK = "FK_Freelancer_Certification";

        private DataSet dataSet = new DataSet();
        private SqlConnection dbConnection;

        private SqlDataAdapter dataAdapterParent, dataAdapterChild;
        private BindingSource bindingChild = new BindingSource();
        private BindingSource bindingParent = new BindingSource();

        private void InitializeDatabase()
        {
            this.dbConnection = new SqlConnection("Data Source=DESKTOP-0UHOTTS\\SQLEXPRESS;"
               + "Initial Catalog = Final_Lab_Doamne_Ajuta;"
               + "Integrated Security = True;");

            this.dataAdapterChild = new SqlDataAdapter($"SELECT * FROM  {this.CHILD_TABLE}",this.dbConnection);
            this.dataAdapterParent = new SqlDataAdapter($"SELECT * FROM {this.PARENT_TABLE}", this.dbConnection);

            new SqlCommandBuilder(dataAdapterChild);

            this.dataAdapterChild.Fill(this.dataSet, this.CHILD_TABLE);
            this.dataAdapterParent.Fill(this.dataSet, this.PARENT_TABLE);

            var dataRelation = new DataRelation(
                this.FK,
                this.dataSet.Tables[this.CHILD_TABLE].Columns["freelancer_id"],
                this.dataSet.Tables[this.PARENT_TABLE].Columns["freelancer_id"],
                false
                );
            this.dataSet.Relations.Add(dataRelation);
        }

        private void InitializeUI()
        {
            this.bindingChild.DataSource = this.dataSet;
            this.bindingChild.DataMember = this.CHILD_TABLE;

            this.bindingParent.DataSource = this.bindingChild;
            this.bindingParent.DataMember = this.FK;

            this.childGridView.DataSource = this.bindingChild;
            this.parentGridView.DataSource = this.bindingParent;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void updateBD_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmd = new SqlCommandBuilder(this.dataAdapterParent);
            cmd.GetInsertCommand();
            this.dataAdapterChild.Update(dataSet, CHILD_TABLE);
            this.dataAdapterParent.Update(dataSet, PARENT_TABLE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitializeDatabase();
            this.InitializeUI();
        }
    }
}
