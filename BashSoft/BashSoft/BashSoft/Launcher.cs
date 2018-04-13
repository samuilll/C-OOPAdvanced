using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Contracts;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
           
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(),new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester,repo,ioManager);
            IInputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
