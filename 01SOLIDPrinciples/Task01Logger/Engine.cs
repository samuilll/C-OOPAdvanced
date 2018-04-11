using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task01Logger.Factories;
using Task01Logger.Interfaces;

namespace Task01Logger
{
  public  class Engine
    {

        private ILogger logger;
        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            AddAppendersToLogger();

            while (true)
            {
                string[] input = Console.ReadLine().Split('|');

                if (input[0] == "END")
                {
                    break;
                }

                ReadCurrentMessage(input);
            }

            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }

        private void ReadCurrentMessage(string[] input)
        {
            string errorLevelAsString = input[0];
            string dateTimeAsString = input[1];
            string errorMessage = input[2];

            IError error = new ErrorFactory().CreateError(dateTimeAsString, errorLevelAsString, errorMessage);

            this.logger.Log(error);
        }

        private void AddAppendersToLogger()
        {
            int appendersNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersNumber; i++)
            {
                List<string> args = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                IAppender appender = new AppenderFactory().CreateAppender(args);

                this.logger.AddAppender(appender);
            }
        }
    }
}
