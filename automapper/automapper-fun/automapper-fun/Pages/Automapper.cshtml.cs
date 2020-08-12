using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using automapper_fun.Models;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace automapper_fun.Pages
{
    public class AutomapperModel : PageModel
    {
        private readonly ILogger<AutomapperModel> _logger;
        private readonly IMapper _mapper;

        public AutomapperModel(ILogger<AutomapperModel> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        
        public void OnGet()
        {
            var developer = new Developer { FirstName = "A", LastName = "B", Email = "developer@test.com", Experience = 5, Salary= 1000 };
            var developerDtoMapped = _mapper.Map<DeveloperDto>(developer);
            var foo = developerDtoMapped.Email;
        }

        //public async Task<IActionResult> Post(Developer developer)
        //{
        //    var developerDtoMapped = _mapper.Map<DeveloperDTO>(developer);
        //    return Ok(developerDtoMapped);
        //}
    }
}
