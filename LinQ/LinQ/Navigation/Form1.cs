using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Platform.Model.DAO;

namespace LinQ
{
    public partial class Form1 : Form
    {

        private ClsEstudiante controller;

        public Form1()
        {
            InitializeComponent();
            controller = new ClsEstudiante();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text) &
                !String.IsNullOrEmpty(txtNombre.Text) &
                !String.IsNullOrEmpty(txtApellido.Text) &
                !String.IsNullOrEmpty(txtEdad.Text) &
                !String.IsNullOrEmpty(txtCarrera.Text) &
                !String.IsNullOrEmpty(txtSemestre.Text))
            {

                // guardar por procedimiento almacenado y linq, mapeo
                bool res = controller.guardar(txtCodigo.Text, txtNombre.Text, txtApellido.Text,
                      Convert.ToInt16(txtEdad.Text), txtCarrera.Text
                      , Convert.ToInt16(txtSemestre.Text));

                if (res)
                {
                    MessageBox.Show("Registrado");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar");
                }



            }
            else
            {
                MessageBox.Show("Complete los campos");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (!String.IsNullOrEmpty(txtCodigo.Text) &
                !String.IsNullOrEmpty(txtNombre.Text) &
                !String.IsNullOrEmpty(txtApellido.Text) &
                !String.IsNullOrEmpty(txtEdad.Text) &
                !String.IsNullOrEmpty(txtCarrera.Text) &
                !String.IsNullOrEmpty(txtSemestre.Text))
            {

                // guardar por procedimiento almacenado y linq, mapeo
                bool res = controller.guardarLINQ(txtCodigo.Text, txtNombre.Text, txtApellido.Text,
                      Convert.ToInt16(txtEdad.Text), txtCarrera.Text
                      , Convert.ToInt16(txtSemestre.Text));

                if (res)
                {
                    MessageBox.Show("Registrado");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar");
                }



            }
            else
            {
                MessageBox.Show("Complete los campos");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {
                Dictionary<String, Object> datos = controller.buscar(txtCodigo.Text);

                if (datos != null)
                {

                    txtNombre.Text = datos["nombre"] + "";
                    txtApellido.Text = datos["apellido"] + "";
                    txtEdad.Text = datos["edad"] + "";
                    txtCarrera.Text = datos["carrera"] + "";
                    txtSemestre.Text = datos["semestre"] + "";
                }
                else
                {
                    MessageBox.Show("Not Found");
                }


            }
            else
            {
                MessageBox.Show("complete codigo");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {
                Dictionary<String, Object> datos = controller.buscarLINQ(txtCodigo.Text);
                if (datos != null)
                {

                    txtNombre.Text = datos["nombre"] + "";
                    txtApellido.Text = datos["apellido"] + "";
                    txtEdad.Text = datos["edad"] + "";
                    txtCarrera.Text = datos["carrera"] + "";
                    txtSemestre.Text = datos["semestre"] + "";
                }
                else
                {
                    MessageBox.Show("Not Found");
                }


            }
            else
            {
                MessageBox.Show("complete codigo");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {
                Dictionary<String, Object> datos = controller.buscarLAMBDA(txtCodigo.Text);

                if (datos != null)
                {

                    txtNombre.Text = datos["nombre"] + "";
                    txtApellido.Text = datos["apellido"] + "";
                    txtEdad.Text = datos["edad"] + "";
                    txtCarrera.Text = datos["carrera"] + "";
                    txtSemestre.Text = datos["semestre"] + "";
                }
                else
                {
                    MessageBox.Show("Not Found");
                }


            }
            else
            {
                MessageBox.Show("Complete codigo");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                bool edit = controller.editarLinq(txtCodigo.Text,
                    txtNombre.Text, txtApellido.Text, Convert.ToInt32 (txtEdad.Text), txtCarrera.Text,
                    Convert.ToInt32(txtSemestre.Text));

                if (edit)
                {
                    MessageBox.Show("Edit correctly");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("Could not edit");
                }



            }
            else
            {
                MessageBox.Show("complete campo codigo");
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                bool remove = controller.eliminarLinq(txtCodigo.Text);

                if (remove)
                {
                    MessageBox.Show("Remove Correctly");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("Could not remove");
                }



            }
            else
            {
                MessageBox.Show("complete campo codigo");
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                bool edit = controller.editarPorProcedimiento(txtCodigo.Text,
                    txtNombre.Text, txtApellido.Text, Convert.ToInt16(txtEdad.Text), txtCarrera.Text,
                    Convert.ToInt16(txtSemestre.Text));

                if (edit)
                {
                    MessageBox.Show("Edit correctly");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("Could not edit");
                }

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                bool remove = controller.eliminarConProcedimiento(txtCodigo.Text);

                if (remove)
                {
                    MessageBox.Show("Remove Correctly");
                    this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);
                }
                else
                {
                    MessageBox.Show("Could not remove");
                }



            }
            else
            {
                MessageBox.Show("complete campo codigo");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pruebaDataSet1.estudiante' table. You can move, or remove it, as needed.
            this.estudianteTableAdapter.Fill(this.pruebaDataSet1.estudiante);

        }
    }
}
