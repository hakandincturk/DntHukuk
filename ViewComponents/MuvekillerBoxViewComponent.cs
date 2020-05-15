using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class MuvekillerBoxViewComponent : ViewComponent
    {

        public MuvekillerBoxViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
