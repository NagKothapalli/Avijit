using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    public class DeleteServiceLine
    {
        //public void ImportClaim_ClaimEditorButtonValidation()
        //{
        //    string claimFileName = "TestClaimViewer2.txt";
        //    int quantity = 2;//Enter the number of lines to be added 
        //    List<ReportClaimImportDetail> impDetailList = import.ClaimImportAndVerification(claimFileName);
        //    app.HomeInstance.NavigateToPageOption(GetValue(TabName.Process_Claims), GetValue(MenuName.Manage_Claims));
        //    IndividualSearchFiltersInputData data = new IndividualSearchFiltersInputData();
        //    data.ClaimId = impDetailList[0].ClaimId.ToString();
        //    app.manageClaimInstance.SetIndividualSearchFiltersAndSearch(data);
        //    Assert.IsTrue(app.manageClaimInstance.ValidateIndividualSearchResults(data), "Data in Search grid did not match after Import");
        //    Assert.IsTrue(app.manageClaimInstance.OpenFirstClaimInGrid(), "Open first claim in grid failed");//open the first claim and switch to claim viewer
        //    app.ClaimEditorInstance.AddServiceLinesAndSave(quantity);//Add 2 service lines and save
        //    app.ClaimEditorInstance.CloseClaimViewer();//Exit the claim viewer after saving
        //    app.manageClaimInstance.OpenFirstClaimInGrid();//Reopen the same claim
        //    Assert.IsTrue(app.ClaimEditorInstance.ConfirmServiceLinesAdded(quantity), "Service line assertion failed");//compare the number of service lines before & after
        //    Assert.IsFalse(app.ClaimEditorInstance.ValidateChargesAmount(), "Charges amount assertion failed");//compare the charges amount before & after
        //    app.ClaimEditorInstance.VerifyDataInNewServiceLines(quantity);
        //}
        //public int LinesBefore;
        //public double AmountBefore;
        //public static IList<ServiceLineData> dataLines = new List<ServiceLineData>();//collection- list of service line data
        //public static IList<ServiceLineData> dataLinesAfter = new List<ServiceLineData>();
        //public void AddServiceLinesAndSave(int quantity)
        //{
        //    CommonUtils.log.LogInfo("Adding the service line");
        //    instClaimEditorPage.BtnSave.IsDisplayed();
        //    LinesBefore = ReadServiceLinesCount();//read the number of service lines before adding new lines
        //    AmountBefore = ReadChargesAmount();//Read the total charges before adding lines
        //    Console.WriteLine("LinesBefore" + LinesBefore);
        //    instClaimEditorPage.BtnAdd.Click();//click add button
        //    AddQuantity(quantity.ToString());//add quantity to dialogue box
        //    AddServiceLineItems(quantity);//Add data in to the new line items
        //    Thread.Sleep(5000);
        //    SaveClaim();
        //    //claimEditorbrowser.driver.FindElement(By.XPath("//span[contains(@id,'cph_header_claimViewerHeader_Label' )  and (contains(text(),'Save'))]")).Click();
        //    Thread.Sleep(20000);
        //}
        //public Boolean ConfirmServiceLinesAdded(int quantity)
        //{
        //    CommonUtils.log.LogInfo("Adding the service line");
        //    instClaimEditorPage.BtnSave.IsDisplayed();
        //    int LinesAfter = ReadServiceLinesCount();
        //    if ((quantity + LinesBefore) == LinesAfter)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public void AddServiceLineItems(int Count)//hardcode in test
        //{
        //    //int rows = instClaimEditorPage.ServiceLinesTable.GetRowCount();- Existing code did not work
        //    for (int i = 0; i < Count; i++)
        //    {
        //        string HCPCS = (new Random().Next(0000, 1111) + 11111).ToString().Substring(0, 5);
        //        Console.WriteLine("HCPCS value =" + HCPCS);
        //        dataLines.Add(new ServiceLineData((250 + i).ToString(), HCPCS, "PO", "PO", "PO", "PO", "06/27/2020", "2", "100"));//taking in to collection
        //        //FindElements(By.XPath("//table[@id='chargelinetable']/tbody/tr[" + (i + 1) + "]/td/input")
        //        //IWebElement table = instClaimEditorPage.ServiceLinesTable.GetWebTable();
        //        //IReadOnlyCollection <IWebElement> columns = table.FindElements(By.XPath("/tbody/tr["+(i+1)+"]/td/input"));
        //        IReadOnlyCollection<IWebElement> columns = claimEditorbrowser.driver.FindElements(By.XPath("//table[@id='chargelinetable']/tbody/tr[" + (i + 1) + "]/td/input"));
        //        columns.ElementAt(1).SendKeys(dataLines.ElementAt(i).RevCode);
        //        columns.ElementAt(3).SendKeys(dataLines.ElementAt(i).HCPCS);
        //        columns.ElementAt(4).SendKeys(dataLines.ElementAt(i).M1);
        //        columns.ElementAt(5).SendKeys(dataLines.ElementAt(i).M2);
        //        columns.ElementAt(6).SendKeys(dataLines.ElementAt(i).M3);
        //        columns.ElementAt(7).SendKeys(dataLines.ElementAt(i).M4);
        //        columns.ElementAt(8).SendKeys(dataLines.ElementAt(i).SvcDate);
        //        columns.ElementAt(9).Clear();
        //        columns.ElementAt(9).SendKeys(dataLines.ElementAt(i).SvcUnits);
        //        columns.ElementAt(11).Clear();
        //        columns.ElementAt(11).SendKeys(dataLines.ElementAt(i).TtlCharges + ".00");
        //    }
        //}
        //public int ReadServiceLinesCount()
        //{
        //    CommonUtils.log.LogInfo("Read the number of service line");
        //    //int rows = instClaimEditorPage.TableServiceLines.GetRowCount();
        //    Console.WriteLine("WindowTitle" + claimEditorbrowser.GetBrowser().Title);
        //    //int rows = instClaimEditorPage.ServiceLinesTable.GetRowCount();
        //    IReadOnlyCollection<IWebElement> rows = claimEditorbrowser.driver.FindElements(By.XPath("//table[@id='chargelinetable']/tbody/tr"));
        //    return rows.Count;
        //}
       
        //public IList<ServiceLineData> ReadServiceLinesData(int count)
        //{
        //    IReadOnlyCollection<IWebElement> rows = claimEditorbrowser.driver.FindElements(By.XPath("//table[@id='chargelinetable']/tbody/tr"));
        //    for (int i = 0; i < rows.Count; i++)
        //    {
        //        IReadOnlyCollection<IWebElement> columns = claimEditorbrowser.driver.FindElements(By.XPath("//table[@id='chargelinetable']/tbody/tr[" + (i + 1) + "]/td/input"));
        //        if (columns.ElementAt(3).GetAttribute("value").Equals(dataLines.ElementAt(0).HCPCS))
        //        {
        //            string revcode = columns.ElementAt(1).GetAttribute("value");
        //            string hcpcs = columns.ElementAt(3).GetAttribute("value");
        //            string M1 = columns.ElementAt(4).GetAttribute("value");
        //            string M2 = columns.ElementAt(5).GetAttribute("value");
        //            string M3 = columns.ElementAt(6).GetAttribute("value");
        //            string M4 = columns.ElementAt(7).GetAttribute("value");
        //            string Svcdate = columns.ElementAt(8).GetAttribute("value");
        //            string SvcUnits = columns.ElementAt(9).GetAttribute("value");
        //            string TtlCharges = columns.ElementAt(11).GetAttribute("value");
        //            dataLinesAfter.Add(new ServiceLineData(revcode, hcpcs, M1, M2, M3, M4, Svcdate, SvcUnits, TtlCharges));
        //        }
        //        if (columns.ElementAt(3).GetAttribute("value").Equals(dataLines.ElementAt(1).HCPCS))
        //        {
        //            string revcode = columns.ElementAt(1).GetAttribute("value");
        //            string hcpcs = columns.ElementAt(3).GetAttribute("value");
        //            string M1 = columns.ElementAt(4).GetAttribute("value");
        //            string M2 = columns.ElementAt(5).GetAttribute("value");
        //            string M3 = columns.ElementAt(6).GetAttribute("value");
        //            string M4 = columns.ElementAt(7).GetAttribute("value");
        //            string Svcdate = columns.ElementAt(8).GetAttribute("value");
        //            string SvcUnits = columns.ElementAt(9).GetAttribute("value");
        //            string TtlCharges = columns.ElementAt(11).GetAttribute("value");
        //            dataLinesAfter.Add(new ServiceLineData(revcode, hcpcs, M1, M2, M3, M4, Svcdate, SvcUnits, TtlCharges));
        //        }
        //    }
        //    return dataLinesAfter;
        //}
        //public void VerifyDataInNewServiceLines(int count) //verifying each added cell
        //{
        //    dataLinesAfter = ReadServiceLinesData(count);
        //    for (int i = 0; i < count; i++)
        //    {
        //        Assert.AreEqual(dataLines.ElementAt(i).RevCode, dataLinesAfter.ElementAt(i).RevCode);
        //        Assert.AreEqual(dataLines.ElementAt(i).HCPCS, dataLinesAfter.ElementAt(i).HCPCS);
        //        Assert.AreEqual(dataLines.ElementAt(i).M1, dataLinesAfter.ElementAt(i).M1);
        //        Assert.AreEqual(dataLines.ElementAt(i).M2, dataLinesAfter.ElementAt(i).M2);
        //        Assert.AreEqual(dataLines.ElementAt(i).M3, dataLinesAfter.ElementAt(i).M3);
        //        Assert.AreEqual(dataLines.ElementAt(i).M4, dataLinesAfter.ElementAt(i).M4);
        //        Assert.AreEqual(dataLines.ElementAt(i).SvcDate, dataLinesAfter.ElementAt(i).SvcDate);
        //        Assert.AreEqual(dataLines.ElementAt(i).SvcUnits, dataLinesAfter.ElementAt(i).SvcUnits);
        //        Assert.AreEqual(dataLines.ElementAt(i).TtlCharges + ".00", dataLinesAfter.ElementAt(i).TtlCharges);
        //    }
        //}
        //public double ReadChargesAmount()
        //{
        //    CommonUtils.log.LogInfo("Read the charges amount");
        //    string amount = instClaimEditorPage.TotalCharges.GetElement().Text;
        //    //int nval = Int32.Parse(amount.Substring(1).Replace(",", "").Replace(".",""));
        //    double nval = Convert.ToDouble(amount.Substring(1).Replace(",", ""));
        //    return nval;
        //}
        //public Boolean ValidateChargesAmount()
        //{
        //    CommonUtils.log.LogInfo("Validate the charges amount");
        //    double AmountAfter = ReadChargesAmount();
        //    AmountAfter = AmountAfter - Int32.Parse(dataLines.ElementAt(0).TtlCharges) - Int32.Parse(dataLines.ElementAt(1).TtlCharges);
        //    return (AmountBefore.Equals(AmountAfter));
        //}
        //public void AddQuantity(string quantity)
        //{
        //    CommonUtils.log.LogInfo("Adding the quantity in service line");
        //    instClaimEditorPage.EditQuantity.SetValue(quantity);
        //    instClaimEditorPage.BtnQuantityAdd.Click();
        //}
        public void FillServiceLineData()
        {

        }
    }

}
