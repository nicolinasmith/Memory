using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.ViewModels
{
    public class EndGameViewModel : BaseViewModel
    {
        public string Message { get; set; }

        public EndGameViewModel(string message)
        {
            Message = message;
        }
    }
}
