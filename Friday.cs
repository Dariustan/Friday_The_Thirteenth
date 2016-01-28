using System;
using System.IO;
namespace Friday
{
//计算所给年份所给月份的天数
  static class Month
  {
    private static int[] monthday={31,28,31,30,31,30,31,31,30,31,30,31};
    public static int Monthday(int year,int month)
    {
      //当月份为2月，且年份可以被4整除时，有可能为闰年，
      if (month==2&&year%4==0) {
        //此时判断是否能被100和400整除
        //可以被100整除但不能被400整除，则不是闰年，2月只有28天
        if (year%100==0&&year%400!=0) {
          return monthday[month-1];
        }
        //否则就是不能被100整除，或者能够被400整除，
        //这种情况就是闰年，2月份有28+1=29天
        else {
          return monthday[month-1]+1;
        }
      }
      //月份不为2月时不必判断
      else {
        return monthday[month-1];
      }
    }
  }
  class Friday
  {
    /// <summary>
    ///   计算从1900年起，在给定数量的年份中，每个月13号对应的星期数的分布情况
    ///   USACO第三题
    ///   http://train.usaco.org/usacoprob2?a=g09fqR3FIcS&S=friday
    /// </summary>
    [STAThread]
    public static void Main(string[] args)
    {
      //week[]用来统计周六到周五出现的次数，第一个数据从周六算起
      int[] week=new int[7];
      int input,year,month,weekday;
      //1900年1月13日是周六，所以weekday初始值为0
      weekday=0;
      StreamReader file=new StreamReader(@"input.txt");
      input =int.Parse(file.ReadLine());
      file.Close();
      for (year=1900; year-1900<input; year++) {
        for (month=1; month<13; month++) {
          //将本一月份的13号对应的星期数作登记，然后计算这下一个月的星期数
          //循环的最后一个月是12月，此时计算的是下一年的一月13号对应的星期数
          week[weekday]++;
          weekday=(weekday+Month.Monthday(year,month))%7;
        }
      }
      StreamWriter Out=File.CreateText(@"out.txt");
      int i;
      for (i=0; i<7; i++) {
        Out.Write("{0} ",week[i]);
      }
      Out.Close();
    }
  }
}
