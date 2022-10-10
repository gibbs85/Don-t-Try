using System;
using System.Collections.Generic;
using System.Text;

public class StockV2
{
    private int code;               // 코드
    private string name;            // 이름
    private string description;     // 종목 설명
    private double price;            // 가격
    private LinkedList<double> recordPrice; // 가격 기록
    private LinkedList<double> recordWeight;    // 가중치 기록
    private double gaussMean;    // gaussian dist. 의 평균
    private double gaussStd;     // gaussian dist. 의 표준편차

    /*
    public Stock(int code, string name, double initPrice);      // 완료

    private gaussianNum();                                      // 완료
    private gaussianNum(double mean, double std);               // 완료
    public double updateGaussian();                             // 완료
    public double updateForced();                               // 완료


    public int getCode();                                       // 완료
    public int getPrice();                                      // 완료
    public string getName();                                    // 완료
    public string getDesc();                                    // 완료
    public LinkedList<double> getRecordPrice();                 // 완료
    public LinkedList<double> getRecordWeight();                // 완료
    public void setName(string name);                           // 완료
    public void setDesc(string description);                    // 완료
    public void setMean(double newMean);                        // 완료
    public void setStd(double newStd);                          // 완료
     */

    public StockV2(int code, string name, double initPrice)
    {
        this.price = initPrice;
        this.recordPrice = new LinkedList<double>();
        this.recordPrice.AddLast(initPrice);
        this.recordWeight = new LinkedList<double>();
        this.recordWeight.AddLast(1.0);

        this.gaussMean = 1.0;
        this.gaussStd = 0.005;

        this.name = name;
        this.description = "NO_DESCRIPTION";
    }

    public double updateGaussian()
    {
        /* 
         * Gaussian 랜덤 변수 가중치를 생성하여 다음 가격 업데이트
         * 
         */
        double newWeight = this.gaussianNum();

        this.price = this.price * newWeight;

        //아래는 recordPrice, recordWeight 업데이트.
        this.recordPrice.AddLast(this.price);
        this.recordWeight.AddLast(newWeight);

        return this.price;
    }

    public double updateForced(double weight)
    {
        /*
         * 인수로 받은 weight로 다음 가격 업데이트.
         * 
         */

        this.price = this.price * weight;

        this.recordPrice.AddLast(this.price);
        this.recordWeight.AddLast(weight);

        return this.price;
    }

    private double gaussianNum()
    {
        /*/////////////////////////////////////////////////////////////////////////
        * 해당 객체의 gaussianMean과 gaussianStd를 가지는 gaussian dist. 를 확률밀도함수로 하는 랜덤 수를 리턴
        * 
        * 
        */////////////////////////////////////////////////////////////////////////
        Random rand = new Random();
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        /*
         * 잘못된 mean, std 설정 등으로 인해 weight가 음수가 나오는 경우를 막기 위한 dirty solution
         */
        double result = this.gaussStd * (randStdNormal) + this.gaussMean;
        if (result < 0)
            result = 0;

        return result;


        //return this.gaussStd * (randStdNormal) + this.gaussMean;
    }

    private double gaussianNum(double mean, double std)
    {
        Random rand = new Random();
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        double result = std * (randStdNormal) + mean;
        if (result < 0)
            result = 0;

        return result;
    }

    public int getCode()
    {
        return this.code;
    }

    public double getPrice()
    {
        return this.price;
    }

    public string getName()
    {
        return this.name;
    }

    public string getDesc()
    {
        return this.description;
    }

    public LinkedList<double> getRecordPrice()
    {
        return this.recordPrice;
    }

    public LinkedList<double> getRecordWeight()
    {
        return this.recordWeight;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void setDesc(string description)
    {
        this.description = description;
    }

    public void setMean(double newMean)
    {
        this.gaussMean = newMean;
    }

    public void setStd(double newStd)
    {
        this.gaussStd = newStd;
    }




}
