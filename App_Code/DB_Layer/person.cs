using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for person
/// </summary>
namespace WDI.DB_Layer
{
	public class person
	{
        public int ID { get; set; }
        public String Name { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Type { get; set; }
        public String Pic_Path { get; set; }
        public String PicSmall_Path { get; set; }
	}
}