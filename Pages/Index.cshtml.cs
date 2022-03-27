using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Log Example...");
            try
            {
                throw new Exception("Exception for test");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Caught exception");
            }
        }
    }
}