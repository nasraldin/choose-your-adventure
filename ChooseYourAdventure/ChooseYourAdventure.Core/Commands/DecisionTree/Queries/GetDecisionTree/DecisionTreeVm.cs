using CleanArchitecture.Application.DecisionTree.Queries.GetDecisionTree;
using System.Collections.Generic;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodos
{
    public class DecisionTreeVm
    {
        public IList<CategoryDto> DecisionTree { get; set; }
    }
}
