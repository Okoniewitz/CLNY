namespace CLNY
{
    using System.Net;
    using System.Web;
    using System;
    using System.Text.Json.Nodes;
    using System.Collections.Generic;
    using System.Globalization;


    public partial class Form1 : Form
    {

        public static short[] Plots = new short[] { 6031,3315 };
        public static (float[], int[], DateTime)[] PlotInfo = new (float[], int[], DateTime)[2];
        public static float price = 0;
        public static short curTab = 0;
        public Form1()
        {
            InitializeComponent();
            updatePrice();
            setUpPlotInfo0(Plots[0],true);
            setUpPlotInfo1(Plots[1],true);
            updateTab();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            updatePrice();
            updateTab();
            clearPlotInfo0();
            setUpPlotInfo0(Plots[0]);
            clearPlotInfo1();
            setUpPlotInfo1(Plots[1]);
        }
        private void setUpPlotInfo0(short PlotID, bool first = false)
        {
            (float[], int[], DateTime) PlotInfo= Functions.getPlotInfo(PlotID);
            p1PlotName.Text = "PLOT NUMBER #" + PlotID;
            p1Wallet.Text = PlotInfo.Item1[0].ToString() +"CLNY / $"+ Math.Round(PlotInfo.Item1[0]*price,2);
            int station = PlotInfo.Item2[0];
            int transport = PlotInfo.Item2[1];
            int robot = PlotInfo.Item2[2];
            int power = PlotInfo.Item2[3];
            DateTime time = PlotInfo.Item3;
            if (station == 1) p1Upg11.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 1) p1Upg21.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 2) p1Upg22.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 3) p1Upg23.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 1) p1Upg31.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 2) p1Upg32.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 3) p1Upg33.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 1) p1Upg41.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 2) p1Upg42.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 3) p1Upg43.BackColor = Color.FromArgb(255, 136, 173, 22);
            int speed = (int)Math.Round(PlotInfo.Item1[1], 0);
            p1Speed.Text =  speed.ToString()+" CLNY/DAY";
            float Daily = (float)Math.Round(price * speed,2);
            float Monthly = (float)Math.Round(price*speed*30,2);
            p1Day.Text = "Day: $"+Daily.ToString();
            p1Month.Text = "Mth: $"+Monthly.ToString();
            if (first) downloadImage("https://meta.marscolony.io/" + PlotID + ".png", PlotID.ToString());
            p1Pic.Image = Image.FromFile(PlotID+".png");
        }
        private void setUpPlotInfo1(short PlotID, bool first=false)
        {
            (float[], int[], DateTime) PlotInfo = Functions.getPlotInfo(PlotID);
            p2PlotName.Text = "PLOT NUMBER #" + PlotID;
            p2Wallet.Text = PlotInfo.Item1[0].ToString() + "CLNY / $" + Math.Round(PlotInfo.Item1[0] * price, 2);
            int station = PlotInfo.Item2[0];
            int transport = PlotInfo.Item2[1];
            int robot = PlotInfo.Item2[2];
            int power = PlotInfo.Item2[3];
            if (station == 1) p2Upg11.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 1) p2Upg21.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 2) p2Upg22.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (transport >= 3) p2Upg23.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 1) p2Upg31.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 2) p2Upg32.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (robot >= 3) p2Upg33.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 1) p2Upg41.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 2) p2Upg42.BackColor = Color.FromArgb(255, 136, 173, 22);
            if (power >= 3) p2Upg43.BackColor = Color.FromArgb(255, 136, 173, 22);
            int speed = (int)Math.Round(PlotInfo.Item1[1], 0);
            p2Speed.Text = speed.ToString() + " CLNY/DAY";
            float Daily = (float)Math.Round(price * speed, 2);
            float Monthly = (float)Math.Round(price * speed * 30, 2);
            p2Day.Text = "Day: $" + Daily.ToString();
            p2Month.Text = "Mth: $" + Monthly.ToString();
            if(first)downloadImage("https://meta.marscolony.io/"+PlotID+".png", PlotID.ToString());
            p2Pic.Image = Image.FromFile(PlotID + ".png");
        }
        private void clearPlotInfo0()
        {
            p1Upg11.BackColor = Color.Silver;
            p1Upg21.BackColor = Color.Silver;
            p1Upg22.BackColor = Color.Silver;
            p1Upg23.BackColor = Color.Silver;
            p1Upg31.BackColor = Color.Silver;
            p1Upg32.BackColor = Color.Silver;
            p1Upg33.BackColor = Color.Silver;
            p1Upg41.BackColor = Color.Silver;
            p1Upg42.BackColor = Color.Silver;
            p1Upg43.BackColor = Color.Silver;
        }
        private void clearPlotInfo1()
        {
            p2Upg11.BackColor = Color.Silver;
            p2Upg21.BackColor = Color.Silver;
            p2Upg22.BackColor = Color.Silver;
            p2Upg23.BackColor = Color.Silver;
            p2Upg31.BackColor = Color.Silver;
            p2Upg32.BackColor = Color.Silver;
            p2Upg33.BackColor = Color.Silver;
            p2Upg41.BackColor = Color.Silver;
            p2Upg42.BackColor = Color.Silver;
            p2Upg43.BackColor = Color.Silver;
        }
        private void updatePrice()
        {
            string _price = Functions.getPrice().Item1.Replace(".", ",");
            price = float.Parse(_price);
            ClnyPrice.Text = "$"+price.ToString();
        }
        private void updateTab()
        {
            (string, string[][],string[],string[]) tabData = Functions.getPrice();
            H0.Text = tabData.Item3[3]+"%";
            if (Functions.FixFloat(tabData.Item3[3]) > 0) H0.ForeColor = Color.Green;
            if (Functions.FixFloat(tabData.Item3[3]) == 0) H0.ForeColor = Color.FromName("ControlText");
            if (Functions.FixFloat(tabData.Item3[3]) < 0) H0.ForeColor = Color.Red;
            H1.Text = tabData.Item3[2]+"%";
            if (Functions.FixFloat(tabData.Item3[2]) > 0) H1.ForeColor = Color.Green;
            if (Functions.FixFloat(tabData.Item3[2]) == 0) H1.ForeColor = Color.FromName("ControlText");
            if (Functions.FixFloat(tabData.Item3[2]) < 0) H1.ForeColor = Color.Red;
            H6.Text = tabData.Item3[1]+"%";
            if (Functions.FixFloat(tabData.Item3[1]) > 0) H6.ForeColor = Color.Green;
            if (Functions.FixFloat(tabData.Item3[1]) == 0) H6.ForeColor = Color.FromName("ControlText");
            if (Functions.FixFloat(tabData.Item3[1]) < 0) H6.ForeColor = Color.Red;
            H24.Text = tabData.Item3[0]+"%";
            if (Functions.FixFloat(tabData.Item3[0]) > 0) H24.ForeColor = Color.Green;
            if (Functions.FixFloat(tabData.Item3[0]) == 0) H24.ForeColor = Color.FromName("ControlText");
            if (Functions.FixFloat(tabData.Item3[0]) < 0) H24.ForeColor = Color.Red;

            changeTab(curTab);
        }
        private void changeTab(short newTab)
        {
            (string, string[][], string[], string[]) tabData = Functions.getPrice();
            if(newTab==0)
            {
                TXNS.Text = (int.Parse(tabData.Item2[0][0])+int.Parse(tabData.Item2[0][1])).ToString();
                BUYS.Text = tabData.Item2[0][0];
                SELLS.Text = tabData.Item2[0][1];
                VOL.Text = "$" + Math.Round(Functions.FixFloat(tabData.Item4[0]) / 1000, 0) + "k";
            }
            if (newTab == 1)
            {
                TXNS.Text = (int.Parse(tabData.Item2[1][0]) + int.Parse(tabData.Item2[1][1])).ToString();
                BUYS.Text = tabData.Item2[1][0];
                SELLS.Text = tabData.Item2[1][1];
                VOL.Text = "$" + Math.Round(Functions.FixFloat(tabData.Item4[1]) / 1000, 0) + "k";
            }
            if (newTab == 2)
            {
                TXNS.Text = (int.Parse(tabData.Item2[2][0]) + int.Parse(tabData.Item2[2][1])).ToString();
                BUYS.Text = tabData.Item2[2][0];
                SELLS.Text = tabData.Item2[2][1];
                VOL.Text = "$"+Math.Round(Functions.FixFloat(tabData.Item4[2])/100, 1) + "k";
            }
            if (newTab == 3)
            {
                TXNS.Text = (int.Parse(tabData.Item2[3][0]) + int.Parse(tabData.Item2[3][1])).ToString();
                BUYS.Text = tabData.Item2[3][0];
                SELLS.Text = tabData.Item2[3][1];
                VOL.Text = "$" + Math.Round(Functions.FixFloat(tabData.Item4[3]), 0);
            }

        }
        private void downloadImage(string URL, string ID)
        {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(URL), ID+".png");
                }
        }

        private void SmoothIncomeTick(object sender, EventArgs e)
        {
            //DateTime.Now
            long difference = (DateTime.Now.Ticks - PlotInfo[0].Item3.Ticks) / 10000000;
            double profit = Math.Round(PlotInfo[0].Item1[0] + (difference/0.001 * 86400 / 8 / 100000000000),3);
            p1Wallet.Text = profit.ToString() + "CLNY / $" + Math.Round(profit * price, 2);
            if(difference%60==0)
            {
                updatePrice();
                updateTab();
                clearPlotInfo0();
                setUpPlotInfo0(Plots[0]);
            }
            difference = (DateTime.Now.Ticks - PlotInfo[1].Item3.Ticks) / 10000000;
            if (difference % 60 == 0)
            {
                updatePrice();
                updateTab();
                clearPlotInfo1();
                setUpPlotInfo1(Plots[1]);
            }
            profit = Math.Round(PlotInfo[1].Item1[0] + (difference / 0.001 * 86400 / 8 / 100000000000), 3);
            p2Wallet.Text = profit.ToString() + "CLNY / $" + Math.Round(profit * price, 2);
        }

        private void H0Button_Click(object sender, EventArgs e)
        {
            curTab = 3;
            changeTab(3);
        }

        private void H1Button_Click(object sender, EventArgs e)
        {
            curTab = 2;
            changeTab(2);
        }

        private void H6Button_Click(object sender, EventArgs e)
        {
            curTab = 1;
            changeTab(1);
        }

        private void H24Button_Click(object sender, EventArgs e)
        {
            curTab = 0;
            changeTab(0);
        }

        private void Pin_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.TopMost = !Form1.ActiveForm.TopMost;
            if (Form1.ActiveForm.TopMost)
            {
                Form1.ActiveForm.Opacity = 0.6f;
                Pin.Text = "U";
            }
            else
            {
                Form1.ActiveForm.Opacity = 1f;
                Pin.Text = "P";
            }
        }
    }

    public class Functions
    {
        public static float FixFloat(string InString)
        {
            return float.Parse(InString.Replace(".", ","));
        }
        private static string makeAPICall(string URL)
        {
            var client = new WebClient();
            return client.DownloadString(URL);
        }
        public static (string, string[][], string[], string[]) getPrice()
        {
            var response = JsonNode.Parse(makeAPICall("https://api.dexscreener.io/latest/dex/tokens/0x0D625029E21540aBdfAFa3BFC6FD44fB4e0A66d0"));
            string price = response["pairs"][0]["priceUsd"].ToString();
            string[] TXNS24 = new string[] { response["pairs"][0]["txns"]["h24"]["buys"].ToString(), response["pairs"][0]["txns"]["h24"]["sells"].ToString() };
            string[] TXNS6 = new string[] { response["pairs"][0]["txns"]["h6"]["buys"].ToString(), response["pairs"][0]["txns"]["h6"]["sells"].ToString() };
            string[] TXNS1 = new string[] { response["pairs"][0]["txns"]["h1"]["buys"].ToString(), response["pairs"][0]["txns"]["h1"]["sells"].ToString() };
            string[] TXNS0 = new string[] { response["pairs"][0]["txns"]["m5"]["buys"].ToString(), response["pairs"][0]["txns"]["m5"]["sells"].ToString() };
            string[][] TXNS = new string[][] { TXNS24, TXNS6, TXNS1, TXNS0 };

            string CHNG24 =  response["pairs"][0]["priceChange"]["h24"].ToString();
            string CHNG6 = response["pairs"][0]["priceChange"]["h6"].ToString();
            string CHNG1 = response["pairs"][0]["priceChange"]["h1"].ToString();
            string CHNG0 = response["pairs"][0]["priceChange"]["m5"].ToString();
            string[] CHNG = new string[] { CHNG24, CHNG6, CHNG1, CHNG0 };

            string VOL24 = response["pairs"][0]["volume"]["h24"].ToString();
            string VOL6 = response["pairs"][0]["volume"]["h6"].ToString();
            string VOL1 = response["pairs"][0]["volume"]["h1"].ToString();
            string VOL0 = "0";
            if(response["pairs"][0]["volume"]["m5"]!=null)
            VOL0 = response["pairs"][0]["volume"]["m5"].ToString();
            string[] VOL = new string[] { VOL24, VOL6, VOL1, VOL0 };

            return (price, TXNS, CHNG, VOL);
        }
        public static (float[],int[], DateTime) getPlotInfo(short PlotID)
        {
            var response = JsonNode.Parse(makeAPICall("https://meta.marscolony.io/"+PlotID));
            var timestr = response["attributes"][2]["value"].ToString();
            var wallet = response["attributes"][3]["value"].ToString();
            var speed = response["attributes"][4]["value"].ToString();
            var station = response["attributes"][5]["value"].ToString();
            var transport = response["attributes"][6]["value"].ToString();
            var robot = response["attributes"][7]["value"].ToString();
            var power = response["attributes"][8]["value"].ToString();

            DateTime time = DateTime.Parse(timestr);
            if (station == "yes") station = "1"; else station = "0";
            int[] upgrades = new int[] {int.Parse(station), int.Parse(transport), int.Parse(robot), int.Parse(power) };
            float[] stats = new float[] { FixFloat(wallet),FixFloat(speed) };
            Form1.PlotInfo[Array.IndexOf(Form1.Plots, PlotID)]= (stats, upgrades, time);
            return (stats, upgrades, time);
        }
    }
}