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

            if(!String.IsNullOrEmpty(txtCodigo.Text) &
                !String.IsNullOrEmpty(txtNombre.Text) &
                ! String.IsNullOrEmpty(txtApellido.Text) &
                !String.IsNullOrEmpty(txtEdad.Text) &
                !String.IsNullOrEmpty(txtCarrera.Text) &
                !String.IsNullOrEmpty(txtSemestre.Text)){

                // guardar por procedimiento almacenado y linq, mapeo
                   bool res = controller.guardar(txtCodigo.Text, txtNombre.Text, txtApellido.Text,
                         Convert.ToInt16(txtEdad.Text), txtCarrera.Text
                         ,  Convert.ToInt16(txtSemestre.Text));

                   if (res)
                   {
                       MessageBox.Show("Registrado");
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
                   Dictionary<String,Object> datos = controller.buscar(txtCodigo.Text);

                   txtNombre.Text = datos["nombre"]+"";
                   txtApellido.Text = datos["apellido"] + "";
                   txtEdad.Text = datos["edad"] + "";
                   txtCarrera.Text = datos["carrera"] + "";
                   txtSemestre.Text = datos["semestre"] + "";
                 

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

                txtNombre.Text = datos["nombre"] + "";
                txtApellido.Text = datos["apellido"] + "";
                txtEdad.Text = datos["edad"] + "";
                txtCarrera.Text = datos["carrera"] + "";
                txtSemestre.Text = datos["semestre"] + "";


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

                txtNombre.Text = datos["nombre"] + "";
                txtApellido.Text = datos["apellido"] + "";
                txtEdad.Text = datos["edad"] + "";
                txtCarrera.Text = datos["carrera"] + "";
                txtSemestre.Text = datos["semestre"] + "";


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



            }
            else
            {
                MessageBox.Show("complete campo codigo");
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
