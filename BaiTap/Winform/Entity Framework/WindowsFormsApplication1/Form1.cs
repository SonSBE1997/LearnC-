using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        EntityFrameworkEntities db = new EntityFrameworkEntities();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = source;
            LoadData();
            AddBinding();
        }

        #region Methods

        void LoadData()
        {
            var result = from o in db.Students
                             //where o.ID < 10
                         select new { ID = o.ID, Name = o.Name, ClassName = o.Class.Name };
            source.DataSource = result.ToList();
        }

        void AddStudent()
        {

            db.Students.Add(new Student()
            {
                Name = txbName.Text,
                IDClass = db.Classes.Where(_ => _.Name == txbClassName.Text).SingleOrDefault().ID
            });
            db.SaveChanges();
            LoadData();
        }

        void EditStudent()
        {
            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
            Student sv = db.Students.Find(id);
            if (sv == null)
            {
                MessageBox.Show("Can not find the student have id = " + id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sv.Name = txbName.Text;
            sv.IDClass = db.Classes.Where(p => p.Name == txbClassName.Text).SingleOrDefault().ID;
            db.SaveChanges();
            LoadData();
        }

        void DeleteStudent()
        {
            Class lop = db.Classes.Where(p => p.Name == txbClassName.Text).SingleOrDefault();
            if (lop == null)
            {
                MessageBox.Show("Can not find class have Class Name  = " + txbClassName.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = lop.ID;
            db.Students.Remove(db.Students.Where(_ => _.Name == txbName.Text &&
            _.IDClass == id).SingleOrDefault());
            db.SaveChanges();
            LoadData();
        }

        void AddBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbClassName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ClassName", true, DataSourceUpdateMode.Never));
        }
        #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditStudent();
        }
    }
}
