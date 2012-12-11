using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.Domain.Commands;
using EFMVC.CommandProcessor.Command;
using EFMVC.Data.Repositories;
using EFMVC.Data.Infrastructure;

namespace EFMVC.Domain.Handlers
{
    public class DeleteExpenseHandler : ICommandHandler<DeleteExpenseCommand>
    {
          private readonly IExpenseRepository expenseRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteExpenseHandler(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            this.expenseRepository = expenseRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteExpenseCommand command)
        {
            var expense = expenseRepository.GetById(command.ExpenseId);
            expenseRepository.Delete(expense);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
