using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.CommandProcessor.Command;
using EFMVC.Domain.Commands;
using EFMVC.Data.Repositories;
using EFMVC.Data.Infrastructure;
using EFMVC.Model;

namespace EFMVC.Domain.Handlers
{
    public class CreateOrUpdateExpenseHandler : ICommandHandler<CreateOrUpdateExpenseCommand>
    {
         private readonly IExpenseRepository expenseRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateExpenseHandler(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            this.expenseRepository = expenseRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateExpenseCommand command)
        {
            var expense = new Expense
            {
                ExpenseId =command.ExpenseId, 
                CategoryId = command.CategoryId,
                Amount = command.Amount,
                Date=command.Date,
                Transaction=command.Transaction 
            };
            if (expense.ExpenseId == 0)
                expenseRepository.Add(expense);
            else
                expenseRepository.Update(expense);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
