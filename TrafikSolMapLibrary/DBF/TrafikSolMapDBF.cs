using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrafikSolMapLibrary.DBF
{
    public class TrafikSolMapDBF: DbContext
    {
        public static string? Postgreconnction { get; set; }
        public static string ConnectionString()
        {
            string connectstr = "";
            try
            {

                connectstr = Postgreconnction;

            }

            catch (Exception e)
            {

            }
            return connectstr;

        }
    }
}
