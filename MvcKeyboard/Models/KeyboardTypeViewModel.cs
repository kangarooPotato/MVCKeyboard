using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcKeyboard.Models
{
    public class KeyboardTypeViewModel
    {
        public List<Keyboard> Keyboards { get; set; }
        public SelectList Types { get; set; }
        public string KeyboardType { get; set; }
        public string SearchString { get; set; }
    }
}