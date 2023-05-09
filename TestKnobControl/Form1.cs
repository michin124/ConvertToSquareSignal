using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace TestKnobControl
{

    public partial class Form1 : Form
    {
        int V1 = 0;
        int V2 = 0;
       
        //SYM
        double SY = 0.0;
        int nSY = 0;
        string[] VSY = new string[100];
        string l8, o8;


        //SPAM
        double SPA = 0.0;
        int nSP = 0;
        string[] VSP = new string[100];
        string l7, o7;

        //RATE
        double RAT = 0.0;
        int nR = 0;
        string[] VRAT = new string[100];
        string l6, o6;


        //STARTSTOP
        //1
        double START1 = 0.0;
        int nSS1 = 0;
        string[] VSS1 = new string[100];
        string l51, o51;
        //2
        double START2 = 0.0;
        int nSS2 = 0;
        string[] VSS2 = new string[100];
        string l52, o52;


        int ON = 0;
        int a = 0;

        //
        int GATE = 0;
        double[] VGATE = new double[] { 0.001, 0.1, 1, 10 };
        
        //TRIGO
        int EXTRY = 0;
        int TRIGO = 0;
        int TRIGOT = 0;

        double TRY = 0.0;
        int nT = 0;
        string[] VTR = new string[100];
        string l4, o4;

        //OFFSET
        double actual;
        double OF = 0.0;
        int nF = 0;
        string[] VOFF = new string[100];
        string l3, o3;

        int bot = 4, anguloa, angulob, up = 0;
        //duty
        double duti = 0.0;
        int nd = 0;
        string[] Vduti = new string[100];
        string l2, o2;


        //voltaje
        double[] volt = new double[] { 0, 0.35355, 0 };
        int lm = 0;
        string[] Vguard = new string[100];
        string  l, o;

        
        //frec
        double frequ = 0.0;
        int nf = 0;
        string[] Vfrec = new string[100];
        string l1, o1;

        bool SS = false;
        bool trigou = false;
        bool efecto = false;
        public bool voltaje = false;
        public bool aceptar = false;
        bool duty = false;
        bool freq = false;
        bool offset = false;
        bool vrms = false;
        bool Mhz = false;
        bool SHIFT = false;
        bool RATE = false;
        bool SPAM = false;
        bool SYM = false;
        



        SerialPort spPuertoSerie = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

        public Form1()
        {

            InitializeComponent();
            spPuertoSerie.Open();
            spPuertoSerie.Handshake = Handshake.None;
            spPuertoSerie.ReadTimeout = 500;
            spPuertoSerie.WriteTimeout = 500;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label15.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            //knobControl2.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.circle;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
             
            //VOLT
            if (voltaje==true)
            {
                label15.Visible = true;
                label15.Text = "Voltaje Pa";
                if (up == 1)
                {
                    if(volt[0]<10)
                    {
                        volt[0] = volt[0] + 0.1;
                        spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[0]}"));
                        label14.Text = volt[0].ToString();
                        
                    }
                    up = 0;
                }
                if(volt[0]>0)
                {
                    if (up == -1)
                    {
                        volt[0] = volt[0] - 0.1;
                        spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[0]}"));
                        label14.Text = volt[0].ToString();
                    }
                    up = 0;
                }
               
            } 
            //FREQ
            if (freq == true)
            {
                label15.Visible = true;
                label15.Text = "Freq Pa";
                
                if (up == 1)
                {
                    frequ = frequ + 1;
                    spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                    label11.Text = frequ.ToString();
                    up = 0;
                }
                if (frequ > 0)
                {
                    if (up == -1)
                    {
                        frequ = frequ - 1;
                        spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label11.Text = frequ.ToString();
                    }
                    up = 0;
                }
            }
            //OFFSET
            if(offset==true)
            {
                label15.Visible = true;
                label15.Text = "OFF SETT pa";

                actual = 10 - volt[0];


                if (up == 1)
                {
                    if (OF < actual)
                    {
                        OF = OF + 1;
                        spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label14.Text = OF.ToString();
                        up = 0;
                    }
                }
                if (OF > 0)
                {
                    if (up == -1)
                    {
                        OF = OF - 1;
                        spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label14.Text = OF.ToString();
                    }
                    up = 0;
                }

            }
            //DUTY
            if (duty == true)
            {
                label15.Visible = true;
                label15.Text = "duty pa";

                if (up == 1)
                {
                    if (duti < 99)
                    {
                        duti = duti + 1;
                       
                        spPuertoSerie.WriteLine(String.Format($":DUTY {duti}"));
                        label14.Text = duti.ToString();
                        up = 0;
                    }
                }
                if (duti > 0)
                {
                    if (up == -1)
                    {
                        duti = duti - 1;
                        spPuertoSerie.WriteLine(String.Format($":DUTY {duti}"));
                        label14.Text = duti.ToString();
                    }
                    up = 0;
                }
            }
            //TRIGOPA
            if (trigou == true)
            {
                label15.Visible = true;
                label15.Text = "trigo pa";

                if (up == 1)
                {
                    if (TRY < 80)
                    {
                        TRY = TRY + 1;
                        //spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label14.Text = TRY.ToString();
                        up = 0;
                    }
                }
                if (TRY > 0)
                {
                    if (up == -1)
                    {
                        TRY = TRY - 1;
                        //spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label14.Text = TRY.ToString();
                    }
                    up = 0;
                }
            }
            //START

            if (SHIFT == false)
            {

                if(SS==true)
                {
                    label15.Visible = true;
                    label15.Text = "STOP";

                    if (up == 1)
                    {
                            START1 = START1 + 1;
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:START {START1}"));
                            label14.Text = TRY.ToString();
                            up = 0;
                        
                    }
                    if (START1 > 0)
                    {
                        if (up == -1)
                        {
                            START1 = START1 - 1;
                            spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:START {START1}"));
                            label14.Text = TRY.ToString();
                        }
                        up = 0;
                    }
                }
                if(RATE==true)
                {
                    label15.Visible = true;
                    label15.Text = "RATE";

                    if (up == 1)
                    {
                        RAT = RAT + 1;
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:RATe {RAT}"));
                        label14.Text = TRY.ToString();
                        up = 0;

                    }
                    if (RAT > 0)
                    {
                        if (up == -1)
                        {
                            RAT = RAT - 1;
                            spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:RATe {RAT}"));
                            label14.Text = TRY.ToString();
                        }
                        up = 0;
                    }
                }
                
            }
            //STOP
            if (SHIFT == true)
            {

                if (SS == true)
                {
                    label15.Visible = true;
                    label15.Text = "START";

                    if (up == 1)
                    {
                        START2 = START2 + 1;
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:STOP {START2}"));
                        label14.Text = TRY.ToString();
                        up = 0;

                    }
                    if (START2 > 0)
                    {
                        if (up == -1)
                        {
                            START2 = START2 - 1;
                            spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:STOP {START2}"));
                            label14.Text = TRY.ToString();
                        }
                        up = 0;
                    }
                }

            }
            //RATE
            







            ////////////
            //ANGLE
            if (angulob != anguloa)
            {
                
                if(angulob > anguloa)
                {
                    up = -1;
                }
                if (angulob < anguloa)
                {
                    up = 1;
                }
                angulob = anguloa;
            }
            anguloa = knobControl2.Value;
            
            Thread.Sleep(1);
            
            //////////////
        }
    

        private void button1_Click(object sender, EventArgs e)
        {

            if (a == 0)
            {
                spPuertoSerie.WriteLine(String.Format(":FUNCtion:WAVeform 1 "));
                a++;

            }

            else if (a == 1)
            {
                spPuertoSerie.WriteLine(String.Format(":FUNCtion:WAVeform 2"));
                a++;
            }
            else if (a == 2)
            {

                spPuertoSerie.WriteLine(String.Format(":FUNCtion:WAVeform 3"));
                a = 0;
            }


        }
        //----------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            duty = false;
            freq = false;
            offset = false;
            voltaje = true;
            trigou = false;
            SS = false;
        }
        //DUTY
        private void button3_Click(object sender, EventArgs e)
        {
            voltaje = false;
            freq = false;
            offset = false;
            trigou = false;
            duty = true;
            SS = false;
        }
        //freq
        private void button4_Click(object sender, EventArgs e)
        {
            voltaje = false;
            duty = false;
            trigou = false;
            offset = false;
            freq = true;
            SS = false;
        }
        //offset
        private void button5_Click(object sender, EventArgs e)
        {
            voltaje = false;
            duty = false;
            freq = false;
            trigou = false;
            offset = true;
            SS = false;
        }
        //TRIGO PHASE
        private void button27_Click(object sender, EventArgs e)
        {
            voltaje = false;
            duty = false;
            freq = false;
            trigou = true;
            offset = false;
            SS = false;
        }
        //STARSTOP
        private void button12_Click(object sender, EventArgs e)
        {
            SS = true;
            voltaje = false;
            freq = false;
            offset = false;
            trigou = false;
            duty = false;
            
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        

        

        //MHz Vrms
        


        private void button20_Click(object sender, EventArgs e)
        {

        }

        

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }



        //NUMEROS
        //1
        private void button38_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "1";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nf; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //2
        private void button37_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "2";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nf; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //3
        private void button36_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "3";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR ; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //4
        private void button21_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "4";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //5
        private void button22_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "5";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //6
        private void button23_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "6";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //7
        private void button16_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "7";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //8
        private void button17_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "8";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //9
        private void button18_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = "9";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nR; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //0
        private void button33_Click(object sender, EventArgs e)
        {

            efecto = true;
            string n = "0";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VOFF[nf] = VOFF[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
            //
            if (SHIFT == true)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS1[nSS1] = VSS1[nSS1 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l51 = "";
                    for (int x = 0; x <= nSS1; x++)
                    {
                        l51 = l51 + VSS1[x];
                    }
                    o51 = l51;
                    nSS1++;
                }

            }
            if (SHIFT == false)
            {
                if (SS == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSS2[nSS2] = VSS2[nSS2 + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l52 = "";
                    for (int x = 0; x <= nSS2; x++)
                    {
                        l52 = l52 + VSS2[x];
                    }
                    o52 = l52;
                    nSS2++;
                }
                if (RATE == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VRAT[nR] = VRAT[nR + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l6 = "";
                    for (int x = 0; x <= nf; x++)
                    {
                        l6 = l6 + VRAT[x];
                    }
                    o6 = l6;
                    nR++;
                }
                if (SPAM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSP[nSP] = VSP[nSP + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l7 = "";
                    for (int x = 0; x <= nSP; x++)
                    {
                        l7 = l7 + VSP[x];
                    }
                    o7 = l7;
                    nSP++;
                }
                if (SYM == true)
                {
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                    //n = spPuertoSerie.ReadLine();
                    VSY[nSY] = VSY[nSY + 1] + n;
                    //char n3 = Convert.ToChar(n2);
                    l8 = "";
                    for (int x = 0; x <= nSY; x++)
                    {
                        l8 = l8 + VSY[x];
                    }
                    o8 = l8;
                    nSY++;
                }

            }
        }
        //.
        private void button32_Click(object sender, EventArgs e)
        {
            efecto = true;
            string n = ".";
            if (voltaje == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vguard[lm] = Vguard[lm + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l = "";
                for (int x = 0; x <= lm; x++)
                {
                    l = l + Vguard[x];
                }
                o = l;
                lm++;
            }



            if (freq == true)
            {


                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vfrec[nf] = Vfrec[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l1 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l1 = l1 + Vfrec[x];
                }
                o1 = l1;
                nf++;
            }

            if (duty == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nd] = Vduti[nd + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l2 = "";
                for (int x = 0; x <= nd; x++)
                {
                    l2 = l2 + Vduti[x];
                }
                o2 = l2;
                nd++;
            }

            if (offset == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                Vduti[nf] = Vduti[nf + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l3 = "";
                for (int x = 0; x <= nf; x++)
                {
                    l3 = l3 + VOFF[x];
                }
                o3 = l3;
                nf++;
            }
            if (trigou == true)
            {

                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage ?"));
                //n = spPuertoSerie.ReadLine();
                VTR[nT] = VTR[nT + 1] + n;
                //char n3 = Convert.ToChar(n2);
                l4 = "";
                for (int x = 0; x <= nT; x++)
                {
                    l4 = l4 + VTR[x];
                }
                o4 = l4;
                nT++;
            }
        }






        private void knobControl2_Load(object sender, EventArgs e)
        {
           

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

    



        //vp
        private void button30_Click(object sender, EventArgs e)
        {
            if (efecto == true)
            {
                int ERROR = 3;
                if (voltaje == true)
                {
                    volt[0] = double.Parse(o);
                    volt[0] = Math.Round(volt[0], 2);
                    spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 1"));
                    spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[0]}"));
                    label14.Text = volt[0].ToString();

                    for (int x = 0; x < lm; x++)
                    {
                        Vguard[x] = "";
                    }
                    ERROR--;
                }
                if (freq == true)
                {
                    frequ = double.Parse(o1);
                    spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                    label11.Text = frequ.ToString();

                    for (int x = 0; x < nf; x++)
                    {
                        Vfrec[x] = "";
                    }
                    ERROR--;
                }
                if(offset==true)
                {
                    actual = 5 - volt[0];
                    OF = double.Parse(o3);
                    label14.Text = OF.ToString();
                    spPuertoSerie.WriteLine(String.Format($":OFFSet {OF}"));
                    

                    if (OF<=actual)
                    {
                        label14.Text = OF.ToString();
                    }
                    else
                    {
                        label14.Text = "error";
                    }
                    for (int x = 0; x < nf; x++)
                    {
                        VOFF[x] = "";
                    }
                    ERROR--;
                }
                if (SHIFT == true)
                {
                    if (SS == true)
                    {

                       

                        START1 = double.Parse(o51);
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:STOP {START1}"));
                        label14.Text = START1.ToString();
                        


                        for (int x = 0; x < nSS1; x++)
                        {
                            VSS1[x] = "";
                        }
                        ERROR--;
                    }
                }
                if (SHIFT == false)
                {
                    if (SS == true)
                    {

                        

                        START2 = double.Parse(o52);
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:STARt {START2}"));
                        label14.Text = START2.ToString();
                        


                        for (int x = 0; x < nSS2; x++)
                        {
                            VSS2[x] = "";
                        }
                        ERROR--;
                    }
                    if (RATE == true)
                    {



                        RAT = double.Parse(o6);
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:RATe {RAT}"));
                        label14.Text = RAT.ToString();
                        


                        for (int x = 0; x < nR; x++)
                        {
                            VRAT[x] = "";
                        }
                        ERROR--;
                    }

                    if (SPAM == true)
                    {



                        SPA = double.Parse(o7);
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:SPAN {SPA}"));
                        label14.Text = SPA.ToString();



                        for (int x = 0; x < nSP; x++)
                        {
                            VSP[x] = "";
                        }
                        ERROR--;
                    }

                    if (SYM == true)
                    {



                        SY = double.Parse(o8);
                        spPuertoSerie.WriteLine(String.Format($":SOURce:SWEep:SYM {SY}"));
                        label14.Text = SY.ToString();



                        for (int x = 0; x < nSY; x++)
                        {
                            VSY[x] = "";
                        }
                        ERROR--;
                    }

                    


                }


                if (ERROR==3)
                {
                    label14.Text = "error";
                    label15.Visible = false;
                    voltaje = false;
                    freq = false;
                    offset = false;
                    trigou = false;
                    duty = false;
                }
                
            }

            //
            
            //
            if (efecto == false)
            {
                if (bot != 0 && bot != 4)
                {
                    if (bot == 2)
                    {
                        if (voltaje == true)
                        {
                            
                                
                            
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 1"));
                            
                            label14.Text = volt[0].ToString();
                            
                        }
                        if (freq == true)
                        {
                            Mhz = true;
                        }
                    }
                    if (bot == 1)
                    {
                        if (voltaje == true)
                        {
                            
                                
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 1"));
                            
                            label14.Text = volt[0].ToString();
                            
                        }
                        if (freq == true)
                        {
                            Mhz = true;
                        }
                    }
                }

               

            }

            for (int x = 0; x < nf; x++)
            {
                Vfrec[x] = "";
            }

            efecto = false;
            aceptar = false;
            bot = 0;
            if (volt[0] > 10)
            {
                volt[0] = 0;
                label14.Text = "errorpa";
                spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 1"));
                spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage 0.01"));
            }
        }



        //KHz
        private void button24_Click(object sender, EventArgs e)
        {
            {

                if (efecto == true)
                {
                    if (voltaje == true)
                    {
                        volt[1] = double.Parse(o);
                        if (volt[1] <= 3)
                        {
                            volt[1] = Math.Round(volt[1], 2);
                            //spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));
                            //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[1]}"));
                            label14.Text = volt[1].ToString();                         
                        }
                        else
                        {
                            label14.Text = "errorpa";
                            volt[1] = 0;
                            //spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));
                            //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[1]}"));
                        }
                        for (int x = 0; x < lm; x++)
                        {
                            Vguard[x] = "";
                        }

                    }
                    if (freq == true)
                    {
                        frequ = double.Parse(o1);
                        frequ = frequ * 1000;
                        spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                        label11.Text = frequ.ToString();
                        for (int x = 0; x < nf; x++)
                        {
                            Vfrec[x] = "";
                        }

                    }

                }
                if (efecto == false)
                {
                    if (bot != 1 && bot != 4)
                    {
                        if (bot == 2)
                        {
                            if (voltaje == true)
                            {
                                spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));     
                                label14.Text = volt[1].ToString();
                            }
                            
                        }
                        if (bot == 0)
                        {
                            if (voltaje == true)
                            {
                                //volt[1] = volt[0] * (1 / (2 * Math.Sqrt(2)));                               
                                spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));                               
                                label14.Text = volt[1].ToString();
                            }
                            if (freq == true)
                            {
                                Mhz = true;
                            }
                        }
                    }

                    else
                    {

                        if (voltaje == true)
                        {
                            volt[1] = double.Parse(o);

                            if (volt[1] <= 3)
                            {
                                volt[1] = Math.Round(volt[1], 2);
                                //spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));
                                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[1]}"));
                                label14.Text = volt[1].ToString();
                            }
                            else
                            {
                                label14.Text = "errorpa";
                                volt[1] = 0;
                                //spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 2"));
                                //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[1]}"));
                            }
                            for (int x = 0; x < lm; x++)
                            {
                                Vguard[x] = "";
                            }                      
                        }
                    }
                }
                bot = 1;
                efecto = false;
            }
        }

        //SHIFT
        private void button34_Click(object sender, EventArgs e)
        {
            SHIFT = true;
        }


        //MMHz
        private void button35_Click(object sender, EventArgs e)
        {    
            //
            if (efecto == true)
            {
                if (voltaje == true)
                {
                    volt[2] = double.Parse(o);
                    volt[2] = Math.Round(volt[2], 2);
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 3"));
                    //spPuertoSerie.WriteLine(String.Format($":AMPLitude:VOLTage {volt[2]}"));
                    label14.Text = volt[2].ToString();

                    for (int x = 0; x < lm; x++)
                    {
                        Vguard[x] = "";
                    }
                }
                if (freq == true)
                {

                    frequ = double.Parse(o1);
                    frequ = frequ * 1000000;
                    spPuertoSerie.WriteLine(String.Format($":FREQuency {frequ}"));
                    label11.Text = frequ.ToString();
                    for (int x = 0; x < nf; x++)
                    {
                        Vfrec[x] = "";
                    }
                }

            }
            if (efecto == false)
            {
                if (bot != 2 && bot != 4)
                {
                    if (bot == 0)
                    {
                        if (voltaje == true)
                        {
                            
                                
                            
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 3"));
                            
                            label14.Text = volt[2].ToString();

                           
                        }
                        if (freq == true)
                        {
                            Mhz = true;
                        }
                    }
                    if (bot == 1)
                    {
                        if (voltaje == true)
                        {

                            
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 3"));
                            label14.Text = volt[2].ToString();

                            
                        }
                        if (freq == true)
                        {
                            Mhz = true;
                        }
                    }
                }
                else
                {
                    if (voltaje == true)
                    {
                        volt[2] = double.Parse(o);
                        if (volt[2] <= 10)
                        {      
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 3"));          
                            label14.Text = volt[2].ToString();
                        }
                        else
                        {
                            label14.Text = "errorpa";
                            spPuertoSerie.WriteLine(String.Format($":AMPLitude: UNIT 3"));
                            volt[2] = 0;
                        }
                        for (int x = 0; x < lm; x++)
                        {
                            Vguard[x] = "";
                        }           
                    }
                }
            }
            bot = 2;
            efecto = false;
        }
        //DEG
        private void button19_Click(object sender, EventArgs e)
        {
            if (efecto == true)
            {
                int ERROR = 2;
                if (duty == true)
                {
                    duti = double.Parse(o2);
                    if (duti < 100)
                    {
                        spPuertoSerie.WriteLine(String.Format($":DUTY {duti}"));
                        label14.Text = duti.ToString();

                        for (int x = 0; x < nd; x++)
                        {
                            Vduti[x] = "";
                        }
                    }
                    ERROR--;
                }
                if (trigou == true)
                {
                    TRY = double.Parse(o4);
                    if (TRY < 80)
                    {
                        spPuertoSerie.WriteLine(String.Format($":SOURce:TRIGger:PHASe {TRY}"));
                        label14.Text = TRY.ToString();

                        for (int x = 0; x < nT; x++)
                        {
                            VTR[x] = "";
                        }
                    }
                    ERROR--;
                }
                if(ERROR==2)
                {
                    label14.Text = "error"; 
                    label15.Visible = false;
                    voltaje = false;
                    freq = false;
                    offset = false;
                    trigou = false;
                    duty = false;
                }
            }
            

        }
        //MOD ON
        private void button6_Click(object sender, EventArgs e)
        {
            //spPuertoSerie.WriteLine(String.Format(":SOURce: MODAM: STATe ?"));
            //string trig_ex = spPuertoSerie.ReadLine();
            //int z = Int32.Parse(trig_ex);
            //label18.Text = trig_ex;
            
            
             if(ON==1)
            {

                spPuertoSerie.WriteLine(String.Format(":SOURce: MODAM: STATe 0"));
                ON = 0;
                label19.Visible = false;
                label19.Text = "";
            }
            else if (ON == 0)
            {
                spPuertoSerie.WriteLine(String.Format(":SOURce: MODAM: STATe 1"));

                label19.Visible = true;
                label19.Text = "ON";
                ON = ON + 1;

            }
        }
        //trig on
        private void button25_Click(object sender, EventArgs e)
        {
            if (TRIGO == 1)
            {

                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:STATe 0"));
                TRIGO = 0;
                label17.Visible = false;
                label17.Text = "";
            }
            else if (TRIGO == 0)
            {
                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:STATe 1"));

                label17.Visible = true;
                label17.Text = "TRIGO ON";
                TRIGO = TRIGO + 1;

            }
        }
        //TRIGO SINGLEORNO
        private void button26_Click(object sender, EventArgs e)
        {
            if (TRIGOT == 1)
            {

                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:MODe 0"));
                TRIGOT = 0;
                label18.Visible = true;
                label18.Text = "SINGLE";
            }
            else if (TRIGOT == 0)
            {
                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:MODe 1"));

                label18.Visible = true;
                label18.Text = "MULTIPLE";
                TRIGOT = TRIGOT + 1;

            }
        }
        //TRIGO EXTERNAL O INT
        private void button28_Click(object sender, EventArgs e)
        {
            if (EXTRY == 1)
            {

                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:SOURce 0"));
                EXTRY = 0;
                label20.Visible = true;
                label20.Text = "INTERNAL";
            }
            else if (EXTRY == 0)
            {
                spPuertoSerie.WriteLine(String.Format(":SOURce:TRIGger:SOURce 1"));

                label20.Visible = true;
                label20.Text = "EXTERNAL";
                EXTRY = EXTRY + 1;

            }
        }
        //GATE
        private void button29_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            if (GATE == 0)
            {

                spPuertoSerie.WriteLine(String.Format($":SOURce:COUNter:GATe  {VGATE[GATE]}"));
                label15.Text = VGATE[GATE].ToString();
                GATE++;

            }

            else if (GATE == 1)
            {
                spPuertoSerie.WriteLine(String.Format($":SOURce:COUNter:GATe  {VGATE[GATE]}"));
                label15.Text = VGATE[GATE].ToString();
                GATE++;
            }
            else if (GATE == 2)
            {

                 spPuertoSerie.WriteLine(String.Format($":SOURce:COUNter:GATe  {VGATE[GATE]}"));
                label15.Text = VGATE[GATE].ToString();
                GATE++;
            }
            else if (GATE == 3)
            {
                label15.Text = VGATE[GATE].ToString();
                spPuertoSerie.WriteLine(String.Format($":SOURce:COUNter:GATe  {VGATE[GATE]}"));
                GATE =0;

            }
            
            
        }
        //log a lin
        private void button13_Click(object sender, EventArgs e)
        {
            if(SHIFT==true)
            {
                label22.Visible = true;
                label22.Text = "Log";
                SHIFT = false;
                spPuertoSerie.WriteLine(String.Format($":SOURce: SWEep: SPACing 1"));
            }
            else
            {
                label22.Visible = true;
                label22.Text = "Linear";
                spPuertoSerie.WriteLine(String.Format($":SOURce: SWEep: SPACing 0"));
            }
        }
        //AMFM
        private void button11_Click(object sender, EventArgs e)
        {
            if (SHIFT == true)
            {
                label23.Visible = true;
                label23.Text = "FM";
                SHIFT = false;
                spPuertoSerie.WriteLine(String.Format($":SOURce:STATe 2"));
            }
            else
            {
                label23.Visible = true;
                label23.Text = "AM";
                spPuertoSerie.WriteLine(String.Format($":SOURce:STATe 1"));
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {

            if (SHIFT == true)
            {
                if (V2 == 0)
                {

                    spPuertoSerie.WriteLine(String.Format($":SOURce:WAVeform  1"));
                    label15.Text = VGATE[GATE].ToString();
                    V2++;

                }

                else if (V2 == 1)
                {
                    spPuertoSerie.WriteLine(String.Format($":SOURce: WAVeform 2"));
                    label15.Text = VGATE[GATE].ToString();
                    V2++;
                }
                else if (V2 == 2)
                {

                    spPuertoSerie.WriteLine(String.Format($":SOURce:WAVeform 3"));
                    label15.Text = VGATE[GATE].ToString();
                    V2=0;
                }

                
                SHIFT = false;
                
            }
            else
            {
                SPAM = true;
                
      
            }
            
            
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (SHIFT == true)
            {
                if (V2 == 1)
                {

                    spPuertoSerie.WriteLine(String.Format($"SOURce:SOURce 0"));

                    V2 = 0;

                }
                else if (V2 == 0)
                {
                    spPuertoSerie.WriteLine(String.Format("SOURce:SOURce1"));


                    V1 = V2 + 1;

                }

                SHIFT = false;

            }
            else
            {
                SYM = true;


            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (SHIFT == true)
            {
                if (V1 == 1)
                {

                    spPuertoSerie.WriteLine(String.Format($"SOURce:SOURce 0"));

                    V1 = 0;
                    
                }
                else if (V1 == 0)
                {
                    spPuertoSerie.WriteLine(String.Format("SOURce:SOURce 1"));


                    V1 = V1 + 1;

                }
                
                SHIFT = false;
                
            }
            else
            {
               
                
               
            }
            RATE = true;
        }

    }
}
