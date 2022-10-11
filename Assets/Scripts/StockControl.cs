using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//enum SettingsStock
//{
//    COUNT_UPDATE_PER_HOUR = 60,
//    COUNT_HOUR_PER_DAY = 24,
//    COUNT_UPDATE_DAYS_PREPLAY = 30,
//    TIME_START_OF_DAY = 9,
//    TIME_END_OF_DAY = 15
//}



public struct StockBought
{
    public int playerCode;
    public int stockCode;
    public double price;
}

public class StockControl
{
    private List<Stock> stocks;
    private List<StockBought> stocksOwned;

    /*
    
    public StockControl();
    public void new_game();
    public void system_save();
    public void system_load();

    public void buyStock(Player player, int stockCode, int count);
    public void sellStock(Player player, int stockCode, int count);

    public double getMoneyBought(int playerCode);
    public double getMoneyBought(int playerCode, int stockCode);
    public double getMoneySellAll(int playerCode);
    public double getMoneySellAll(int playerCode, int stockCode);
    public double getMoneyAvg(int playerCode, int stockCode); //��ܰ�
    public int getCountOwn(int playerCode, int stockCode);
    public void updateAllStocks(int timeInterval);
    public int getPrice(int stockCode);
    public Stock getStock(int stockCode);
    public Stock getStock(string stockName);
    public LinkedList<double> getRecordDay(int stockCode, int time);
    public double getRateDay(int stockCode, int time);
    public int getCountStocks();
    public Stock getStockAt(int index);
    public List<StockBought> getListStocksOwn(int playerCode);

     */

    public StockControl()
    {
        this.stocks = new List<Stock>();
        this.stocksOwned = new List<StockBought>();
    }

