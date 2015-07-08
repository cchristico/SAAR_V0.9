using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAAR.Negocio;
using System.Threading.Tasks;
using SAAR.Datos;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CLSConsulta cts = new CLSConsulta();
        string DatoEliminar;
        ValidarConsultas valCons = new ValidarConsultas();
        public Form1()
        {
            InitializeComponent();
            renderizacion();
            this.MinimumSize = new Size(750, 330);
            DataTable DT = cts.consultar("select * from AREACOMUN");
            dataGridView1.DataSource = DT;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            dtTimer.Format = DateTimePickerFormat.Custom;
            dtTimer.CustomFormat = "HH : mm";

            
        }
     
   private void txtArComTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;
            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtArComNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;
            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtArComAforo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else if (char.IsLetter(e.KeyChar))
                e.Handled = true;
            else if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String MenIngreso="";
            MenIngreso = valCons.insAreaComun(txtArComTipo.Text.ToString(), txtArComNombre.Text.ToString(), txtArComAforo.Text.ToString(), txtArComOper.Text.ToString());
            
                MessageBox.Show("Ingreso Exitoso");
            
           // else { MessageBox.Show("Verifique Información"+MenIngreso); }
                DataTable DT = cts.consultar("select * from AREACOMUN");
                dataGridView1.DataSource = DT;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;  
            limpiar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }





        public void limpiar()
        {
            txtArComNombre.Clear();
            txtArComAforo.Clear();
            txtArComOper.Clear();
            txtArComTipo.Clear();
        }
        private void renderBtn(Button boton)
        {
            boton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.None;
        }
        private void renderTxt(TextBox txtBox)
        {
            txtBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.None;
        }

        public void renderizacion()
        {
            AreasComunes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.None;
            renderBtn(btbAcCan);
            renderBtn(btnActualizar);
            renderBtn(btnCancelar);
            renderBtn(btnEliminar);
            renderBtn(btnIngresar);
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.None;
            renderTxt(txtArComAforo);
            renderTxt(txtArComNombre);
            renderTxt(txtArComTipo);
            renderTxt(txtArComOper);
            
        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message = "Desea Eliminar: " + txtArComNombre.Text.ToString();
            const string caption = "Habitación Eliminada";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    valCons.eliminarArea(DatoEliminar);
                }
                catch {
                    MessageBox.Show("Area Comun Eliminada", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                limpiar();

                DataTable DT = cts.consultar("select * from AREACOMUN");
                dataGridView1.DataSource = DT;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;  
            
                
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            valCons.actualizar(DatoEliminar.Trim(), txtArComTipo.Text.ToString().Trim(), txtArComNombre.Text.ToString().Trim(), txtArComAforo.Text.ToString().Trim(), txtArComOper.Text.ToString().Trim());
            limpiar();
            DataTable DT = cts.consultar("select * from AREACOMUN");
            dataGridView1.DataSource = DT;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblTime2.Text = DateTime.Now.ToLongTimeString();
            lblDate2.Text = DateTime.Now.ToLongDateString();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DatoEliminar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtArComTipo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtArComNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtArComAforo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtArComOper.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        
        
        }
 
    }

