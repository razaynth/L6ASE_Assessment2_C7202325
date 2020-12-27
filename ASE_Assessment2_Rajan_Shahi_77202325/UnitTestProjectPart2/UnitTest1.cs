using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace UnitTestProjectPart2
{
    [TestClass]
    public class UnitTestcmd
    {
        [TestMethod]
        public void TestMethod_Moveto()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("moveto 30,20", "", MyCanvass);
        }
        [TestMethod]
        public void TestMethod_DrawTo()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("drawto 40,60", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Drawsquare()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("sqaure 70", "", MyCanvass);

        }

        [TestMethod]
        public void TestMethod_Drawcircle()
        {

            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("circle 60", "", MyCanvass);
        }


        [TestMethod]
        public void TestMethod_Drawrectangle()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("rectangle 70,80", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Drawtriangle()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("triangle 70,80,60", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Fillstatus()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("fill on", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_PenColor()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("pen black", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_CLEAR()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("clear", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_RESET()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("reset", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Command_run_Moveto()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("run", "moveto 60,40", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Parameter_existing_TEST()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("value = 5", "", MyCanvass);
        }

        [TestMethod]
        public void TestMethod_Parameter_Add_TEST()
        {
            ASE_Assessment2.Form1 form = new ASE_Assessment2.Form1();
            ASE_Assessment2.cmdReader reader = new ASE_Assessment2.cmdReader();
            Bitmap outBitmap = form.ShowBitmap;
            ASE_Assessment2.Canvass MyCanvass = new ASE_Assessment2.Canvass(Graphics.FromImage(outBitmap));
            reader.Cmd("value = value + 5", "", MyCanvass);
            reader.Cmd("value = value - 5", "", MyCanvass);
            reader.Cmd("value = value / 5", "", MyCanvass);
            reader.Cmd("value = value * 5", "", MyCanvass);
        }
     }
 }