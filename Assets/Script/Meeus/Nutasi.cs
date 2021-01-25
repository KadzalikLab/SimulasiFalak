﻿

public class Nutasi {


    public static double [] deltaPsiDanEpsilon(double t){
        double d=Konversi.toRadians((297.85036+445267.11148*t-0.0019142*t*t+t*t*t/189474)%360);
        double m=Konversi.toRadians((357.52772+35999.05034*t-0.0001603*t*t-t*t*t/300000)%360);
        double m1=Konversi.toRadians((134.96298+477198.867398*t+0.0086972*t*t+t*t*t/56250)%360);
        double f=Konversi.toRadians((93.27191+483202.017538*t-0.0036825*t*t+t*t*t/327270)%360);
        double omega1=(125.04452-1934.136261*t+0.0020708*t*t+t*t*t/450000)%360;
        if (omega1<0)omega1+=360;
        double omega=Konversi.toRadians(omega1);

        double deltaPsi=0;
        //(koefisien1+koefisien2*t)*System.Math.Sin(D*d+M*m+M'*m1+F*f+OMEGA*omega)
        deltaPsi+=(-171996+-174.2*t)*System.Math.Sin(0*d+0*m+0*m1+0*f+1*omega);
        deltaPsi+=(-13187+-1.6*t)*System.Math.Sin(-2*d+0*m+0*m1+2*f+2*omega);
        deltaPsi+=(-2274+-0.2*t)*System.Math.Sin(0*d+0*m+0*m1+2*f+2*omega);
        deltaPsi+=(2062+0.2*t)*System.Math.Sin(0*d+0*m+0*m1+0*f+2*omega);
        deltaPsi+=(1426+-3.4*t)*System.Math.Sin(0*d+1*m+0*m1+0*f+0*omega);
        deltaPsi+=(712+0.1*t)*System.Math.Sin(0*d+0*m+1*m1+0*f+0*omega);
        deltaPsi+=(-517+1.2*t)*System.Math.Sin(-2*d+1*m+0*m1+2*f+2*omega);
        deltaPsi+=(-386+-0.4*t)*System.Math.Sin(0*d+0*m+0*m1+2*f+1*omega);
        deltaPsi+=(217+-0.5*t)*System.Math.Sin(-2*d+-1*m+0*m1+2*f+2*omega);
        deltaPsi+=(129+0.1*t)*System.Math.Sin(-2*d+0*m+0*m1+2*f+1*omega);
        deltaPsi+=(63+0.1*t)*System.Math.Sin(0*d+0*m+1*m1+0*f+1*omega);
        deltaPsi+=(-58+-0.1*t)*System.Math.Sin(0*d+0*m+-1*m1+0*f+1*omega);
        deltaPsi+=(17+-0.1*t)*System.Math.Sin(0*d+2*m+0*m1+0*f+0*omega);
        deltaPsi+=(-16+0.1*t)*System.Math.Sin(-2*d+2*m+0*m1+2*f+2*omega);
        deltaPsi+=(-301+0*t)*System.Math.Sin(0*d+0*m+1*m1+2*f+2*omega);
        deltaPsi+=(-158+0*t)*System.Math.Sin(-2*d+0*m+1*m1+0*f+0*omega);
        deltaPsi+=(123+0*t)*System.Math.Sin(0*d+0*m+-1*m1+2*f+2*omega);
        deltaPsi+=(63+0*t)*System.Math.Sin(2*d+0*m+0*m1+0*f+0*omega);
        deltaPsi+=(-59+0*t)*System.Math.Sin(2*d+0*m+-1*m1+2*f+2*omega);
        deltaPsi+=(-51+0*t)*System.Math.Sin(0*d+0*m+1*m1+2*f+1*omega);
        deltaPsi+=(48+0*t)*System.Math.Sin(-2*d+0*m+2*m1+0*f+0*omega);
        deltaPsi+=(46+0*t)*System.Math.Sin(0*d+0*m+-2*m1+2*f+1*omega);
        deltaPsi+=(-38+0*t)*System.Math.Sin(2*d+0*m+0*m1+2*f+2*omega);
        deltaPsi+=(-31+0*t)*System.Math.Sin(0*d+0*m+2*m1+2*f+2*omega);
        deltaPsi+=(29+0*t)*System.Math.Sin(0*d+0*m+2*m1+0*f+0*omega);
        deltaPsi+=(29+0*t)*System.Math.Sin(-2*d+0*m+2*m1+2*f+2*omega);
        deltaPsi+=(26+0*t)*System.Math.Sin(0*d+0*m+0*m1+2*f+0*omega);
        deltaPsi+=(-22+0*t)*System.Math.Sin(-2*d+0*m+0*m1+2*f+0*omega);
        deltaPsi+=(21+0*t)*System.Math.Sin(0*d+0*m+-1*m1+2*f+1*omega);
        deltaPsi+=(16+0*t)*System.Math.Sin(2*d+0*m+-1*m1+0*f+1*omega);
        deltaPsi+=(-15+0*t)*System.Math.Sin(0*d+1*m+0*m1+0*f+1*omega);
        deltaPsi+=(-13+0*t)*System.Math.Sin(-2*d+0*m+1*m1+0*f+1*omega);
        deltaPsi+=(-12+0*t)*System.Math.Sin(0*d+-1*m+0*m1+0*f+1*omega);
        deltaPsi+=(11+0*t)*System.Math.Sin(0*d+0*m+2*m1+-2*f+0*omega);
        deltaPsi+=(-10+0*t)*System.Math.Sin(2*d+0*m+-1*m1+2*f+1*omega);
        deltaPsi+=(-8+0*t)*System.Math.Sin(2*d+0*m+1*m1+2*f+2*omega);
        deltaPsi+=(7+0*t)*System.Math.Sin(0*d+1*m+0*m1+2*f+2*omega);
        deltaPsi+=(-7+0*t)*System.Math.Sin(-2*d+1*m+1*m1+0*f+0*omega);
        deltaPsi+=(-7+0*t)*System.Math.Sin(0*d+-1*m+0*m1+2*f+2*omega);
        deltaPsi+=(-7+0*t)*System.Math.Sin(2*d+0*m+0*m1+2*f+1*omega);
        deltaPsi+=(6+0*t)*System.Math.Sin(2*d+0*m+1*m1+0*f+0*omega);
        deltaPsi+=(6+0*t)*System.Math.Sin(-2*d+0*m+2*m1+2*f+2*omega);
        deltaPsi+=(6+0*t)*System.Math.Sin(-2*d+0*m+1*m1+2*f+1*omega);
        deltaPsi+=(-6+0*t)*System.Math.Sin(2*d+0*m+-2*m1+0*f+1*omega);
        deltaPsi+=(-6+0*t)*System.Math.Sin(2*d+0*m+0*m1+0*f+1*omega);
        deltaPsi+=(5+0*t)*System.Math.Sin(0*d+-1*m+1*m1+0*f+0*omega);
        deltaPsi+=(-5+0*t)*System.Math.Sin(-2*d+-1*m+0*m1+2*f+1*omega);
        deltaPsi+=(-5+0*t)*System.Math.Sin(-2*d+0*m+0*m1+0*f+1*omega);
        deltaPsi+=(-5+0*t)*System.Math.Sin(0*d+0*m+2*m1+2*f+1*omega);
        deltaPsi+=(4+0*t)*System.Math.Sin(-2*d+0*m+2*m1+0*f+1*omega);
        deltaPsi+=(4+0*t)*System.Math.Sin(-2*d+1*m+0*m1+2*f+1*omega);
        deltaPsi+=(4+0*t)*System.Math.Sin(0*d+0*m+1*m1+-2*f+0*omega);
        deltaPsi+=(-4+0*t)*System.Math.Sin(-1*d+0*m+1*m1+0*f+0*omega);
        deltaPsi+=(-4+0*t)*System.Math.Sin(-2*d+1*m+0*m1+0*f+0*omega);
        deltaPsi+=(-4+0*t)*System.Math.Sin(1*d+0*m+0*m1+0*f+0*omega);
        deltaPsi+=(3+0*t)*System.Math.Sin(0*d+0*m+1*m1+2*f+0*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(0*d+0*m+-2*m1+2*f+2*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(-1*d+-1*m+1*m1+0*f+0*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(0*d+1*m+1*m1+0*f+0*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(0*d+-1*m+1*m1+2*f+2*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(2*d+-1*m+-1*m1+2*f+2*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(0*d+0*m+3*m1+2*f+2*omega);
        deltaPsi+=(-3+0*t)*System.Math.Sin(2*d+-1*m+0*m1+2*f+2*omega);
        deltaPsi/=10000;
        double deltaPsi_d=deltaPsi/3600;

        double u=t/100;
        double epsilonZero=23+(double)26/60+21.448/3600+(-4680.93*u-1.55*u*u+1999.25*u*u*u-51.38*u*u*u*u-249.67*u*u*u*u*u-39.05*u*u*u*u*u*u+7.12*u*u*u*u*u*u*u+27.87*u*u*u*u*u*u*u*u+5.79*u*u*u*u*u*u*u*u*u+2.45*u*u*u*u*u*u*u*u*u*u)/3600;
        double deltaEpsilon=0;
        deltaEpsilon+=(92025+8.9*t)*System.Math.Cos(0*d+0*m+0*m1+0*f+1*omega);
deltaEpsilon+=(5736+-3.1*t)*System.Math.Cos(-2*d+0*m+0*m1+2*f+2*omega);
deltaEpsilon+=(977+-0.5*t)*System.Math.Cos(0*d+0*m+0*m1+2*f+2*omega);
deltaEpsilon+=(-895+0.5*t)*System.Math.Cos(0*d+0*m+0*m1+0*f+2*omega);
deltaEpsilon+=(54+-0.1*t)*System.Math.Cos(0*d+1*m+0*m1+0*f+0*omega);
deltaEpsilon+=(224+-0.6*t)*System.Math.Cos(-2*d+1*m+0*m1+2*f+2*omega);
deltaEpsilon+=(129+-0.1*t)*System.Math.Cos(0*d+0*m+1*m1+2*f+2*omega);
deltaEpsilon+=(-95+0.3*t)*System.Math.Cos(-2*d+-1*m+0*m1+2*f+2*omega);
deltaEpsilon+=(-7+0*t)*System.Math.Cos(0*d+0*m+1*m1+0*f+0*omega);
deltaEpsilon+=(200+0*t)*System.Math.Cos(0*d+0*m+0*m1+2*f+1*omega);
deltaEpsilon+=(-70+0*t)*System.Math.Cos(-2*d+0*m+0*m1+2*f+1*omega);
deltaEpsilon+=(-53+0*t)*System.Math.Cos(0*d+0*m+-1*m1+2*f+2*omega);
deltaEpsilon+=(-33+0*t)*System.Math.Cos(0*d+0*m+1*m1+0*f+1*omega);
deltaEpsilon+=(26+0*t)*System.Math.Cos(2*d+0*m+-1*m1+2*f+2*omega);
deltaEpsilon+=(32+0*t)*System.Math.Cos(0*d+0*m+-1*m1+0*f+1*omega);
deltaEpsilon+=(27+0*t)*System.Math.Cos(0*d+0*m+1*m1+2*f+1*omega);
deltaEpsilon+=(-24+0*t)*System.Math.Cos(0*d+0*m+-2*m1+2*f+1*omega);
deltaEpsilon+=(16+0*t)*System.Math.Cos(2*d+0*m+0*m1+2*f+2*omega);
deltaEpsilon+=(13+0*t)*System.Math.Cos(0*d+0*m+2*m1+2*f+2*omega);
deltaEpsilon+=(-12+0*t)*System.Math.Cos(-2*d+0*m+1*m1+2*f+2*omega);
deltaEpsilon+=(-10+0*t)*System.Math.Cos(0*d+0*m+-1*m1+2*f+1*omega);
deltaEpsilon+=(-8+0*t)*System.Math.Cos(2*d+0*m+-1*m1+0*f+1*omega);
deltaEpsilon+=(7+0*t)*System.Math.Cos(-2*d+-2*m+0*m1+2*f+2*omega);
deltaEpsilon+=(9+0*t)*System.Math.Cos(0*d+1*m+0*m1+0*f+1*omega);
deltaEpsilon+=(7+0*t)*System.Math.Cos(-2*d+0*m+1*m1+0*f+1*omega);
deltaEpsilon+=(6+0*t)*System.Math.Cos(0*d+-1*m+0*m1+0*f+1*omega);
deltaEpsilon+=(5+0*t)*System.Math.Cos(2*d+0*m+-1*m1+2*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(2*d+0*m+1*m1+2*f+2*omega);
deltaEpsilon+=(-3+0*t)*System.Math.Cos(0*d+1*m+0*m1+2*f+2*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(0*d+-1*m+0*m1+2*f+2*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(2*d+0*m+0*m1+2*f+1*omega);
deltaEpsilon+=(-3+0*t)*System.Math.Cos(-2*d+0*m+2*m1+2*f+2*omega);
deltaEpsilon+=(-3+0*t)*System.Math.Cos(-2*d+0*m+1*m1+2*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(2*d+0*m+-2*m1+0*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(2*d+0*m+0*m1+0*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(-2*d+-1*m+0*m1+2*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(-2*d+0*m+0*m1+0*f+1*omega);
deltaEpsilon+=(3+0*t)*System.Math.Cos(0*d+0*m+2*m1+2*f+1*omega);
deltaEpsilon/=10000;
double deltaEpsilon_d=deltaEpsilon/3600;
double epsilon=epsilonZero+deltaEpsilon_d;

        return new double[]{0,deltaPsi,deltaPsi_d,u,epsilonZero,deltaEpsilon,epsilon};

    }
}
