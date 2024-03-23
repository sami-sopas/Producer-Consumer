using Producer_Consumer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Container = Producer_Consumer.Classes.Container;

namespace Producer_Consumer
{
    public partial class Form1 : Form
    {
        private Container container;

        public Form1()
        {
            container = new Container();
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
        }

        public async void main()
        {
            Consumer consumer;
            Producer producer; 

            int moves, i;

            do
            {
                moves = container.NextMoves();

                for (i = 0; i < moves; ++i)
                {
                    await Task.Delay(1000);
                    consumer = container.GetConsumer();
                    producer = container.GetProducer();

                    //Turno consumidor
                    if (container.GetCurrentTurn() == Constants.CONSUMER_TURN)
                    {
         
                        //Si el consumidor consume...
                        if (consumer.getState() == Constants.WORKING)
                        {
                            //Se van eliminando los elementos del buffer
                            if (container.setAction(consumer.getCurrentPos(), consumer.Consume()))
                            {
                                SetImage(consumer.getCurrentPos(), Constants.CONSUMER_TURN);
                                consumer = container.GetConsumer();
                                consumer.setCurrentPos(consumer.getCurrentPos() + 1);
                            }

                            //Si llega al final del buffer, regresa al inicio
                            if (consumer.getCurrentPos() == Constants.CONTAINER_SIZE)
                            {
                                consumer.setCurrentPos(0);
                            }
                        }

                        if (consumer.getState() == Constants.TRYING)
                        {
                            ChangeStateLabel(consumer.getState(), producer.getState());
                            break;
                        }
                    }
                    else //Turno productor
                    {
                        //Si el productor produce...
                        if (producer.getState() == Constants.WORKING)
                        {
                            //Se van agregando los elementos al buffer
                            if (container.setAction(producer.getCurrentPos(), producer.Produce()))
                            {
                                SetImage(producer.getCurrentPos(), Constants.PRODUCER_TURN);
                                producer = container.GetProducer();
                                producer.setCurrentPos(producer.getCurrentPos() + 1);
                            }
                            if (producer.getCurrentPos() == Constants.CONTAINER_SIZE)
                            {
                                producer.setCurrentPos(0);
                            }
                        }
                        if (producer.getState() == Constants.TRYING)
                        {
                            ChangeStateLabel(consumer.getState(), producer.getState());
                            break;
                        }
                    }

                    ChangeStateLabel(consumer.getState(), producer.getState());
                    Update();
                }
            } while (true);
        }

        /*
         * Actualiza la imagen de los contenedores
        */  
        public void SetImage(int index, int turn)
        {
            Bitmap bmp = new Bitmap("..\\..\\cupcake.png");
            PictureBox pb = new PictureBox();

            //Determinar la posicion de la imagen que se cambiara
            switch (index)
            {
                case 0: pb = pictureBox1; break;
                case 1: pb = pictureBox2; break;
                case 2: pb = pictureBox3; break;
                case 3: pb = pictureBox4; break;
                case 4: pb = pictureBox5; break;
                case 5: pb = pictureBox6; break;
                case 6: pb = pictureBox7; break;
                case 7: pb = pictureBox8; break;
                case 8: pb = pictureBox9; break;
                case 9: pb = pictureBox10; break;
                case 10: pb = pictureBox11; break;
                case 11: pb = pictureBox12; break;
                case 12: pb = pictureBox13; break;
                case 13: pb = pictureBox14; break;
                case 14: pb = pictureBox15; break;
                case 15: pb = pictureBox16; break;
                case 16: pb = pictureBox17; break;
                case 17: pb = pictureBox18; break;
                case 18: pb = pictureBox19; break;
                case 19: pb = pictureBox20; break;
                case 20: pb = pictureBox21; break;
                case 21: pb = pictureBox22; break;
                case 22: pb = pictureBox23; break;
                case 23: pb = pictureBox24; break;
                case 24: pb = pictureBox24; break;
            }

            //Se agrega o quita la imagen dependiendo del turno
            if (turn == Constants.PRODUCER_TURN)
            {
                pb.Image = bmp;
            }
            
            if(turn == Constants.CONSUMER_TURN)
            {
                if (pb.Image != null)
                {
                    pb.Image = null;
                }
            }
        }

        /*
         * Funcion para cambiar el label del productor o consumidor
         * en base a la accion que esten realizando
        */
        public void ChangeStateLabel(int consumer, int producer)
        {
            switch (producer)
            {
                case Constants.WORKING:
                    producerState.Text = "TRABAJANDO";
                    producerState.BackColor = Color.Green;
                    producerState.Refresh();
                    break;
                case Constants.TRYING:
                    producerState.Text = "INTENTANDO TRABAJAR";
                    producerState.BackColor = Color.Orange;
                    producerState.Refresh();
                    break;
                default:
                    producerState.Text = "DURMIENDO";
                    producerState.BackColor = Color.Red;
                    producerState.Refresh();
                    break;
            }
            switch (consumer)
            {
                case Constants.WORKING:
                    consumerState.Text = "TRABAJANDO";
                    consumerState.BackColor = Color.Green;
                    consumerState.Refresh();
                    break;
                case Constants.TRYING:
                    consumerState.Text = "INTENTANDO TRABAJAR";
                    consumerState.BackColor = Color.Orange;
                    producerState.Refresh();
                    break;
                default:
                    consumerState.Text = "DURMIENDO";
                    consumerState.BackColor = Color.Red;
                    consumerState.Refresh();
                    break;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            main();
            startButton.Enabled = false;
            startButton.Visible = false;
        }

        //Para cerrar el programa con Esc
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es la tecla "Esc"
            if (e.KeyCode == Keys.Escape)
            {
                // Mostrar un mensaje de advertencia
                MessageBox.Show("Programa finalizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cerrar la ventana
                this.Close();
            }
        }

    }
}
