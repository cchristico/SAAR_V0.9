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
        string IdActivo;
        ValidarConsultas valCons = new ValidarConsultas();
        public Form1()
        {
            InitializeComponent();
            renderizacion();
            llenarCmbActivo();
            this.MinimumSize = new Size(750, 330);
            /*Inicialización Area Comun*/
            DataTable DT = cts.consultar("select * from AREACOMUN");
            dataGridView1.DataSource = DT;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].Visible = false;
            /*Inicializacion Activos*/
            DataTable DT1 = cts.consultar("select IDACTIVO, NOMBRE_ACT as Nombre, CANTIDAD_ACT as Cantidad,OBSERVACION_ACT as Observaciones from ACTIVOS order by IDACTIVO");
            dtGridActivos.DataSource = DT1;
            dtGridActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtGridActivos.Columns[0].Visible = false;
            /**/
            dtTimer.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dtTimer.CustomFormat = "HH : mm";
            dateTimePicker3.CustomFormat = "HH : mm";


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
            String MenIngreso = "";
            MenIngreso = valCons.insAreaComun(txtArComTipo.Text.ToString(), txtArComNombre.Text.ToString(), txtArComAforo.Text.ToString(), cmbOperabilidad.SelectedItem.ToString().Substring(0, 1));

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
            cmbOperabilidad.SelectedIndex = 0;
            txtArComTipo.Clear();
        }
        public void limpiar1()
        {
            txtCant.Clear();
            txtObs.Clear();
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
            //renderTxt(cmbOperabilidad);


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message = "Desea Eliminar: " + txtArComNombre.Text.ToString();
            const string caption = "Area Eliminada";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    valCons.eliminarArea(DatoEliminar);
                }
                catch
                {
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
            valCons.actualizar(DatoEliminar.Trim(), txtArComTipo.Text.ToString().Trim(), txtArComNombre.Text.ToString().Trim(), txtArComAforo.Text.ToString().Trim(), cmbOperabilidad.SelectedItem.ToString().Substring(0, 1));
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
            lblFechMan.Text = DateTime.Now.ToLongDateString();
            lblTimeMan.Text = DateTime.Now.ToLongTimeString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            timer.Start();
        }

        /*Activos*/
        private void limpiarActivo()
        {
            txtAcCant.Clear();
            txtAcNomb.Clear();
            txtAcObs.Clear();
        }

        private void btbAcGuar_Click(object sender, EventArgs e)
        {

            valCons.ingresarActivo(txtAcNomb.Text.ToString(), txtAcObs.Text.ToString(), txtAcCant.Text.ToString());
            DataTable DT1 = cts.consultar("select IDACTIVO, NOMBRE_ACT as Nombre, CANTIDAD_ACT as Cantidad,OBSERVACION_ACT as Observaciones from ACTIVOS order by IDACTIVO");
            dtGridActivos.DataSource = DT1;
            llenarCmbActivo();
            txtAcNomb.Text = "";
            txtAcObs.Text = "";
            txtAcCant.Text = "";
        }

        private void btnAcAct_Click(object sender, EventArgs e)
        {
            valCons.actualizarAcivo(IdActivo, txtAcNomb.Text.ToString(), txtAcObs.Text.ToString(), txtAcCant.Text.ToString());
            DataTable DT1 = cts.consultar("select IDACTIVO, NOMBRE_ACT as Nombre, CANTIDAD_ACT as Cantidad,OBSERVACION_ACT as Observaciones from ACTIVOS order by IDACTIVO");
            dtGridActivos.DataSource = DT1;
            llenarCmbActivo();
        }

        private void btbAcElim_Click(object sender, EventArgs e)
        {
            string message = "Desea Eliminar: " + txtAcNomb.Text.ToString();
            const string caption = "Activo Eliminado";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    valCons.eliminarExistenciaAct(IdActivo);
                    valCons.eliminarActivo(IdActivo);
                }
                catch
                {
                    MessageBox.Show("Activo Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



                DataTable DT1 = cts.consultar("select IDACTIVO, NOMBRE_ACT as Nombre, CANTIDAD_ACT as Cantidad,OBSERVACION_ACT as Observaciones from ACTIVOS order by IDACTIVO");
                dtGridActivos.DataSource = DT1;
                llenarCmbActivo();
            }
        }

        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            DatoEliminar = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            txtArComTipo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            txtArComNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            txtArComAforo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            //cmbOperabilidad.SelectedItem.ToString().Equals(dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim());
            //txtArComOper.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            int indice = 0;
            indice = itemCmb(dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim());
            cmbOperabilidad.SelectedIndex = indice;
            DataTable DT = cts.consultar("select ac.IDACTIVO ,ac.NOMBRE_ACT as Activos, ex.CANTIDAD_EXISTENCIAS as Cantidad, ac.OBSERVACION_ACT as Observaciones from ACTIVOS ac inner join EXISTENCIAS ex on ac.IDACTIVO=ex.IDACTIVO and ex.IDAREACOMUN=" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
            dataGridView6.DataSource = DT;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView6.Columns[0].Visible = false;
            

        }
        
        private void btnInsAct_Click(object sender, EventArgs e)
        {
            if (txtCant.Text.ToString() == "")
            {
                MessageBox.Show("Especificar Cantidad");
            }
            else
            {
            //    try
            //    {
                    int idActivo = (int.Parse(cmbActivo.SelectedIndex.ToString())) + 1;
                    txtCant.Text.ToString().Trim();
                    valCons.ingActAreaCom(idActivo.ToString(), DatoEliminar, txtCant.Text.ToString().Trim());
            //    }
            //    catch
            //    {
                    MessageBox.Show("El activo " + cmbActivo.SelectedItem.ToString() + " ya se enceuntra asociado\n");
            //    }
                DataTable DT = cts.consultar("select ac.IDACTIVO ,ac.NOMBRE_ACT as Activos, ex.CANTIDAD_EXISTENCIAS as Cantidad, ac.OBSERVACION_ACT as Observaciones from ACTIVOS ac inner join EXISTENCIAS ex on ac.IDACTIVO=ex.IDACTIVO and ex.IDAREACOMUN=" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                dataGridView6.DataSource = DT;
                limpiar1();
            }
            
        }

        private int itemCmb(string value)
        {
            int Indice = 0;
            string d = "D";
            string m = "M";
            string i = "I";
            if (value == d)
                Indice = 1;
            if (value == m)
                Indice = 2;
            if (value == i)
                Indice = 3;
            return Indice;
        }
        private void llenarCmbActivo()
        {
            List<string> Activo = new List<string>();
            try
            {
                DataTable DT = cts.consultar("select NOMBRE_ACT from ACTIVOS order by IDACTIVO");

                for (int i = 0; i < DT.Rows.Count; i++)
                {

                    Activo.Add(DT.Rows[i][0].ToString().Trim());
                }
                cmbActivo.DataSource = null;
                cmbActivo.DataSource = Activo;
            }
            catch
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // int idAct = int.Parse(cmbActivo.SelectedIndex.ToString())+1;
            int idAct = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString().Trim());
            string message = "Desea Eliminar: " + cmbActivo.SelectedItem.ToString();
            const string caption = "Activo Eliminado";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    valCons.eliminarActAreaCom(idAct.ToString(), DatoEliminar);
                    //valCons.eliminarArea(DatoEliminar);
                }
                catch
                {
                    MessageBox.Show("Activo asociado Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                limpiar1();
                DataTable DT = cts.consultar("select ac.IDACTIVO ,ac.NOMBRE_ACT as Activos, ex.CANTIDAD_EXISTENCIAS as Cantidad, ac.OBSERVACION_ACT as Observaciones from ACTIVOS ac inner join EXISTENCIAS ex on ac.IDACTIVO=ex.IDACTIVO and ex.IDAREACOMUN=" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                dataGridView6.DataSource = DT;

            }

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idAct= int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString().Trim())-1;
            cmbActivo.SelectedIndex = idAct;
            txtCant.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString().Trim();
            txtObs.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idAct= dataGridView6.CurrentRow.Cells[0].Value.ToString().Trim();
            valCons.actualizarActAreaCom(txtCant.Text.Trim(), idAct, DatoEliminar);
            DataTable DT = cts.consultar("select ac.IDACTIVO ,ac.NOMBRE_ACT as Activos, ex.CANTIDAD_EXISTENCIAS as Cantidad, ac.OBSERVACION_ACT as Observaciones from ACTIVOS ac inner join EXISTENCIAS ex on ac.IDACTIVO=ex.IDACTIVO and ex.IDAREACOMUN=" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
            dataGridView6.DataSource = DT;
            limpiar1();
        }

        private void dtGridActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdActivo = dtGridActivos.CurrentRow.Cells[0].Value.ToString().Trim();
            txtAcNomb.Text = dtGridActivos.CurrentRow.Cells[1].Value.ToString().Trim();
            txtAcCant.Text =dtGridActivos.CurrentRow.Cells[2].Value.ToString().Trim();
            txtAcObs.Text = dtGridActivos.CurrentRow.Cells[3].Value.ToString().Trim();
        }
       
    }
    }

