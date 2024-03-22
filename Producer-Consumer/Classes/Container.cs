using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer.Classes
{ 
    static class Constants
    {
        public const int CONTAINER_SIZE = 20;
        public const int SLEEPING = 0;
        public const int WORKING = 1;
        public const int TRYING = 2;
        public const int PRODUCER_TURN = 1;
        public const int CONSUMER_TURN = 2;
    }

    class Container
    {
        private Producer producer;
        private Consumer consumer;

        private int currentTurn;
        private Random randomTurn;
        private Random amount;
        private bool[] buffer;

        public Container()
        {
            buffer = new bool[Constants.CONTAINER_SIZE];
            producer = new Producer();
            consumer = new Consumer();
            currentTurn = 0;
            randomTurn = new Random();
            amount = new Random();
            
            //Dejar el buffer vacio
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = false;
            }   
        }

        public bool setAction(int pos, bool action)
        {
            if (action == buffer[pos])
            {
                if (action)
                {
                    producer.setState(Constants.TRYING);
                }
                else
                {
                    consumer.setState(Constants.TRYING);
                }
                return false;
            }
            buffer[pos] = action;
            return true;
        }


        public int NextMoves()
        {
            int p, a;
            p = randomTurn.Next() % 100;
            a = amount.Next(3, 7);

            if (p % 2 == 0)
            {
                currentTurn = Constants.PRODUCER_TURN;
            }
            else
            {
                currentTurn = Constants.CONSUMER_TURN;
            }

            if (currentTurn == Constants.PRODUCER_TURN)
            {
                if (ProductsCount() != Constants.CONTAINER_SIZE)
                {
                    producer.setState(Constants.WORKING);
                    consumer.setState(Constants.SLEEPING);
                }
                else
                {
                    producer.setState(Constants.TRYING);
                    consumer.setState(Constants.SLEEPING);
                }
            }
            else //CONSUMER TURN
            {
                if (ProductsCount() > 0)
                {
                    consumer.setState(Constants.WORKING);
                    producer.setState(Constants.SLEEPING);
                }
                else
                {
                    consumer.setState(Constants.TRYING);
                    producer.setState(Constants.SLEEPING);
                }
            }

            return a;
        }

        public int ProductsCount()
        {
            int productsCount = 0;

            for (int i = 0; i < Constants.CONTAINER_SIZE; ++i)
            {
                if (buffer[i])
                {
                    productsCount++;
                }
            }
            return productsCount;
        }

        public Consumer GetConsumer()
        {
            return consumer;
        }

        public Producer GetProducer()
        {
            return producer;
        }

        public int GetCurrentTurn()
        {
            return currentTurn;
        }
    }
}
