using System;
using System.Collections.Generic;
using System.Text;

public class StockV2
{
    private int code;               // �ڵ�
    private string name;            // �̸�
    private string description;     // ���� ����
    private double price;            // ����
    private LinkedList<double> recordPrice; // ���� ���
    private LinkedList<double> recordWeight;    // ����ġ ���
    private double gaussMean;    // gaussian dist. �� ���
    private double gaussStd;     // gaussian dist. �� ǥ������

    /*
    public Stock(int code, string name, double initPrice);      // �Ϸ�

    private gaussianNum();                                      // �Ϸ�
    private gaussianNum(double mean, double std);               // �Ϸ�
    public double updateGaussian();                             // �Ϸ�
    public double updateForced();                               // �Ϸ�


    public int getCode();                                       // �Ϸ�
    public int getPrice();                                      // �Ϸ�
    public string getName();                                    // �Ϸ�
    public string getDesc();                                    // �Ϸ�
    public LinkedList<double> getRecordPrice();                 // �Ϸ�
    public LinkedList<double> getRecordWeight();                // �Ϸ�
    public void setName(string name);                           // �Ϸ�
    public void setDesc(string description);                    // �Ϸ�
    public void setMean(double newMean);                        // �Ϸ�
    public void setStd(double newStd);                          // �Ϸ�
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
         * Gaussian ���� ���� ����ġ�� �����Ͽ� ���� ���� ������Ʈ
         * 
         */
        double newWeight = this.gaussianNum();

        this.price = this.price * newWeight;

        //�Ʒ��� recordPrice, recordWeight ������Ʈ.
        this.recordPrice.AddLast(this.price);
        this.recordWeight.AddLast(newWeight);

        return this.price;
    }

    public double updateForced(double weight)
    {
        /*
         * �μ��� ���� weight�� ���� ���� ������Ʈ.
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
        * �ش� ��ü�� gaussianMean�� gaussianStd�� ������ gaussian dist. �� Ȯ���е��Լ��� �ϴ� ���� ���� ����
        * 
        * 
        */////////////////////////////////////////////////////////////////////////
        Random rand = new Random();
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

        /*
         * �߸��� mean, std ���� ������ ���� weight�� ������ ������ ��츦 ���� ���� dirty solution
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
