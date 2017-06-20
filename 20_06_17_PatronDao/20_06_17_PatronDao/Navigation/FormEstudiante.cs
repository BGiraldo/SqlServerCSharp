using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Platform.Comunication.Controllers;
using Platform.Object.Model;

namespace _20_06_17_PatronDao
{
    public partial class Form1 : Form
    {

        private EstudianteController controller;

        public Form1()
        {
            InitializeComponent();
            controller = new EstudianteController();
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

                if (controller.solicitudGuardar(txtCodigo.Text, txtNombre.Text,
                    txtApellido.Text, Convert.ToInt32(txtEdad.Text), 
                    txtCarrera.Text, Convert.ToInt32(txtSemestre.Text)))
                {

                    MessageBox.Show("Guardado adecuadamente");
                    // listarTabla();
                }
                else
                {
                    MessageBox.Show("No se ha podido Guardar");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                ClsEstudiante estudiante = controller.solicitudBuscar(txtCodigo.Text);

                if (estudiante != null)
                {

                    txtNombre.Text = estudiante.Nombre;
                    txtApellido.Text = estudiante.Apellido;
                    txtEdad.Text = estudiante.Edad+"";
                    txtCarrera.Text = estudiante.Carrera;
                    txtSemestre.Text = estudiante.Semestre + "";

                }else{
                    MessageBox.Show("No fue encontrado");
                }

            }
            else
            {
                MessageBox.Show("Complete el campo");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCodigo.Text))
            {

                ClsEstudiante estudiante = controller.solicitudBuscar(txtCodigo.Text);

                if (estudiante != null)
                {

                    estudiante.Codigo = txtCodigo.Text;
                    estudiante.Nombre = txtNombre.Text;
                    estudiante.Apellido = txtApellido.Text;
                    estudiante.Edad = Convert.ToInt32(txtEdad.Text);
                    estudiante.Carrera = txtCarrera.Text;
                    estudiante.Semestre = Convert.ToInt32(txtSemestre);

                    bool edit = controller.solicitudEditar(estudiante);

                    if (edit)
                    {

                    }
                    else
                    {

                    }

                }
                else
                {
                    MessageBox.Show("No fue encontrado");
                }

            }
            else
            {
                MessageBox.Show("Complete el campo");
            }
            
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pruebaDataSet.estudiante' Puede moverla o quitarla según sea necesario.
            this.estudianteTableAdapter.Fill(this.pruebaDataSet.estudiante);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.estudianteTableAdapter.FillBy(this.pruebaDataSet.estudiante);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
