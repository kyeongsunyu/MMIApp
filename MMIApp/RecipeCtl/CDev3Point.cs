using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMI
{
    public class CDevPckCen
    {
        public List<Pck3Point> FrontCen;
        public List<Pck3Point> RearCen;

        public CDevPckCen()
        {
            FrontCen = new List<Pck3Point>();
            RearCen = new List<Pck3Point>();
        }

        public void F_GetPckCen()
        {
            double mX, mY;

            FrontCen = null;
            FrontCen = new List<Pck3Point>();
            Pck3Point p;

            for (int k = 0; k < 8; k++)
            {
                mX = MmiGV.mtSettingData[16].dPosArray[19+k];
                mY = MmiGV.mtSettingData[15].dPosArray[1+k];

                p = new Pck3Point(mX, mY);
                FrontCen.Add(p);
            }
        }
        public void R_GetPckCen()
        {
            double mX, mY;

            RearCen = null;
            RearCen = new List<Pck3Point>();
            Pck3Point p;

            for (int k = 0; k < 8; k++)
            {
                mX = MmiGV.mtSettingData[23].dPosArray[19 + k];
                mY = MmiGV.mtSettingData[15].dPosArray[9 + k];

                p = new Pck3Point(mX, mY);
                RearCen.Add(p);
            }
        }

        public void F_SetPckCen()
        {
            for (int k = 0; k < 8; k++)
            {
                MmiGV.mtSettingData[16].dPosArray[19 + k] = FrontCen[k].mX;
                MmiGV.mtSettingData[15].dPosArray[1 + k] = FrontCen[k].mY;
            }
        }

        public void R_SetPckCen()
        {
            for (int k = 0; k < 8; k++)
            {
                MmiGV.mtSettingData[23].dPosArray[19 + k] = RearCen[k].mX;
                MmiGV.mtSettingData[15].dPosArray[9 + k] = RearCen[k].mY;
            }
        }

    }    


    public class CDev3Point
    {
        public List<List<Pck3Point>> Front3P;
        public List<List<Pck3Point>> Rear3P; 

        public CDev3Point()
        {
            Front3P = new List<List<Pck3Point>>();
            Rear3P = new List<List<Pck3Point>>();
        }


        public void F_Get3Point()
        {
            Front3P = null;
            Front3P = new List<List<Pck3Point>>();
            Pck3Point p;
            List<Pck3Point> Unit;
            
            for (int j=0;j<6;j++)
            {
                Unit = new List<Pck3Point>();
                for (int k = 0; k < 3; k++)
                {
                    p = new Pck3Point(0, 0);
                    Unit.Add(p);
                }

                Front3P.Add(Unit);
            }
            //---------------
            int cnt = 0;
            for(int k=0; k < 3; k++)
            {
                Front3P[0][k].mX = MmiGV.mtSettingData[16].dPosArray[k+1]; //파레트1
                cnt = 3;
                Front3P[1][k].mX = MmiGV.mtSettingData[16].dPosArray[cnt+k+1]; //파레트2
                cnt = cnt + 3;
                Front3P[2][k].mX = MmiGV.mtSettingData[16].dPosArray[cnt+k+1]; //Good 1 
                cnt = cnt + 3;
                Front3P[3][k].mX = MmiGV.mtSettingData[16].dPosArray[cnt+k+1]; //Good 2 
                cnt = cnt + 3;
                Front3P[4][k].mX = MmiGV.mtSettingData[16].dPosArray[cnt+k+1]; //Rework 
                cnt = cnt + 3;
                Front3P[5][k].mX = MmiGV.mtSettingData[16].dPosArray[cnt+k+1]; //NG 
                //------------------    

                Front3P[0][k].mY = MmiGV.mtSettingData[9].dPosArray[1+k+1]; //Front +  파레트1 
                Front3P[1][k].mY = MmiGV.mtSettingData[10].dPosArray[1+k+1]; //Front +  파레트2 
                Front3P[2][k].mY = MmiGV.mtSettingData[30].dPosArray[k+1]; //Front +  Good 1 
                Front3P[3][k].mY = MmiGV.mtSettingData[31].dPosArray[k+1]; //Front + Good 2 
                Front3P[4][k].mY = MmiGV.mtSettingData[32].dPosArray[k+1]; //Front +  Rework 
                Front3P[5][k].mY = MmiGV.mtSettingData[33].dPosArray[k+1]; //Front + NG 
            }
        }
        public void F_Set3Point()
        {
            int cnt = 0;
            for (int k = 0; k < 3; k++)
            {
                MmiGV.mtSettingData[16].dPosArray[k + 1] = Front3P[0][k].mX; //파레트1
                cnt = 3;
                MmiGV.mtSettingData[16].dPosArray[cnt + k + 1] = Front3P[1][k].mX; //파레트2
                cnt = cnt + 3;
                MmiGV.mtSettingData[16].dPosArray[cnt + k + 1] = Front3P[2][k].mX; //Good 1 
                cnt = cnt + 3;
                MmiGV.mtSettingData[16].dPosArray[cnt + k + 1] = Front3P[3][k].mX; //Good 2 
                cnt = cnt + 3;
                MmiGV.mtSettingData[16].dPosArray[cnt + k + 1] = Front3P[4][k].mX; //Rework 
                cnt = cnt + 3;
                MmiGV.mtSettingData[16].dPosArray[cnt + k + 1] = Front3P[5][k].mX; //NG 
                //------------------    

                MmiGV.mtSettingData[9].dPosArray[1 + k + 1] = Front3P[0][k].mY; //Front +  파레트1 
                MmiGV.mtSettingData[10].dPosArray[1 + k + 1] = Front3P[1][k].mY ; //Front +  파레트2 
                MmiGV.mtSettingData[30].dPosArray[k + 1] = Front3P[2][k].mY; //Front +  Good 1 
                MmiGV.mtSettingData[31].dPosArray[k + 1] = Front3P[3][k].mY; //Front + Good 2 
                MmiGV.mtSettingData[32].dPosArray[k + 1] = Front3P[4][k].mY; //Front +  Rework 
                MmiGV.mtSettingData[33].dPosArray[k + 1] = Front3P[5][k].mY; //Front + NG 
            }

        }
        public void R_Get3Point()
        {
            Rear3P = null;
            Rear3P = new List<List<Pck3Point>>();
            Pck3Point p;
            List<Pck3Point> Unit;

            for (int j = 0; j < 6; j++)
            {
                Unit = new List<Pck3Point>();
                for (int k = 0; k < 3; k++)
                {
                    p = new Pck3Point(0, 0);
                    Unit.Add(p);
                }

                Rear3P.Add(Unit);
            }
            //---------------
            int cnt = 0;
            for (int k = 0; k < 3; k++)
            {
                Rear3P[0][k].mX = MmiGV.mtSettingData[23].dPosArray[k + 1]; //파레트1
                cnt = 3;
                Rear3P[1][k].mX = MmiGV.mtSettingData[23].dPosArray[cnt + k + 1]; //파레트2
                cnt = cnt + 3;
                Rear3P[2][k].mX = MmiGV.mtSettingData[23].dPosArray[cnt + k + 1]; //Good 1 
                cnt = cnt + 3;
                Rear3P[3][k].mX = MmiGV.mtSettingData[23].dPosArray[cnt + k + 1]; //Good 2 
                cnt = cnt + 3;
                Rear3P[4][k].mX = MmiGV.mtSettingData[23].dPosArray[cnt + k + 1]; //Rework 
                cnt = cnt + 3;
                Rear3P[5][k].mX = MmiGV.mtSettingData[23].dPosArray[cnt + k + 1]; //NG 
                //------------------    

                Rear3P[0][k].mY = MmiGV.mtSettingData[9].dPosArray[4 + k + 1]; //Rear +  파레트1 
                Rear3P[1][k].mY = MmiGV.mtSettingData[10].dPosArray[4 + k + 1]; //Rear +  파레트2 
                Rear3P[2][k].mY = MmiGV.mtSettingData[30].dPosArray[3+k + 1]; //Rear +  Good 1 
                Rear3P[3][k].mY = MmiGV.mtSettingData[31].dPosArray[3+k + 1]; //Rear + Good 2 
                Rear3P[4][k].mY = MmiGV.mtSettingData[32].dPosArray[3+k + 1]; //Rear +  Rework 
                Rear3P[5][k].mY = MmiGV.mtSettingData[33].dPosArray[3+k + 1]; //Rear + NG 
            }
        }
        public void R_Set3Point()
        {
            int cnt = 0;
            for (int k = 0; k < 3; k++)
            {
                MmiGV.mtSettingData[23].dPosArray[k + 1] = Rear3P[0][k].mX; //파레트1
                cnt = 3;
                MmiGV.mtSettingData[23].dPosArray[cnt + k + 1] = Rear3P[1][k].mX; //파레트2
                cnt = cnt + 3;
                MmiGV.mtSettingData[23].dPosArray[cnt + k + 1] = Rear3P[2][k].mX; //Good 1 
                cnt = cnt + 3;
                MmiGV.mtSettingData[23].dPosArray[cnt + k + 1] = Rear3P[3][k].mX; //Good 2 
                cnt = cnt + 3;
                MmiGV.mtSettingData[23].dPosArray[cnt + k + 1] = Rear3P[4][k].mX; //Rework 
                cnt = cnt + 3;
                MmiGV.mtSettingData[23].dPosArray[cnt + k + 1] = Rear3P[5][k].mX; //NG 
                //------------------    

                MmiGV.mtSettingData[9].dPosArray[4 + k + 1] = Rear3P[0][k].mY; //Rear +  파레트1 
                MmiGV.mtSettingData[10].dPosArray[4 + k + 1] = Rear3P[1][k].mY; //Rear +  파레트2 
                MmiGV.mtSettingData[30].dPosArray[3 + k + 1] = Rear3P[2][k].mY; //Rear +  Good 1 
                MmiGV.mtSettingData[31].dPosArray[3 + k + 1] = Rear3P[3][k].mY; //Rear + Good 2 
                MmiGV.mtSettingData[32].dPosArray[3 + k + 1] = Rear3P[4][k].mY; //Rear +  Rework 
                MmiGV.mtSettingData[33].dPosArray[3 + k + 1] = Rear3P[5][k].mY; //Rear + NG 
            }
        }

    }

    public class Pck3Point
    {
        public double mX;
        public double mY;

        public Pck3Point(double xVal, double yVal)
        {
            mX = xVal;
            mY = yVal;
        }

    }    
}
