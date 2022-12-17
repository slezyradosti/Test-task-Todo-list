using Application.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using TodoList.WebUI.Controllers;
using Type = Domain.EntityModels.Type;

namespace TodoList.WebUI.ViewComponents
{
    public class TypeViewComponent: ViewComponent
    {
        private readonly DataContext _context;

        public TypeViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Types.AsQueryable()
                    .OrderBy(n => n.TypeName)
                    .ToList()
                    );
        }
    }
}
