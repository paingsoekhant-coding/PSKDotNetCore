using Dapper;
using PSKDotNetCore.Shared;
using PSKDotNetCore.WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSKDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * , 1 result from  tbl_blog");
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;
            if (e.RowIndex == -1) return; 

            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();

                BlogList();
            }else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to Delete?","",MessageBoxButtons.YesNo ,MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
              
                DeleteBlog(blogId);   
            }
        }

        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
