using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for employee
/// </summary>
namespace WDI.DB_Layer
{
	public class employee
	{
        public int ID { get; set; }
        public String Name {get; set;}
        public int Access { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
	}
}