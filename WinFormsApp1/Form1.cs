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

            this.dataAdapterChild = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectChild"], this.dbConnection);
            this.dataAdapterParent = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectParent"], this.dbConnection);

            new SqlCommandBuilder(dataAdapterChild);

            this.dataAdapterChild.Fill(this.dataSet, ConfigurationManager.AppSettings["ChildTableName"]);
            this.dataAdapterParent.Fill(this.dataSet, ConfigurationManager.AppSettings["ParentTableName"]);

            MessageBox.Show(ConfigurationManager.AppSettings["ParentReferencedKey"]);
           /* MessageBox.Show(dataSet.Tables[ConfigurationManager.AppSettings["ParentTableName"]].Columns[ConfigurationManager.AppSettings["ParentReferencedKey"]]);
            MessageBox.Show(dataSet.Tables[ConfigurationManager.AppSettings["ChildTableName"]].Columns[ConfigurationManager.AppSettings["ChildForeignKey"]]);*/

            var dataRelation = new DataRelation(
                 ConfigurationManager.AppSettings["ForeignKey"],
                 dataSet.Tables[ConfigurationManager.AppSettings["ParentTableName"]].Columns[ConfigurationManager.AppSettings["ParentReferencedKey"]],
                 dataSet.Tables[ConfigurationManager.AppSettings["ChildTableName"]].Columns[ConfigurationManager.AppSettings["ChildForeignKey"]],
                 false);
            dataSet.Relations.Add(dataRelation);
           // this.dataSet.Relations.Add(dataRelation);
        }

        private void InitializeUI()
        {
            this.bindingChild.DataSource = this.dataSet;
            this.bindingChild.DataMember = ConfigurationManager.AppSettings["ParentTableName"]; ;

            this.bindingParent.DataSource = this.bindingChild;
            this.bindingParent.DataMember = ConfigurationManager.AppSettings["ForeignKey"];

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
            this.dataAdapterChild.Update(dataSet, ConfigurationManager.AppSettings["ChildTableName"]);
            this.dataAdapterParent.Update(dataSet, ConfigurationManager.AppSettings["ParentTableName"]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitializeDatabase();
            this.InitializeUI();
        }
    }
}
