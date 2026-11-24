using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tapşırığın adını yaz!");
                return;
            }

            dataGridView1.Rows.Add(textBox1.Text.Trim(), textBox2.Text.Trim(), dateTimePicker1.Value.ToString("dd.MM.yyyy HH:mm"), false);

            textBox1.Clear();
            textBox2.Clear();
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty) dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool isChecked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (isChecked)
                {
                    int rowIndex = e.RowIndex;
                    BeginInvoke(new Action(() =>
                    {
                        if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                        {
                            dataGridView1.Rows.RemoveAt(rowIndex);
                        }
                    }));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}