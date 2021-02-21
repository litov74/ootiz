using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOTiZ
{
    public partial class Calculator : Form
    {
        DataGridViewCell Cell;
        Rectangle rect;
        int value = 0;
        int move = 0;

        public Calculator(DataGridViewCell Cell, Rectangle rect)
        {
            InitializeComponent();
            this.rect = rect;
            this.Cell = Cell;
        }

        public new void Show()
        {
            if (Cell.DataGridView != null)
            {
                Cell.DataGridView.Enabled = false;
                base.Show();
                base.Activate();
                Input.Focus();
                this.Location = rect.Location;
                this.Width = rect.Width + Ok.Width;
                this.Height = rect.Height;
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            DoMove();
            Cell.Value = value;
            this.Close();
        }

        private void DoMove()
        {
            int value;
            if (int.TryParse(Input.Text, out value))
            {
                switch (move)
                {
                    case (0): { this.value  = value; break; }
                    case (1): { this.value += value; break; }
                    case (2): { this.value -= value; break; }
                    case (3): { this.value *= value; break; }
                    case (4): { this.value /= value; break; }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || 
                 e.KeyChar > 57) && 
                 e.KeyChar != 8)
            {
                e.Handled = true;
                if (e.KeyChar == '=' |
                    e.KeyChar == '+' |
                    e.KeyChar == '-' |
                    e.KeyChar == '*' |
                    e.KeyChar == '/')
                    DoMove();
                switch (e.KeyChar)
                {
                    case ((char)27): { this.Close(); break; }
                    case ('='): { move = 0; Input.Text = this.value.ToString(); break; }
                    case ('+'): { move = 1; Input.Clear(); break; }
                    case ('-'): { move = 2; Input.Clear(); break; }
                    case ('*'): { move = 3; Input.Clear(); break; }
                    case ('/'): { move = 4; Input.Clear(); break; }
                }
                e.Handled = true;
            }
        }

        private void Calculator_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Calculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Cell.DataGridView != null)
            {
                Cell.DataGridView.Enabled = true;
                Cell.DataGridView.Focus();
            }
        }
    }
}
