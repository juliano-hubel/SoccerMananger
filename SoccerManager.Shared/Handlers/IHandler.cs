﻿using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);

    }
}
