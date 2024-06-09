using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages
{
    public class SubmittedModel : PageModel
    {
        public double InputData { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("InputData"))
            {
                double.TryParse(TempData["InputData"].ToString(), out double inputData);
                InputData = inputData;
            }
        }
    }
}
