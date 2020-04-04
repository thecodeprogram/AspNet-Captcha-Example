using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    private string captchaText;
    private int width = 400;
    private int height = 100;
    private Random rnd = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        captchaText = generateCaptchaCode(5);
        this.Session["captchaCode"] = captchaText;
        imgCaptchaImage.src = generateCaptchaImage();
    }

    protected void btnCheckCaptcha_Click(object sender, EventArgs e)
    { 
        if (txtCaptchaCode.Text == this.Session["captchaCode"].ToString())
            lblmsg.Text = "Captcha is correct";
        else
            lblmsg.Text = "Captcha is incorrect";        
    }

    private string generateCaptchaCode(int charCount)
    {
        Random r = new Random();
        string s = "";
        for (int i = 0; i < charCount; i++)
        {
            int a = r.Next(3);
            int chr;
            switch (a)
            {
                case 0:
                    chr = r.Next(0, 9);
                    s = s + chr.ToString();
                    break;
                case 1:
                    chr = r.Next(65, 90);
                    s = s + Convert.ToChar(chr).ToString();
                    break;
                case 2:
                    chr = r.Next(97, 122);
                    s = s + Convert.ToChar(chr).ToString();
                    break;
            }
        }
        return s;
    }

    private Bitmap generateCaptchaImage()
    {
        //First declare a bitmap and declare graphic from this bitmap
        Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bitmap);
        //And create a rectangle to delegete this image graphic 
        Rectangle rect = new Rectangle(0, 0, width, height);
        //And create a brush to make some drawings
        HatchBrush hatchBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Aqua, Color.White);
        g.FillRectangle(hatchBrush, rect);
        
        //here we make the text configurations
        GraphicsPath graphicPath = new GraphicsPath();
        //add this string to image with the rectangle delegate
        graphicPath.AddString(captchaText, FontFamily.GenericMonospace, (int)FontStyle.Bold, 90, rect, null);
        //And the brush that you will write the text
        hatchBrush = new HatchBrush(HatchStyle.Percent20, Color.Black, Color.GreenYellow);
        g.FillPath(hatchBrush, graphicPath);
        //We are adding the dots to the image
        for (int i = 0; i < (int)(rect.Width * rect.Height / 50F); i++)
        {
            int x = rnd.Next(width);
            int y = rnd.Next(height);
            int w = rnd.Next(10);
            int h = rnd.Next(10);
            g.FillEllipse(hatchBrush, x, y, w, h);
        }
        //Remove all of variables from the memory to save resource
        hatchBrush.Dispose();
        g.Dispose();
        //return the image to the related component
        return bitmap;
    }
}