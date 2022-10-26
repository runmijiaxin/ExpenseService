using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using System;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project project = new Project(ProjectType.INTERNAL, projectName: "Internal project");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expected: ExpenseType.INTERNAL_PROJECT_EXPENSE, actual: expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, projectName: "Project A");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expected: ExpenseType.EXPENSE_TYPE_A, actual: expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, projectName: "Project B");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expected: ExpenseType.EXPENSE_TYPE_B, actual: expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, projectName: "Project");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expected: ExpenseType.OTHER_EXPENSE, actual: expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project project = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, projectName: "UNEXPECTED_PROJECT_TYPE");
            // when
            Action action = () => ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            Assert.Throws<UnexpectedProjectTypeException>(action);
            Assert.Throws<UnexpectedProjectTypeException>(() => ExpenseService.GetExpenseCodeByProjectTypeAndName(project));
            // then
        }
    }
}