using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Common.Interfaces;

namespace CreateCateringData
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Catering.Business.Engine();
            engine.CreateData();
        }
    }
}
