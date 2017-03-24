using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for picture
/// </summary>
namespace WDI.DB_Layer
{
    public class picture
    {
        public int ID { get; set; }
        public String Picture_Path { get; set; }
        public int Project_ID { get; set; }        
    }
}