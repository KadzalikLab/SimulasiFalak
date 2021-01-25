

public class hisabEp {

 public static double [] Meeus (double JD) {





        double JD_UT=JD;

        double delta_T=0;
        //JDE waktu TD(Dynamical time)
        double jde=JD_UT+delta_T;

        double T_TD=(jde-2451545)/36525;
        double tau=T_TD/10;






        double deltaPsi= Nutasi.deltaPsiDanEpsilon(T_TD)[2];

        double epsilon= Nutasi.deltaPsiDanEpsilon(T_TD)[6];
        double epsilon_r=Konversi.toRadians(epsilon);


        //Bulan
        //l1= bujur rata-rata bulan
        double L1=(218.3164591+481267.88134236*T_TD-0.0013268*T_TD*T_TD+T_TD*T_TD*T_TD/538841-T_TD*T_TD*T_TD*T_TD/65194000)%360;

        //elongasi rata2 bulan
        double d= tabelBulan.sukuPeriodik(T_TD,L1)[1];

        //Anomali rata2 Matahari
         double m= tabelBulan.sukuPeriodik(T_TD,L1)[2];

        //Anomali rata2 bulan
        double ma= tabelBulan.sukuPeriodik(T_TD,L1)[3];

        //Argumen bujur bulan
        double f= tabelBulan.sukuPeriodik(T_TD,L1)[4];

        //Eksentrisitas orbit
        double e=tabelBulan.sukuPeriodik(T_TD,L1)[5];

        //Koreksi bujur bulan
        double koreksibujurB= tabelBulan.sukuPeriodik(T_TD,L1)[6];
        double bujurB=(L1+koreksibujurB)%360;
        double bujurB_nampak=(bujurB+deltaPsi)%360;
        if (bujurB_nampak<0)bujurB_nampak+=360;
        double bujurB_nampak_r=Konversi.toRadians(bujurB_nampak);

        //Koreksi lintang bulan
        double lintangB= tabelBulan.sukuPeriodik(T_TD,L1)[7];
        double lintangB_r=Konversi.toRadians(lintangB);

        //Koreksi jarak bumi-bulan
        double jarakBB=385000.56+tabelBulan.sukuPeriodik(T_TD,L1)[8];

        double sudutParalaksB=Konversi.toDegrees(System.Math.Asin(6378.14/jarakBB));
        double sudutJariB=358473400/(jarakBB*3600);

        double alphaBulan=(Konversi.toDegrees(System.Math.Atan2(System.Math.Sin(bujurB_nampak_r)*System.Math.Cos(epsilon_r)-System.Math.Tan(lintangB_r)*System.Math.Sin(epsilon_r),System.Math.Cos(bujurB_nampak_r))))%360;
        if (alphaBulan<0)alphaBulan=(alphaBulan+360)%360;
        double alphaBulanPukul=alphaBulan/15;

        double deltaBulan=Konversi.toDegrees(System.Math.Asin(System.Math.Sin(lintangB_r)*System.Math.Cos(epsilon_r)+System.Math.Cos(lintangB_r)*System.Math.Sin(epsilon_r)*System.Math.Sin(bujurB_nampak_r)));
        double deltaBulan_r=Konversi.toRadians(deltaBulan);



        //Matahari
        double L   = tabelMatahari.bujurEkliptik(tau,koreksibujurB)[1];
        double theta = tabelMatahari.bujurEkliptik(tau,koreksibujurB)[2];

        double lambdaM = tabelMatahari.bujurEkliptik(tau,koreksibujurB)[3];
        double lambdaM_r =Konversi.toRadians(lambdaM);
        double Delta_theta = tabelMatahari.bujurEkliptik(tau,koreksibujurB)[4];
        double theta_terkoreksi = tabelMatahari.bujurEkliptik(tau,koreksibujurB)[5];
        double jarakBumi_Matahari = tabelMatahari.jarakBumiMat(tau);
        double jarakBm_M=149598000*jarakBumi_Matahari;
        double lintangM = tabelMatahari.lintangEkliptikB(tau,lambdaM_r)[2];
        double beta_M_r =Konversi.toRadians(lintangM/3600);
        double koreksiAberasi=-20.4898/(3600*jarakBumi_Matahari);

        double bujurM_nampak=(theta_terkoreksi+deltaPsi+koreksiAberasi)%360;
        if (bujurM_nampak<0)bujurM_nampak+=360;
        double bujurM_nampak_r=Konversi.toRadians(bujurM_nampak);
        double sudutJariM=(959.63/3600)/jarakBumi_Matahari;

        double alphaMatahari=(Konversi.toDegrees(System.Math.Atan2(System.Math.Sin(bujurM_nampak_r)*System.Math.Cos(epsilon_r)-System.Math.Tan(beta_M_r)*System.Math.Sin(epsilon_r),System.Math.Cos(bujurM_nampak_r))))%360;
        if (alphaMatahari<0)alphaMatahari=(alphaMatahari+360)%360;
        double alphaM_pukul=alphaMatahari/15;
        double deltaMatahari=Konversi.toDegrees(System.Math.Asin(System.Math.Sin(beta_M_r)*System.Math.Cos(epsilon_r)+System.Math.Cos(beta_M_r)*System.Math.Sin(epsilon_r)*System.Math.Sin(bujurM_nampak_r)));
        double deltaM_r=Konversi.toRadians(deltaMatahari);


        double U=(JD-2451545)/36525;
        //bujur rata2 matahari
        double L0 =Konversi.toRadians((280.46607+36000.7698*U)%360);
        double EoT=(-1*(1789+237*U)*System.Math.Sin(L0)-(7146-62*U)*System.Math.Cos(L0)+(9934-14*U)*System.Math.Sin(2*L0)-(29+5*U)*System.Math.Cos(2*L0)+(74+10*U)*System.Math.Sin(3*L0)+(320-4*U)*System.Math.Cos(3*L0)-212*System.Math.Sin(4*L0))/1000;

        EoT/=60; //jadikan menit

        double sudutFai=System.Math.Acos(System.Math.Sin(deltaBulan_r)*System.Math.Sin(deltaM_r)+System.Math.Cos(deltaBulan_r)*System.Math.Cos(deltaM_r)*System.Math.Cos(Konversi.toRadians(alphaBulan-alphaMatahari)));
        double sudutFase=System.Math.Atan2(jarakBm_M*System.Math.Sin(sudutFai),jarakBB-jarakBm_M*System.Math.Cos(sudutFai));
        double sudutFase_d=Konversi.toDegrees(sudutFase);


        double iluminasiB=(1+System.Math.Cos(sudutFase))/2;


        //menampilkan hasil
        //formatter jarak antara teks yang di print biar layoutnya rapi
//        String formatter ="%-8s%-15s%-15s%-15s%-15s%-15s%-15s%5s%n";
//        System.out.println("\n"+"Data Matahari");
//        System.out.printf(formatter,"Jam","Ecliptic","Ecliptic","Right","Apparent","Semi","Kemiringan","Equation");
//        System.out.printf(formatter,"Gmt","Longitude","Latitude","Ascension","Declination","Diameter","(Epsilon)","of time");
//        System.out.printf(formatter,(int)jam,desimal_ke_derajat(theta_terkoreksi)[1]+"\u00B0"+desimal_ke_derajat(theta_terkoreksi)[2]+"\u2032"+desimal_ke_derajat(theta_terkoreksi)[3]+"\u2033",(float)lintangM,desimal_ke_derajat(alphaMatahari)[1]+":"+desimal_ke_derajat(alphaMatahari)[2]+":"+desimal_ke_derajat(alphaMatahari)[3],desimal_ke_derajat(deltaMatahari)[1]+"\u00B0"+desimal_ke_derajat(deltaMatahari)[2]+"\u2032"+desimal_ke_derajat(deltaMatahari)[3]+"\u2033",desimal_ke_derajat(sudutJariM)[1]+"\u00B0"+desimal_ke_derajat(sudutJariM)[2]+"\u2032"+desimal_ke_derajat(sudutJariM)[3]+"\u2033",desimal_ke_derajat(epsilon)[1]+"\u00B0"+desimal_ke_derajat(epsilon)[2]+"\u2032"+desimal_ke_derajat(epsilon)[3]+"\u2033",desimal_ke_derajat(EoT)[1]+"\u00B0"+desimal_ke_derajat(EoT)[2]+"\u2032"+desimal_ke_derajat(EoT)[3]+"\u2033");

//
//        System.out.println("\n\n"+"Data Bulan");
//        System.out.printf(formatter,"Jam","Apparent","Apparent","Right","Apparent","Semi","Horizontal","Iluminasi");
//        System.out.printf(formatter,"Gmt","Longitude","Latitude","Ascension","Declination","Diameter","Parallax","Bulan");
//        System.out.printf(formatter,(int)jam,desimal_ke_derajat(bujurB_nampak)[1]+"\u00B0"+desimal_ke_derajat(bujurB_nampak)[2]+"\u2032"+desimal_ke_derajat(bujurB_nampak)[3]+"\u2033",desimal_ke_derajat(lintangB)[1]+"\u00B0"+desimal_ke_derajat(lintangB)[2]+"\u2032"+desimal_ke_derajat(lintangB)[3]+"\u2033",desimal_ke_derajat(alphaBulan)[1]+":"+desimal_ke_derajat(alphaBulan)[2]+":"+desimal_ke_derajat(alphaBulan)[3],desimal_ke_derajat(deltaBulan)[1]+"\u00B0"+desimal_ke_derajat(deltaBulan)[2]+"\u2032"+desimal_ke_derajat(deltaBulan)[3]+"\u2033",desimal_ke_derajat(sudutJariB)[1]+"\u00B0"+desimal_ke_derajat(sudutJariB)[2]+"\u2032"+desimal_ke_derajat(sudutJariB)[3]+"\u2033",desimal_ke_derajat(sudutParalaksB)[1]+"\u00B0"+desimal_ke_derajat(sudutParalaksB)[2]+"\u2032"+desimal_ke_derajat(sudutParalaksB)[3]+"\u2033",String.format("%.7f", iluminasiB));


	// indeks
	// 01 ekliptik long M
	// 02 ekliptik lat M
	// 03 Arekta M 
	// 04 Deklinasi M
	// 05 sudut jariM
	// 06 kemiringanM
	// 07 Eot
	// 08 jarak mat-bumi

	// 09 ekliptik long B
	// 10 eklitik lat bulan 
	// 11 A rekta B
	// 12 delinasi B
	// 13 sudutjari B
	// 14 sudut paralaks
	// 15 iluminasi B
	// 16 sudut fase
	// 17 jarak bumi-bulan
    return  new double[]{0,theta_terkoreksi,lintangM,alphaMatahari,deltaMatahari,sudutJariM,epsilon,EoT,jarakBm_M,bujurB_nampak,lintangB,alphaBulan,deltaBulan,sudutJariB,sudutParalaksB,iluminasiB,sudutFase,jarakBB};



    }


    public  static int []desimal_ke_derajat(double desimal){
        //cek nilai negatif atau bMatahariBulanMeeusukan
        bool negatif=false;
        if (desimal<0)negatif=true;

        //ini menghitungnya mengabaikan nilai negatif
        desimal=System.Math.Abs(desimal);
        int jah=(int)desimal;
        double qoh=System.Math.Abs((desimal%1)*60);
        double ni=System.Math.Round((qoh%1)*60);
        //ini pembulatan
        if ((int)ni>59){ni-=60; qoh+=1;}
        if ((int)qoh>59){qoh-=60; jah+=1;}

        //bila negatif
        if (negatif) {
            if (jah==0)
            { if ((int)qoh==0)return new int[]{0, -jah,-(int)qoh,(int)-ni};else return new int[]{0, -jah,-(int)qoh,(int)ni};}

            else return new int[]{0, -jah,(int)qoh,(int)ni}; }

        //bila positif
        else return new int[]{0,jah,(int)qoh,(int)ni};
    }



}
