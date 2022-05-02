using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unity;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.BusinessLogicsContracts;

namespace SoftwareInstallationShopView
{
    public partial class FormPackages : Form
    {
        private readonly IPackageLogic logic;
        public FormPackages(IPackageLogic _logic)
        {
            InitializeComponent();
            logic = _logic;
        }
        private void FormPackages_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
          
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var package in list)
                    {
                        string strComponents = string.Empty;
                        foreach (var component in package.PackageComponents)
                        {
                            strComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                        }
                        dataGridView.Rows.Add(new object[] { package.Id, package.PackageName, package.Price, strComponents });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPackage>();
            if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormPackage>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new PackageBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                    LoadData();
                }
            }
        }
    

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
