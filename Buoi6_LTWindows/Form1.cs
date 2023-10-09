using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Buoi6_LTWindows
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            this.rdbNu.Checked = true;
            this.cbbKhoa.SelectedIndex = 0;
        }

        public void insertOrUpdate(int row)
        {
            dgvDanhSach.Rows[row].Cells[0].Value = txtMaSV.Text;
            dgvDanhSach.Rows[row].Cells[1].Value = txtHoTen.Text;
            dgvDanhSach.Rows[row].Cells[2].Value = rdbNam.Checked ? "Nam" : "Nữ";
            dgvDanhSach.Rows[row].Cells[3].Value = cbbKhoa.Text;
            dgvDanhSach.Rows[row].Cells[4].Value = txtDiemTB.Text;
        }

        public void resetNull()
        {
            txtHoTen.Text = txtDiemTB.Text = txtMaSV.Text = string.Empty;
            rdbNu.Checked = true;
            cbbKhoa.SelectedIndex = 0;
        }

        public bool checkMaSV()
        {
            if(txtMaSV.Text.Length != 2)
            {
                return false;
            }
            return true;
        }

        public bool checkDTB()
        {
            float dtb = float.Parse(txtDiemTB.Text);
            if (dtb > 10 || dtb < 0)
                return false;
            return true;
        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chi nhap so", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int row = timSinhVien(txtMaSV.Text);
                if(row == -1)
                {
                    throw new Exception("Sinh vien khong ton tai");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Ban co muon xoa?", "Thong bao", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        dgvDanhSach.Rows.RemoveAt(row);
                        countGender();
                        resetNull();
                        MessageBox.Show("Xoa thanh cong", "Thong bao", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lay index cua dong nguoi dung dang chon
            int index = int.Parse(e.RowIndex.ToString());
            txtMaSV.Text = dgvDanhSach[0, index].Value.ToString();
            txtHoTen.Text = dgvDanhSach[1, index].Value.ToString();
            if (dgvDanhSach[2, index].Value.ToString() == "Nam")
                rdbNam.Checked = true;
            else
                rdbNu.Checked = true;
            cbbKhoa.Text = dgvDanhSach[3, index].Value.ToString();
            txtDiemTB.Text = dgvDanhSach[4, index].Value.ToString();
        }
    }
}
