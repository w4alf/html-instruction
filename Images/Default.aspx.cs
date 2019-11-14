using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            DirectoryInfo diFiles = new DirectoryInfo(Server.MapPath("."));
            filelist.InnerHtml += "<h1>Files in " + diFiles.Name + " folder</h1>";

            foreach (var dir in diFiles.GetDirectories())
            {
                filelist.InnerHtml += "&lt;<a href='" + dir.Name + "'>" + dir.Name + "</a>&gt;<br>";
            }


            foreach (var file in diFiles.GetFiles("*.*"))
            {
                if (!(file.Extension == ".cs" | file.Extension == ".aspx"))
                {
                    filelist.InnerHtml += "<a href='" + file.Name + "'>" + file.Name + "</a><br>";
                }
            }
                
        }
        catch (Exception e1)
        {
            filelist.InnerHtml += "<br><br>" + e1.Message;
        }



    }
}