    public void new_game()
    {
        Stock stockSamsung = new Stock(100, "�缺����", 68000);
        Stock stockKakao = new Stock(101, "����", 83000);
        Stock stockHyundai = new Stock(102, "�����ڵ���", 186500);
        Stock stockSk = new Stock(103, "�ֽ����ڷ���", 58200);
        Stock stockLg = new Stock(104, "����ȭ��", 545000);
        Stock stockApple = new Stock(105, "����", 175254);
        Stock stockNaver = new Stock(106, "�׹�", 275000);
        Stock stockGoogle = new Stock(107, "����", 2774420);
        Stock stockMeta = new Stock(108, "MEKA", 50000);

        this.stocks.Add(stockSamsung);
        this.stocks.Add(stockKakao);
        this.stocks.Add(stockHyundai);
        this.stocks.Add(stockSk);
        this.stocks.Add(stockLg);
        this.stocks.Add(stockApple);
        this.stocks.Add(stockNaver);
        this.stocks.Add(stockGoogle);
        this.stocks.Add(stockMeta);

        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * set Stocks Descriptions.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stockSamsung.setDesc("�������� �ϳ����� ����ִ� ����� ���䰰�� �ֽ�. �츮���� ��ǥ��� �ֽ��Ѿ� 1��. �ֱ� �������� �������� ���� ȣȲ�ΰͰ���");
        stockKakao.setDesc("�����̸� ���� �����̸� ����. �÷��� ������� �������� ���. ������ ������ �˸� �׸��� �帧�� �� �� �ִٴ� ���� �ִ�");
        stockHyundai.setDesc("�ε��� �ڵ��� ��� 1��. ���� ���� ������ ���� ���ڰ� �� ������. �ؿܿ����� �������鿡�� ������ ������");
        stockSk.setDesc("��Ż� ���������� 1��. �ֱٿ��� KT�� ���� ���� ������ ����� ���̰� �ִ�. �����ϰ� ���� ����");
        stockLg.setDesc("�ֱ� ���� �迭���� �������ַ���� �����������鼭 ���� �ս��� �ô�. ������ �츮���� ������ �缺 �������� ����� ��ŭ ���ġ�� ����. ���� ���� ���� �ֱ� �ְ��� ���� ��������");
        stockApple.setDesc("���� 1�� ����Ʈ�� ���. �ؿ��ֽ� 1�� �����̾����� ���� �ֽĵ��� �������鼭 ���� ������ ���� �������ִ�. ������ ������ ������ �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");
        stockNaver.setDesc("�������� �ε��� �÷��� 1�� ����̾����� ���� �ӵ��� ��������� ������ �������� �зȴ�. ������� ���� ��Ÿ���� ���������� �ֱ� �̸��� ������");
        stockGoogle.setDesc("���� �ִ� �˻� �÷���. ���躸�ٴ� �̹����� �����ϴ� ���. ������ ������ ������ �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");
        stockMeta.setDesc("��Ÿ���� ����� �پ����Ͽ� �ְ��� ��� �ö���. ������ �ֱ� ������ ���� �����ϴ�. ���翡 ���ļ� �ؿ� �ֽĽ����� ��ü������ ħü���ε��ϴ�");

        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * set Stocks attributes.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        stockSamsung.setMean(1.00001); stockSamsung.setStd(0.0015);
        stockKakao.setMean(1.000005); stockKakao.setStd(0.003);
        stockHyundai.setMean(1.00001); stockHyundai.setStd(0.0012);
        stockSk.setMean(1.00001); stockSk.setStd(0.001);
        stockLg.setMean(1.000003); stockLg.setStd(0.0025);
        stockApple.setMean(1.00002); stockApple.setStd(0.0017);
        stockNaver.setMean(1.00001); stockNaver.setStd(0.0029);
        stockGoogle.setMean(1.00001); stockGoogle.setStd(0.0010);
        stockMeta.setMean(1.00001); stockMeta.setStd(0.0022);

        /*//////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         * generate stock price history. before start playing.
         *
         *//////////////////////////////////////////////////////////////////////////////////////////////////////

        foreach(Stock stock in this.stocks)
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * (int)SettingsStock.COUNT_HOUR_PER_DAY * (int)SettingsStock.COUNT_UPDATE_DAYS_PREPLAY; j++)
            {
                stock.updateGaussian();
            }
        }
    }

    public void buyStock(Player player, int stockCode, int count)
    {
        StockBought bought;
        bought.playerCode = player.getCode();
        bought.stockCode = stockCode;
        bought.price = this.getStock(stockCode).getPrice();

        for (int i=0; i<count; i++)
        {
            this.stocksOwned.Add(bought);
            player.spendMoney(bought.price);
        }
    }

    public void sellStock(Player player, int stockCode, int count)
    {
        double price = this.getPrice(stockCode) * count;
        player.spendMoney(-price);

        int playerCode = player.getCode();
        int iter = 0;
        foreach(StockBought stockbought in (this.stocksOwned.FindAll(stockbought => (stockbought.playerCode == playerCode) && (stockbought.stockCode == stockCode))))
        {
            if (iter == count)
                break;

            this.stocksOwned.Remove(stockbought);
            Debug.Log("DELETED.");

            iter++;
        }



    }

    public double getPrice(int stockCode)
    {
        return this.getStock(stockCode).getPrice();
    }

    public int getCountOwn(int playerCode, int stockCode)
    {
        return this.stocksOwned.Where(stockbought => (stockbought.stockCode == stockCode) && (stockbought.playerCode == playerCode) ).Count();
    }

    public Stock getStock(int stockCode)
    {
        return this.stocks.Find(stock => stock.getCode() == stockCode);
    }

    public Stock getStock(string stockName)
    {
        return this.stocks.Find(stock => stock.getName() == stockName);
    }


    public double getMoneyBought(int playerCode)
    {
        double money = 0;

        foreach(StockBought stockbought in (this.stocksOwned.FindAll(stockbought => stockbought.playerCode == playerCode)))
        {
            money += stockbought.price;
        }

        return money;
    }


    public double getMoneyBought(int playerCode, int stockCode)
    {
        double money = 0;

        foreach (StockBought stockbought in (this.stocksOwned.FindAll(stockbought => (stockbought.playerCode == playerCode) && (stockbought.stockCode == stockCode))))
        {
            money += stockbought.price;
        }

        return money;
    }

    public void updateAllStocks(int timeInterval)
    {
        foreach (Stock stock in this.stocks)
        {
            for (int j = 0; j < (int)SettingsStock.COUNT_UPDATE_PER_HOUR * timeInterval; j++)
            {
                stock.updateGaussian();
            }
        }
    }

    public double getMoneySellAll(int playerCode)
    {
        double money = 0;

        foreach (StockBought stockbought in (this.stocksOwned.FindAll(stockbought => stockbought.playerCode == playerCode)))
        {
            double price = this.getStock(stockbought.stockCode).getPrice();
            money += price;
        }

        return money;
    }

    public double getMoneySellAll(int playerCode, int stockCode)
    {
        int count = this.getCountOwn(playerCode, stockCode);
        double price = this.getStock(stockCode).getPrice();

        return count * price;
    }

    public double getMoneyAvg(int playerCode, int stockCode) //��ܰ�
    {
        return (this.getMoneySellAll(playerCode, stockCode)) / (this.getCountOwn(playerCode, stockCode));
    }

    //public LinkedList<double> getRecordDay(int stockCode, int time)
    public double[] getRecordDay(int stockCode, int time)
    {
        //Debug.Log("StockControl.cs.244 : getRecordDay : " + "Initiated");

        Stock stock = this.getStock(stockCode);
        double[] result;

        int lengthRecord = this.getStock(stockCode).getLengthRecord();
        int lengthRecordtoCut = (time - (int)SettingsStock.TIME_START_OF_DAY) * (int)SettingsStock.COUNT_UPDATE_PER_HOUR;
        if (lengthRecordtoCut > lengthRecord)
        {
            lengthRecordtoCut = lengthRecord;
        }

        result = new double[lengthRecordtoCut];
        for (int i = 0; i < lengthRecordtoCut; i++)
        {
            //result[^(i + 1)] = stock.getRecordPrice().ElementAt(lengthRecordtoCut-1-i);
            result[^(i + 1)] = stock.getRecordPrice().ElementAt(stock.getLengthRecord() - 1 - i);
        }

        //Debug.Log("StockControl.cs.262 : getRecordDay.stockCode : " + stockCode);
        //Debug.Log("StockControl.cs.263 : getRecordDay.stockCode_found : " + stock.getCode());
        //Debug.Log("StockControl.cs.262 : getRecordDay.lengthRecordToCut : " + lengthRecordtoCut);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[0] : " + result[0]);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[1] : " + result[1]);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[2] : " + result[2]);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[^1] : " + result[^3]);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[^1] : " + result[^2]);
        //Debug.Log("StockControl.cs.262 : getRecordDay.result.[^1] : " + result[^1]);
        //2022-10-12-02:01. ������ �Ϸ� ġ �����Ͱ� �ƴ� ���� �Ϸ�ġ �����͸� �θ��� ����. => �ذ�.


        return result;

    }
    
    public double getRateDay(int stockCode, int time)
    {
        double priceStart;
        double priceNow;
        double rate;

        double[] record = this.getRecordDay(stockCode, time);
        priceStart = record[0];
        priceNow = record[^1];
        rate = ((priceNow - priceStart) / priceStart) * 100;

        return rate;
    }


    public int getCountStocks()
    {
        return this.stocks.Count;
    }


    public Stock getStockAt(int index)
    {
        return this.stocks.ElementAt(index);
    }

    public List<StockBought> getListStocksOwn(int playerCode)
    {
        List<StockBought> listOwned = new List<StockBought>();
        listOwned = this.stocksOwned.FindAll(stockbought => stockbought.playerCode == playerCode);
        return listOwned;
    }

    public List<StockBought> getListStocksOwnMerged(int playerCode)
    {
        List<StockBought> listOwned = this.getListStocksOwn(playerCode);

        //listOwned = listOwned.DistinctBy(stockbought => stockbought.stockCode);

        List<StockBought> listMerged =
            listOwned
            .GroupBy(stock => stock.stockCode)
            .Select(kind => kind.First())
            .ToList();

        return listMerged;
    }



}
