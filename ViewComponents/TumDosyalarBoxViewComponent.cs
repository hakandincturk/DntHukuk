using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class TumDosyalarBoxViewComponent :ViewComponent
    {
        public TumDosyalarBoxViewComponent()
        {
              
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
