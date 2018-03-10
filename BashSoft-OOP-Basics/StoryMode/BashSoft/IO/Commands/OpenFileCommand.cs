using System;
using System.Collections.Generic;
using System.Text;
using SimpleJudge;
using BashSoft.Exceptions;
using System.Diagnostics;
using System.IO;

namespace BashSoft.IO.Commands
{
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {

            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var fileName = this.Data[1];
            var filePath = SessionData.currentPath + "\\" + fileName;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            Process.Start(filePath);
        }
    }
}
