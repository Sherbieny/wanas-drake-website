using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for project
/// </summary>
namespace WDI.DB_Layer
{
	public class project
	{
		public int ID { get; set; }
        public String Name { get; set; }
        public int Category { get; set; }
        public String Descrition { get; set; }
        public String Main_Pic_Path { get; set; }
        public String Small_Description { get; set; }
        public String Location { get; set; }
        public String Total_Area { get; set; }
        public String BuiltUp_Area { get; set; }
	}
}