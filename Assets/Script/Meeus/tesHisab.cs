using System;
    class tesHisab
    {
        static void Main(string[] args)
        {
            Double tanggal,bulan,tahun,jam,menit,detik;
            //jam=DateTime.Now.ToString("HH:mm:ss tt");

            tanggal=Convert.ToDouble(DateTime.Now.ToString("dd"));
            bulan=Convert.ToDouble(DateTime.Now.ToString("MM"));
            tahun=Convert.ToDouble(DateTime.Now.ToString("yyyy"));

            jam=Convert.ToDouble(DateTime.Now.ToString("HH"));
            menit=Convert.ToDouble(DateTime.Now.ToString("mm"));
            detik=Convert.ToDouble(DateTime.Now.ToString("ss"));
            
            double jd=Konversi.TanggalKeJulianDay(tahun,bulan,tanggal,jam,menit,detik)+1;
            
            Console.WriteLine(tanggal+" - "+ bulan+" - "+ tahun+", "+ jam+ " : "+menit +" : "+ detik);
            Console.WriteLine(jd);
              double bujur_m,lintang_m,asr_m,dekl_m,epsilon,EoT,jarakBm_M,bujur_b,lintang_b,asr_b,dekl_b,iluminasiB,sudutFase,jarakBB;

            bujur_m=hisabEp.Meeus(jd)[1];
lintang_m=hisabEp.Meeus(jd)[2];
asr_m=hisabEp.Meeus(jd)[3];
dekl_m=hisabEp.Meeus(jd)[4];
epsilon=hisabEp.Meeus(jd)[6];
EoT=hisabEp.Meeus(jd)[7];
jarakBm_M=hisabEp.Meeus(jd)[8];

bujur_b=hisabEp.Meeus(jd)[9];
lintang_b=hisabEp.Meeus(jd)[10];
asr_b=hisabEp.Meeus(jd)[11];
dekl_b=hisabEp.Meeus(jd)[12];
iluminasiB=hisabEp.Meeus(jd)[15];
sudutFase=hisabEp.Meeus(jd)[16];
jarakBB=hisabEp.Meeus(jd)[17];

 Console.WriteLine(jarakBm_M/100000000);
  Console.WriteLine(jarakBB/1000000);


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




        }
    }
