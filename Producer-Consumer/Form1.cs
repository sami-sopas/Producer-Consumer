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
        }

        public async void main()
        {
            Consumer consumer = new Consumer();
            Producer producer = new Producer();
            int moves, i;

            do
            {
                moves = container.NextMoves();

                for (i = 0; i < moves; ++i)
                {
                    await Task.Delay(1000);
                    consumer = container.GetConsumer();
                    producer = container.GetProducer();

                    if (container.GetCurrentTurn() == Constants.CONSUMER_TURN)
                    {
                        if (consumer.getState() == Constants.WORKING)
                        {
                            if (container.setAction(consumer.getCurrentPos(), consumer.Consume()))
                            {
                                SetImage(consumer.getCurrentPos(), Constants.CONSUMER_TURN);
                                consumer = container.GetConsumer();
                                consumer.setCurrentPos(consumer.getCurrentPos() + 1);
                            }
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
                    else
                    {
                        if (producer.getState() == Constants.WORKING)
                        {
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

        private void startButton_Click(object sender, EventArgs e)
        {
            main();
            startButton.Enabled = false;
            startButton.Visible = false;
        }
    }
}
